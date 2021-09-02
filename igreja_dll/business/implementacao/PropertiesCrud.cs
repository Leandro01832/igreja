﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using business.contrato;
using database;

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
            try
            {
                Type t = Model.GetType();
                if (tipo != Model.GetType())
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

                    for (int j = 0; j < 5; j++)
                        if (Model.GetType().GetProperties().ToList().FirstOrDefault(p => p.PropertyType.IsClass &&
                                  p.GetValue(Model) == null && p.PropertyType.IsAbstract ||
                                  p.PropertyType.IsClass && p.GetValue(Model) == null &&
                                  p.PropertyType.BaseType == typeof(modelocrud)) != null)
                        {
                            var prop = Model.GetType().GetProperties().ToList().FirstOrDefault(p => p.PropertyType.IsClass &&
                                p.GetValue(Model) == null && p.PropertyType.IsAbstract ||
                                p.PropertyType.IsClass && p.GetValue(Model) == null &&
                                p.PropertyType.BaseType == typeof(modelocrud));

                            var propInt = Model.GetType().GetProperties().ToList()
                                .First(p => p.Name.ToLower().Contains(prop.Name.ToLower()));

                            int? valor = (int?)propInt.GetValue(Model, null);

                            modelocrud model = null;
                            if (valor != null)
                                model = modelocrud.Modelos.FirstOrDefault(m => m.GetType()
                                .IsSubclassOf(prop.PropertyType) && m.Id == valor || m.GetType() == prop.PropertyType && m.Id == valor);


                            if (model == null && valor != null)
                            {
                                var listaTypes = prop.PropertyType.Assembly.GetTypes()
                                .Where(type => !type.IsAbstract && type.IsSubclassOf(prop.PropertyType))
                                .Select(type => type).ToList();
                                bool condicao = false;
                                foreach (var item in listaTypes)
                                {
                                    object objeto = Activator.CreateInstance(item);
                                    model = (modelocrud)objeto;
                                    model.Id = (int)valor;
                                    model.Select_padrao = $" Select * from {model.GetType().Name} where Id={(int)valor} ";
                                    condicao = model.recuperar((int)valor);
                                    if (condicao)
                                        break;
                                }
                                if (model == null)
                                {
                                    object objeto = Activator.CreateInstance(prop.PropertyType);
                                    model = (modelocrud)objeto;
                                    model.Id = (int)valor;
                                    model.Select_padrao = $" Select * from {model.GetType().Name} where Id={(int)valor} ";
                                    model.recuperar((int)valor);
                                }
                            }

                            if (model != null)
                                prop.SetValue(Model, model);
                        }

                    Model.T = Model.T.BaseType;
                    return true;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void GetProperties(Type tipo)
        {
            try
            {
                Type ClassBase = Model.GetType();
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
                    Model.T = Model.GetType();

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


                tipo = Model.GetType();
                while (tipo != typeof(modelocrud))
                {
                    if (tipo.BaseType == Model.T)
                    { Model.T = tipo; break; }
                    else
                        tipo = tipo.BaseType;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void UpdateProperties(Type tipo)
        {
            try
            {
                Type ClassBase = Model.GetType();
                string update = "";
                string properties = "";
                string values = "";
                while (ClassBase != typeof(modelocrud))
                {
                    if (ClassBase.BaseType == typeof(modelocrud))
                    {
                        if (Model.T == Model.GetType())
                            Model.T = ClassBase;
                        break;
                    }
                    else
                        ClassBase = ClassBase.BaseType;
                }

                if (tipo == null)
                    Model.T = Model.GetType();

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

                Model.T = Model.GetType();
                while (Model.T != typeof(modelocrud))
                {
                    if (Model.T == tipo)
                        break;
                    else
                        Model.T = Model.T.BaseType;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public string DeleteProperties(Type tipo)
        {
            try
            {
                string delete = "";
                delete += Model.Delete_padrao.Replace(GetType().Name, tipo.Name);
                Model.T = tipo.BaseType;

                if (tipo == Model.GetType())
                    if (Model.GetType().GetProperties().Where(p => !p.PropertyType.IsAbstract &&
                        p.PropertyType != typeof(string) && p.PropertyType != typeof(DateTime)
                        && p.PropertyType.Name != "List`1" && p.PropertyType.IsClass).ToList().Count != 0)
                    {
                        delete += VerficaPropertyClassDeleteProperties(Model.GetType());
                    }
                return delete;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private string VerficaPropertyClassDeleteProperties(Type type)
        {
            try
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
                    }
                }
                return delete;
            }
            catch (Exception ex) { throw new Exception(ex.InnerException.Message); }
        }

        private void VerficaPropertyClassSetProperties(Type tipo)
        {
            try
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
            catch (Exception ex) { throw new Exception(ex.InnerException.Message); }
        }

        private void VerficaPropertyClassInsertProperties(Type type)
        {
            try
            {
                Type ClassBase = Model.GetType();
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
            catch (Exception ex) { throw new Exception(ex.InnerException.Message); }
        }

        private void VerficaPropertyClassUpdateProperties(Type type, int id)
        {
            try
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
            catch (Exception ex) { throw new Exception(ex.InnerException.Message); }
        }

        private string VerificaProperties(string values, PropertyInfo property, string classe, object objeto)
        {
            try
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
            catch(Exception ex){ throw new Exception(ex.InnerException.Message); }
        }

        private string VerificaUpdateProperties(PropertyInfo property, object objeto)
        {
            try
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
            catch (Exception ex) { throw new Exception(ex.InnerException.Message); }
        }
    }
}
