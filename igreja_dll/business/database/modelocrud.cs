using business.classes;
using business.classes.Abstrato;
using business.classes.Celula;
using business.classes.Celulas;
using business.classes.Intermediario;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
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
        //construtor para Entity Framework
        public modelocrud()
        {
            this.bd = new BDcomum();
            Erro_Conexao = false;
            QuantErro = 0;
            this.T = GetType();
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
        }

        private string insert_padrao;
        private string update_padrao;
        private string delete_padrao;
        private string select_padrao;
        
        public BDcomum bd;
        public SqlDataReader dr;
        public SqlConnection conexao;
        public Type T;
        private static int indice = 0;
        private static string classe = "";

        [NotMapped]
        public static List<modelocrud> Modelos = new List<modelocrud>();

        [Key]
        public int Id { get; set; }
        [NotMapped]
        public static bool Erro_Conexao;
        [NotMapped]
        public static string textoPorcentagem = "0%";
        [NotMapped]
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
        public abstract string salvar();
        public abstract string alterar(int id);
        public abstract string excluir(int id);
        public abstract bool recuperar(int id);

        public bool recuperar()
        {
            Select_padrao = $"select M.Id from {this.GetType().Name} as M ";
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                try
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
                    if (this is Reuniao) Reuniao.Reunioes = new List<Reuniao>();
                    if (this is MudancaEstado) MudancaEstado.Mudancas = new List<MudancaEstado>();
                    if (this is Historico) Historico.Historicos = new List<Historico>();
                    if (this is Chamada) Chamada.Chamadas = new List<Chamada>();
                    if (this is Telefone) Telefone.Telefones = new List<Telefone>();
                    if (this is Endereco) Endereco.Enderecos = new List<Endereco>();
                    if (this is EnderecoCelula) EnderecoCelula.EnderecosCelula = new List<EnderecoCelula>();
                    if (this is MinisterioCelula) MinisterioCelula.MinisterioCelulas = new List<MinisterioCelula>();
                    if (this is PessoaMinisterio) PessoaMinisterio.PessoaMinisterios = new List<PessoaMinisterio>();
                    if (this is ReuniaoPessoa) ReuniaoPessoa.ReuniaoPessoas = new List<ReuniaoPessoa>();

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

            if (this.conexao.State == ConnectionState.Closed)
                this.conexao = this.bd.obterconexao();
            SqlCommand comando = new SqlCommand(Select_padrao, this.conexao);
            try
            {
                this.dr = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + this.GetType());
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
                        if (property.Name == "UltimoRegistro" || property.Name == "password") { }
                        else
                        if (property.PropertyType == typeof(DateTime))
                            property.SetValue(this, DateTime.Parse(Convert.ToString(dr[property.Name])));
                        else
                        if (property.PropertyType == typeof(int))
                            property.SetValue(this, int.Parse(Convert.ToString(dr[property.Name])));
                        else
                        if (property.PropertyType == typeof(string))
                            property.SetValue(this, Convert.ToString(dr[property.Name]));
                        else
                        if (property.PropertyType == typeof(bool))
                            property.SetValue(this, Convert.ToBoolean(dr[property.Name]));
                        else
                        if (property.PropertyType == typeof(TimeSpan))
                            property.SetValue(this, TimeSpan.Parse(Convert.ToString(dr[property.Name])));
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

                T = T.BaseType;
                return true;
            }
            return false;
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
                {
                    if (T == GetType())
                    {
                        T = ClassBase;
                        indice++;
                        if(indice == 1)
                        classe = T.Name;
                     }
                    break;
                }
                else
                    ClassBase = ClassBase.BaseType;
            }

            if (tipo == null)
            { T = GetType(); indice = 0; }

            var propertiesDeclaring = T.GetProperties().Where(e => e.ReflectedType == e.DeclaringType).ToList();


            foreach (var property in propertiesDeclaring)
            {
                if (property.Name != "UltimoRegistro" && property.PropertyType.Name != "List`1"
                    && property.PropertyType.IsPublic)
                {
                    if (property.PropertyType.IsClass && property.PropertyType == typeof(string))
                    {
                        properties += property.Name + ", ";
                        values = VerificaProperties(values, property, classe);
                    }
                    else if (!property.PropertyType.IsClass)
                    {
                        properties += property.Name + ", ";
                        values = VerificaProperties(values, property, classe);
                    }
                }
            }

            if(values != "")
            values = values.Remove(values.Length - 2, 2);
            if(properties != "")
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

                Insert_padrao += insert;
            }

            tipo = GetType();
            while (tipo != typeof(modelocrud))
            {
                if (tipo.BaseType == T)
                { T = tipo;  break; }
                else
                    tipo = tipo.BaseType;
            }
        }

        public void UpdateProperties(Type tipo, int id)
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

            var propertiesDeclaring = T.GetProperties().Where(e => e.ReflectedType == e.DeclaringType).ToList();


            foreach (var property in propertiesDeclaring)
            {
                if (property.Name != "UltimoRegistro" && property.PropertyType.Name != "List`1"
                    && property.PropertyType.IsPublic)
                {
                    if (property.PropertyType.IsClass && property.PropertyType == typeof(string))
                    {
                        properties = property.Name + "=";
                        values += properties + VerificaUpdateProperties(property);
                    }
                    else if (!property.PropertyType.IsClass)
                    {
                        properties = property.Name + "=";
                        values += properties + VerificaUpdateProperties(property);
                    }
                }
            }

            values = values.Remove(values.Length - 2, 2);
            properties = properties.Remove(properties.Length - 2, 2);

            if (T != typeof(modelocrud) && propertiesDeclaring.Count > 0)
            {
                update = $" update {T.Name} set {values} " + $" where Id='{id}' ";
                Update_padrao += update;
            }

            T = GetType();
            while (T != typeof(modelocrud))
            {
                if (T.BaseType == tipo)
                    break;
                else
                    T = T.BaseType;
            }
        }

        private string VerificaProperties(string values, PropertyInfo property, string ClassBase)
        {
            if (property.Name == "Id")
                values += $"IDENT_CURRENT('{ClassBase}'), ";
            else
            if (property.PropertyType == typeof(TimeSpan?) || property.PropertyType == typeof(TimeSpan))
            {
                var time = TimeSpan.Parse(property.GetValue(this, null).ToString());
                values += "'" + time.ToString() + "', ";
            }
            else
             if (property.PropertyType == typeof(DateTime))
            {
                var data = DateTime.Parse(property.GetValue(this, null).ToString());
                values += "'" + data.ToString("yyyy-MM-dd") + "', ";
            }
            else
             if (property.PropertyType == typeof(int?))
            {
                if (property.GetValue(this, null) != null)
                    values += property.GetValue(this, null).ToString() + ", ";
                else
                    values += "" + "null" + ", ";
            }
            else
            if (property.PropertyType == typeof(int))
                values += property.GetValue(this, null).ToString() + ", ";
            else
            {
                if (property.GetValue(this, null) == null)
                    values += "'" + "null" + "', ";
                else
                    values += "'" + property.GetValue(this, null).ToString() + "', ";
            }

            return values;
        }

        private string VerificaUpdateProperties(PropertyInfo property)
        {
            string values = "";
            if (property.PropertyType == typeof(TimeSpan?) || property.PropertyType == typeof(TimeSpan))
            {
                var time = TimeSpan.Parse(property.GetValue(this, null).ToString());
                values = "'" + time.ToString() + "', ";
            }
            else
            if (property.PropertyType == typeof(DateTime))
            {
                var data = DateTime.Parse(property.GetValue(this, null).ToString());
                values = "'" + data.ToString("yyyy-MM-dd") + "', ";
            }
            else
            if (property.PropertyType == typeof(int?))
            {
                if (property.GetValue(this, null) != null)
                    values = property.GetValue(this, null).ToString() + ", ";
                else
                    values = "'" + "null" + "', ";
            }
            else
            if (property.PropertyType == typeof(int))
                values = property.GetValue(this, null).ToString() + ", ";
            else
            {
                if (property.GetValue(this, null) == null)
                    values = "'" + "null" + "', ";
                else
                    values = "'" + property.GetValue(this, null).ToString() + "', ";
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
            List<modelocrud> q = null;
            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "Data_reuniao")
                q = modelos.OfType<Reuniao>().Where(i => i.Data_reuniao >= comecar && i.Data_reuniao <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<PessoaDado>().ToList().Count > 0 && campo == "Data_nascimento")
                q = modelos.OfType<PessoaDado>().Where(i => i.Data_nascimento >= comecar && i.Data_nascimento <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<MudancaEstado>().ToList().Count > 0 && campo == "DataMudanca")
                q = modelos.OfType<MudancaEstado>().Where(i => i.DataMudanca >= comecar && i.DataMudanca <= terminar).Cast<modelocrud>().ToList();
            return q;
        }

        public List<modelocrud> PesquisarPorData(List<modelocrud> modelos, DateTime apenasUmDia, string campo)
        {
            List<modelocrud> q = null;
            return q;
        }

        public List<modelocrud> PesquisarPorNumero(List<modelocrud> modelos, int comecar, int terminar, string campo)
        {
            List<modelocrud> q = null;
            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "Id")
                q = modelos.OfType<Reuniao>().Where(i => i.Id >= comecar && i.Id <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<Pessoa>().ToList().Count > 0 && campo == "Id")
                q = modelos.OfType<Pessoa>().Where(i => i.Id >= comecar && i.Id <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<Celula>().ToList().Count > 0 && campo == "Id")
                q = modelos.OfType<Celula>().Where(i => i.Id >= comecar && i.Id <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<Ministerio>().ToList().Count > 0 && campo == "Id")
                q = modelos.OfType<Ministerio>().Where(i => i.Id >= comecar && i.Id <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<Membro>().ToList().Count > 0 && campo == "Data_batismo")
                q = modelos.OfType<Membro>().Where(i => i.Data_batismo >= comecar && i.Data_batismo <= terminar).Cast<modelocrud>().ToList();
            return q;
        }

        public List<modelocrud> PesquisarPorNumero(List<modelocrud> modelos, int apenasUmNumero, string campo)
        {
            List<modelocrud> q = null;
            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "Id")
                q = modelos.OfType<Reuniao>().Where(i => i.Id >= apenasUmNumero).Cast<modelocrud>().ToList();

            if (modelos.OfType<Pessoa>().ToList().Count > 0 && campo == "Id")
                q = modelos.OfType<Pessoa>().Where(i => i.Id >= apenasUmNumero).Cast<modelocrud>().ToList();

            if (modelos.OfType<Celula>().ToList().Count > 0 && campo == "Id")
                q = modelos.OfType<Celula>().Where(i => i.Id >= apenasUmNumero).Cast<modelocrud>().ToList();

            if (modelos.OfType<Ministerio>().ToList().Count > 0 && campo == "Id")
                q = modelos.OfType<Ministerio>().Where(i => i.Id >= apenasUmNumero).Cast<modelocrud>().ToList();

            if (modelos.OfType<Membro>().ToList().Count > 0 && campo == "Data_batismo")
                q = modelos.OfType<Membro>().Where(i => i.Data_batismo >= apenasUmNumero).Cast<modelocrud>().ToList();
            return q;
        }

        public List<modelocrud> PesquisarPorTexto(List<modelocrud> modelos, string texto, string campo)
        {
            List<modelocrud> q = null;
            if (modelos.OfType<Crianca>().ToList().Count > 0 && campo == "Nome_pai")
                q = modelos.OfType<Crianca>().Where(p => p.Nome_pai.Contains(texto)).Cast<modelocrud>().ToList();

            if (modelos.OfType<Crianca>().ToList().Count > 0 && campo == "Nome_mae")
                q = modelos.OfType<Crianca>().Where(p => p.Nome_mae.Contains(texto)).Cast<modelocrud>().ToList();

            if (modelos.OfType<Pessoa>().ToList().Count > 0 && campo == "Email")
                q = modelos.OfType<Pessoa>().Where(p => p.Email.Contains(texto)).Cast<modelocrud>().ToList();

            if (modelos.OfType<Pessoa>().ToList().Count > 0 && campo == "NomePessoa")
                q = modelos.OfType<Pessoa>().Where(p => p.NomePessoa.Contains(texto)).Cast<modelocrud>().ToList();

            if (modelos.OfType<Celula>().ToList().Count > 0 && campo == "Nome")
                q = modelos.OfType<Celula>().Where(p => p.Nome.Contains(texto)).Cast<modelocrud>().ToList();

            if (modelos.OfType<Ministerio>().ToList().Count > 0 && campo == "Nome")
                q = modelos.OfType<Ministerio>().Where(p => p.Nome.Contains(texto)).Cast<modelocrud>().ToList();
            return q;
        }

        public List<modelocrud> PesquisarPorHorario(List<modelocrud> modelos, TimeSpan comecar, TimeSpan terminar, string campo)
        {
            List<modelocrud> q = null;
            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "Horario_fim")
                q = modelos.OfType<Reuniao>().Where(i => i.Horario_fim >= comecar && i.Horario_fim <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "Horario_inicio")
                q = modelos.OfType<Reuniao>().Where(i => i.Horario_inicio >= comecar && i.Horario_inicio <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<Celula>().ToList().Count > 0 && campo == "Horario")
                q = modelos.OfType<Celula>().Where(i => i.Horario >= comecar && i.Horario <= terminar).Cast<modelocrud>().ToList();

            return q;
        }

        public List<modelocrud> PesquisarPorHorario(List<modelocrud> modelos, TimeSpan apenasUmHorario, string campo)
        {
            List<modelocrud> q = null;
            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "Horario_fim")
                q = modelos.OfType<Reuniao>().Where(i => i.Horario_fim == apenasUmHorario).Cast<modelocrud>().ToList();

            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "Horario_inicio")
                q = modelos.OfType<Reuniao>().Where(i => i.Horario_inicio == apenasUmHorario).Cast<modelocrud>().ToList();

            if (modelos.OfType<Celula>().ToList().Count > 0 && campo == "Horario_inicio")
                q = modelos.OfType<Celula>().Where(i => i.Horario == apenasUmHorario).Cast<modelocrud>().ToList();
            return q;
        }
        #endregion

        #region MethodsPorcentagem
        public static int GeTotalRegistrosPessoas()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    var stringConexao = "";
                    if (BDcomum.BancoEnbarcado) stringConexao = BDcomum.conecta1;
                    else stringConexao = BDcomum.conecta2;
                    using (con = new SqlConnection(stringConexao))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Pessoa", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }


            return _TotalRegistros;
        }

        public static int GeTotalRegistrosCelulas()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    var stringConexao = "";
                    if (BDcomum.BancoEnbarcado) stringConexao = BDcomum.conecta1;
                    else stringConexao = BDcomum.conecta2;
                    using (con = new SqlConnection(stringConexao))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Celula", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }

        public static int GeTotalRegistrosMinisterios()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    var stringConexao = "";
                    if (BDcomum.BancoEnbarcado) stringConexao = BDcomum.conecta1;
                    else stringConexao = BDcomum.conecta2;
                    using (con = new SqlConnection(stringConexao))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Ministerio", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }

        public static int GeTotalRegistrosReunioes()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    var stringConexao = "";
                    if (BDcomum.BancoEnbarcado) stringConexao = BDcomum.conecta1;
                    else stringConexao = BDcomum.conecta2;
                    using (con = new SqlConnection(stringConexao))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Reuniao", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }

        public static int GeTotalRegistrosMudancaEstado()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    var stringConexao = "";
                    if (BDcomum.BancoEnbarcado) stringConexao = BDcomum.conecta1;
                    else stringConexao = BDcomum.conecta2;
                    using (con = new SqlConnection(stringConexao))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM MudancaEstado", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }

        public static int GeTotalRegistrosPessoasEmMinisterios()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    var stringConexao = "";
                    if (BDcomum.BancoEnbarcado) stringConexao = BDcomum.conecta1;
                    else stringConexao = BDcomum.conecta2;
                    using (con = new SqlConnection(stringConexao))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM PessoaMinisterio", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }

        public static int GeTotalRegistrosPessoasEmReunioes()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    var stringConexao = "";
                    if (BDcomum.BancoEnbarcado) stringConexao = BDcomum.conecta1;
                    else stringConexao = BDcomum.conecta2;
                    using (con = new SqlConnection(stringConexao))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM ReuniaoPessoa", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }

        public static int GeTotalRegistrosHistoricos()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    var stringConexao = "";
                    if (BDcomum.BancoEnbarcado) stringConexao = BDcomum.conecta1;
                    else stringConexao = BDcomum.conecta2;
                    using (con = new SqlConnection(stringConexao))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Historico", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }

        public static int GeTotalRegistrosMinisterioCelula()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    var stringConexao = "";
                    if (BDcomum.BancoEnbarcado) stringConexao = BDcomum.conecta1;
                    else stringConexao = BDcomum.conecta2;
                    using (con = new SqlConnection(stringConexao))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM MinisterioCelula", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }

        public static void calcularPorcentagem()
        {
            try
            {
                var pessoas = GeTotalRegistrosPessoas();
                var PessoasEmMinisterios = GeTotalRegistrosPessoasEmMinisterios();
                var PessoasEmReunioes = GeTotalRegistrosPessoasEmReunioes();
                var Historicos = GeTotalRegistrosHistoricos();
                var celulas = GeTotalRegistrosCelulas();
                var ministerios = GeTotalRegistrosMinisterios();
                var reunioes = GeTotalRegistrosReunioes();
                var mudancas = GeTotalRegistrosMudancaEstado();
                var totalRegistros = pessoas + celulas + ministerios + reunioes + mudancas
                    + PessoasEmMinisterios  + PessoasEmReunioes + Historicos;

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

                var quantidadeCarregada = quantMudancas + quantReunioes +
                quantVisitante + quantLider_Celula + quamtCelula_Jovem +
                quantCrianca + quantLider_Celula_Treinamento + quamtCelula_Adolescente +
                quantMembro_Batismo + quantLider_Ministerio + quamtCelula_Casado +
                quantMembro_Aclamacao + quantLider_Ministerio_Treinamento + quamtCelula_Crianca +
                quantMembro_Reconciliacao + quantSupervisor_Celula + quamtCelula_Adulto +
                quantMembro_Transferencia + quantSupervisor_Celula_Treinamento +
                quantVisitanteLgpd + quantSupervisor_Ministerio +
                quantCriancaLgpd + quantSupervisor_Ministerio_Treinamento +
                quantMembro_TransferenciaLgpd +
                quantMembro_BatismoLgpd +
                quantMembro_AclamacaoLgpd +
                quantMembro_ReconciliacaoLgpd;

                var porcentagem = (int)((100 * quantidadeCarregada) / totalRegistros);
                textoPorcentagem = porcentagem.ToString() + "%";
            }
            catch { }
        } 
        #endregion
    }
}
