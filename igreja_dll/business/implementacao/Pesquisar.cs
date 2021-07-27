using business.classes;
using business.classes.Abstrato;
using business.classes.Pessoas;
using business.contrato;
using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.implementacao
{
    class Pesquisar : IPesquisar
    {
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
    }
}
