using database;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Pessoa;

namespace WindowsFormsApp1.ListViews
{
    public class TodosListViews : ListView
    {
        public int numero;
        public modelocrud Modelo { get; set; }

        public  TodosListViews(modelocrud modelo)
        {
            this.View = View.List;
            this.Size = new System.Drawing.Size(500, 300);
            this.ItemSelectionChanged += TodosListViews_ItemSelectionChanged;
            this.Location = new System.Drawing.Point(50, 50);
            this.Font = new System.Drawing.Font("Arial", 15);


            Modelo = modelo;
        }

        private void TodosListViews_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                this.Text = this.SelectedItems[0].Text;
                numero = int.Parse(Regex.Match(this.Text, @"\d+").Value);
            }
            catch (Exception)
            {                
            }
        }

        

        
    }
}
