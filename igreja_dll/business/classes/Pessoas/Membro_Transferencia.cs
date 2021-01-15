using business.classes.Abstrato;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace business.classes.Pessoas
{
       [Table("Membro_Transferencia")]
    public class Membro_Transferencia : Membro
    {    
        private string nome_cidade_transferencia;
        private string estado_transferencia;
        private string nome_igreja_transferencia;

        [Display(Name = "Nome da cidade onde morava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_cidade_transferencia
        {
            get
            {
                return nome_cidade_transferencia;
            }

            set
            {
                if (value != "")
                nome_cidade_transferencia = value;
                else
                {
                    MessageBox.Show("O nome de cidade de transerencia pecisa ser preechido corretamente");
                    nome_cidade_transferencia = null;
                }
            }
        }

        [Display(Name = "Estado onde morava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Estado_transferencia
        {
            get
            {
                return estado_transferencia;
            }

            set
            {
                if(value != "")
                estado_transferencia = value;
                else
                {
                    MessageBox.Show("O estado de transferencia deve ser preechido corretamente");
                    estado_transferencia = null;
                }
            }
        }

        [Display(Name = "Igreja onde congregava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_igreja_transferencia
        {
            get
            {
                return nome_igreja_transferencia;
            }

            set
            {
                if(value != "")
                nome_igreja_transferencia = value;
                else
                {
                    MessageBox.Show("O nome da igreja deve ser preenchido corretamente");
                    nome_igreja_transferencia = null;
                }
            }
        }
        
        public Membro_Transferencia() : base()
        {
        }
        
        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Membro_Transferencia set Nome_igreja_transferencia='{Nome_igreja_transferencia}', " +
            $" Estado_transferencia='{Estado_transferencia}', Nome_cidade_transferencia='{Nome_cidade_transferencia}', " +
            $"  where Id='{id}' " + BDcomum.addNaLista;
            
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Membro_Transferencia where Id='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Membro_Transferencia as MT "
            + " inner join Membro as M on MT.Id=M.Id "
            + " inner join PessoaDado as PD on M.Id=PD.Id inner join Pessoa as P on PD.Id=P.Id";
            if (id != null) Select_padrao += $" where MT.Id='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return null;
            }

            if (id != null)
            {
                base.recuperar(id);
                try
                {
                    dr.Read();
                    this.Nome_cidade_transferencia = Convert.ToString(dr["Nome_cidade_transferencia"]);
                    this.Estado_transferencia = Convert.ToString(dr["Estado_transferencia"]);
                    this.Nome_igreja_transferencia = Convert.ToString(dr["Nome_cidade_transferencia"]);                    
                    dr.Close();
                    modelos.Add(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    bd.obterconexao().Close();
                }
                return modelos;
            }
            else
            {
                try
                {
                    while (dr.Read())
                    {
                        Membro_Transferencia mt = new Membro_Transferencia();
                        mt.Id = int.Parse(Convert.ToString(dr["Id"]));
                        mt.Codigo = int.Parse(Convert.ToString(dr["Codigo"]));
                        mt.Nome = Convert.ToString(dr["Nome"]);                        
                        modelos.Add(mt);
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    bd.obterconexao().Close();
                }
                return modelos;
            }

        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Membro_transferencia (Nome_cidade_transferencia, " +
              " Estado_transferencia, Nome_igreja_transferencia, Id) " +
              $" values ('{Nome_cidade_transferencia}', '{Estado_transferencia}', '{Nome_igreja_transferencia}', " +
              " IDENT_CURRENT('Pessoa'))" + BDcomum.addNaLista;
            
            bd.SalvarModelo(this);
            
            return Insert_padrao;            
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.Nome;
        }

    }
}
