if (typeof (Logistics) == "undefined") { Logistics = {} }
if (typeof (Logistics.Account) == "undefined") { Logistics.Account = {} }


Logistics.Account = {

    OnChange: function (executionContext) {

        var formContext = executionContext.getFormContext();
        var nameAccount = formContext.getAttribute("name").getValue();

        nameAccount = nameAccount.toLowerCase().replace(/(?:^|\s)\S/g, function (w) {
            return w.toUpperCase();
        });

        formContext.getAttribute("name").setValue(nameAccount);
    },
    OnCepChange: function (executionContext) {
        var formContext = executionContext.getFormContext();

        var contaCep = formContext.getAttribute("address1_postalcode").getValue();

		if (contaCep.length == 8 && /\d{8}/.test(contaCep)) {
			var execute_grp_GetEnderecoViaCEP_Request = {
				// Parameters
				CEP: contaCep, // Edm.String

				getMetadata: function () {
					return {
						boundParameter: null,
						parameterTypes: {
							CEP: { typeName: "Edm.String", structuralProperty: 1 }
						},
						operationType: 0, operationName: "grp_GetEnderecoViaCEP"
					};
				}
			};

			Xrm.WebApi.execute(execute_grp_GetEnderecoViaCEP_Request).then(
				function success(response) {
					if (response.ok) { return response.json(); }
				}
			).then(function (responseBody) {
				var result = responseBody;
				console.log(result);
				// Return Type: mscrm.grp_GetEndereoViaCEPResponse
				// Output Parameters
				var logradouro = result["Logradouro"]; // Edm.String
				var complemento = result["Complemento"]; // Edm.String
				var bairro = result["Bairro"]; // Edm.String
				var localidade = result["Localidade"]; // Edm.String
				var uf = result["UF"]; // Edm.String
				var ibge = result["IBGE"]; // Edm.String
				var ddd = result["DDD"]; // Edm.String

				formContext.getAttribute("grp_logradouro").setValue(logradouro);
				formContext.getAttribute("grp_complemento").setValue(complemento);
				formContext.getAttribute("grp_bairro").setValue(bairro);
				formContext.getAttribute("grp_localidade").setValue(localidade);
				formContext.getAttribute("grp_uf").setValue(uf);
				formContext.getAttribute("grp_ibge").setValue(ibge);
				formContext.getAttribute("grp_ddd").setValue(ddd);
			}).catch(function (error) {
				console.log(error.message);
			});
		} else {
			Xrm.Navigation.openErrorDialog({ errorCode: 1234, message: "CEP inválido." });
			formContext.getAttribute("address1_postalcode").setValue(null);
		}
	},
    CNPJOnChange: function (executionContext) {
        var formContext = executionContext.getFormContext();
        var cnpj = formContext.getAttribute("grp_cnpj").getValue();

        if (cnpj != null) {
            if (cnpj.length == 14) {
                var formattedCNPJ = cnpj.replace(/^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, "$1.$2.$3/$4-$5");
                formContext.getAttribute("grp_cnpj").setValue(formattedCNPJ);

            }
            else {
                formContext.getAttribute("grp_cnpj").setValue(null);
                Logistics.Account.DynamicsAlert("CNPJ digitado não é valido ou incorreto", "CNPJ inválido");
            }
        }
        else {
            Logistics.Account.DynamicsAlert("Digite um valor para o CNPJ", "CNPJ incorreto");
        }
    },
    DynamicsAlert: function (alertText, alertTitle) {
        var alertStrings = {
            confirmButtonLabel: "OK",
            text: alertText,
            title: alertTitle
        };

        var alertOptions = {
            height: 120,
            width: 200
        };

        Xrm.Navigation.openAlertDialog(alertStrings, alertOptions);
    }
}