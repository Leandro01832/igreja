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
        public modelocrud Modelo { get; set; }
        public string Tipo { get; set; }

        public  TodosListViews(modelocrud modelo, string tipo)
        {
            this.Tipo = tipo;
           // this.View = View.Tile;
            this.Size = new System.Drawing.Size(600, 300);
           // this.ItemSelectionChanged += TodosListViews_ItemSelectionChanged;
            this.SelectedValueChanged += TodosListViews_SelectedValueChanged;
            this.Location = new System.Drawing.Point(50, 50);
            this.Font = new System.Drawing.Font("Arial", 15);
            Modelo = modelo;
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
