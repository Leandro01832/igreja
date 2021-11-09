using business.classes.Esboco.Abstrato;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace business.classes.Fontes
{
    [Table("Versiculo")]
    public class Versiculo : Fonte
    {
        public Versiculo() : base()
        {

        }
        public string Livro { get; set; }
        public string Texto { get; set; }
        public int Capitulo { get; set; }
                
    }
}