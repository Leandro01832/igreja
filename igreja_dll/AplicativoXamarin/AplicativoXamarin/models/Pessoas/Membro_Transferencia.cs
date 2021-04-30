namespace AplicativoXamarin.models.Pessoas
{
    public class Membro_Transferencia : Membro
    {    
        public string Nome_cidade_transferencia { get; set; }
        public string Estado_transferencia { get; set; }
        public string Nome_igreja_transferencia { get; set; }

        public Membro_Transferencia() : base()
        {
        }
        
    }
}
