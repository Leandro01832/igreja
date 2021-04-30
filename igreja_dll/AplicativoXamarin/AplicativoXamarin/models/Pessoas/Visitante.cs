
using System;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AplicativoXamarin.models.Pessoas
{
    public class Visitante : PessoaDado
    {       
        public DateTime Data_visita { get; set; }
        public string Condicao_religiosa { get; set; }


        public Visitante() : base()
        {
        }    

    }
}
