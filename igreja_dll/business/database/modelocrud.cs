﻿using business.classes;
using business.classes.Abstrato;
using database.banco;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database
{
     public abstract class  modelocrud : IPesquisar
    {
        //construtor para Entity Framework
        public modelocrud()
        {
            this.bd = new BDcomum();
        }


        private string insert_padrao;
        private string update_padrao;
        private string delete_padrao;
        private string select_padrao;
        
        [NotMapped]
        public string Insert_padrao { get => insert_padrao; set => insert_padrao = value; }
        [NotMapped]
        public string Update_padrao { get => update_padrao; set => update_padrao = value; }
        [NotMapped]
        public string Delete_padrao { get => delete_padrao; set => delete_padrao = value; }
        [NotMapped]
        public string Select_padrao { get => select_padrao; set => select_padrao = value; }

        public BDcomum bd;       

        public abstract string salvar();
        public abstract string alterar( int id);
        public abstract string excluir(int id);
        public abstract List<modelocrud> recuperar(int? id);

        public bool retornoDados(SqlDataReader dr, string pesquisa)
        {
            try
            {
                int valor = int.Parse(Convert.ToString(dr[pesquisa]));
                return true;
            }
            catch (Exception)
            {
              return  false;
            }
        }

        public string PesquisarPorData(DateTime comecar, DateTime terminar, string campo)
        {
            return $" {campo}>={comecar.ToString()} and {campo}<={terminar.ToString()} ";
        }

        public string PesquisarPorData(DateTime apenasUmDia, string campo)
        {
            return $" {campo}=={apenasUmDia.ToString()} ";
        }

        public string PesquisarPorNumero(int comecar, int terminar, string campo)
        {
            return $" {campo}>={comecar.ToString()} and {campo}<={terminar.ToString()} ";
        }

        public string PesquisarPorNumero(int apenasUmNumero, string campo)
        {
            return $" {campo}=={apenasUmNumero.ToString()} ";
        }

        public string PesquisarPorTexto(string texto, string campo)
        {
            return $" {campo} like '{texto}' ";
        }

        public string PesquisarPorHorario(TimeSpan comecar, TimeSpan terminar, string campo)
        {
            return $" {campo}>={comecar.ToString()} and {campo}<={terminar.ToString()} ";
        }

        public string PesquisarPorHorario(TimeSpan apenasUmHorario, string campo)
        {
            return $" {campo}=={apenasUmHorario.ToString()} ";
        }
    }
}
