using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFIgrejaLgpd.ListViews;

namespace WFIgrejaLgpd.Formulario.Pessoa
{
    public partial class Membro : FormularioListView
    {

        public Membro() : base(new ListViewMembro(null, "MembroLgpd"))
        {
            InitializeComponent();
        }

        private void Membro_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de membros";
          //  var lista = await Task.Run(() => business.classes.Abstrato.MembroLgpd.recuperarTodosMembros());
            
        }
    }
}
