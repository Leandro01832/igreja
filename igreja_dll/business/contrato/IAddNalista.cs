using database;

namespace business.contrato
{
    interface IAddNalista
    {
        void AdicionarNaLista(string NomeTabela, modelocrud modeloQRecebe, modelocrud modeloQPreenche, string numeros);
        void RemoverDaLista(string NomeTabela, modelocrud modeloQRecebe, modelocrud modeloQPreenche, string numeros);
    }
}
