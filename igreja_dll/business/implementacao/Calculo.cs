using business.classes;
using business.classes.Abstrato;
using business.classes.Intermediario;
using database;

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

                if (Pessoa.visitantes != null) quantVisitante += Pessoa.visitantes.Count;
                if (Pessoa.criancas != null) quantCrianca += Pessoa.criancas.Count;
                if (Pessoa.membros_Aclamacao != null) quantMembro_Aclamacao += Pessoa.membros_Aclamacao.Count;
                if (Pessoa.membros_Batismo != null) quantMembro_Batismo += Pessoa.membros_Batismo.Count;
                if (Pessoa.membros_Reconciliacao != null) quantMembro_Reconciliacao += Pessoa.membros_Reconciliacao.Count;
                if (Pessoa.membros_Transferencia != null) quantMembro_Transferencia += Pessoa.membros_Transferencia.Count;
                if (Pessoa.visitantesLgpd != null) quantVisitanteLgpd += Pessoa.visitantesLgpd.Count;
                if (Pessoa.criancasLgpd != null) quantCriancaLgpd += Pessoa.criancasLgpd.Count;
                if (Pessoa.membros_AclamacaoLgpd != null) quantMembro_AclamacaoLgpd += Pessoa.membros_AclamacaoLgpd.Count;
                if (Pessoa.membros_BatismoLgpd != null) quantMembro_BatismoLgpd += Pessoa.membros_BatismoLgpd.Count;
                if (Pessoa.membros_ReconciliacaoLgpd != null) quantMembro_ReconciliacaoLgpd += Pessoa.membros_ReconciliacaoLgpd.Count;
                if (Pessoa.membros_TransferenciaLgpd != null) quantMembro_TransferenciaLgpd += Pessoa.membros_TransferenciaLgpd.Count;

                if (Celula.celulasAdolescente != null) quamtCelula_Adolescente += Celula.celulasAdolescente.Count;
                if (Celula.celulasAdulto != null) quamtCelula_Adulto += Celula.celulasAdulto.Count;
                if (Celula.celulasCasado != null) quamtCelula_Casado += Celula.celulasCasado.Count;
                if (Celula.celulasJovem != null) quamtCelula_Jovem += Celula.celulasJovem.Count;
                if (Celula.celulasCrianca != null) quamtCelula_Crianca += Celula.celulasCrianca.Count;

                if (Ministerio.lideresCelula != null) quantLider_Celula += Ministerio.lideresCelula.Count;
                if (Ministerio.LideresCelulaTreinamento != null) quantLider_Celula_Treinamento += Ministerio.LideresCelulaTreinamento.Count;
                if (Ministerio.lideresMinisterio != null) quantLider_Ministerio += Ministerio.lideresMinisterio.Count;
                if (Ministerio.lideresMinisterioTreinamento != null) quantLider_Ministerio_Treinamento += Ministerio.lideresMinisterioTreinamento.Count;
                if (Ministerio.supervisoresCelula != null) quantSupervisor_Celula += Ministerio.supervisoresCelula.Count;
                if (Ministerio.supervisoresCelulaTreinamento != null) quantSupervisor_Celula_Treinamento += Ministerio.supervisoresCelulaTreinamento.Count;
                if (Ministerio.supervisoresMinisterio != null) quantSupervisor_Ministerio += Ministerio.supervisoresMinisterio.Count;
                if (Ministerio.supervisoresMinisterioTreinamento != null) quantSupervisor_Ministerio_Treinamento += Ministerio.supervisoresMinisterioTreinamento.Count;

                if (Reuniao.Reunioes != null) quantReunioes += Reuniao.Reunioes.Count;
                if (MudancaEstado.Mudancas != null) quantMudancas += MudancaEstado.Mudancas.Count;
                if (PessoaMinisterio.PessoaMinisterios != null) quantPessoasEmMinisterios += PessoaMinisterio.PessoaMinisterios.Count;
                if (ReuniaoPessoa.ReuniaoPessoas != null) quantPessoasEmReunioes += ReuniaoPessoa.ReuniaoPessoas.Count;
                if (MinisterioCelula.MinisterioCelulas != null) quantMinisteriosEmCelulas += MinisterioCelula.MinisterioCelulas.Count;
                if (Historico.Historicos != null) quantHistoricos += Historico.Historicos.Count;

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
