using Cappta.Gp.Api.Com;
using Cappta.Gp.Api.Com.Model;
using System;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ComponenteTef
{
	public partial class ComponenteTef : Form
	{
		private bool processandoPagamento;

		private int tipoParcelamento;

		private const int INTERVALO_MILISEGUNDOS = 500;

		ClienteCappta clienteCappta = new ClienteCappta();

		private string SENHA_ADMINISTRATIVA = "cappta";

		private int tipoVia = TIPO_VIA_TODAS;

		private const int TIPO_VIA_TODAS = 1;

		private const int TIPO_VIA_CLIENTE = 2;

		private const int TIPO_VIA_LOJA = 3;

		public ComponenteTef()
		{
			InitializeComponent();
		}

		private void ComponenteTef_Load(object sender, EventArgs e)
		{
			AutenticarPdv();
			ConfigurarModoIntegracao(false);	
		}

		private void AutenticarPdv()
		{
			var chaveAutenticacao = ConfigurationManager.AppSettings["ChaveAutenticacao"];
			if (String.IsNullOrWhiteSpace(chaveAutenticacao)) { this.InvalidarAutenticacao("Chave de Autenticação inválida"); }

			var cnpj = ConfigurationManager.AppSettings["Cnpj"];
			if (String.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14) { this.InvalidarAutenticacao("CNPJ inválido"); }

			int pdv;
			if (Int32.TryParse(ConfigurationManager.AppSettings["Pdv"], out pdv) == false || pdv == 0)
			{
				this.InvalidarAutenticacao("PDV inválido");
			}

			int resultadoAutenticacao = this.clienteCappta.AutenticarPdv(cnpj, pdv, chaveAutenticacao);
			if (resultadoAutenticacao == 0) { return; }

			String mensagem = Mensagens.ResourceManager.GetString(String.Format("RESULTADO_CAPPTA_{0}", resultadoAutenticacao));
			this.ExibeMensagemAutenticacaoInvalida(resultadoAutenticacao);
		}

		private void ConfigurarModoIntegracao(bool exibirInterface)
		{
			IConfiguracoes configs = new Configuracoes
			{
				ExibirInterface = exibirInterface
			};

			int resultado = clienteCappta.Configurar(configs);
			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }
		}

		private void CriarMensagemErroPainel(int resultado)
		{
			String mensagem = Mensagens.ResourceManager.GetString(String.Format("RESULTADO_CAPPTA_{0}", resultado));
			if (String.IsNullOrEmpty(mensagem)) { mensagem = "Não foi possível executar a operação."; }

			this.AtualizarResultado(String.Format("{0}. Código de erro {1}", mensagem, resultado));
		}

		private void ExibeMensagemAutenticacaoInvalida(int resultadoAutenticacao)
		{
			var mensagem = Mensagens.ResourceManager.GetString(string.Format("RESULTADO_CAPPTA_{0}", resultadoAutenticacao));
			MessageBox.Show(mensagem, "SAMPLE API COM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			Environment.Exit(0);
		}

		private void InvalidarAutenticacao(string mensagemErro)
		{
			this.CriarMensagemErroJanela(String.Format("{0}. Verifique seu valor no arquivo de configuração.", mensagemErro));
			Environment.Exit(0);
		}

		private void CriarMensagemErroJanela(string vmensagemErro)
		{
			MessageBox.Show(vmensagemErro, "Erro");
		}

		private void Pagamento_SelectedIndexChanged(object sender, EventArgs e)
		{
			int indexTipoPagamento = comboBoxPagamento.SelectedIndex;

			if (indexTipoPagamento == 0) { PagamentoDebito(); }
			if (indexTipoPagamento == 1) { PagamentoCredito(); }
		}

		private void PagamentoCredito()
		{
			double valor = 100;
			IDetalhesCredito details = new DetalhesCredito();


			details.QuantidadeParcelas = Convert.ToInt32(this.comboBoxParcelas.SelectedItem);
			details.TipoParcelamento = TipoParcelamento();
			details.TransacaoParcelada = IsTransacaoParcelada();
			

			int resultado = this.clienteCappta.PagamentoCredito(valor, details);
			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

			this.processandoPagamento = true;
			this.IterarOperacaoTef();
		}

		private int TipoParcelamento()
		{			
			var item = comboBoxTipoParcelamento.SelectedIndex;
			if (item == 0) { tipoParcelamento = 1; }
			if (item == 1) { tipoParcelamento = 2; }

			return tipoParcelamento;
		}

		private Boolean IsTransacaoParcelada()
		{
			var parcelas = Convert.ToInt32(this.comboBoxParcelas.SelectedItem);
			if (parcelas >= 2)
			{

				return true;
			}
			else
			{
				return false;
			}
		}

		private void PagamentoDebito()
		{

			double valor = 100;

			int resultado = this.clienteCappta.PagamentoDebito(valor);
			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

			this.processandoPagamento = true;
			this.IterarOperacaoTef();
		}

		private void IterarOperacaoTef()
		{
			IIteracaoTef iteracaoTef = null;

			do
			{
				iteracaoTef = clienteCappta.IterarOperacaoTef();

				if (iteracaoTef is IMensagem)
				{
					this.ExibirMensagem((IMensagem)iteracaoTef);
					Thread.Sleep(INTERVALO_MILISEGUNDOS);
				}

				if (iteracaoTef is IRequisicaoParametro) { this.RequisitarParametros((IRequisicaoParametro)iteracaoTef); }
				if (iteracaoTef is IRespostaTransacaoPendente) { this.ResolverTransacaoPendente((IRespostaTransacaoPendente)iteracaoTef); }

				if (iteracaoTef is IRespostaOperacaoRecusada) { this.ExibirDadosOperacaoRecusada((IRespostaOperacaoRecusada)iteracaoTef); }
				if (iteracaoTef is IRespostaOperacaoAprovada)
				{
					this.ExibirDadosOperacaoAprovada((IRespostaOperacaoAprovada)iteracaoTef);
					this.FinalizarPagamento();
				}

			} while (this.OperacaoNaoFinalizada(iteracaoTef));
		}

		private bool OperacaoNaoFinalizada(IIteracaoTef iteracaoTef)
		{
			return iteracaoTef.TipoIteracao != 1 && iteracaoTef.TipoIteracao != 2 && iteracaoTef.TipoIteracao != 12;
		}

		private void FinalizarPagamento()
		{
			if (this.processandoPagamento == false) { return; }

			this.processandoPagamento = false;

			this.clienteCappta.ConfirmarPagamentos();

			this.Close();
		}

		public void ExibirDadosOperacaoAprovada(IRespostaOperacaoAprovada resposta)
		{
			StringBuilder mensagemAprovada = new StringBuilder();

			if (resposta.CupomCliente != null) { mensagemAprovada.Append(resposta.CupomCliente.Replace("\"", String.Empty)).AppendLine().AppendLine(); }
			if (resposta.CupomLojista != null) { mensagemAprovada.Append(resposta.CupomLojista.Replace("\"", String.Empty)).AppendLine(); }
			if (resposta.CupomReduzido != null) { mensagemAprovada.Append(resposta.CupomReduzido.Replace("\"", String.Empty)).AppendLine(); }

			this.AtualizarResultado(mensagemAprovada.ToString());
		}

		public void ExibirDadosOperacaoRecusada(IRespostaOperacaoRecusada resposta)
		{
			this.AtualizarResultado(String.Format("Código: {0}{1}{2}", resposta.CodigoMotivo, Environment.NewLine, resposta.Motivo));
		}

		private void ResolverTransacaoPendente(IRespostaTransacaoPendente transacaoPendente)
		{
			StringBuilder mensagemTransacoesPendentes = new StringBuilder();
			mensagemTransacoesPendentes.AppendLine(transacaoPendente.Mensagem);

			foreach (var transacao in transacaoPendente.ListaTransacoesPendentes)
			{
				mensagemTransacoesPendentes.AppendLine($"Número de Controle: {transacao.NumeroControle}");
				mensagemTransacoesPendentes.AppendLine($"Bandeira: {transacao.NomeBandeiraCartao}");
				mensagemTransacoesPendentes.AppendLine($"Adquirente: {transacao.NomeAdquirente}");
				mensagemTransacoesPendentes.AppendLine($"Valor: {transacao.Valor}");
				mensagemTransacoesPendentes.AppendLine($"Data: {transacao.DataHoraAutorizacao}");
			}

			string input = Microsoft.VisualBasic.Interaction.InputBox(mensagemTransacoesPendentes.ToString());
			this.clienteCappta.EnviarParametro(input, String.IsNullOrWhiteSpace(input) ? 2 : 1);
		}

		private void RequisitarParametros(IRequisicaoParametro requisicaoParametros)
		{
			string input = Microsoft.VisualBasic.Interaction.InputBox(requisicaoParametros.Mensagem + Environment.NewLine + Environment.NewLine);
			this.clienteCappta.EnviarParametro(input, String.IsNullOrWhiteSpace(input) ? 2 : 1);
		}

		private void ExibirMensagem(IMensagem mensagem)
		{
			AtualizarResultado(mensagem.Descricao);
		}

		private void AtualizarResultado(string resposta)
		{
			this.textBoxresultado.Text = resposta;
			this.textBoxresultado.Update();
		}

		private void OpcaoAdmcomboBoxAdm_SelectedIndexChanged(object sender, EventArgs e)
		{

			int indextipooperacao = comboBoxAdm.SelectedIndex;

			if (indextipooperacao == 0) { TornarVisivelReimpressao(); }
			if (indextipooperacao == 1) { Cancelamento(); }
		}

		private void Cancelamento()
		{
			string numeroControle = textBoxNumeroControle.Text;
			if (String.IsNullOrEmpty(textBoxNumeroControle.Text)) { this.CriarMensagemErroJanela("Número de controle não pode ser vazio."); textBoxNumeroControle.Focus(); return; }
			int resultado = this.clienteCappta.CancelarPagamento(SENHA_ADMINISTRATIVA, numeroControle);
			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

			this.processandoPagamento = false;

			this.IterarOperacaoTef();
		}

		private void TornarVisivelReimpressao()
		{
			labelTipoVia.Visible = true;
			comboBoxTipoVia.Visible = true;
		}

		private void EscolherViacomboBoxTipoVia_SelectedIndexChanged(object sender, EventArgs e)
		{
			int indexTipoVia = comboBoxTipoVia.SelectedIndex;
		
			if (indexTipoVia == 1) { this.TodasAsVias(); }
			if (indexTipoVia == 2) { this.ViaCliente(); }
			if (indexTipoVia == 3) { this.ViaLoja(); }

			this.Reimpressao();
		}

		private void TodasAsVias()
		{
			this.tipoVia = TIPO_VIA_TODAS;
		}

		private void ViaCliente()
		{
			this.tipoVia = TIPO_VIA_CLIENTE;
		}

		private void ViaLoja()
		{
			this.tipoVia = TIPO_VIA_LOJA;
		}

		private void Reimpressao()
		{
			var numeroControle = textBoxNumeroControle.Text;
			if (string.IsNullOrWhiteSpace(numeroControle)){ this.CriarMensagemErroJanela("Número de controle não pode ser vazio."); textBoxNumeroControle.Focus(); return; }

			var resultado = this.clienteCappta.ReimprimirCupom(textBoxNumeroControle.Text, this.tipoVia);

			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

			this.processandoPagamento = false;
			this.IterarOperacaoTef();
		}
	}
}
