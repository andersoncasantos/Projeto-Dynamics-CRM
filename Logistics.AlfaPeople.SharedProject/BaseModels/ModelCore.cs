using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistiscs.AlfaPeople.Models.BaseModels
{
	public abstract class ModelCore
	{
		public IOrganizationService ServiceClient { get; set; }
		public string LogicalName { get; set; }

		public Entity RetrieveFirstRow(QueryExpression query)
		{
			EntityCollection retrivedRow = this.ServiceClient.RetrieveMultiple(query);

			if (retrivedRow.Entities.Count > 0) { return retrivedRow.Entities.FirstOrDefault(); }
			else { return null; }
		}

		public Entity RetrieveLastRow(QueryExpression query)
		{
			EntityCollection retrivedRow = this.ServiceClient.RetrieveMultiple(query);

			if (retrivedRow.Entities.Count > 0) { return retrivedRow.Entities.LastOrDefault(); }
			else { return null; }
		}
	}
}
