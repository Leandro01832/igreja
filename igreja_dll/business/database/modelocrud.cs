using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Intermediario;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using business.contrato;
using business.implementacao;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace database
{
    public abstract class modelocrud : IPesquisar
    {
        public modelocrud()
        {
            this.bd = new BDcomum();
            Select_padrao = $"select * from {this.GetType().Name} as C where C.Id='{this.Id}'";
            Delete_padrao = $" delete from {this.GetType().Name} where Id='{this.Id}' ";
            Erro_Conexao = false;
            QuantErro = 0;
            this.T = GetType();
            pesquisar = new Pesquisar();
        }

        public modelocrud(int id)
        {
            this.bd = new BDcomum();
            Select_padrao = $"select * from {this.GetType().Name} as C where C.Id='{id}'";
            Delete_padrao = $" delete from {this.GetType().Name} where Id='{id}' ";
            this.conexao = this.bd.obterconexao();
            this.T = GetType();
            Erro_Conexao = false;
            QuantErro = 0;
            pesquisar = new Pesquisar();
            Id = id;
        }

        private string insert_padrao;
        private string update_padrao;
        private string delete_padrao;
        private string select_padrao;

        static Pesquisar pesquisar;
        public BDcomum bd;
        public SqlDataReader dr;
        public SqlConnection conexao;
        public Type T;
        public bool existeLista;
        private static string classe = "";
        
        public static List<modelocrud> Modelos = new List<modelocrud>();

        [Key]
        public int Id { get; set; }        
        public static bool Erro_Conexao;        
        public static string textoPorcentagem = "0%";        
        public static int QuantErro;
        [NotMapped]
        public string Insert_padrao { get => insert_padrao; set => insert_padrao = value; }
        [NotMapped]
        public string Update_padrao { get => update_padrao; set => update_padrao = value; }
        [NotMapped]
        public string Delete_padrao { get => delete_padrao; set => delete_padrao = value; }
        [NotMapped]
        public string Select_padrao { get => select_padrao; set => select_padrao = value; }

        #region MethodsCrud
      //  public abstract string salvar();

        public string salvar()
        {
            var ClassBase = GetType();
            while (ClassBase != typeof(modelocrud))
            if (ClassBase.BaseType == typeof(modelocrud))
            break;
            else
            ClassBase = ClassBase.BaseType;
            T = ClassBase;
            classe = T.Name;
            while (T != GetType())
            GetProperties(T);
            GetProperties(null);                           
            bd.SalvarModelo(this);
            return Insert_padrao;
        }

        public string alterar(int id)
        {            
            while (T != typeof(modelocrud))
            UpdateProperties(T);
            UpdateProperties(null);
            bd.Editar(this);
            return Update_padrao;
        }

        public string excluir(int id)
        {
            string comando = "";
            while (T != typeof(modelocrud))
            comando += DeleteProperties(T);
            delete_padrao = comando;
            bd.Excluir(this);
            return Delete_padrao;
        }

        public bool recuperar(int id)
        {
            bool retorno = false;
            while (T != typeof(modelocrud))
            {
                if (SetProperties(T))
                    retorno = true;
                else retorno = false;
            }
            T = GetType();
            return retorno;
        }

        public static void buscarListas()
        {
            for (int j = 0; j < 5; j++)
                for (var i = 0; i < Modelos.Count; i++)
                {
                    if (Modelos[i].GetType().GetProperties().ToList().FirstOrDefault(p => p.PropertyType.IsClass &&
                      p.GetValue(Modelos[i]) == null && p.PropertyType.IsAbstract ||
                      p.PropertyType.IsClass && p.GetValue(Modelos[i]) == null &&
                      p.PropertyType.BaseType == typeof(modelocrud)) != null)
                    {
                        var prop = Modelos[i].GetType().GetProperties().ToList().FirstOrDefault(p => p.PropertyType.IsClass &&
                            p.GetValue(Modelos[i]) == null && p.PropertyType.IsAbstract ||
                            p.PropertyType.IsClass && p.GetValue(Modelos[i]) == null &&
                            p.PropertyType.BaseType == typeof(modelocrud));

                        var propInt = Modelos[i].GetType().GetProperties().ToList()
                            .First(p => p.Name.ToLower().Contains(prop.Name.ToLower()));

                        int? valor = (int?)propInt.GetValue(Modelos[i], null);

                        modelocrud model = null;
                        if (valor != null)
                            model = Modelos.First(m => m.GetType().IsSubclassOf(prop.PropertyType) && m.Id == valor ||
                            m.GetType() == prop.PropertyType && m.Id == valor);

                        prop.SetValue(Modelos[i], model);
                    }
                }

            List<object> lista = new List<object>();
            for (var i = 0; i < Modelos.Count; i++)
            {
                
                for (var k = 0; k < Modelos.Count; k++)
                {
                    var props = Modelos[k].GetType().GetProperties();

                    foreach (var prop in props)
                    {
                        if (prop.GetValue(Modelos[k]) == Modelos[i])
                            lista.Add(Modelos[k]);
                    }


                    if (k == Modelos.Count - 1 && lista.Count > 0)
                    {
                        var propLista = Modelos[i].GetType().GetProperties()
                        .Where(p => p.PropertyType.Name == "List`1").ToList();

                       if(propLista.FirstOrDefault(p => p.PropertyType.GetGenericArguments()[0] == typeof(MinisterioCelula)) != null)
                       propLista.First(p => p.PropertyType.GetGenericArguments()[0] == typeof(MinisterioCelula)).SetValue(Modelos[i], lista.OfType<MinisterioCelula>().ToList());

                        if (propLista.FirstOrDefault(p => p.PropertyType.GetGenericArguments()[0] == typeof(PessoaMinisterio)) != null)
                            propLista.First(p => p.PropertyType.GetGenericArguments()[0] == typeof(PessoaMinisterio)).SetValue(Modelos[i], lista.OfType<PessoaMinisterio>().ToList());

                        if (propLista.FirstOrDefault(p => p.PropertyType.GetGenericArguments()[0] == typeof(ReuniaoPessoa)) != null)
                            propLista.First(p => p.PropertyType.GetGenericArguments()[0] == typeof(ReuniaoPessoa)).SetValue(Modelos[i], lista.OfType<ReuniaoPessoa>().ToList());

                        if (propLista.FirstOrDefault(p => p.PropertyType.GetGenericArguments()[0] == typeof(Pessoa)) != null)
                            propLista.First(p => p.PropertyType.GetGenericArguments()[0] == typeof(Pessoa)).SetValue(Modelos[i], lista.OfType<Pessoa>().ToList());

                        if (propLista.FirstOrDefault(p => p.PropertyType.GetGenericArguments()[0] == typeof(Historico)) != null)
                            propLista.First(p => p.PropertyType.GetGenericArguments()[0] == typeof(Historico)).SetValue(Modelos[i], lista.OfType<Historico>().ToList());

                        lista.Clear();
                    }
                }
            }

            var listaPessoas = Modelos.OfType<Pessoa>().OrderBy(m => m.Id).ToList();
            var listaMinisterios = Modelos.OfType<Ministerio>().OrderBy(m => m.Id).ToList();
            var listaCelulas = Modelos.OfType<Celula>().OrderBy(m => m.Id).ToList();
            var listaReuniao = Modelos.OfType<Reuniao>().OrderBy(m => m.Id).ToList();
            var listaPessoasEmReuniao = Modelos.OfType<ReuniaoPessoa>().OrderBy(m => m.Id).ToList();
            var listaPessoasEmMinisterio = Modelos.OfType<PessoaMinisterio>().OrderBy(m => m.Id).ToList();
            var listaMinisteriosEmCelulas = Modelos.OfType<MinisterioCelula>().OrderBy(m => m.Id).ToList();
        }

        public bool recuperar()
        {
            Select_padrao = $"select M.Id from {this.GetType().Name} as M ";
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                if (this is Pessoa)
                {
                    if (this is Visitante) Pessoa.visitantes = new List<Visitante>();
                    if (this is Crianca) Pessoa.criancas = new List<Crianca>();
                    if (this is Membro_Aclamacao) Pessoa.membros_Aclamacao = new List<Membro_Aclamacao>();
                    if (this is Membro_Batismo) Pessoa.membros_Batismo = new List<Membro_Batismo>();
                    if (this is Membro_Reconciliacao) Pessoa.membros_Reconciliacao = new List<Membro_Reconciliacao>();
                    if (this is Membro_Transferencia) Pessoa.membros_Transferencia = new List<Membro_Transferencia>();
                    if (this is VisitanteLgpd) Pessoa.visitantesLgpd = new List<VisitanteLgpd>();
                    if (this is CriancaLgpd) Pessoa.criancasLgpd = new List<CriancaLgpd>();
                    if (this is Membro_AclamacaoLgpd) Pessoa.membros_AclamacaoLgpd = new List<Membro_AclamacaoLgpd>();
                    if (this is Membro_BatismoLgpd) Pessoa.membros_BatismoLgpd = new List<Membro_BatismoLgpd>();
                    if (this is Membro_ReconciliacaoLgpd) Pessoa.membros_ReconciliacaoLgpd = new List<Membro_ReconciliacaoLgpd>();
                    if (this is Membro_TransferenciaLgpd) Pessoa.membros_TransferenciaLgpd = new List<Membro_TransferenciaLgpd>();
                }
                else
                    if (this is Ministerio)
                {
                    if (this is Lider_Celula) Ministerio.lideresCelula = new List<Lider_Celula>();
                    if (this is Lider_Celula_Treinamento) Ministerio.LideresCelulaTreinamento = new List<Lider_Celula_Treinamento>();
                    if (this is Lider_Ministerio) Ministerio.lideresMinisterio = new List<Lider_Ministerio>();
                    if (this is Lider_Ministerio_Treinamento) Ministerio.lideresMinisterioTreinamento = new List<Lider_Ministerio_Treinamento>();
                    if (this is Supervisor_Celula) Ministerio.supervisoresCelula = new List<Supervisor_Celula>();
                    if (this is Supervisor_Celula_Treinamento) Ministerio.supervisoresCelulaTreinamento = new List<Supervisor_Celula_Treinamento>();
                    if (this is Supervisor_Ministerio) Ministerio.supervisoresMinisterio = new List<Supervisor_Ministerio>();
                    if (this is Supervisor_Ministerio_Treinamento) Ministerio.supervisoresMinisterioTreinamento = new List<Supervisor_Ministerio_Treinamento>();
                }
                else
                    if (this is Celula)
                {
                    if (this is Celula_Adolescente) Celula.celulasAdolescente = new List<Celula_Adolescente>();
                    if (this is Celula_Adulto) Celula.celulasAdulto = new List<Celula_Adulto>();
                    if (this is Celula_Casado) Celula.celulasCasado = new List<Celula_Casado>();
                    if (this is Celula_Jovem) Celula.celulasJovem = new List<Celula_Jovem>();
                    if (this is Celula_Crianca) Celula.celulasCrianca = new List<Celula_Crianca>();
                }
                else
                {

                    if (this is Reuniao) Reuniao.Reunioes = new List<Reuniao>();
                    else
                    if (this is MudancaEstado) MudancaEstado.Mudancas = new List<MudancaEstado>();
                    else
                    if (this is Historico) Historico.Historicos = new List<Historico>();
                    else
                    if (this is Chamada) Chamada.Chamadas = new List<Chamada>();
                    else
                    if (this is Telefone) Telefone.Telefones = new List<Telefone>();
                    else
                    if (this is Endereco) Endereco.Enderecos = new List<Endereco>();
                    else
                    if (this is EnderecoCelula) EnderecoCelula.EnderecosCelula = new List<EnderecoCelula>();
                    else
                    if (this is MinisterioCelula) MinisterioCelula.MinisterioCelulas = new List<MinisterioCelula>();
                    else
                    if (this is PessoaMinisterio) PessoaMinisterio.PessoaMinisterios = new List<PessoaMinisterio>();
                    else
                    if (this is ReuniaoPessoa) ReuniaoPessoa.ReuniaoPessoas = new List<ReuniaoPessoa>();
                }

                try
                {
                    SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao(conexao);
                        return false;
                    }

                    List<int> modelos = new List<int>();
                    while (dr.Read())
                    {
                        var num = int.Parse(Convert.ToString(dr["Id"]));
                        modelos.Add(num);
                    }
                    dr.Close();

                    //Recursividade
                    bd.fecharconexao(conexao);

                    foreach (var m in modelos)
                    {
                        if (this is Pessoa)
                        {
                            if (this is Visitante) { var c = new Visitante(m); if (c.recuperar(m)) Pessoa.visitantes.Add(c); else { Pessoa.visitantes = null; return false; } }
                            if (this is Crianca) { var c = new Crianca(m); if (c.recuperar(m)) Pessoa.criancas.Add(c); else { Pessoa.criancas = null; return false; } }
                            if (this is Membro_Aclamacao) { var c = new Membro_Aclamacao(m); if (c.recuperar(m)) Pessoa.membros_Aclamacao.Add(c); else { Pessoa.membros_Aclamacao = null; return false; } }
                            if (this is Membro_Batismo) { var c = new Membro_Batismo(m); if (c.recuperar(m)) Pessoa.membros_Batismo.Add(c); else { Pessoa.membros_Batismo = null; return false; } }
                            if (this is Membro_Reconciliacao) { var c = new Membro_Reconciliacao(m); if (c.recuperar(m)) Pessoa.membros_Reconciliacao.Add(c); else { Pessoa.membros_Reconciliacao = null; return false; } }
                            if (this is Membro_Transferencia) { var c = new Membro_Transferencia(m); if (c.recuperar(m)) Pessoa.membros_Transferencia.Add(c); else { Pessoa.membros_Transferencia = null; return false; } }
                            if (this is VisitanteLgpd) { var c = new VisitanteLgpd(m); if (c.recuperar(m)) Pessoa.visitantesLgpd.Add(c); else { Pessoa.visitantesLgpd = null; return false; } }
                            if (this is CriancaLgpd) { var c = new CriancaLgpd(m); if (c.recuperar(m)) Pessoa.criancasLgpd.Add(c); else { Pessoa.criancasLgpd = null; return false; } }
                            if (this is Membro_AclamacaoLgpd) { var c = new Membro_AclamacaoLgpd(m); if (c.recuperar(m)) Pessoa.membros_AclamacaoLgpd.Add(c); else { Pessoa.membros_AclamacaoLgpd = null; return false; } }
                            if (this is Membro_BatismoLgpd) { var c = new Membro_BatismoLgpd(m); if (c.recuperar(m)) Pessoa.membros_BatismoLgpd.Add(c); else { Pessoa.membros_BatismoLgpd = null; return false; } }
                            if (this is Membro_ReconciliacaoLgpd) { var c = new Membro_ReconciliacaoLgpd(m); if (c.recuperar(m)) Pessoa.membros_ReconciliacaoLgpd.Add(c); else { Pessoa.membros_ReconciliacaoLgpd = null; return false; } }
                            if (this is Membro_TransferenciaLgpd) { var c = new Membro_TransferenciaLgpd(m); if (c.recuperar(m)) Pessoa.membros_TransferenciaLgpd.Add(c); else { Pessoa.membros_TransferenciaLgpd = null; return false; } }
                        }
                        else
                        if (this is Ministerio)
                        {
                            if (this is Lider_Celula) { var c = new Lider_Celula(m); if (c.recuperar(m)) Ministerio.lideresCelula.Add(c); else { Ministerio.lideresCelula = null; return false; } }
                            if (this is Lider_Celula_Treinamento) { var c = new Lider_Celula_Treinamento(m); if (c.recuperar(m)) Ministerio.LideresCelulaTreinamento.Add(c); else { Ministerio.LideresCelulaTreinamento = null; return false; } }
                            if (this is Lider_Ministerio) { var c = new Lider_Ministerio(m); if (c.recuperar(m)) Ministerio.lideresMinisterio.Add(c); else { Ministerio.lideresMinisterio = null; return false; } }
                            if (this is Lider_Ministerio_Treinamento) { var c = new Lider_Ministerio_Treinamento(m); if (c.recuperar(m)) Ministerio.lideresMinisterioTreinamento.Add(c); else { Ministerio.lideresMinisterioTreinamento = null; return false; } }
                            if (this is Supervisor_Celula) { var c = new Supervisor_Celula(m); if (c.recuperar(m)) Ministerio.supervisoresCelula.Add(c); else { Ministerio.supervisoresCelula = null; return false; } }
                            if (this is Supervisor_Celula_Treinamento) { var c = new Supervisor_Celula_Treinamento(m); if (c.recuperar(m)) Ministerio.supervisoresCelulaTreinamento.Add(c); else { Ministerio.supervisoresCelulaTreinamento = null; return false; } }
                            if (this is Supervisor_Ministerio) { var c = new Supervisor_Ministerio(m); if (c.recuperar(m)) Ministerio.supervisoresMinisterio.Add(c); else { Ministerio.supervisoresMinisterio = null; return false; } }
                            if (this is Supervisor_Ministerio_Treinamento) { var c = new Supervisor_Ministerio_Treinamento(m); if (c.recuperar(m)) Ministerio.supervisoresMinisterioTreinamento.Add(c); else { Ministerio.supervisoresMinisterioTreinamento = null; return false; } }
                        }
                        else
                        if (this is Celula)
                        {
                            if (this is Celula_Adolescente) { var c = new Celula_Adolescente(m); if (c.recuperar(m)) Celula.celulasAdolescente.Add(c); else { Celula.celulasAdolescente = null; return false; } }
                            if (this is Celula_Adulto) { var c = new Celula_Adulto(m); if (c.recuperar(m)) Celula.celulasAdulto.Add(c); else { Celula.celulasAdulto = null; return false; } }
                            if (this is Celula_Casado) { var c = new Celula_Casado(m); if (c.recuperar(m)) Celula.celulasCasado.Add(c); else { Celula.celulasCasado = null; return false; } }
                            if (this is Celula_Jovem) { var c = new Celula_Jovem(m); if (c.recuperar(m)) Celula.celulasJovem.Add(c); else { Celula.celulasJovem = null; return false; } }
                            if (this is Celula_Crianca) { var c = new Celula_Crianca(m); if (c.recuperar(m)) Celula.celulasCrianca.Add(c); else { Celula.celulasCrianca = null; return false; } }
                        }
                        else
                        {
                            if (this is Reuniao) { var c = new Reuniao(m); if (c.recuperar(m)) Reuniao.Reunioes.Add(c); else { Reuniao.Reunioes = null; return false; } }
                            else
                            if (this is MudancaEstado) { var c = new MudancaEstado(m); if (c.recuperar(m)) MudancaEstado.Mudancas.Add(c); else { MudancaEstado.Mudancas = null; return false; } }
                            else
                            if (this is Historico) { var c = new Historico(m); if (c.recuperar(m)) Historico.Historicos.Add(c); else { Historico.Historicos = null; return false; } }
                            else
                            if (this is Chamada) { var c = new Chamada(m); if (c.recuperar(m)) Chamada.Chamadas.Add(c); else { Chamada.Chamadas = null; return false; } }
                            else
                            if (this is Telefone) { var c = new Telefone(m); if (c.recuperar(m)) Telefone.Telefones.Add(c); else { Telefone.Telefones = null; return false; } }
                            else
                            if (this is Endereco) { var c = new Endereco(m); if (c.recuperar(m)) Endereco.Enderecos.Add(c); else { Endereco.Enderecos = null; return false; } }
                            else
                            if (this is EnderecoCelula) { var c = new EnderecoCelula(m); if (c.recuperar(m)) EnderecoCelula.EnderecosCelula.Add(c); else { EnderecoCelula.EnderecosCelula = null; return false; } }
                            else
                            if (this is MinisterioCelula) { var c = new MinisterioCelula(m); if (c.recuperar(m)) MinisterioCelula.MinisterioCelulas.Add(c); else { MinisterioCelula.MinisterioCelulas = null; return false; } }
                            else
                            if (this is PessoaMinisterio) { var c = new PessoaMinisterio(m); if (c.recuperar(m)) PessoaMinisterio.PessoaMinisterios.Add(c); else { PessoaMinisterio.PessoaMinisterios = null; return false; } }
                            else
                            if (this is ReuniaoPessoa) { var c = new ReuniaoPessoa(m); if (c.recuperar(m)) ReuniaoPessoa.ReuniaoPessoas.Add(c); else { ReuniaoPessoa.ReuniaoPessoas = null; return false; } }

                        }
                    }
                }

                catch (Exception ex)
                {
                    TratarExcessao(ex);
                    return false;
                }
                finally
                {
                    bd.fecharconexao(conexao);
                }
                return true;
            }
            return false;
        }
        #endregion

        #region MethodsProperties

        public static object ConvertList(List<object> value, Type type)
        {
            var containedType = type.GenericTypeArguments[0];
            return value.Select(item => Convert.ChangeType(item, containedType)).ToList();
        }

        public bool SetProperties(Type tipo)
        {
            Type t = GetType();
            if (tipo != GetType())
            {
                while (t != typeof(modelocrud))
                {
                    if (t.BaseType == tipo)
                        break;
                    else
                        t = t.BaseType;
                }
                Select_padrao = Select_padrao.Replace(t.Name, tipo.Name);
            }

            var propertiesDeclaring = tipo.GetProperties().Where(e => e.ReflectedType == e.DeclaringType);

            if (this.conexao == null)
                this.conexao = this.bd.obterconexao();

            if (this.conexao.State == ConnectionState.Closed)
                this.conexao = this.bd.obterconexao();

            SqlCommand comando = new SqlCommand(Select_padrao, this.conexao);
            try
            {
                this.dr = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - " + this.GetType());
            }

            if (conexao != null)
            {
                if (dr.HasRows == false)
                {
                    dr.Close();
                    bd.fecharconexao(conexao);
                    return false;
                }

                try
                {
                    dr.Read();
                    foreach (var property in propertiesDeclaring)
                    {
                        if (property.PropertyType.Name == "List`1")
                        {
                            Type itemType = property.PropertyType.GetGenericArguments()[0];
                        }
                        else
                        if (property.PropertyType == typeof(long) || property.PropertyType == typeof(long?))
                        {
                            try
                            {
                                property.SetValue(this, long.Parse(Convert.ToString(dr[property.Name])));
                            }
                            catch { property.SetValue(this, null); }
                        }
                        else
                        if (property.PropertyType == typeof(double) || property.PropertyType == typeof(double?))
                        {
                            try
                            {
                                property.SetValue(this, double.Parse(Convert.ToString(dr[property.Name])));
                            }
                            catch { property.SetValue(this, null); }
                        }
                        else
                        if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                        {
                            try
                            {
                                property.SetValue(this, DateTime.Parse(Convert.ToString(dr[property.Name])));
                            }
                            catch { property.SetValue(this, null); }
                        }
                        else
                        if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                        {
                            try
                            {
                                property.SetValue(this, int.Parse(Convert.ToString(dr[property.Name])));
                            }
                            catch { property.SetValue(this, null); }
                        }
                        else
                        if (property.PropertyType == typeof(string))
                        {
                            try
                            {
                                property.SetValue(this, Convert.ToString(dr[property.Name]));
                            }
                            catch { property.SetValue(this, null); }
                        }
                        else
                        if (property.PropertyType == typeof(bool))
                        {
                            try
                            {
                                property.SetValue(this, Convert.ToBoolean(dr[property.Name]));
                            }
                            catch { property.SetValue(this, null); }
                        }
                        else
                        if (property.PropertyType == typeof(TimeSpan) || property.PropertyType == typeof(TimeSpan?))
                        {
                            try
                            {
                                property.SetValue(this, TimeSpan.Parse(Convert.ToString(dr[property.Name])));
                            }
                            catch { property.SetValue(this, null); }
                        }
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    dr.Close();
                    TratarExcessao(ex);
                    return false;
                }
                finally
                {
                    bd.fecharconexao(conexao);
                }

                if (this.GetType().GetProperties().Where(p =>
                p.PropertyType.GetProperties().Where(pr => pr.ReflectedType ==
                pr.DeclaringType && pr.Name == "Id").ToList().Count != 0)
                .ToList().Count != 0)
                {
                    VerficaPropertyClassSetProperties(this.GetType());
                }
                
                T = T.BaseType;
                return true;
            }
            return false;
        }

        public string DeleteProperties(Type tipo)
        {
            string delete = "";
            delete += Delete_padrao.Replace(GetType().Name, tipo.Name);
            T = tipo.BaseType;
            
            if (tipo == GetType())
                if (this.GetType().GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                    p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                    && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass).ToList().Count != 0)
                {
                    delete += VerficaPropertyClassDeleteProperties(this.GetType());
                }
            return delete;
        }

        private string VerficaPropertyClassDeleteProperties(Type type)
        {
            string delete = "";
            foreach (var item in type.GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                 p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                  && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass).ToList())
            {
                object objeto = Activator.CreateInstance(item.PropertyType);
                modelocrud modelo = (modelocrud)objeto;
                modelo.Id = this.Id;
                if (modelo.GetType().GetProperties()
                .Where(p => p.ReflectedType == p.DeclaringType && p.Name == "Id").ToList().Count == 1)
                {
                    delete += $" delete from {modelo.GetType().Name} where Id='{this.Id}' ";
                   // modelo.excluir(this.Id);
                }
            }
            return delete;
        }

        private void VerficaPropertyClassSetProperties(Type tipo)
        {
            foreach (var item in tipo.GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                 p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                  && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass).ToList())
            {
                object objeto = Activator.CreateInstance(item.PropertyType);
                modelocrud modelo = (modelocrud)objeto;
                modelo.Id = this.Id;
                if (modelo.GetType().GetProperties()
                .Where(p => p.ReflectedType == p.DeclaringType && p.Name == "Id").ToList().Count == 1)
                {
                    modelo.select_padrao = $"select * from {modelo.GetType().Name} as C where C.Id='{this.Id}'";
                    modelo.recuperar(this.Id);
                }

                foreach (var item2 in this.GetType().GetProperties())
                {
                    if (item == item2)
                        item2.SetValue(this, modelo);
                }
            }
        }

        public void GetProperties(Type tipo)
        {
            Type ClassBase = GetType();
            string insert = "";
            string properties = "";
            string values = "";

            while (ClassBase != typeof(modelocrud))
            {
                if (ClassBase.BaseType == typeof(modelocrud))
                    break;
                else
                    ClassBase = ClassBase.BaseType;
            }

            if (tipo == null)
                T = GetType();

            var propertiesDeclaring = T.GetProperties().Where(e => e.ReflectedType == e.DeclaringType
            && !e.PropertyType.IsAbstract && e.PropertyType.Name != "List`1"
            && e.PropertyType.BaseType != typeof(modelocrud)).ToList();

            foreach (var property in propertiesDeclaring)
            {
                properties += property.Name + ", ";
                values = VerificaProperties(values, property, classe, this);
            }

            if (values != "")
                values = values.Remove(values.Length - 2, 2);
            if (properties != "")
                properties = properties.Remove(properties.Length - 2, 2);

            if (T != typeof(modelocrud))
            {
                if (T != ClassBase && values != "")
                    insert = $"insert into {T.Name} (Id, {properties} ) values (IDENT_CURRENT('{ClassBase.Name}'), {values} ) ";
                else
                    if (T != ClassBase && values == "")
                    insert = $"insert into {T.Name} (Id) values (IDENT_CURRENT('{ClassBase.Name}') ) ";
                else
                    insert = $"insert into {T.Name} ( {properties} ) values ( {values} ) ";

                Insert_padrao += insert.Replace("Insert_padrao, Update_padrao, Delete_padrao, Select_padrao,", "");
            }

            if (tipo == null)
            {
                if (this.GetType().GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                   p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                   && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass).ToList().Count != 0)
                {
                    VerficaPropertyClassInsertProperties(this.GetType());
                }
            }


            tipo = GetType();
            while (tipo != typeof(modelocrud))
            {
                if (tipo.BaseType == T)
                { T = tipo; break; }
                else
                    tipo = tipo.BaseType;
            }
        }

        private void VerficaPropertyClassInsertProperties(Type type)
        {
            Type ClassBase = GetType();
            while (ClassBase != typeof(modelocrud))
            {
                if (ClassBase.BaseType == typeof(modelocrud))
                    break;
                else
                    ClassBase = ClassBase.BaseType;
            }
            foreach (var property in type.GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                 p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                  && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass &&
                  p.PropertyType.GetProperties().Where(pr => pr.ReflectedType ==
                pr.DeclaringType && pr.Name == "Id").ToList().Count != 0).ToList())
            {
                string properties = "";
                string values = "";
                object objeto = property.GetValue(this, null);
                modelocrud model = (modelocrud)objeto;
                model.Select_padrao = "Teste123";
                model.Update_padrao = "Teste123";
                model.Delete_padrao = "Teste123";
                model.Insert_padrao = "Teste123";
                foreach (var item in property.PropertyType.GetProperties().Where(p => !p.PropertyType.IsAbstract))
                {
                    properties += item.Name + ", ";
                    values = VerificaProperties(values, item, classe, property.GetValue(this));
                }
                properties = properties.Replace(", Insert_padrao, Update_padrao, Delete_padrao, Select_padrao", "");
                values = values.Replace(", 'Teste123'", "");
                if (values != "")
                {
                    if (values != "")
                        values = values.Remove(values.Length - 2, 2);
                    if (properties != "")
                        properties = properties.Remove(properties.Length - 2, 2);
                    Insert_padrao += $"insert into {property.PropertyType.Name} ( {properties} ) values ( {values} ) ";
                }
            }
        }

        public void UpdateProperties(Type tipo)
        {
            Type ClassBase = GetType();
            string update = "";
            string properties = "";
            string values = "";
            while (ClassBase != typeof(modelocrud))
            {
                if (ClassBase.BaseType == typeof(modelocrud))
                {
                    if (T == GetType())
                        T = ClassBase;
                    break;
                }
                else
                    ClassBase = ClassBase.BaseType;
            }

            if (tipo == null)
                T = GetType();

            var propertiesDeclaring = T.GetProperties().Where(e => e.ReflectedType == e.DeclaringType
            && !e.PropertyType.IsAbstract && e.PropertyType.Name != "List`1"
            && e.PropertyType.BaseType != typeof(modelocrud)).ToList();


            foreach (var property in propertiesDeclaring)
            {
                properties = property.Name + "=";
                values += properties + VerificaUpdateProperties(property, this);
            }

            values = values.Remove(values.Length - 2, 2);
            properties = properties.Remove(properties.Length - 2, 2);

            if (T != typeof(modelocrud) && propertiesDeclaring.Count > 0)
            {
                update = $" update {T.Name} set {values} " + $" where Id='{this.Id}' ";
                Update_padrao += update;
            }

            if (tipo == null)
            {
                if (this.GetType().GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                   p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                   && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass).ToList().Count != 0)
                {
                    VerficaPropertyClassUpdateProperties(this.GetType(), this.Id);
                }
            }

            if (tipo != null)
                while (tipo != typeof(modelocrud))
                {
                    if (tipo.BaseType == T)
                        break;
                    else
                        tipo = tipo.BaseType;
                }

            T = GetType();
            while (T != typeof(modelocrud))
            {
                if (T == tipo)
                    break;
                else
                    T = T.BaseType;
            }

        }

        private void VerficaPropertyClassUpdateProperties(Type type, int id)
        {
            var propertiesDeclaring = type.GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                   p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                   && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass).ToList();

            foreach (var property in propertiesDeclaring.Where(p =>
                  p.PropertyType.GetProperties().Where(pr => pr.ReflectedType ==
                pr.DeclaringType && pr.Name == "Id").ToList().Count != 0))
            {
                object objeto = property.GetValue(this, null);
                modelocrud model = (modelocrud)objeto;
                model.select_padrao = "";
                model.update_padrao = "";
                model.delete_padrao = "";
                model.insert_padrao = "";
                string update = "";
                string properties = "";
                string values = "";

                foreach (var item in property.PropertyType.GetProperties().Where(p => !p.PropertyType.IsAbstract))
                {
                    properties = item.Name + "=";
                    values += properties + VerificaUpdateProperties(item, objeto);
                }

                values = values.Remove(values.Length - 2, 2);
                properties = properties.Remove(properties.Length - 2, 2);

                if (T != typeof(modelocrud) && propertiesDeclaring.Count > 0)
                {
                    update = $" update {property.PropertyType.Name} set {values} " + $" where Id='{id}' ";
                    Update_padrao += update.Replace(", Insert_padrao='', Update_padrao='', Delete_padrao='', Select_padrao=''", "");
                }
            }
        }

        private string VerificaProperties(string values, PropertyInfo property, string classe, object objeto)
        {
            if (property.PropertyType.Name == "List`1")
            {
                existeLista = true;
            }
            else
            if (property.Name == "Id")
                values += $"IDENT_CURRENT('{classe}'), ";
            else
            if (property.PropertyType == typeof(double?) || property.PropertyType == typeof(double))
            {
                double? prop = null;
                if (property.GetValue(objeto, null) != null)
                    prop = double.Parse(property.GetValue(objeto, null).ToString());
                if (prop != null)
                    values += "" + prop.ToString() + ", ";
                else
                    values += "" + "null" + ", ";
            }
            else
            if (property.PropertyType == typeof(long?) || property.PropertyType == typeof(long))
            {
                long? prop = null;
                if (property.GetValue(objeto, null) != null)
                    prop = long.Parse(property.GetValue(objeto, null).ToString());
                if (prop != null)
                    values += "" + prop.ToString() + ", ";
                else
                    values += "" + "null" + ", ";
            }
            else
            if (property.PropertyType == typeof(TimeSpan?) || property.PropertyType == typeof(TimeSpan))
            {
                TimeSpan? prop = null;
                if (property.GetValue(objeto, null) != null)
                    prop = TimeSpan.Parse(property.GetValue(objeto, null).ToString());
                if (prop != null)
                    values += "'" + prop.ToString() + "', ";
                else
                    values += "" + "null" + ", ";
            }
            else
             if (property.PropertyType == typeof(DateTime?) || property.PropertyType == typeof(DateTime))
            {
                DateTime? prop = null;
                if (property.GetValue(objeto, null) != null)
                    prop = Convert.ToDateTime(property.GetValue(objeto, null).ToString());
                if (prop != null)
                    values += "'" + prop?.ToString("yyyy-MM-dd") + "', ";
                else
                    values += "" + "null" + ", ";
            }
            else
             if (property.PropertyType == typeof(int?) || property.PropertyType == typeof(int))
            {
                int? prop = null;
                if (property.GetValue(objeto, null) != null)
                    prop = int.Parse(property.GetValue(objeto, null).ToString());
                if (prop != null)
                    values += "" + prop.ToString() + ", ";
                else
                    values += "" + "null" + ", ";
            }
            else
             if (property.PropertyType == typeof(string))
            {
                string prop = null;
                if (property.GetValue(objeto, null) != null)
                    prop = property.GetValue(objeto, null).ToString();
                if (prop != null)
                    values += "'" + prop.ToString() + "', ";
                else
                    values += "" + "null" + ", ";
            }
            else
             if (property.PropertyType == typeof(bool))
            {
                bool prop = Convert.ToBoolean(property.GetValue(objeto, null));
                if (prop) values += "'True', ";
                else values += "'False', ";
            }
            else
            {

            }

            return values;
        }

        private string VerificaUpdateProperties(PropertyInfo property, object objeto)
        {
            string values = "";
            if (property.PropertyType.Name == "List`1")
            {
                existeLista = true;
            }
            else
            if (property.PropertyType == typeof(double?) || property.PropertyType == typeof(double))
            {
                double? prop = null;
                if (property.GetValue(objeto, null) != null)
                    prop = double.Parse(property.GetValue(objeto, null).ToString());
                if (prop != null)
                    values = "" + prop.ToString() + ", ";
                else
                    values = "" + "null" + ", ";
            }
            else
            if (property.PropertyType == typeof(long?) || property.PropertyType == typeof(long))
            {
                long? prop = null;
                if (property.GetValue(objeto, null) != null)
                    prop = long.Parse(property.GetValue(objeto, null).ToString());
                if (prop != null)
                    values = "" + prop.ToString() + ", ";
                else
                    values = "" + "null" + ", ";
            }
            else
            if (property.PropertyType == typeof(TimeSpan?) || property.PropertyType == typeof(TimeSpan))
            {
                TimeSpan? prop = null;
                if (property.GetValue(objeto, null) != null)
                    prop = TimeSpan.Parse(property.GetValue(objeto, null).ToString());
                if (prop != null)
                    values = "'" + prop.ToString() + "', ";
                else
                    values = "" + "null" + ", ";
            }
            else
             if (property.PropertyType == typeof(DateTime?) || property.PropertyType == typeof(DateTime))
            {
                DateTime? prop = null;
                if (property.GetValue(objeto, null) != null)
                    prop = Convert.ToDateTime(property.GetValue(objeto, null).ToString());
                if (prop != null)
                    values = "'" + prop?.ToString("yyyy-MM-dd") + "', ";
                else
                    values = "" + "null" + ", ";
            }
            else
             if (property.PropertyType == typeof(int?) || property.PropertyType == typeof(int))
            {
                int? prop = null;
                if (property.GetValue(objeto, null) != null)
                    prop = int.Parse(property.GetValue(objeto, null).ToString());
                if (prop != null)
                    values = "" + prop.ToString() + ", ";
                else
                    values = "" + "null" + ", ";
            }
            else
             if (property.PropertyType == typeof(string))
            {
                string prop = null;
                if (property.GetValue(objeto, null) != null)
                    prop = property.GetValue(objeto, null).ToString();
                if (prop != null)
                    values = "'" + prop.ToString() + "', ";
                else
                    values = "" + "null" + ", ";
            }
            else
             if (property.PropertyType == typeof(bool))
            {
                bool prop = Convert.ToBoolean(property.GetValue(objeto, null));
                if (prop) values = "'True', ";
                else values += "'False', ";
            }
            else
            {

            }

            return values;
        }
        #endregion

        public bool retornoDados(SqlDataReader dr, string pesquisa)
        {
            try
            {
                int valor = int.Parse(Convert.ToString(dr[pesquisa]));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void TratarExcessao(Exception ex)
        {
            if (ex.Message.Contains("instância"))
            {
                BDcomum.podeAbrir = false;
            }
            else if (ex.Message.Contains("reader"))
            {
                MessageBox.Show("A leitura dos dados não esta sendo realizada. Verifique sua conexão!!! " + this.GetType().Name);
            }
            else if (ex.Message.Contains("ExecuteReader"))
            {
                MessageBox.Show(" Verifique sua ExecuteReader!!! " + this.GetType().Name);
            }
            else if (!ex.Message.Contains("transporte") && !ex.Message.Contains("servidor não está respondendo")
                && !ex.Message.Contains("não foi inicializada")
                && !ex.Message.Contains("conexão é fechada"))
                MessageBox.Show(ex.Message + " - " + this.GetType().Name);

            else if (ex.Message.Contains("transporte") || ex.Message.Contains("servidor não está respondendo")
                || ex.Message.Contains("não foi inicializada")
                || ex.Message.Contains("conexão é fechada"))
            {

                Erro_Conexao = true;
                QuantErro++;

                if (QuantErro == 1)
                    MessageBox.Show("Verifique sua conexão" + this.GetType().Name);
            }
        }

        #region MethodsQuery
        public List<modelocrud> PesquisarPorData(List<modelocrud> modelos, DateTime comecar, DateTime terminar, string campo)
        {
            return pesquisar.PesquisarPorData(modelos, comecar, terminar, campo);
        }

        public List<modelocrud> PesquisarPorData(List<modelocrud> modelos, DateTime apenasUmDia, string campo)
        {
            return pesquisar.PesquisarPorData(modelos, apenasUmDia, campo);
        }

        public List<modelocrud> PesquisarPorNumero(List<modelocrud> modelos, int comecar, int terminar, string campo)
        {
            return pesquisar.PesquisarPorNumero(modelos, comecar, terminar, campo);
        }

        public List<modelocrud> PesquisarPorNumero(List<modelocrud> modelos, int apenasUmNumero, string campo)
        {
            return pesquisar.PesquisarPorNumero(modelos, apenasUmNumero, campo);
        }

        public List<modelocrud> PesquisarPorTexto(List<modelocrud> modelos, string texto, string campo)
        {
            return pesquisar.PesquisarPorTexto(modelos, texto, campo);
        }

        public List<modelocrud> PesquisarPorHorario(List<modelocrud> modelos, TimeSpan comecar, TimeSpan terminar, string campo)
        {
            return pesquisar.PesquisarPorHorario(modelos, comecar, terminar, campo);
        }

        public List<modelocrud> PesquisarPorHorario(List<modelocrud> modelos, TimeSpan apenasUmHorario, string campo)
        {
            return pesquisar.PesquisarPorHorario(modelos, apenasUmHorario, campo);
        }
        #endregion

        #region MethodPorcentagem          
        public static void calcularPorcentagem()
        {
            try
            {
                var pessoas = Pessoa.TotalRegistro();
                var PessoasEmMinisterios = PessoaMinisterio.TotalRegistro();
                var PessoasEmReunioes = ReuniaoPessoa.TotalRegistro();
                var MinisteriosEmCelulas = MinisterioCelula.TotalRegistro();
                var Historicos = Historico.TotalRegistro();
                var celulas = Celula.TotalRegistro();
                var ministerios = Ministerio.TotalRegistro();
                var reunioes = Reuniao.TotalRegistro();
                var mudancas = MudancaEstado.TotalRegistro();
                var totalRegistros = pessoas + celulas + ministerios + reunioes + mudancas
                    + PessoasEmMinisterios + PessoasEmReunioes + Historicos + MinisteriosEmCelulas;

                var quantVisitante = 0; var quamtCelula_Jovem = 0; var quantLider_Celula = 0;
                var quantCrianca = 0; var quamtCelula_Adolescente = 0; var quantLider_Celula_Treinamento = 0;
                var quantMembro_Batismo = 0; var quamtCelula_Casado = 0; var quantLider_Ministerio = 0;
                var quantMembro_Aclamacao = 0; var quamtCelula_Crianca = 0; var quantLider_Ministerio_Treinamento = 0;
                var quantMembro_Reconciliacao = 0; var quamtCelula_Adulto = 0; var quantSupervisor_Celula = 0;
                var quantMembro_Transferencia = 0; var quantSupervisor_Celula_Treinamento = 0;
                var quantVisitanteLgpd = 0; var quantSupervisor_Ministerio = 0;
                var quantCriancaLgpd = 0; var quantSupervisor_Ministerio_Treinamento = 0;
                var quantMembro_TransferenciaLgpd = 0;
                var quantMembro_BatismoLgpd = 0;
                var quantMembro_AclamacaoLgpd = 0;
                var quantMembro_ReconciliacaoLgpd = 0;

                var quantMudancas = 0;
                var quantReunioes = 0;
                var quantPessoasEmMinisterios = 0;
                var quantPessoasEmReunioes = 0;
                var quantMinisteriosEmCelulas = 0;
                var quantHistoricos = 0;

                if (Pessoa.visitantes != null) quantVisitante += Pessoa.visitantes.Count;
                if (Pessoa.criancas != null) quantCrianca += Pessoa.criancas.Count;
                if (Pessoa.membros_Aclamacao != null) quantMembro_Aclamacao += Pessoa.membros_Aclamacao.Count;
                if (Pessoa.membros_Batismo != null) quantMembro_Batismo += Pessoa.membros_Batismo.Count;
                if (Pessoa.membros_Reconciliacao != null) quantMembro_Reconciliacao += Pessoa.membros_Reconciliacao.Count;
                if (Pessoa.membros_Transferencia != null) quantMembro_Transferencia += Pessoa.membros_Transferencia.Count;
                if (Pessoa.visitantesLgpd != null) quantVisitanteLgpd += Pessoa.visitantesLgpd.Count;
                if (Pessoa.criancasLgpd != null) quantCriancaLgpd += Pessoa.criancasLgpd.Count;
                if (Pessoa.membros_AclamacaoLgpd != null) quantMembro_AclamacaoLgpd += Pessoa.membros_AclamacaoLgpd.Count;
                if (Pessoa.membros_BatismoLgpd != null) quantMembro_BatismoLgpd += Pessoa.membros_BatismoLgpd.Count;
                if (Pessoa.membros_ReconciliacaoLgpd != null) quantMembro_ReconciliacaoLgpd += Pessoa.membros_ReconciliacaoLgpd.Count;
                if (Pessoa.membros_TransferenciaLgpd != null) quantMembro_TransferenciaLgpd += Pessoa.membros_TransferenciaLgpd.Count;

                if (Celula.celulasAdolescente != null) quamtCelula_Adolescente += Celula.celulasAdolescente.Count;
                if (Celula.celulasAdulto != null) quamtCelula_Adulto += Celula.celulasAdulto.Count;
                if (Celula.celulasCasado != null) quamtCelula_Casado += Celula.celulasCasado.Count;
                if (Celula.celulasJovem != null) quamtCelula_Jovem += Celula.celulasJovem.Count;
                if (Celula.celulasCrianca != null) quamtCelula_Crianca += Celula.celulasCrianca.Count;

                if (Ministerio.lideresCelula != null) quantLider_Celula += Ministerio.lideresCelula.Count;
                if (Ministerio.LideresCelulaTreinamento != null) quantLider_Celula_Treinamento += Ministerio.LideresCelulaTreinamento.Count;
                if (Ministerio.lideresMinisterio != null) quantLider_Ministerio += Ministerio.lideresMinisterio.Count;
                if (Ministerio.lideresMinisterioTreinamento != null) quantLider_Ministerio_Treinamento += Ministerio.lideresMinisterioTreinamento.Count;
                if (Ministerio.supervisoresCelula != null) quantSupervisor_Celula += Ministerio.supervisoresCelula.Count;
                if (Ministerio.supervisoresCelulaTreinamento != null) quantSupervisor_Celula_Treinamento += Ministerio.supervisoresCelulaTreinamento.Count;
                if (Ministerio.supervisoresMinisterio != null) quantSupervisor_Ministerio += Ministerio.supervisoresMinisterio.Count;
                if (Ministerio.supervisoresMinisterioTreinamento != null) quantSupervisor_Ministerio_Treinamento += Ministerio.supervisoresMinisterioTreinamento.Count;

                if (Reuniao.Reunioes != null) quantReunioes += Reuniao.Reunioes.Count;
                if (MudancaEstado.Mudancas != null) quantMudancas += MudancaEstado.Mudancas.Count;
                if (PessoaMinisterio.PessoaMinisterios != null) quantPessoasEmMinisterios += PessoaMinisterio.PessoaMinisterios.Count;
                if (ReuniaoPessoa.ReuniaoPessoas != null) quantPessoasEmReunioes += ReuniaoPessoa.ReuniaoPessoas.Count;
                if (MinisterioCelula.MinisterioCelulas != null) quantMinisteriosEmCelulas += MinisterioCelula.MinisterioCelulas.Count;
                if (Historico.Historicos != null) quantHistoricos += Historico.Historicos.Count;

                var quantidadeCarregada = quantMudancas + quantReunioes +
                quantVisitante + quantLider_Celula + quamtCelula_Jovem +
                quantCrianca + quantLider_Celula_Treinamento + quamtCelula_Adolescente +
                quantMembro_Batismo + quantLider_Ministerio + quamtCelula_Casado +
                quantMembro_Aclamacao + quantLider_Ministerio_Treinamento + quamtCelula_Crianca +
                quantMembro_Reconciliacao + quantSupervisor_Celula + quamtCelula_Adulto +
                quantMembro_Transferencia + quantSupervisor_Celula_Treinamento +
                quantVisitanteLgpd + quantSupervisor_Ministerio +
                quantCriancaLgpd + quantSupervisor_Ministerio_Treinamento +
                quantMembro_TransferenciaLgpd + quantPessoasEmMinisterios +
                quantMembro_BatismoLgpd + quantPessoasEmReunioes +
                quantMembro_AclamacaoLgpd + quantMinisteriosEmCelulas +
                quantMembro_ReconciliacaoLgpd + quantHistoricos;

                var porcentagem = (int)((100 * quantidadeCarregada) / totalRegistros);
                textoPorcentagem = porcentagem.ToString() + "%";
            }
            catch { }
        }
        #endregion
    }
}
