using business.classes.Celulas;
using business.classes.Intermediario;
using business.classes.Ministerio;
using database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
namespace business.classes.Abstrato
{
    [Table("Celula")]
    public abstract class Celula : modelocrud
    {
        #region properties        
        private string nome = "nome";
        [Display(Name = "Nome da celula")]
        [OpcoesBase(Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome
        {
            get
            {
                if ( string.IsNullOrWhiteSpace(nome))
                    throw new Exception("Nome");
                return nome;
            }
            set
            {
                nome = value;
                if (string.IsNullOrWhiteSpace(nome))
                    throw new Exception("Nome");
            }
        }

        private string dia_semana = "dia";
        [Display(Name = "Dia da semana")]
        [OpcoesBase(Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Dia_semana
        {
            get
            {
                if ( string.IsNullOrWhiteSpace(dia_semana))
                    throw new Exception("Dia_semana");
                return dia_semana;
            }
            set
            {
                dia_semana = value;
                if (string.IsNullOrWhiteSpace(dia_semana))
                    throw new Exception("Dia_semana");
            }
        }

        private TimeSpan horario = new TimeSpan(0, 0, 0);
        [Display(Name = "Horário")]
        [OpcoesBase(Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan Horario
        {
            get
            {
                if ( horario == null)
                    throw new Exception("Horario");
                return horario;
            }
            set { horario = value; }
        }

        
        [JsonIgnore]
        public virtual List<Pessoa> Pessoas { get; set; }

        [Display(Name = "Máximo de pessoas")]
        public int Maximo_pessoa { get; set; }

        private List<MinisterioCelula> ministerios =   new List<MinisterioCelula>
        {
            new MinisterioCelula{ Ministerio = new Lider_Celula() },
            new MinisterioCelula{ Ministerio = new Lider_Celula_Treinamento() }
        };

        
        [JsonIgnore]
        public virtual List<MinisterioCelula> Ministerios
        {
            get
            {
                var m = this;
                if ( ministerios.Count <= 1 )
                {
                    ErroCadastro = "Celula precisa de pelo menos um líder de celula e um líder de celula em treinamento." +
                    " Verifique a lista de ministérios";
                    throw new Exception("Ministerios");
                }
                else
                {
                    bool condicao1 = false;
                    bool condicao2 = false;
                    foreach (var item in ministerios)
                    {
                        if (item.Ministerio is Lider_Celula) condicao1 = true;
                        if (item.Ministerio is Lider_Celula_Treinamento) condicao2 = true;
                        if (condicao1 && condicao2)
                        {
                            ErroCadastro = "";
                            break;
                        }
                    }
                    if (!condicao1 || !condicao2)
                    {
                        ErroCadastro = "Celula precisa de pelo menos um líder de celula e um líder de celula em treinamento." +
                        " Verifique a lista de ministérios";
                        throw new Exception("Ministerios");
                    }
                }

                return ministerios;
            }
            set
            { ministerios = value; }
        }
        [JsonIgnore]
        public virtual EnderecoCelula EnderecoCelula { get; set; }

        public static int UltimoRegistro;
        #endregion

        public Celula() : base()
        {
            if (!EntityCrud)
            {
                this.Maximo_pessoa = 50;
                EnderecoCelula = new EnderecoCelula();
                Pessoas = new List<Pessoa>();
            }

        }        
        
        public override string ToString()
        {
            return base.Id.ToString() + " - " + this.Nome;
        }
    }
}
