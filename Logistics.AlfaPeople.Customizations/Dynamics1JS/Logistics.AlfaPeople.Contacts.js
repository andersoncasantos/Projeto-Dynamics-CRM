if (typeof (Logistics) == "undefined") { Logistics = {} }
if (typeof (Logistics.Contacts) == "undefined") { Logistics.Contacts = {} }

Logistics.Contacts = {

    OnChange: function (executionContext) {
        var formContext = executionContext.getFormContext();

        var cpf = formContext.getAttribute("grp_cpf").getValue();

        if ((cpf != null) && (cpf.length == 11)) {
            var cpfFormatted = cpf.replace(/^(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
            formContext.getAttribute("grp_cpf").setValue(cpfFormatted);
        } else {
            Logistics.Contacts.DynamicsAlert("CPF Inválido", "Digite um CPF válido!");
            formContext.getAttribute("grp_cpf").setValue(null);
        }
    },
    DynamicsAlert: function (alertText, alertTitle) {
        var alertStrings = {
            confirmButtomLabel: "Ok",
            text: alertText,
            title: alertTitle
        };

        var alertOptions = {
            heigh: 120,
            width: 200
        };

        Xrm.Navigation.openAlertDialog(alertStrings, alertOptions);
    }
}