using Logistiscs.AlfaPeople.Models.BaseModels;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Text;
using System.Threading.Tasks;

namespace Logistiscs.AlfaPeople.Models.Models
{
	public class Produto : ModelCore
	{
		public Produto(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
			this.LogicalName = "product";
		}

		public Guid Create(Entity product)
		{
			Guid productId = ServiceClient.Create(product);
			return productId;
		}
	}
}
