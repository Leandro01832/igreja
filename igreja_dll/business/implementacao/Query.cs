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

            if (modelos.Where(m => m.GetType() == tipo || m.GetType().IsSubclassOf(tipo)).ToList().Count > 0 )
                q = modelos.Where(i => Convert.ToDateTime(info.GetValue(i)) >= comecar &&
                Convert.ToDateTime(info.GetValue(i)) <= terminar && i.GetType() == tipo ||
                 Convert.ToDateTime(info.GetValue(i)) >= comecar && Convert.ToDateTime(info.GetValue(i)) <= terminar &&
                 i.GetType().IsSubclassOf(tipo))
                    .Cast<modelocrud>().ToList();
            
            return q;
        }
        

        public List<modelocrud> PesquisarPorHorario(List<modelocrud> modelos, TimeSpan comecar, TimeSpan terminar, string campo, Type tipo)
        {
            List<modelocrud> q = null;
            PropertyInfo info = tipo.GetProperty(campo);

            if (modelos.Where(m => m.GetType() == tipo || m.GetType().IsSubclassOf(tipo)).ToList().Count > 0)
                q = modelos.Where(i => TimeSpan.Parse(info.GetValue(i).ToString()) >= comecar &&
                TimeSpan.Parse(info.GetValue(i).ToString()) <= terminar &&
                 i.GetType() == tipo ||
                 TimeSpan.Parse(info.GetValue(i).ToString()) >= comecar &&
                TimeSpan.Parse(info.GetValue(i).ToString()) <= terminar &&
                 i.GetType().IsSubclassOf(tipo))
                    .Cast<modelocrud>().ToList();

            return q;
        }
        

        public List<modelocrud> PesquisarPorNumero(List<modelocrud> modelos, int comecar, int terminar, string campo, Type tipo)
        {
            List<modelocrud> q = null;
            PropertyInfo info = tipo.GetProperty(campo);

            if (modelos.Where(m => m.GetType() == tipo || m.GetType().IsSubclassOf(tipo)).ToList().Count > 0)
                q = modelos.Where(i => int.Parse(info.GetValue(i).ToString()) >= comecar &&
                int.Parse(info.GetValue(i).ToString()) <= terminar &&
                 i.GetType() == tipo ||
                 int.Parse(info.GetValue(i).ToString()) >= comecar &&
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
                q = modelos.Where(i => info.GetValue(i).ToString().Contains(texto) && i.GetType() == tipo ||
                info.GetValue(i).ToString().Contains(texto) && i.GetType().IsSubclassOf(tipo)).Cast<modelocrud>().ToList();

            return q;
        }
    }
}
