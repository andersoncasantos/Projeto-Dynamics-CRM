using Logistics.AlfaPeople.Models;
using Logistics.AlfaPeople.PluginsDyn1.LogisticsISV;
using Logistiscs.AlfaPeople.Models.Controllers;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AlfaPeople.Plugins.Plugins
{
	public class OportunidadeManager : PluginCore
	{
		public Entity Oportunidade { get; set; }
		public CrmServiceClient ServiceClient { get; set; }

		public override void ExecutePlugin(IServiceProvider serviceProvider)
		{
			this.Oportunidade = (Entity)this.Context.InputParameters["Target"];
			this.Oportunidade.Attributes.Add("grp_idprincipal", FormatIdPrincipal());

			this.ServiceClient = Singleton.GetService();
			this.TracingService.Trace("Serviço recuperado com sucesso");

			OportunidadeController oportunidadeControl = new OportunidadeController(this.ServiceClient);
			oportunidadeControl.Create(SetNewOportunidadeAttributes());
			this.TracingService.Trace("Oportunidade nova criada");
		}

		private Entity SetNewOportunidadeAttributes()
		{
			Entity oportunidadeToCreate = new Entity("opportunity");

			string[] oportunidadeAtributos = new string[]
			{
				"name",
				"purchasetimeframe",
				"description",
				"budgetamount_base",
				"purchaseprocess",
				"currentsituation",
				"customerneed",
				"proposedsolution"
			};
			foreach (string att in oportunidadeAtributos)
			{
				if (this.Oportunidade.Attributes.TryGetValue(att, out object value))
				{
					oportunidadeToCreate[att] = value;
				}
			}

			oportunidadeToCreate["dyn2_idprincipal"] = this.Oportunidade["grp_idprincipal"];


			return oportunidadeToCreate;
		}

		public string FormatIdPrincipal()
		{
			string numIdentificador = this.Oportunidade["grp_nmr_identificador"].ToString();
			return "OPP-" + numIdentificador + "-A1A2";
		}
	}
}
