using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AplicativoXamarin.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }        
        public string Password { get; set; }              
        public bool Visitante { get; set; }
        public bool Crianca { get; set; }
        public bool MembroAclamacao { get; set; }
        public bool MembroReconciliacao { get; set; }
        public bool MembroTransferencia { get; set; }
        public bool MembroBatismo { get; set; }

        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            this.Visitante = false;
            this.Crianca = false;
            this.MembroAclamacao = false;
            this.MembroBatismo = false;
            this.MembroReconciliacao = false;
            this.MembroTransferencia = false;
            

            this.RegisterCommand = new Command(() =>
            {
                MessagingCenter.Send<RegisterViewModel>(this, "Cadastrar");
            });

        }
    }
}
