using database;

namespace business.classes
{
    public class DadoExcluido : modelocrud
    {
        public int IdDado { get; set; }
        public string Entidade { get; set; }
    }
}
