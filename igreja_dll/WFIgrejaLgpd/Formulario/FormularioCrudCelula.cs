﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFIgrejaLgpd.Formulario;

namespace WFIgrejaLgpd
{
   public class FormularioCrudCelula : WFCrud
    {
        public FormularioCrudCelula()
        {

        }

        public FormularioCrudCelula(business.classes.Abstrato.Celula p, bool Deletar, bool Atualizar, bool Detalhes)
           : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormularioCrudCelula
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "FormularioCrudCelula";
            this.Load += new System.EventHandler(this.FormularioCrudCelula_Load);
            this.ResumeLayout(false);

        }

        private void FormularioCrudCelula_Load(object sender, EventArgs e)
        {

        }
    }
}