using database;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Pessoa;

namespace WindowsFormsApp1.ListViews
{
    public class TodosListViews : ListBox
    {
        public int numero;
        public Type Tipo { get; set; }

        public  TodosListViews(Type tipo)
        {
            this.Tipo = tipo;
           // this.View = View.Tile;
            this.Size = new System.Drawing.Size(600, 300);
           // this.ItemSelectionChanged += TodosListViews_ItemSelectionChanged;
            this.SelectedValueChanged += TodosListViews_SelectedValueChanged;
            this.Location = new System.Drawing.Point(50, 50);
            this.Font = new System.Drawing.Font("Arial", 15);
        }

        private void TodosListViews_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Text = this.SelectedValue.ToString();
                numero = int.Parse(Regex.Match(this.Text, @"\d+").Value);
            }
            catch (Exception)
            {
            }
        }

        private void TodosListViews_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            
        }

        

        
    }
}
