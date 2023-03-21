using Logistics.AlfaPeople.PluginsDyn1.LogisticsISV;
using Logistics.AlfaPeople.SharedProject.Controllers;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AlfaPeople.Plugins.Plugins
{
	public class ContaManager : PluginCore
	{
		public Entity Conta { get; set; }
		public override void ExecutePlugin(IServiceProvider serviceProvider)
		{
			this.Conta = (Entity)this.Context.InputParameters["Target"];

			string cnpj = this.Conta["grp_cnpj"].ToString();
			this.TracingService.Trace("Cnpj recuperado");

			ContaController contaControl = new ContaController(this.Service);
			var getContaByCNPJReturn = contaControl.GetContaByCNPJ(cnpj, new string[] { "name" });

			if (getContaByCNPJReturn != null)
			{
				throw new InvalidPluginExecutionException("Esse CNPJ já cadastrado.");
			}
		}
	}
}
