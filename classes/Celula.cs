using igreja2.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace igreja2.classes
{
    class Celula : Endereco_Celula
    {
        private int id;
        private string cel_nome;
        private string lider;
        private string lider_treinamento;
        private List<Pessoa> pessoas;
        private string dia_semana;
        private DateTime horario;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Cel_nome
        {
            get
            {
                return cel_nome;
            }

            set
            {
                if (value != "")
                cel_nome = value;
                else
                {
                    MessageBox.Show("A celula precisa de um nome.");
                    cel_nome = null;
                }
                
            }
        }

        public string Lider_treinamento
        {
            get
            {
                return lider_treinamento;
            }

            set
            {
                if (value != "")
                lider_treinamento = value;
                else
                {
                    MessageBox.Show("A celula precisa de um lider em treinamento. Preencha o campo lider em treinamento");
                    lider_treinamento = null;
                }
                    
            }
        }     

        public string Dia_semana
        {
            get
            {
                return dia_semana;
            }

            set
            {
                if (value != "")
                dia_semana = value;
                else
                {
                    MessageBox.Show("Preencha o campo dia da semana para as reuniões de celula");
                    dia_semana = null;
                }
            }
        }

        public DateTime Horario
        {
            get
            {
                return horario;
            }

            set
            {
                horario = value;
            }
        }

        internal List<Pessoa> Pessoas
        {
            get
            {
                return pessoas;
            }

            set
            {
                pessoas = value;
            }
        }

        public string Lider
        {
            get
            {
                return lider;
            }

            set
            {
                if (value != "")
                lider = value;
                else
                {
                    MessageBox.Show("A celula precisa de um lider. Preencha o campo lider");
                    lider = null;
                }
                    
            }
        }

        

        public Celula()
        {
            bd = new BDcomum();
        }
      

        public override string alterar()
        {
            update_padrao = "update celula set cel_lider='@lider', cel_horario='@horario'," +
            " cel_lider_treinamento='@lider_treinamento', cel_dia_semana='@dia_semana' where id_celula='@id' " +
            "update endereco_celula set cel_bairro='@bairro', cel_rua='@rua', cel_numero='@numero' " +
            " from endereco_celula inner join celula on id_celula=end_celula where id_celula='@id'";
            Update = update_padrao.Replace("@id", id.ToString());
            Update = Update.Replace("@lider", lider);
            Update = Update.Replace("@lider_treinamento", lider_treinamento);
            Update = Update.Replace("@dia_semana", dia_semana);
            Update = Update.Replace("@horario", horario.ToString("HH:mm:ss"));
            Update = Update.Replace("@bairro", this.Cel_bairro);
            Update = Update.Replace("@rua", this.Cel_rua);
            Update = Update.Replace("@numero", this.Cel_numero.ToString());
            return bd.montar_sql(Update, null, null);

        }

        public override string excluir()
        {
            return base.excluir();
        }

        public override string recuperar()
        {
            bd = new BDcomum();
           select_padrao = "select * from celula inner join endereco_celula on id_celula=end_celula" +
                " where id_celula='@id' order by id_celula asc";
            Select = select_padrao.Replace("@id", id.ToString());
            
            return bd.buscar_dados(Select, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null);
        }

        public override string salvar()
        {
            
            insert_padrao = "insert into celula(cel_nome, cel_lider, cel_lider_treinamento, cel_dia_semana, cel_horario)" +
                "values ('@nome', '@lider', '@lider_treinamento', '@dia_semana', '@horario') " +
                "insert into endereco_celula (cel_bairro, cel_rua, cel_numero, end_celula) values ('@bairro', '@rua', '@numero', IDENT_CURRENT('celula'))";

            Insert = insert_padrao.Replace("@nome", cel_nome);
            Insert = Insert.Replace("@lider", lider);
            Insert = Insert.Replace("@lider_treinamento", lider_treinamento);
            Insert = Insert.Replace("@dia_semana", dia_semana);

            Insert = Insert.Replace("@horario", horario.ToString("HH:mm:ss"));

            Insert = Insert.Replace("@bairro", this.Cel_bairro);
            Insert = Insert.Replace("@rua", this.Cel_rua);
            Insert = Insert.Replace("@numero", this.Cel_numero.ToString());

            return bd.montar_sql(Insert, null, null);          
        }


        public int visitar()
        {
            return id;
        }
    }
}
