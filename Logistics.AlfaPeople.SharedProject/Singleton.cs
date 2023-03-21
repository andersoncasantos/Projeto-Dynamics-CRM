using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AlfaPeople.Models
{
    public class Singleton
    {
        public static CrmServiceClient GetService()
        {
			string url = "org7978f91a";
			string clientId = "8d95d123-bce0-4ba6-bd3f-e9db6e555c54";
			string clientSecret = "kRG8Q~13K2uaW~OOYeRAULi3X0OMQtVJBGMSbbUa";

			CrmServiceClient serviceClient = new CrmServiceClient($"AuthType=ClientSecret;Url=https://{url}.crm2.dynamics.com/;AppId={clientId};ClientSecret={clientSecret};");
			return serviceClient;
		}
    }
}
