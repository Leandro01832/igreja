using AplicativoXamarin.models;
using AplicativoXamarin.models.Pessoas;
using AplicativoXamarin.models.PessoasLgpd;
using AplicativoXamarin.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AplicativoXamarin.ViewModels
{
   public class ViewModelEdicao : BaseViewModel
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public bool Visitante { get; set; }
        public bool Crianca { get; set; }
        public bool MembroAclamacao { get; set; }
        public bool MembroReconciliacao { get; set; }
        public bool MembroTransferencia { get; set; }
        public bool MembroBatismo { get; set; }

        public ICommand TakePicture { get; set; }
        public ICommand NextData { get; set; }
        public ICommand UpdateDataVisitante { get; set; }
        public ICommand UpdateDataCrianca { get; set; }
        public ICommand UpdateDataMembroBatismo { get; set; }
        public ICommand UpdateDataMembroReconciliacao { get; set; }
        public ICommand UpdateDataMembroTransferencia { get; set; }
        public ICommand UpdateDataMembroAclamacao { get; set; }
        public ICommand UpdateDataVisitanteLgpd { get; set; }
        public ICommand UpdateDataCriancaLgpd { get; set; }
        public ICommand UpdateDataMembroBatismoLgpd { get; set; }
        public ICommand UpdateDataMembroReconciliacaoLgpd { get; set; }
        public ICommand UpdateDataMembroTransferenciaLgpd { get; set; }
        public ICommand UpdateDataMembroAclamacaoLgpd { get; set; }

        public MediaFile file { get; set; }

        public Visitante visitante { get; set; }
        public Crianca crianca { get; set; }
        public Membro_Aclamacao membro_Aclamacao { get; set; }
        public Membro_Batismo membro_Batismo { get; set; }
        public Membro_Reconciliacao membro_Reconciliacao { get; set; }
        public Membro_Transferencia membro_Transferencia { get; set; }
        public VisitanteLgpd visitanteLgpd { get; set; }
        public CriancaLgpd criancaLgpd { get; set; }
        public Membro_AclamacaoLgpd membro_AclamacaoLgpd { get; set; }
        public Membro_BatismoLgpd membro_BatismoLgpd { get; set; }
        public Membro_ReconciliacaoLgpd membro_ReconciliacaoLgpd { get; set; }
        public Membro_TransferenciaLgpd membro_TransferenciaLgpd { get; set; }

        private bool aguarde;
        public bool Aguarde
        {
            get { return aguarde; }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }

        public ViewModelEdicao()
        {

            visitante = new Visitante();
            crianca = new Crianca();
            membro_Aclamacao = new Membro_Aclamacao();
            membro_Batismo = new Membro_Batismo();
            membro_Reconciliacao = new Membro_Reconciliacao();
            membro_Transferencia = new Membro_Transferencia();

            visitanteLgpd = new VisitanteLgpd();
            criancaLgpd = new CriancaLgpd();
            membro_AclamacaoLgpd = new Membro_AclamacaoLgpd();
            membro_BatismoLgpd = new Membro_BatismoLgpd();
            membro_ReconciliacaoLgpd = new Membro_ReconciliacaoLgpd();
            membro_TransferenciaLgpd = new Membro_TransferenciaLgpd();

            NextData = new Command(async () =>
            {

                modelocrud m = null;

                Pessoa p = await ApiServices.GetPessoa();

                if (p is PessoaLgpd)
                {
                    if (Visitante) m = visitante;
                    if (Crianca) m = crianca;
                    if (MembroAclamacao) m = membro_Aclamacao;
                    if (MembroBatismo) m = membro_Batismo;
                    if (MembroReconciliacao) m = membro_Reconciliacao;
                    if (MembroTransferencia) m = membro_Transferencia;
                }
                else if (p is PessoaDado)
                {
                    if (Visitante) m = visitanteLgpd;
                    if (Crianca) m = criancaLgpd;
                    if (MembroAclamacao) m = membro_AclamacaoLgpd;
                    if (MembroBatismo) m = membro_BatismoLgpd;
                    if (MembroReconciliacao) m = membro_ReconciliacaoLgpd;
                    if (MembroTransferencia) m = membro_TransferenciaLgpd;
                }


                MessagingCenter.Send<modelocrud>(m, "Next");

            });

            TakePicture = new Command(async () =>
            {
                Aguarde = true;
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    MessagingCenter.Send<ViewModelEdicao>(this, "SemCamera");
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

            UpdateDataVisitante = new Command(() =>
            {
                UpdateData(visitante);
            });

            UpdateDataCrianca = new Command(() =>
            {
                UpdateData(crianca);
            });

            UpdateDataMembroAclamacao = new Command(() =>
            {
                UpdateData(membro_Aclamacao);
            });

            UpdateDataMembroBatismo = new Command(() =>
            {
                UpdateData(membro_Batismo);
            });

            UpdateDataMembroReconciliacao = new Command(() =>
            {
                UpdateData(membro_Reconciliacao);
            });

            UpdateDataMembroTransferencia = new Command(() =>
            {
                UpdateData(membro_Transferencia);
            });

            UpdateDataCriancaLgpd = new Command(() =>
            {
                UpdateData(membro_TransferenciaLgpd);
            });

            UpdateDataVisitanteLgpd = new Command(() =>
            {
                UpdateData(visitanteLgpd);
            });

            UpdateDataMembroAclamacaoLgpd = new Command(() =>
            {
                UpdateData(membro_AclamacaoLgpd);
            });

            UpdateDataMembroBatismoLgpd = new Command(() =>
            {
                UpdateData(membro_BatismoLgpd);
            });

            UpdateDataMembroTransferenciaLgpd = new Command(() =>
            {
                UpdateData(membro_TransferenciaLgpd);
            });

            UpdateDataMembroReconciliacaoLgpd = new Command(() =>
            {
                UpdateData(membro_ReconciliacaoLgpd);
            });

        }

        private void UpdateData(Pessoa modelo)
        {
            Aguarde = true;
            modelo.MudarEstado(App.UserCurrent.IdPessoa, modelo);
            Aguarde = false;
        }

        private ImageSource imageSource;
        public ImageSource ImageSource
        {
            set
            {
                if (imageSource != value)
                {
                    imageSource = value;
                    OnPropertyChanged();
                }
            }
            get
            {
                return imageSource;
            }
        }
    }
}
