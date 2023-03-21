using Logistiscs.AlfaPeople.Models.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistiscs.AlfaPeople.Models.Controllers
{
	public class ProdutoController
	{
		public IOrganizationService ServiceClient { get; set; }
		public Produto Product { get; set; }

		public ProdutoController(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
			this.Product = new Produto(serviceClient);
		}

		public Guid Create(Entity product)
		{
			return Product.Create(product);
		}
	}
}
