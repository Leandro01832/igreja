using database;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public interface IFormCrud
    {
        void LoadFormCrud(modelocrud modelo, bool detalhes, bool deletar, bool atualizar, Form Atual);
        void Clicar(Form form, string function, modelocrud Modelo = null,
            bool detalhes = false, bool deletar = false, bool atualizar = false);
    }
}
