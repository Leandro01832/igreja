using database;

namespace business.classes
{
    public class DadoAlterado : modelocrud
    {
        public int IdDado { get; set; }
        public string Entidade { get; set; }
    }
}
