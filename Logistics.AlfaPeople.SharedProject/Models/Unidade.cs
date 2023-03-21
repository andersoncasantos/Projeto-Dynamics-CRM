using Logistiscs.AlfaPeople.Models.BaseModels;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistiscs.AlfaPeople.Models.Models
{
	public class Unidade : ModelCore
	{
		public Unidade(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
			this.LogicalName = "uom";
		}

		public Guid Create(Entity unidade)
		{
			Entity unidadeNew = new Entity(this.LogicalName);

			unidadeNew["uomscheduleid"] = (EntityReference)unidade["uomscheduleid"];
			unidadeNew["name"] = unidade["name"].ToString();
			unidadeNew["quantity"] = (decimal)unidade["quantity"];
			unidadeNew["baseuom"] = (EntityReference)unidade["baseuom"];

			Guid unidadeId = this.ServiceClient.Create(unidadeNew);
			return unidadeId;
		}

		public Entity GetUnidadeById(Guid unidadeId, string[] columns)
		{
			QueryExpression queryUnidade = new QueryExpression(this.LogicalName);
			queryUnidade.ColumnSet.AddColumns(columns);
			queryUnidade.Criteria.AddCondition("uomid", ConditionOperator.Equal, unidadeId);

			return RetrieveFirstRow(queryUnidade);
		}

		public Entity GetUnidadeByName(string unidadeName, string[] columns)
		{
			QueryExpression queryUnidade = new QueryExpression(this.LogicalName);
			queryUnidade.ColumnSet.AddColumns(columns);
			queryUnidade.Criteria.AddCondition("name", ConditionOperator.Equal, unidadeName);

			return RetrieveFirstRow(queryUnidade);
		}
	}
}
