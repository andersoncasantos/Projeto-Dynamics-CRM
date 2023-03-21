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
	public class GrupoDeUnidades : ModelCore
	{
		public GrupoDeUnidades(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
			this.LogicalName = "uomschedule";
		}

		public Guid Create(Entity grupoUnidades)
		{
			Guid grupoUnidadesId = ServiceClient.Create(grupoUnidades);
			return grupoUnidadesId;
		}

		public Entity GetGrupoByName(string grupoName, string[] columns)
		{
			QueryExpression queryGrupo = new QueryExpression(this.LogicalName);
			queryGrupo.ColumnSet.AddColumns(columns);
			queryGrupo.Criteria.AddCondition("name", ConditionOperator.Equal, grupoName);

			return RetrieveFirstRow(queryGrupo);
		}

		public Entity GetGrupoById(Guid grupoId, string[] columns)
		{
			QueryExpression queryGrupo = new QueryExpression(this.LogicalName);
			queryGrupo.ColumnSet.AddColumns(columns);
			queryGrupo.Criteria.AddCondition("uomscheduleid", ConditionOperator.Equal, grupoId);

			return RetrieveFirstRow(queryGrupo);
		}
	}
}
