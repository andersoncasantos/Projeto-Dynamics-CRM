using Logistics.AlfaPeople.SharedProject.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.AlfaPeople.SharedProject.Controllers
{
	public class ContaController
	{
		public IOrganizationService ServiceClient { get; set; }
		public Conta Conta { get; set; }

		public ContaController(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
			this.Conta = new Conta(this.ServiceClient);
		}

		public Entity GetContaByCNPJ(string CNPJ, string[] columns)
		{
			return this.Conta.GetContaByCNPJ(CNPJ, columns);
		}
	}
}
