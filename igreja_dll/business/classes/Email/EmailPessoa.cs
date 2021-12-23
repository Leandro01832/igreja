using business.classes.Pessoas;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace business
{
    [Table("EmailPessoa")]
    public class EmailPessoa : Email
    {
        private static int UltimoRegistro;

        public string Remetente { get; set; }

        public string ConteudoTexto { get; set; }
        public string Body { get; set; }
        public int? AtendenteId { get; set; }
        public virtual Atendente Atendente { get; set; }
    }
}
