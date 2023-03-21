using Logistics.AlfaPeople.PluginsDyn1.LogisticsISV;
using Logistiscs.AlfaPeople.Models.VO;
using Microsoft.Xrm.Sdk.Workflow;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AlfaPeople.Plugins.Actions
{
	public class GetEndereoViaCEP : ActionCore
	{
        [Input("CEP")]
		public InArgument<string> CEP { get; set; }

		[Output("Logradouro")]
		public OutArgument<string> Logradouro { get; set; }

		[Output("Complemento")]
		public OutArgument<string> Complemento { get; set; }

		[Output("Bairro")]
		public OutArgument<string> Bairro { get; set; }

		[Output("Localidade")]
		public OutArgument<string> Localidade { get; set; }

		[Output("UF")]
		public OutArgument<string> UF { get; set; }

		[Output("IBGE")]
		public OutArgument<string> IBGE { get; set; }

		[Output("DDD")]
		public OutArgument<string> DDD { get; set; }

		public override void ExecuteAction()
		{
			this.TracingService.Trace("Entrou na executeAction");

			RestResponse response = GetEnderecoOnAPI();
			this.TracingService.Trace(response.Content);

			ContaVO contaVO = JsonConvert.DeserializeObject<ContaVO>(response.Content) ?? throw new Exception("Endereço não encontrado");
			this.TracingService.Trace(contaVO.Logradouro);

			Logradouro.Set(this.Context, contaVO.Logradouro);
			Complemento.Set(this.Context, contaVO.Complemento);
			Bairro.Set(this.Context, contaVO.Bairro);
			Localidade.Set(this.Context, contaVO.Localidade);
			UF.Set(this.Context, contaVO.Uf);
			IBGE.Set(this.Context, contaVO.Ibge);
			DDD.Set(this.Context, contaVO.Ddd);
			this.TracingService.Trace("Variaveis setadas");
		}

		private RestResponse GetEnderecoOnAPI()
		{
			var options = new RestClientOptions($"https://viacep.com.br")
			{
				MaxTimeout = -1,
			};
			var client = new RestClient(options);

			var request = new RestRequest($"/ws/{CEP.Get(this.Context)}/json/", Method.Get);
			RestResponse response = client.Execute(request);
			return response;
		}
	}
}
