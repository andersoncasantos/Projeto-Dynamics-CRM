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
	public class ContatoManager : PluginCore
	{
		public Entity Contato { get; set; }

		public override void ExecutePlugin(IServiceProvider serviceProvider)
		{
			this.Contato = (Entity)this.Context.InputParameters["Target"];

			string cpf = this.Contato["grp_cpf"].ToString();
			this.TracingService.Trace("Cpf recuperado");

			ContatoController contatoControl = new ContatoController(this.Service);
			var getContatoByCPF = contatoControl.GetContatoByCPF(cpf, new string[] { "fullname" });

			if (getContatoByCPF != null)
			{
				throw new InvalidPluginExecutionException("Esse CPF já foi cadastrado");
			}
		}
	}
}
