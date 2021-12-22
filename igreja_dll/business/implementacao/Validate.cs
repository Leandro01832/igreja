using business.contrato;
using database;
using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace business.implementacao
{
    public class Validate : IValidate
    {

        public Validate(modelocrud modelo)
        {
            Modelo = modelo;
        }

        //validar data
        Regex rgData = new Regex(@"(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/(19|20)\d{2}");
        
        //validar hora
        Regex rgHora = new Regex(@"^[0-2][0-3]:[0-5][0-9]$");

        //validar moeda
        Regex rgMoeda = new Regex(@"^([1-9]{1}[\d]{0,2}(\.[\d]{3})*(\,[\d]{0,2})?|[1-9]{1}[\d]{0,}(\,[\d]{0,2})?|0(\,[\d]{0,2})?|(\,[\d]{1,2})?)$");
        //^(R\$ ?\d{1,3},\d{2}|U\$ ?\d{1,3}\.\d{2})$

        public modelocrud Modelo { get; }

        public void Validar(string valor, string name)
        {
            var props = Modelo.GetType().GetProperties();

            foreach(var item in props)
            {
                if(item.PropertyType == typeof(DateTime) && item.Name == name ||
                    item.PropertyType == typeof(DateTime?) && item.Name == name)
                {
                    if (rgData.IsMatch(valor))
                        item.SetValue(Modelo, Convert.ToDateTime(valor));
                    else
                        item.SetValue(Modelo, new DateTime(0001, 01, 01));
                }

                if (item.PropertyType == typeof(TimeSpan) && item.Name == name ||
                    item.PropertyType == typeof(TimeSpan?) && item.Name == name)
                {
                    if (rgHora.IsMatch(valor))
                        item.SetValue(Modelo, TimeSpan.Parse(valor));
                    else
                        item.SetValue(Modelo, new TimeSpan(0, 0, 0));
                }

                if (item.PropertyType == typeof(decimal) && item.Name == name ||
                    item.PropertyType == typeof(decimal?) && item.Name == name)
                {
                    if (rgMoeda.IsMatch(valor))
                    {
                        decimal v = decimal.Parse(valor);
                        try { item.SetValue(Modelo, decimal.Parse(v.ToString("F2"))); }
                        catch { throw new Exception(name); }
                    }
                    else
                        throw new Exception(name);
                }
            }

        }
    }
}
