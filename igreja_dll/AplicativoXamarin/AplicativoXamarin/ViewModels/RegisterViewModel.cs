
using AplicativoXamarin.models.Interface;
using GalaSoft.MvvmLight.Command;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AplicativoXamarin.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
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
        public ICommand TirarFotoCommand { get; set; }

        public MediaFile file { get; set; }

        private bool aguarde;
        public bool Aguarde
        {
            get { return aguarde; }
            set
            {
                aguarde = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Aguarde"));
            }
        }

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
                Aguarde = true;
                MessagingCenter.Send<RegisterViewModel>(this, "Cadastrar");
                Aguarde = false;
            });

            TirarFotoCommand = new Command(async () =>
            {
                Aguarde = true;
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    MessagingCenter.Send<RegisterViewModel>(this, "SemCamera");
                    return;
                }

                 file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Photos",
                    Name = "Pessoa.jpg"
                });

                if (file != null)
                {
                    ImageSource = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        
                        return stream;
                    });
                }
                Aguarde = false;
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ImageSource imageSource;
        public ImageSource ImageSource
        {
            set
            {
                if (imageSource != value)
                {
                    imageSource = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageSource"));
                }
            }
            get
            {
                return imageSource;
            }
        }

    }
}
