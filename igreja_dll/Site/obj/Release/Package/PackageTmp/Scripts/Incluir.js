

function postMinisterio(numero) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        var formData = new FormData();

        formData.append("Id", numero);

        

        $.ajax({
            url: "/Home/ParticiparMinisterio",
            data: formData,
            processData: !1,
            contentType: !1,
            type: "POST",
            headers: headers,
            success: function (data) {
            stopUpdatingProgressIndicator();
            alert("Você foi incluido com sucesso!");
            }
        });
    }






