using Logistiscs.AlfaPeople.Models.BaseModels;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.AlfaPeople.SharedProject.Models
{
	public class Conta : ModelCore
	{
		public Conta(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
			this.LogicalName = "account";
		}

		public Entity GetContaByCNPJ(string CNPJ, string[] columns)
		{
			QueryExpression queryConta = new QueryExpression(this.LogicalName);
			queryConta.ColumnSet.AddColumns(columns);
			queryConta.Criteria.AddCondition("grp_cnpj", ConditionOperator.Equal, CNPJ);

			return RetrieveFirstRow(queryConta);
		}
	}
}
