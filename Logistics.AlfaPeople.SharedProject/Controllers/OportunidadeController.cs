using Logistiscs.AlfaPeople.Models.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistiscs.AlfaPeople.Models.Controllers
{
	public class OportunidadeController
	{
		public IOrganizationService ServiceClient { get; set; }
		public Oportunidade Oportunidade { get; set; }

		public OportunidadeController(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
			this.Oportunidade = new Oportunidade(this.ServiceClient);
		}

		public Guid Create(Entity oportunidade)
		{
			return this.Oportunidade.Create(oportunidade);
		}
	}
}
