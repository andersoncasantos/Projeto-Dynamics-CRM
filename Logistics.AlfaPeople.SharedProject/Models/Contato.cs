using Logistiscs.AlfaPeople.Models.BaseModels;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.AlfaPeople.SharedProject.Models
{
	public class Contato : ModelCore
	{
		public Contato(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
			this.LogicalName = "contact";
		}

		public Entity GetContatoByCPF(string CPF, string[] columns)
		{
			QueryExpression queryContato = new QueryExpression(this.LogicalName);
			queryContato.ColumnSet.AddColumns(columns);
			queryContato.Criteria.AddCondition("grp_cpf", ConditionOperator.Equal, CPF);

			return RetrieveFirstRow(queryContato);
		}
	}
}
