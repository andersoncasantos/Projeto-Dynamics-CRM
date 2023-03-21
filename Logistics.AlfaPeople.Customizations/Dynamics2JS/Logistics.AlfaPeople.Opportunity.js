if (typeof (Logistics) == "undefined") { Logistics = {} }
if (typeof (Logistics.Opportunity) == "undefined") { Logistics.Opportunity = {} }

Logistics.Opportunity = {
    OnSave: function (executionContext) {
        var formContext = executionContext.getFormContext();
        var formType = formContext.ui.getFormType();

        if (formType == 2) {
            Xrm.Navigation.openErrorDialog({ errorCode: 1234, message: "Você não pode atualizar uma oportunidade diretamente pelo Dynamics 2" });
        }
    },
}