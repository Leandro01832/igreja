using business;
using business.classes.Abstrato;
using business.contrato;
using business.implementacao;
using database.banco;
using System;
using System.Collections;
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

        [OpcoesBase(ChavePrimaria = true, Obrigatorio = true)]
        [Key]
        public int Id { get; set; }
        public static List<modelocrud> Modelos = new List<modelocrud>();

        static Calculo calculo = new Calculo();
        PropertiesCrud property;
        static Query pesquisar = new Query();
        static Entity entity = new Entity();
        public BDcomum bd;
        public SqlDataReader dr;
        public SqlConnection conexao;
        public modelocrud ModelEntity;
        public Type T;
        public string ErroCadastro = "";
        public static string classe = "";

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

        public static Type ReturnBase(Type type)
        {
            while (type.BaseType != typeof(modelocrud))
                type = type.BaseType;

            return type;
        }

        public static int TotalRegistro(Type tipo)
        {
            var types = listTypesSon(typeof(modelocrud));
            var lista = types.Where(e => e.GetProperties()
                .Where(p => p.ReflectedType == p.DeclaringType && p.Name == "Id").ToList().Count == 0).ToList();

            var _TotalRegistros = 0;
            SqlConnection conexao = null;
            SqlCommand cmd = null;

            if (tipo == null)
                foreach (var item in lista)
                    if (BDcomum.podeAbrir)
                        _TotalRegistros += buscarCount(_TotalRegistros, conexao, cmd, item);

            if (tipo != null)
            {
                if (tipo.IsAbstract)
                {
                    var t = listTypesSon(tipo);
                    foreach (var item in t)
                        _TotalRegistros += buscarCount(_TotalRegistros, conexao, cmd, item);

                }
                else
                    _TotalRegistros += buscarCount(_TotalRegistros, conexao, cmd, tipo);
            }

            return _TotalRegistros;
        }

        private static int buscarCount(int _TotalRegistros, SqlConnection con, SqlCommand cmd, Type item)
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
                    _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                    con.Close();
                }
            }
            catch (Exception)
            {
                BDcomum.podeAbrir = false;
            }
            return _TotalRegistros;
        }

        public static int GetUltimoRegistro(Type tipo)
        {
            var Id = 0;
            SqlConnection conn = new SqlConnection(BDcomum.conecta1);
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    Type BaseModel = ReturnBase(tipo);
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
                else if (!item.PropertyType.IsSubclassOf(typeof(modelocrud)))
                    try { item.SetValue(modelocrud, null); }
                    catch { }
                else if (item.PropertyType.IsSubclassOf(typeof(modelocrud)) && !item.PropertyType.IsAbstract)

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
            .Where(type => type.IsSubclassOf(tipo) || type == tipo).ToList();

            return listaTypes;
        }

        public static modelocrud buscarConcreto(Type itemType, int num)
        {
            var listaTypes = modelocrud.listTypesSon(itemType);
            foreach (var item in listaTypes)
            {
                var model = (modelocrud)Activator.CreateInstance(item);
                model.Id = num;
                if (model.recuperar(num))
                    return model;
            }
            return null;
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

        private void setar(object i2)
        {
            var model = (modelocrud)i2;
            if (model.GetType().BaseType == typeof(modelocrud) &&
            model.GetType().GetProperties().Where(e => e.ReflectedType == e.DeclaringType).ToList().Count == 4 &&
            model.GetType().GetProperties().Where(e => e.ReflectedType == e.DeclaringType &&
            e.PropertyType == typeof(int)).ToList().Count == 2)
            {
                model.salvar();
                Modelos.Add(model);
            }

            else
            {
                model.alterar(model.Id);
            }
        }

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
                    Type model = ReturnBase(GetType());
                    int num = GetUltimoRegistro(model);
                    Id = num;

                    // save list

                    var props = GetType().GetProperties().Where(p => p.PropertyType.Name == "List`1").ToList();

                    foreach (var i in props)
                    {
                        var list = i.GetValue(this);
                        if (list != null)
                        {
                            IList collection = (IList)i.GetValue(this);
                            foreach (var i2 in collection)
                                foreach (var pro in i2.GetType().GetProperties())
                                    if (pro.Name.ToLower().Contains(ReturnBase(GetType()).Name.ToLower()) && pro.PropertyType == typeof(int) ||
                                    pro.Name.ToLower().Contains(ReturnBase(GetType()).Name.ToLower()) && pro.PropertyType == typeof(int?))
                                    {
                                        pro.SetValue(i2, Id);
                                        setar(i2);
                                        break;
                                    }
                        }
                    }

                    Select_padrao = $"select * from {GetType().Name} as C where C.Id='{Id}'";
                    Delete_padrao = $" delete from {GetType().Name} where Id='{Id}' ";

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
                T = GetType();

                // save list

                var props = GetType().GetProperties().Where(p => p.PropertyType.Name == "List`1").ToList();
                foreach (var item in props)
                {
                    var listAtual = (IList)item.GetValue(this);
                    if (listAtual != null && listAtual.Count > 0 && recuperar(id))
                    {
                        var propBanco = GetType().GetProperty(item.Name);
                        var listaBanco = (IList)propBanco.GetValue(this);
                        for (var i = 0; i < listAtual[0].GetType().Name.Length; i++)
                            if (i > 0 && char.IsUpper(listAtual[0].GetType().Name[i])
                             && listAtual[0].GetType().BaseType == typeof(modelocrud) &&
                             listAtual[0].GetType().GetProperties().Where(e => e.ReflectedType == e.DeclaringType).ToList().Count == 4 &&
                             listAtual[0].GetType().GetProperties().Where(e => e.ReflectedType == e.DeclaringType &&
                             e.PropertyType == typeof(int)).ToList().Count == 2)
                            {

                                foreach (var itemlista in listAtual)
                                {
                                    var m = (modelocrud)itemlista;

                                    if (!m.recuperar(m.Id))
                                    {
                                        var ps = itemlista.GetType().GetProperties();
                                        foreach (var itemprop in ps)
                                            if (itemprop.Name.ToLower().Contains(ReturnBase(GetType()).Name.ToLower()) && itemprop.PropertyType == typeof(int?) ||
                                               itemprop.Name.ToLower().Contains(ReturnBase(GetType()).Name.ToLower()) && itemprop.PropertyType == typeof(int))
                                            {
                                                itemprop.SetValue(m, Id);
                                                var itemprop2 = itemlista.GetType().GetProperty(itemprop.Name.Replace("Id", ""));
                                                itemprop2.SetValue(m, this);
                                                m.salvar();
                                            }
                                    }

                                }

                                foreach (var itemlista in listaBanco)
                                {
                                    var teste = false;
                                    var m = (modelocrud)itemlista;
                                    foreach (var itemlist in listAtual)
                                    {
                                        var m2 = (modelocrud)itemlist;
                                        if (m.Id == m2.Id)
                                            teste = true;
                                    }
                                    if (!teste)
                                        m.excluir(m.Id);
                                }

                            }
                            else
                            {
                                foreach (var itemlista in listaBanco)
                                {
                                    var ps = itemlista.GetType().GetProperties();
                                    foreach (var itemprop in ps)
                                        if (itemprop.Name.ToLower().Contains(ReturnBase(GetType()).Name.ToLower()) && itemprop.PropertyType == typeof(int?))
                                        {
                                            var model = (modelocrud)itemlista;
                                            itemprop.SetValue(model, null);
                                            model.alterar(model.Id);
                                        }
                                }

                                foreach (var itemlista in listAtual)
                                {
                                    var ps = itemlista.GetType().GetProperties();
                                    foreach (var itemprop in ps)
                                        if (itemprop.Name.ToLower().Contains(ReturnBase(GetType()).Name.ToLower()) && itemprop.PropertyType == typeof(int?))
                                        {
                                            var model = (modelocrud)itemlista;
                                            itemprop.SetValue(model, Id);
                                            model.alterar(model.Id);
                                        }
                                }
                            }

                    }
                }

                return Update_padrao;
            }
            else
                alterarEntity(this); return "";
        }

        public string excluir(int id)
        {
            if (!EntityCrud)
            {
                bool condicao = false;
                IList listaBanco = null;
                var props = GetType().GetProperties().Where(p => p.PropertyType.Name == "List`1").ToList();
                if (props.Count > 0)
                {
                    foreach (var item in props)
                    {
                        var tipo = item.PropertyType.GetGenericArguments()[0];
                        var propBanco = GetType().GetProperty(item.Name);
                        listaBanco = (IList)propBanco.GetValue(this);
                        if (listaBanco != null && listaBanco.Count > 0)
                            if (tipo.GetProperties().Where(e => e.ReflectedType == e.DeclaringType).ToList().Count != 4 ||
                             tipo.GetProperties().Where(e => e.ReflectedType == e.DeclaringType &&
                             e.PropertyType == typeof(int)).ToList().Count != 2 ||
                             tipo.BaseType != typeof(modelocrud) ||
                             tipo.GetProperties().Where(p => p.PropertyType.Name == "List`1").ToList().Count > 0)
                            {
                                var list = tipo.GetProperties().Where(p =>
                                p.Name.ToLower().Contains(ReturnBase(GetType()).Name.ToLower()) &&
                                p.PropertyType == typeof(int?)).ToList();
                                if(list.Count == 0)
                                condicao = true;
                                else
                                {
                                    foreach (var item2 in listaBanco)
                                    {
                                        var model = (modelocrud)item2;
                                        list[0].SetValue(model, null);
                                        model.alterar(model.Id);
                                    }
                                }
                                break;
                            }
                    }

                    if (condicao)                    
                        throw new Exception($"Remova todos os itens da lista primeiro.");
                }

                string comando = "";
                while (T != typeof(modelocrud))
                    comando += DeleteProperty(T) + " ";
                Delete_padrao = comando;

                if (Delete_padrao != "")
                {
                    deleteIntermediario();
                    bd.Excluir(this);
                }
                return Delete_padrao;

            }
            else
                excluirEntity(this); return "";
        }

        private void deleteIntermediario()
        {
            var listaTypes = typeof(modelocrud).Assembly.GetTypes()
            .Where(type => type.BaseType == typeof(modelocrud) &&
             type.GetProperties().Where(e => e.ReflectedType == e.DeclaringType).ToList().Count == 4 &&
             type.GetProperties().Where(e => e.ReflectedType == e.DeclaringType &&
             e.PropertyType == typeof(int)).ToList().Count == 2).ToList();

            foreach (var item in listaTypes)
            {
                for (var i = 0; i < item.GetType().Name.Length; i++)
                    if (i > 0 && char.IsUpper(item.GetType().Name[i]))
                        if (item.Name.Contains(ReturnBase(GetType()).Name))
                        {
                            var prop = item.GetProperties().Where(p => p.Name.Contains(ReturnBase(GetType()).Name)).ToList();

                            if (prop.Count > 0)
                            {
                                var conectar = bd.obterconexao();
                                SqlCommand comando2 = new SqlCommand($"select Id from {item.Name} where {prop[0].Name}={Id}"
                                                , conectar);
                                SqlDataReader dr2 = comando2.ExecuteReader();
                                if (dr2.HasRows)
                                {
                                    while (dr2.Read())
                                    {
                                        var num = int.Parse(Convert.ToString(dr2["Id"]));
                                        var model = (modelocrud)Activator.CreateInstance(item);
                                        model.Delete_padrao = $" delete from {item.Name} where Id='{num}' ";
                                        model.bd.Excluir(model);
                                    }
                                    dr2.Close();
                                    conectar.Dispose();
                                }

                            }
                        }
            }

        }

        public bool recuperar(int id)
        {
            if (!EntityCrud)
            {
                Select_padrao = $"select * from {GetType().Name} as C where C.Id='{id}'";
                Delete_padrao = $" delete from {GetType().Name} where Id='{id}' ";
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
        public List<modelocrud> PesquisarPorData(List<modelocrud> modelos, DateTime comecar, DateTime terminar, string campo, Type tipo)
        {
            return pesquisar.PesquisarPorData(modelos, comecar, terminar, campo, tipo);
        }

        public List<modelocrud> PesquisarPorNumero(List<modelocrud> modelos, int comecar, int terminar, string campo, Type tipo)
        {
            return pesquisar.PesquisarPorNumero(modelos, comecar, terminar, campo, tipo);
        }

        public List<modelocrud> PesquisarPorTexto(List<modelocrud> modelos, string texto, string campo, Type tipo)
        {
            return pesquisar.PesquisarPorTexto(modelos, texto, campo, tipo);
        }

        public List<modelocrud> PesquisarPorHorario(List<modelocrud> modelos, TimeSpan comecar, TimeSpan terminar, string campo, Type tipo)
        {
            return pesquisar.PesquisarPorHorario(modelos, comecar, terminar, campo, tipo);
        }

        public List<modelocrud> PesquisarPorCondicao(List<modelocrud> modelos, bool condicao, string campo, Type tipo)
        {
            return pesquisar.PesquisarPorCondicao(modelos, condicao, campo, tipo);
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
