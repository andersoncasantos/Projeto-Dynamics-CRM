using Logistiscs.AlfaPeople.Models.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistiscs.AlfaPeople.Models.Controllers
{
	public class GrupoDeUnidadesController
	{
		public IOrganizationService ServiceClient { get; set; }
		public GrupoDeUnidades GrupoUnidades { get; set; }

		public GrupoDeUnidadesController(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
			this.GrupoUnidades = new GrupoDeUnidades(this.ServiceClient);
		}

		public Guid Create(Entity grupoDeUnidade)
		{
			return GrupoUnidades.Create(grupoDeUnidade);
		}

		public Entity GetGrupoByName(string grupoName, string[] columns)
		{
			return GrupoUnidades.GetGrupoByName(grupoName, columns);
		}

		public Entity GetGrupoById(Guid grupoId, string[] columns)
		{
			return GrupoUnidades.GetGrupoById(grupoId, columns);
		}
	}
}
