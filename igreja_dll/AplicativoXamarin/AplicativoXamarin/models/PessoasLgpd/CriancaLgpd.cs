
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using AplicativoXamarin.models.Pessoas;
using Newtonsoft.Json;
using AplicativoXamarin.ViewModels;

namespace AplicativoXamarin.models.PessoasLgpd
{
    public class CriancaLgpd : PessoaLgpd
    {
        public string Nome_pai { get; set; }
        public string Nome_mae { get; set; }

        public CriancaLgpd() : base()
        {
        }

        internal string ReturnJson(RegisterViewModel msg)
        {
            var j = JsonConvert.SerializeObject(new
            {
                Email = msg.Email,
                password = msg.Password,
                Nome_pai = " - ",
                Nome_mae = " - ",
                NomePessoa = " - "
            });

            return j;
        }
    }
}
