using Logistics.AlfaPeople.SharedProject.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.AlfaPeople.SharedProject.Controllers
{
	public class ContatoController
	{
		public IOrganizationService ServiceClient { get; set; }
		public Contato Contato { get; set; }

		public ContatoController(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
			this.Contato = new Contato(this.ServiceClient);
		}

		public Entity GetContatoByCPF(string CPF, string[] columns)
		{
			return this.Contato.GetContatoByCPF(CPF, columns);
		}
	}
}
