using AplicativoXamarin.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AplicativoXamarin.ViewModels
{
  public  class DetalheMinisterioViewModel : BaseViewModel
    {
        public DetalheMinisterioViewModel(Ministerio ministerio)
        {
            this.Ministerio = ministerio;
            ParticiparCommand = new Command(() =>
            {
                MessagingCenter.Send(ministerio, "Participar");
            });

            CelulasCommand = new Command(() =>
            {
                MessagingCenter.Send(ministerio, "Celulas");
            });

            PessoasCommand = new Command(() =>
            {
                MessagingCenter.Send(ministerio, "Pessoas");
            });

        }

        public ICommand ParticiparCommand { get; set; }
        public ICommand CelulasCommand { get; set; }
        public ICommand PessoasCommand { get; set; }

        public Ministerio Ministerio { get; set; }
    }
}
