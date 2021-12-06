using business.contrato;
using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace business.implementacao
{
    public class Query : IPesquisar
    {

        public List<modelocrud> PesquisarPorData(List<modelocrud> modelos, DateTime comecar, DateTime terminar, string campo, Type tipo)
        {
            List<modelocrud> q = null;
            PropertyInfo info = tipo.GetProperty(campo);

            if (info.PropertyType == typeof(DateTime) || info.PropertyType == typeof(DateTime?))
                q = modelos.Where(i => info.GetValue(i) != null && Convert.ToDateTime(info.GetValue(i)) >= comecar &&
                Convert.ToDateTime(info.GetValue(i)) <= terminar && i.GetType() == tipo ||
                info.GetValue(i) != null && Convert.ToDateTime(info.GetValue(i)) >= comecar &&
                Convert.ToDateTime(info.GetValue(i)) <= terminar && i.GetType().IsSubclassOf(tipo))
                .Cast<modelocrud>().ToList();
            
            return q;
        }
        
        public List<modelocrud> PesquisarPorHorario(List<modelocrud> modelos, TimeSpan comecar, TimeSpan terminar, string campo, Type tipo)
        {
            List<modelocrud> q = null;
            PropertyInfo info = tipo.GetProperty(campo);

            if (info.PropertyType == typeof(TimeSpan) || info.PropertyType == typeof(TimeSpan?))
                q = modelos.Where(i => info.GetValue(i) != null && TimeSpan.Parse(info.GetValue(i).ToString()) >= comecar &&
                TimeSpan.Parse(info.GetValue(i).ToString()) <= terminar &&
                 i.GetType() == tipo ||
                info.GetValue(i) != null && TimeSpan.Parse(info.GetValue(i).ToString()) >= comecar &&
                TimeSpan.Parse(info.GetValue(i).ToString()) <= terminar &&
                 i.GetType().IsSubclassOf(tipo))
                    .Cast<modelocrud>().ToList();

            return q;
        }
        
        public List<modelocrud> PesquisarPorNumero(List<modelocrud> modelos, int comecar, int terminar, string campo, Type tipo)
        {
            List<modelocrud> q = null;
            PropertyInfo info = tipo.GetProperty(campo);

            if(info.PropertyType == typeof(int) || info.PropertyType == typeof(int?))
                q = modelos.Where(i => info.GetValue(i) != null && int.Parse(info.GetValue(i).ToString()) >= comecar &&
                int.Parse(info.GetValue(i).ToString()) <= terminar &&
                 i.GetType() == tipo ||
                info.GetValue(i) != null && int.Parse(info.GetValue(i).ToString()) >= comecar &&
                int.Parse(info.GetValue(i).ToString()) <= terminar &&
                 i.GetType().IsSubclassOf(tipo))
                    .Cast<modelocrud>().ToList();

            if (info.PropertyType == typeof(long) || info.PropertyType == typeof(long?))
                q = modelos.Where(i => info.GetValue(i) != null && int.Parse(info.GetValue(i).ToString()) >= comecar &&
                int.Parse(info.GetValue(i).ToString()) <= terminar &&
                 i.GetType() == tipo ||
                info.GetValue(i) != null && long.Parse(info.GetValue(i).ToString()) >= comecar &&
                int.Parse(info.GetValue(i).ToString()) <= terminar &&
                 i.GetType().IsSubclassOf(tipo))
                    .Cast<modelocrud>().ToList();

            if (info.PropertyType == typeof(decimal) || info.PropertyType == typeof(decimal?))
                q = modelos.Where(i => info.GetValue(i) != null && int.Parse(info.GetValue(i).ToString()) >= comecar &&
                int.Parse(info.GetValue(i).ToString()) <= terminar &&
                 i.GetType() == tipo ||
                info.GetValue(i) != null && decimal.Parse(info.GetValue(i).ToString()) >= comecar &&
                int.Parse(info.GetValue(i).ToString()) <= terminar &&
                 i.GetType().IsSubclassOf(tipo))
                    .Cast<modelocrud>().ToList();

            if (info.PropertyType == typeof(double) || info.PropertyType == typeof(double?))
                q = modelos.Where(i => info.GetValue(i) != null && int.Parse(info.GetValue(i).ToString()) >= comecar &&
                int.Parse(info.GetValue(i).ToString()) <= terminar &&
                 i.GetType() == tipo ||
                info.GetValue(i) != null && double.Parse(info.GetValue(i).ToString()) >= comecar &&
                int.Parse(info.GetValue(i).ToString()) <= terminar &&
                 i.GetType().IsSubclassOf(tipo))
                    .Cast<modelocrud>().ToList();

            return q;
        }
        
        public List<modelocrud> PesquisarPorTexto(List<modelocrud> modelos, string texto, string campo, Type tipo)
        {
            List<modelocrud> q = null;
            PropertyInfo info = tipo.GetProperty(campo);

            if (modelos.Where(m => m.GetType() == tipo || m.GetType().IsSubclassOf(tipo)).ToList().Count > 0)
                q = modelos.Where(i => info.GetValue(i) != null &&
                info.GetValue(i).ToString().Contains(texto) && i.GetType() == tipo ||
                info.GetValue(i) != null && info.GetValue(i).ToString().Contains(texto) &&
                i.GetType().IsSubclassOf(tipo)).Cast<modelocrud>().ToList();

            return q;
        }

        public List<modelocrud> PesquisarPorCondicao(List<modelocrud> modelos, bool condicao, string campo, Type tipo)
        {
            List<modelocrud> q = null;
            PropertyInfo info = tipo.GetProperty(campo);

            if (modelos.Where(m => m.GetType() == tipo && condicao ||
            m.GetType().IsSubclassOf(tipo)).ToList().Count > 0 && condicao)
                q = modelos.Where(i => info.GetValue(i) != null &&
               Convert.ToBoolean(info.GetValue(i)) == condicao && i.GetType() == tipo ||
                info.GetValue(i) != null && Convert.ToBoolean(info.GetValue(i)) == condicao &&
                i.GetType().IsSubclassOf(tipo)).Cast<modelocrud>().ToList();

            return q;
        }
    }
}
