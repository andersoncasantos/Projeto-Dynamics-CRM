using Logistics.AlfaPeople.PluginsDyn1.LogisticsISV;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AlfaPeople.PluginsDyn2.Plugins
{
	public class ProdutoManager : PluginCore
	{
		public override void ExecutePlugin(IServiceProvider serviceProvider)
		{
			Entity product = (Entity)this.Context.InputParameters["Target"];
			bool productIsIntegration = (bool)product["dyn2_isintegration"];

			if (!productIsIntegration)
			{
				throw new InvalidPluginExecutionException("Um produto não pode ser diretamente cadastrado pelo Dynamics 2");
			}
		}
	}
}
