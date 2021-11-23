using business.classes.Intermediario;
using database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace business.classes
{
    public class Reuniao : modelocrud
    {
        #region Properties
        private DateTime data_reuniao = new DateTime(0001, 01, 01);
        [OpcoesBase(Obrigatorio =true)]
        [Display(Name = "Data da reunião")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_reuniao
        {
            get
            {
                if (data_reuniao.ToString("dd/MM/yyyy") == new DateTime(0001, 01, 01).ToString("dd/MM/yyyy"))
                    throw new Exception("Data_reuniao");
                return data_reuniao;
            }
            set { data_reuniao = value; }
        }

        private TimeSpan horario_inicio = new TimeSpan(0, 0, 0);
        [OpcoesBase(Obrigatorio = true)]
        [Display(Name = "Horário de início")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan Horario_inicio
        {
            get
            {
                if (horario_inicio.Hours == 0 &&
                    horario_inicio.Minutes == 0 && horario_inicio.Seconds == 0)
                    throw new Exception("Horario_inicio");
                return horario_inicio;
            }
            set { horario_inicio = value; }
        }

        private TimeSpan? horario_fim = new TimeSpan(0, 0, 0);
        [Display(Name = "Horário de termino")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan? Horario_fim { get; set; }

        private string local_reuniao = "local";
        [OpcoesBase(Obrigatorio = true)]
        [Display(Name = "Local da reunião")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Local_reuniao
        {
            get
            {
                if (string.IsNullOrWhiteSpace(local_reuniao))
                    throw new Exception("Local_reuniao");
                return local_reuniao;
            }
            set
            {
                local_reuniao = value;
                if (string.IsNullOrWhiteSpace(local_reuniao))
                    throw new Exception("Local_reuniao");
            }
        }

        [JsonIgnore]
        public virtual List<ReuniaoPessoa> Pessoas { get; set; }
        
        public static int UltimoRegistro;
        
        #endregion        
        
        public Reuniao() : base(){ }

        public override string ToString()
        {
            return this.Id.ToString() + " - Data da reunião: " + this.Data_reuniao.ToString();
        }
        
    }
}
