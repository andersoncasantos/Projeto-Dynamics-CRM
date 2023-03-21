using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Text;

namespace Logistics.AlfaPeople.PluginsDyn1.LogisticsISV
{
	public abstract class ActionCore : CodeActivity
	{
        public IWorkflowContext WorkflowContext { get; set; }
        public IOrganizationServiceFactory ServiceFactory { get; set; }
        public IOrganizationService Service { get; set; }
		public ITracingService TracingService { get; set; }

		public CodeActivityContext Context { get; set; }

		protected override void Execute(CodeActivityContext context)
		{
			this.Context = context;

			this.WorkflowContext = context.GetExtension<IWorkflowContext>();
			this.ServiceFactory = context.GetExtension<IOrganizationServiceFactory>();
			this.Service = this.ServiceFactory.CreateOrganizationService(this.WorkflowContext.UserId);
			this.TracingService = this.Context.GetExtension<ITracingService>();

			ExecuteAction();
		}

		public abstract void ExecuteAction();
	}
}