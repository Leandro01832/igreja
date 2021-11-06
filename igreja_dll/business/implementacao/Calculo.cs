using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Intermediario;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System.Linq;

namespace business.implementacao
{
   public class Calculo 
    {
        public void CalcularPorcentagem()
        {
            try
            {
                var pessoas = Pessoa.TotalRegistro();
                var PessoasEmMinisterios = PessoaMinisterio.TotalRegistro();
                var PessoasEmReunioes = ReuniaoPessoa.TotalRegistro();
                var MinisteriosEmCelulas = MinisterioCelula.TotalRegistro();
                var Historicos = Historico.TotalRegistro();
                var celulas = Celula.TotalRegistro();
                var ministerios = Ministerio.TotalRegistro();
                var reunioes = Reuniao.TotalRegistro();
                var mudancas = MudancaEstado.TotalRegistro();
                var totalRegistros = pessoas + celulas + ministerios + reunioes + mudancas
                    + PessoasEmMinisterios + PessoasEmReunioes + Historicos + MinisteriosEmCelulas;

                var quantVisitante = 0; var quamtCelula_Jovem = 0; var quantLider_Celula = 0;
                var quantCrianca = 0; var quamtCelula_Adolescente = 0; var quantLider_Celula_Treinamento = 0;
                var quantMembro_Batismo = 0; var quamtCelula_Casado = 0; var quantLider_Ministerio = 0;
                var quantMembro_Aclamacao = 0; var quamtCelula_Crianca = 0; var quantLider_Ministerio_Treinamento = 0;
                var quantMembro_Reconciliacao = 0; var quamtCelula_Adulto = 0; var quantSupervisor_Celula = 0;
                var quantMembro_Transferencia = 0; var quantSupervisor_Celula_Treinamento = 0;
                var quantVisitanteLgpd = 0; var quantSupervisor_Ministerio = 0;
                var quantCriancaLgpd = 0; var quantSupervisor_Ministerio_Treinamento = 0;
                var quantMembro_TransferenciaLgpd = 0;
                var quantMembro_BatismoLgpd = 0;
                var quantMembro_AclamacaoLgpd = 0;
                var quantMembro_ReconciliacaoLgpd = 0;

                var quantMudancas = 0;
                var quantReunioes = 0;
                var quantPessoasEmMinisterios = 0;
                var quantPessoasEmReunioes = 0;
                var quantMinisteriosEmCelulas = 0;
                var quantHistoricos = 0;
                
                 quantVisitante                += modelocrud.Modelos.OfType<Visitante               >().ToList().Count;
                 quantCrianca                  += modelocrud.Modelos.OfType<Crianca                 >().ToList().Count;
                 quantMembro_Aclamacao         += modelocrud.Modelos.OfType<Membro_Aclamacao        >().ToList().Count;
                 quantMembro_Batismo           += modelocrud.Modelos.OfType<Membro_Batismo          >().ToList().Count;
                 quantMembro_Reconciliacao     += modelocrud.Modelos.OfType<Membro_Reconciliacao    >().ToList().Count;
                 quantMembro_Transferencia     += modelocrud.Modelos.OfType<Membro_Transferencia    >().ToList().Count;
                 quantVisitanteLgpd            += modelocrud.Modelos.OfType<VisitanteLgpd           >().ToList().Count;
                 quantCriancaLgpd              += modelocrud.Modelos.OfType<CriancaLgpd             >().ToList().Count;
                 quantMembro_AclamacaoLgpd     += modelocrud.Modelos.OfType<Membro_AclamacaoLgpd    >().ToList().Count;
                 quantMembro_BatismoLgpd       += modelocrud.Modelos.OfType<Membro_BatismoLgpd      >().ToList().Count;
                 quantMembro_ReconciliacaoLgpd += modelocrud.Modelos.OfType<Membro_ReconciliacaoLgpd>().ToList().Count;
                 quantMembro_TransferenciaLgpd += modelocrud.Modelos.OfType<Membro_TransferenciaLgpd>().ToList().Count;

                 quamtCelula_Adolescente += modelocrud.Modelos.OfType<Celula_Adolescente    >().ToList().Count;
                 quamtCelula_Adulto      += modelocrud.Modelos.OfType<Celula_Adulto         >().ToList().Count;
                 quamtCelula_Casado      += modelocrud.Modelos.OfType<Celula_Casado         >().ToList().Count;
                 quamtCelula_Jovem       += modelocrud.Modelos.OfType<Celula_Jovem          >().ToList().Count;
                 quamtCelula_Crianca += modelocrud.Modelos.OfType<Celula_Crianca>().ToList().Count;

                 quantLider_Celula                      += modelocrud.Modelos.OfType<Visitante               >().ToList().Count;
                 quantLider_Celula_Treinamento          += modelocrud.Modelos.OfType<Crianca                 >().ToList().Count;
                 quantLider_Ministerio                  += modelocrud.Modelos.OfType<Membro_Aclamacao        >().ToList().Count;
                 quantLider_Ministerio_Treinamento      += modelocrud.Modelos.OfType<Membro_Batismo          >().ToList().Count;
                 quantSupervisor_Celula                 += modelocrud.Modelos.OfType<Membro_Reconciliacao    >().ToList().Count;
                 quantSupervisor_Celula_Treinamento     += modelocrud.Modelos.OfType<Membro_Transferencia    >().ToList().Count;
                 quantSupervisor_Ministerio             += modelocrud.Modelos.OfType<VisitanteLgpd           >().ToList().Count;
                 quantSupervisor_Ministerio_Treinamento += modelocrud.Modelos.OfType<CriancaLgpd             >().ToList().Count;

                quantReunioes             += modelocrud.Modelos.OfType<Reuniao>().ToList().Count;
                quantMudancas             += modelocrud.Modelos.OfType<MudancaEstado>().ToList().Count;
                quantPessoasEmMinisterios += modelocrud.Modelos.OfType<PessoaMinisterio>().ToList().Count;
                quantPessoasEmReunioes    += modelocrud.Modelos.OfType<ReuniaoPessoa>().ToList().Count;
                quantMinisteriosEmCelulas += modelocrud.Modelos.OfType<MinisterioCelula>().ToList().Count;
                quantHistoricos           += modelocrud.Modelos.OfType<MinisterioCelula>().ToList().Count;

                var quantidadeCarregada = quantMudancas + quantReunioes +
                quantVisitante + quantLider_Celula + quamtCelula_Jovem +
                quantCrianca + quantLider_Celula_Treinamento + quamtCelula_Adolescente +
                quantMembro_Batismo + quantLider_Ministerio + quamtCelula_Casado +
                quantMembro_Aclamacao + quantLider_Ministerio_Treinamento + quamtCelula_Crianca +
                quantMembro_Reconciliacao + quantSupervisor_Celula + quamtCelula_Adulto +
                quantMembro_Transferencia + quantSupervisor_Celula_Treinamento +
                quantVisitanteLgpd + quantSupervisor_Ministerio +
                quantCriancaLgpd + quantSupervisor_Ministerio_Treinamento +
                quantMembro_TransferenciaLgpd + quantPessoasEmMinisterios +
                quantMembro_BatismoLgpd + quantPessoasEmReunioes +
                quantMembro_AclamacaoLgpd + quantMinisteriosEmCelulas +
                quantMembro_ReconciliacaoLgpd + quantHistoricos;

                var porcentagem = (int)((100 * quantidadeCarregada) / totalRegistros);
                modelocrud.textoPorcentagem = porcentagem.ToString() + "%";
            }
            catch { }
        }

    }
}
