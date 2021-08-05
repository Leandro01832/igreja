using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using business.contrato;
using database;
using database.banco;

namespace business.implementacao
{
    public class PropertiesCrud :  IPropertiesCrud
    {
        public modelocrud Model { get; }

        public PropertiesCrud(modelocrud model)
        {
            Model = model;
        }

        public bool SetProperties(Type tipo)
        {
            Type t =Model.GetType();
            if (tipo !=Model.GetType())
            {
                while (t != typeof(modelocrud))
                {
                    if (t.BaseType == tipo)
                        break;
                    else
                        t = t.BaseType;
                }
                Model.Select_padrao = Model.Select_padrao.Replace(t.Name, tipo.Name);
            }

            var propertiesDeclaring = tipo.GetProperties().Where(e => e.ReflectedType == e.DeclaringType);

            if (Model.conexao == null)
                Model.conexao = Model.bd.obterconexao();

            if (Model.conexao.State == ConnectionState.Closed)
                Model.conexao = Model.bd.obterconexao();

            SqlCommand comando = new SqlCommand(Model.Select_padrao, Model.conexao);
            try
            {
                Model.dr = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - " + Model.GetType());
            }

            if (Model.conexao != null)
            {
                if (Model.dr.HasRows == false)
                {
                    Model.dr.Close();
                    Model.bd.fecharconexao(Model.conexao);
                    return false;
                }

                try
                {
                    Model.dr.Read();
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
                                property.SetValue(Model, long.Parse(Convert.ToString(Model.dr[property.Name])));
                            }
                            catch { property.SetValue(Model, null); }
                        }
                        else
                        if (property.PropertyType == typeof(double) || property.PropertyType == typeof(double?))
                        {
                            try
                            {
                                property.SetValue(Model, double.Parse(Convert.ToString(Model.dr[property.Name])));
                            }
                            catch { property.SetValue(Model, null); }
                        }
                        else
                        if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                        {
                            try
                            {
                                property.SetValue(Model, DateTime.Parse(Convert.ToString(Model.dr[property.Name])));
                            }
                            catch { property.SetValue(Model, null); }
                        }
                        else
                        if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                        {
                            try
                            {
                                property.SetValue(Model, int.Parse(Convert.ToString(Model.dr[property.Name])));
                            }
                            catch { property.SetValue(Model, null); }
                        }
                        else
                        if (property.PropertyType == typeof(string))
                        {
                            try
                            {
                                property.SetValue(Model, Convert.ToString(Model.dr[property.Name]));
                            }
                            catch { property.SetValue(Model, null); }
                        }
                        else
                        if (property.PropertyType == typeof(bool))
                        {
                            try
                            {
                                property.SetValue(Model, Convert.ToBoolean(Model.dr[property.Name]));
                            }
                            catch { property.SetValue(Model, null); }
                        }
                        else
                        if (property.PropertyType == typeof(TimeSpan) || property.PropertyType == typeof(TimeSpan?))
                        {
                            try
                            {
                                property.SetValue(Model, TimeSpan.Parse(Convert.ToString(Model.dr[property.Name])));
                            }
                            catch { property.SetValue(Model, null); }
                        }
                    }
                    Model.dr.Close();
                }
                catch (Exception ex)
                {
                    Model.dr.Close();
                    Model.TratarExcessao(ex);
                    return false;
                }
                finally
                {
                    Model.bd.fecharconexao(Model.conexao);
                }

                if (Model.GetType().GetProperties().Where(p =>
                p.PropertyType.GetProperties().Where(pr => pr.ReflectedType ==
                pr.DeclaringType && pr.Name == "Id").ToList().Count != 0)
                .ToList().Count != 0)
                {
                    VerficaPropertyClassSetProperties(Model.GetType());
                }

                Model.T = Model.T.BaseType;
                return true;
            }
            return false;
        }

        public string DeleteProperties(Type tipo)
        {
            string delete = "";
            delete += Model.Delete_padrao.Replace(GetType().Name, tipo.Name);
            Model.T = tipo.BaseType;

            if (tipo ==Model.GetType())
                if (Model.GetType().GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                    p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                    && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass).ToList().Count != 0)
                {
                    delete += VerficaPropertyClassDeleteProperties(Model.GetType());
                }
            return delete;
        }

        public string VerficaPropertyClassDeleteProperties(Type type)
        {
            string delete = "";
            foreach (var item in type.GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                 p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                  && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass).ToList())
            {
                object objeto = Activator.CreateInstance(item.PropertyType);
                modelocrud modelo = (modelocrud)objeto;
                modelo.Id = Model.Id;
                if (modelo.GetType().GetProperties()
                .Where(p => p.ReflectedType == p.DeclaringType && p.Name == "Id").ToList().Count == 1)
                {
                    delete += $" delete from {modelo.GetType().Name} where Id='{Model.Id}' ";
                    // modelo.excluir(Model.Id);
                }
            }
            return delete;
        }

        public void VerficaPropertyClassSetProperties(Type tipo)
        {
            foreach (var item in tipo.GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                 p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                  && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass).ToList())
            {
                object objeto = Activator.CreateInstance(item.PropertyType);
                modelocrud modelo = (modelocrud)objeto;
                modelo.Id = Model.Id;
                if (modelo.GetType().GetProperties()
                .Where(p => p.ReflectedType == p.DeclaringType && p.Name == "Id").ToList().Count == 1)
                {
                    modelo.Select_padrao = $"select * from {modelo.GetType().Name} as C where C.Id='{Model.Id}'";
                    modelo.recuperar(Model.Id);
                }

                foreach (var item2 in Model.GetType().GetProperties())
                {
                    if (item == item2)
                        item2.SetValue(Model, modelo);
                }
            }
        }

        public void GetProperties(Type tipo)
        {
            Type ClassBase =Model.GetType();
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
                Model.T =Model.GetType();

            var propertiesDeclaring = Model.T.GetProperties().Where(e => e.ReflectedType == e.DeclaringType
            && !e.PropertyType.IsAbstract && e.PropertyType.Name != "List`1"
            && e.PropertyType.BaseType != typeof(modelocrud)).ToList();

            foreach (var property in propertiesDeclaring)
            {
                properties += property.Name + ", ";
                values = VerificaProperties(values, property, modelocrud.classe, Model);
            }

            if (values != "")
                values = values.Remove(values.Length - 2, 2);
            if (properties != "")
                properties = properties.Remove(properties.Length - 2, 2);

            if (Model.T != typeof(modelocrud))
            {
                if (Model.T != ClassBase && values != "")
                    insert = $"insert into {Model.T.Name} (Id, {properties} ) values (IDENT_CURRENT('{ClassBase.Name}'), {values} ) ";
                else
                    if (Model.T != ClassBase && values == "")
                    insert = $"insert into {Model.T.Name} (Id) values (IDENT_CURRENT('{ClassBase.Name}') ) ";
                else
                    insert = $"insert into {Model.T.Name} ( {properties} ) values ( {values} ) ";

                Model.Insert_padrao += insert.Replace("Insert_padrao, Update_padrao, Delete_padrao, Select_padrao,", "");
            }

            if (tipo == null)
            {
                if (Model.GetType().GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                   p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                   && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass).ToList().Count != 0)
                {
                    VerficaPropertyClassInsertProperties(Model.GetType());
                }
            }


            tipo =Model.GetType();
            while (tipo != typeof(modelocrud))
            {
                if (tipo.BaseType == Model.T)
                { Model.T = tipo; break; }
                else
                    tipo = tipo.BaseType;
            }
        }

        public void VerficaPropertyClassInsertProperties(Type type)
        {
            Type ClassBase =Model.GetType();
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
                object objeto = property.GetValue(Model, null);
                modelocrud model = (modelocrud)objeto;
                model.Select_padrao = "Teste123";
                model.Update_padrao = "Teste123";
                model.Delete_padrao = "Teste123";
                model.Insert_padrao = "Teste123";
                foreach (var item in property.PropertyType.GetProperties().Where(p => !p.PropertyType.IsAbstract))
                {
                    properties += item.Name + ", ";
                    values = VerificaProperties(values, item, modelocrud.classe, property.GetValue(Model));
                }
                properties = properties.Replace(", Insert_padrao, Update_padrao, Delete_padrao, Select_padrao", "");
                values = values.Replace(", 'Teste123'", "");
                if (values != "")
                {
                    if (values != "")
                        values = values.Remove(values.Length - 2, 2);
                    if (properties != "")
                        properties = properties.Remove(properties.Length - 2, 2);
                    Model.Insert_padrao += $"insert into {property.PropertyType.Name} ( {properties} ) values ( {values} ) ";
                }
            }
        }

        public void UpdateProperties(Type tipo)
        {
            Type ClassBase =Model.GetType();
            string update = "";
            string properties = "";
            string values = "";
            while (ClassBase != typeof(modelocrud))
            {
                if (ClassBase.BaseType == typeof(modelocrud))
                {
                    if (Model.T ==Model.GetType())
                        Model.T = ClassBase;
                    break;
                }
                else
                    ClassBase = ClassBase.BaseType;
            }

            if (tipo == null)
                Model.T =Model.GetType();

            var propertiesDeclaring = Model.T.GetProperties().Where(e => e.ReflectedType == e.DeclaringType
            && !e.PropertyType.IsAbstract && e.PropertyType.Name != "List`1"
            && e.PropertyType.BaseType != typeof(modelocrud)).ToList();


            foreach (var property in propertiesDeclaring)
            {
                properties = property.Name + "=";
                values += properties + VerificaUpdateProperties(property, Model);
            }

            values = values.Remove(values.Length - 2, 2);
            properties = properties.Remove(properties.Length - 2, 2);

            if (Model.T != typeof(modelocrud) && propertiesDeclaring.Count > 0)
            {
                update = $" update {Model.T.Name} set {values} " + $" where Id='{Model.Id}' ";
                Model.Update_padrao += update;
            }

            if (tipo == null)
            {
                if (Model.GetType().GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                   p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                   && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass).ToList().Count != 0)
                {
                    VerficaPropertyClassUpdateProperties(Model.GetType(), Model.Id);
                }
            }

            if (tipo != null)
                while (tipo != typeof(modelocrud))
                {
                    if (tipo.BaseType == Model.T)
                        break;
                    else
                        tipo = tipo.BaseType;
                }

            Model.T =Model.GetType();
            while (Model.T != typeof(modelocrud))
            {
                if (Model.T == tipo)
                    break;
                else
                    Model.T = Model.T.BaseType;
            }

        }

        public void VerficaPropertyClassUpdateProperties(Type type, int id)
        {
            var propertiesDeclaring = type.GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                   p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                   && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass).ToList();

            foreach (var property in propertiesDeclaring.Where(p =>
                  p.PropertyType.GetProperties().Where(pr => pr.ReflectedType ==
                pr.DeclaringType && pr.Name == "Id").ToList().Count != 0))
            {
                object objeto = property.GetValue(Model, null);
                modelocrud model = (modelocrud)objeto;
                model.Select_padrao = "";
                model.Update_padrao = "";
                model.Delete_padrao = "";
                model.Insert_padrao = "";
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

                if (Model.T != typeof(modelocrud) && propertiesDeclaring.Count > 0)
                {
                    update = $" update {property.PropertyType.Name} set {values} " + $" where Id='{id}' ";
                    Model.Update_padrao += update.Replace(", Insert_padrao='', Update_padrao='', Delete_padrao='', Select_padrao=''", "");
                }
            }
        }

        public string VerificaProperties(string values, PropertyInfo property, string classe, object objeto)
        {
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

        public string VerificaUpdateProperties(PropertyInfo property, object objeto)
        {
            string values = "";
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
    }
}
