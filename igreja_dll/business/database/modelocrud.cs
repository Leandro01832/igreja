using business;
using business.classes.Abstrato;
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
        
        public static Type ReturnBase(Type type)
        {
            while (type.BaseType != typeof(modelocrud))
                type = type.BaseType;

            return type;
        }

        public static int GetUltimoRegistro(Type BaseModel)
        {
            var Id = 0;
            SqlConnection conn = new SqlConnection(BDcomum.conecta1);
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    cmd = new SqlCommand($"SELECT TOP(1) Id FROM {BaseModel.Name} order by Id desc", conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    Id = int.Parse(dr["Id"].ToString());
                    dr.Close();
                    conn.Dispose();

                }
                catch (Exception ex)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return Id;
        }

        public static void anularDados(modelocrud modelocrud)
        {
            var props = modelocrud.GetType().GetProperties();
            foreach (var item in props)
                if (item.PropertyType == typeof(DateTime))
                    item.SetValue(modelocrud, new DateTime(0001, 01, 01));
                else if (item.PropertyType == typeof(int) ||
                item.PropertyType == typeof(double) ||
                item.PropertyType == typeof(decimal))
                    item.SetValue(modelocrud, 0);
                else if (item.PropertyType == typeof(TimeSpan))
                    item.SetValue(modelocrud, new TimeSpan(0, 0, 0));
                else if(!item.PropertyType.IsSubclassOf(typeof(modelocrud)))
                    try { item.SetValue(modelocrud, null); }
                    catch { }
                else if(item.PropertyType.IsSubclassOf(typeof(modelocrud)) && !item.PropertyType.IsAbstract)

                    foreach (var item2 in item.PropertyType.GetProperties())
                        if (item2.PropertyType == typeof(DateTime))
                            item2.SetValue(item.GetValue(modelocrud, null), new DateTime(0001, 01, 01));
                        else if (item2.PropertyType == typeof(int) ||
                        item2.PropertyType == typeof(double) ||
                        item2.PropertyType == typeof(decimal))
                            item2.SetValue(item.GetValue(modelocrud, null), 0);
                        else if (item2.PropertyType == typeof(TimeSpan))
                            item2.SetValue(item.GetValue(modelocrud, null), new TimeSpan(0, 0, 0));
                        else if (!item2.PropertyType.IsSubclassOf(typeof(modelocrud)))
                            try { item2.SetValue(item.GetValue(modelocrud, null), null); }
                            catch { }
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
        public static string classe = "";

        public static List<modelocrud> Modelos = new List<modelocrud>();

        [OpcoesBase(ChavePrimaria = true, Obrigatorio = true)]
        [Key]
        public int Id { get; set; }
        public static bool Erro_Conexao;
        public static string textoPorcentagem = "0%";
        public static int QuantErro;
        public static bool EntityCrud = false;
        public string Insert_padrao;
        public string Update_padrao;
        public string Delete_padrao;
        public string Select_padrao;
        public static bool ativar;
        public static Pessoa pessoa;
        public bool anular = true;

        public string exibirMensagemErro(Exception ex, int condicao)
        {
            string mensagem = "";
            var props = this.GetType().GetProperties();
            foreach (var item in props)
                if (item.PropertyType.IsSubclassOf(typeof(modelocrud)))
                {
                    foreach (var item2 in item.PropertyType.GetProperties())
                        if (item2.Name == ex.Message && condicao == 1)
                            mensagem = "Erro no campo " + formatarTexto(item2.Name) + ". Corrija o erro para fazer o cadastro.";
                        else if (item2.Name == ex.Message && condicao == 2)
                        {
                            OpcoesBase opc = (OpcoesBase)item2.GetCustomAttribute(typeof(OpcoesBase));
                            if (opc != null && opc.Obrigatorio) mensagem += " O Campo " + formatarTexto(item2.Name) + " é Obrigatório.\n";
                            if (this.ErroCadastro != "") mensagem += "Observação no campo " + formatarTexto(item2.Name) + ": " + this.ErroCadastro;

                        }
                }
                else
            if (item.Name == ex.Message && condicao == 1)
                    mensagem = "Erro no campo " + item.Name + ". Corrija o erro para fazer o cadastro.";
                else if (item.Name == ex.Message && condicao == 2)
                {
                    OpcoesBase opc = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));
                    if (opc != null && opc.Obrigatorio) mensagem += " O Campo " + formatarTexto(item.Name) + " é Obrigatório.\n";
                    if (this.ErroCadastro != "") mensagem += "Observação no campo " + formatarTexto(item.Name) + ": " + this.ErroCadastro;

                }
            return mensagem;
        }

        public static string formatarTexto(string name)
        {
            name = name.Replace("Frm", "");
            name = name.Replace("_", " ");

            if (name.Contains("Form") && !name.Contains("Formulario"))
                name = name.Replace("Form", "");

            name = name.Replace("MDI", "");

            for (var i = 0; i < name.Length; i++)
                if (i > 0 && name.Any(c1 => char.IsUpper(name[i])) &&
                name.Any(c2 => char.IsLower(name[i - 1])))
                    name = name.Replace(name[i - 1].ToString(), name[i - 1] + " ");
            
            return name;
        }

        public static List<Type> listTypesSon(Type tipo)
        {
            var listaTypes = tipo.Assembly.GetTypes()
            .Where(type => !type.IsAbstract && type.IsSubclassOf(tipo)).ToList();

            return listaTypes;
        }
        public static List<Type> listTypesAll(Type tipo)
        {
            var listaTypes = tipo.Assembly.GetTypes()
            .Where(type =>  type.IsSubclassOf(tipo) || type == tipo).ToList();

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
                while (T != typeof(modelocrud))
                UpdateProperty(T);
                bd.Editar(this);
                T = this.GetType();
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
                    comando += DeleteProperty(T) + " ";
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

        public static int TotalRegistro(Type tipo)
        {
            var types = listTypesSon(typeof(modelocrud));

            var _TotalRegistros = 0;
            SqlConnection conexao = null;
            SqlCommand cmd = null;

            if (tipo == null)
                foreach (var item in types)
                    if (BDcomum.podeAbrir)
                        _TotalRegistros += buscarCount( _TotalRegistros,  conexao,   cmd, item);

            if (tipo != null)
            {
                if (tipo.IsAbstract)
                {
                    var t = listTypesSon(tipo);
                    foreach(var item in t)
                    _TotalRegistros = buscarCount( _TotalRegistros, conexao, cmd, item);

                }
                else
                    _TotalRegistros += buscarCount(_TotalRegistros, conexao, cmd, tipo);
            }
                    
            return _TotalRegistros;
        }

        private static int buscarCount( int _TotalRegistros,  SqlConnection con,  SqlCommand cmd, Type item)
        {
            try
            {
                var stringConexao = "";
                if (BDcomum.BancoEnbarcado) stringConexao = BDcomum.conecta1;
                else stringConexao = BDcomum.conecta2;
                using (con = new SqlConnection(stringConexao))
                {
                    cmd = new SqlCommand($"SELECT COUNT(*) FROM {item.Name}", con);
                    con.Open();
                    _TotalRegistros += int.Parse(cmd.ExecuteScalar().ToString());
                    con.Close();
                }
            }
            catch (Exception)
            {
                BDcomum.podeAbrir = false;
            }
            return _TotalRegistros;
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
