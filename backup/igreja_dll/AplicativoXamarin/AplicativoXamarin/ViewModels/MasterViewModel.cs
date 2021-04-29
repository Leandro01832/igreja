using AplicativoXamarin.models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AplicativoXamarin.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        private Pessoa usuario;

        private bool editando = false;

        public bool Editando
        {
            get { return editando; }
            private set
            {
                editando = value;
                OnPropertyChanged(nameof(Editando));
            }
        }

        public MasterViewModel(Pessoa usuario)
        {
            this.usuario = usuario;

            EditarPerfilCommand = new Command(() => {

                MessagingCenter.Send<Pessoa>(usuario, "EditarPerfil");

            });

            EditarCommand = new Command(() => {

                this.Editando = true;

            });

            SalvarCommand = new Command(() => {

                MessagingCenter.Send<Pessoa>(usuario, "SalvarPerfil");
                this.Editando = false;
            });
        }

        public ICommand EditarCommand { get; set; }
        public ICommand EditarPerfilCommand { get; set; }
        public ICommand SalvarCommand { get; set; }
    }
}
