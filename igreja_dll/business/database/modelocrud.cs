using business;
using business.classes;
using business.classes.Abstrato;
using business.classes.Intermediario;
using business.classes.Pessoas;
using business.contrato;
using business.implementacao;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database
{
    public abstract class modelocrud : IPesquisar, IEntity<modelocrud>
    {
        public modelocrud()
        {    
            this.bd = new BDcomum();            
            Erro_Conexao = false;
            QuantErro = 0;
            this.T = GetType();
            property = new PropertiesCrud(this);
        }
        
        static Calculo calculo = new Calculo();
        PropertiesCrud property;
        static Pesquisar pesquisar = new Pesquisar();
        static Entity entity = new Entity();
        public BDcomum bd;
        public SqlDataReader dr;
        public SqlConnection conexao;
        public modelocrud ModelEntity;
        public Type T;
        public string ErroCadastro = "";
        public string Operacao = "";
        public static string classe = "";
        
        public static List<modelocrud> Modelos = new List<modelocrud>();

        [OpcoesBase(ChavePrimaria = true, Obrigatorio = true)]
        [Key]
        public int Id { get; set; }        
        public static bool Erro_Conexao;        
        public static string textoPorcentagem = "0%";        
        public static int QuantErro;
        public static bool  EntityCrud = false;
        public string Insert_padrao;
        public string Update_padrao;
        public string Delete_padrao;
        public string Select_padrao;
        public static bool ativar;
        public static Pessoa pessoa;

        public string exibirMensagemErro(Exception ex, int condicao)
        {
            string mensagem = "";
            var props = this.GetType().GetProperties();
            foreach (var item in props)
            if (item.Name == ex.Message && condicao == 1)
            mensagem = "Erro no campo " + item.Name + ". Corrija o erro para fazer o cadastro.";
            else if (item.Name == ex.Message && condicao == 2)
            {
                    OpcoesBase opc = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));
                if (opc != null && opc.Obrigatorio) mensagem += "Erro no campo " + item.Name + ". Este Campo é Obrigatório.\n"; 
                if (this.ErroCadastro != "") mensagem += "Erro no campo " + item.Name + ". " + this.ErroCadastro; 
                
            }
           return mensagem;
        }

        public static List<Type> listTypes(Type tipo)
        {
            var listaTypes = tipo.Assembly.GetTypes()
            .Where(type => !type.IsAbstract && type.IsSubclassOf(tipo)).ToList();

            return listaTypes;
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

        #region MethodsCrud
        public string salvar()
        {
            if (!EntityCrud)
            {
                this.Operacao = "insert";
                try
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
                        GetProperty(T);
                    GetProperty(null);
                    bd.SalvarModelo(this);
                    this.Operacao = "";
                    return Insert_padrao;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
                salvarEntity(this); return "";            
        }

        public string alterar(int id)
        {
            if (!EntityCrud)
            {
                this.Operacao = "update";
                while (T != typeof(modelocrud))
                    UpdateProperty(T);
                UpdateProperty(null);
                bd.Editar(this);
                this.Operacao = "";
                return Update_padrao;
            }
            else
                alterarEntity(this); return "";            
        }

        public string excluir(int id)
        {
            if (!EntityCrud)
            {
                string comando = "";
                while (T != typeof(modelocrud))
                    comando += DeleteProperty(T);
                Delete_padrao = comando;
                bd.Excluir(this);
                return Delete_padrao;
            }
            else
                excluirEntity(this); return "";            
        }

        public bool recuperar(int id)
        {
            if (!EntityCrud)
            {
                bool retorno = false;
                while (T != typeof(modelocrud))
                {
                    if (SetProperty(T))
                        retorno = true;
                    else { retorno = false; break; };
                }
                T = GetType();
                return retorno;
            }
            else
            {
              var model = recuperarEntity(id, this);
                if (model == null) return false;
                else return true;
            }
        }

        public static void buscarListas()
        {
            List<object> lista = new List<object>();
            for (var i = 0; i < Modelos.Count; i++)
            {
                
                for (var k = 0; k < Modelos.Count; k++)
                {
                    var props = Modelos[k].GetType().GetProperties();

                    foreach (var prop in props)
                    {
                        modelocrud model = null;
                        if(prop.PropertyType.IsClass && prop.PropertyType.IsSubclassOf(typeof(modelocrud)))
                        {
                            model = (modelocrud)prop.GetValue(Modelos[k]);
                            if (model != null && model.Id == Modelos[i].Id && model.GetType().Name == Modelos[i].GetType().Name)
                                lista.Add(Modelos[k]);
                        }
                        
                    }


                    if (k == Modelos.Count - 1 && lista.Count > 0)
                    {
                        var propLista = Modelos[i].GetType().GetProperties()
                            .Where(p => p.PropertyType.Name == "List`1").ToList();                        

                        if (propLista.FirstOrDefault(p => p.PropertyType.GetGenericArguments()[0] == typeof(MinisterioCelula)) != null)
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
                    
                    while (dr.Read())
                    {
                        var num = int.Parse(Convert.ToString(dr["Id"]));
                        modelocrud mod = null;                        
                        mod = (modelocrud)Activator.CreateInstance(GetType());
                        mod.Id = num;
                        mod.Select_padrao = $"select * from {GetType().Name} as C where C.Id='{mod.Id}'";
                        mod.Delete_padrao = $" delete from {GetType().Name} where Id='{mod.Id}' ";
                        if (mod.recuperar(mod.Id))
                            Modelos.Add(mod);
                    }
                    dr.Close();
                    
                    bd.fecharconexao(conexao);    
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

        public void salvarEntity(modelocrud model)
        {
            EntityCrud = true;
            entity.salvarEntity(model);
        }

        public void alterarEntity(modelocrud model)
        {
            EntityCrud = true;
            entity.alterarEntity(model);
        }

        public void excluirEntity(modelocrud model)
        {
            EntityCrud = true;
            entity.excluirEntity(model);
        }

        public modelocrud recuperarEntity(int id, modelocrud model)
        {
            EntityCrud = true;
            ModelEntity = entity.recuperarEntity(id, model);
            return ModelEntity;
        }

        public static Task<List<modelocrud>> recuperarEntity(Type type)
        {
            EntityCrud = true;
            return Entity.recuperarEntity(type);
        }
        #endregion

        #region MethodsProperties
        //
        private bool SetProperty(Type tipo)
        {
            return property.SetProperties(tipo);
        }

        private string DeleteProperty(Type tipo)
        {
            return property.DeleteProperties(tipo);
        }

        private void GetProperty(Type tipo)
        {
            try
            {
                property.GetProperties(tipo);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void UpdateProperty(Type tipo)
        {
            property.UpdateProperties(tipo);
        }
        #endregion        

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
            calculo.CalcularPorcentagem();            
        }

        
        #endregion
    }
}
