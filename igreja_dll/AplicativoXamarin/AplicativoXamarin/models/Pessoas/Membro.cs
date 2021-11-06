

namespace AplicativoXamarin.models.Pessoas
{
    public  class Membro : PessoaDado
    {        
        
        private int data_batismo;
        private bool desligamento;
        
        public int Data_batismo
        {
            get
            {
                return data_batismo;
            }

            set
            {
                data_batismo = value;
            }
        }

        public bool Desligamento
        {
            get
            {
                return desligamento;
            }

            set
            {
                desligamento = value;
            }
        }

        public bool Save()
        {
            return true;
        }

        public string Motivo_desligamento { get; set; }

        public Membro() : base()
        {
        }
        
    }
}
