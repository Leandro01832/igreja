using business.classes.Abstrato;
using business.classes.Pessoas;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Classe.financeiro
{
    [Table("Admin")]
    public class Admin : PessoaDado
    {
        [Index("USER", 2, IsUnique = true)]
        [Column(TypeName = "varchar")]
        public string User { get; set; }
        public string Password { get; set; }
        public string Permissao { get; set; }

        public Admin()
        {
            
        }
        
        public static string PrimeiroAdminUser = "leandro";
        public static string PrimeiroAdminPassword = "01832";
        public static string PrimeiroAdminPermissao = "Aluguel, Cantina, Compra, Dizimo, Retiro, Transporte, Transacao";


        public bool verificarAutenticacao(Admin adm)
        {
            if (Modelos.OfType<Admin>().FirstOrDefault(m => m.User == adm.User) != null &&
                Modelos.OfType<Admin>().FirstOrDefault(m =>  m.Password == adm.Password) != null)
                return true;
            return false;
        }

        public bool verificarTodos()
        {
            bool condicao = false;
            var modelos = Modelos.OfType<Admin>();

            if(modelos != null)
            foreach(var item in modelos)
            {
                    if (this.verificarAutenticacao(item))
                    {
                        condicao = true;
                        this.Permissao = item.Permissao;
                    }
            }

            return condicao;
        }

        public bool verificarPermissao(string permissao)
        {
            if (this.Permissao.Contains(permissao)) return true;
            return false;
        }

    }


}
