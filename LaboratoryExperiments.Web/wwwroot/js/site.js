function getStations(id) {
    $.get({
        url: "/Stations/GetStationsByBranchId/" + id,
        success: function (data) {

            var html = '`<option value="">Choose...</option>';
            $.each(data, function (key, value) {

                html += `<option value=${value.value}>${value.text}</option>`
            });
            $('#StationId').html(html)
        },
        error: function () {
            showErrorMessage();
        }
    })
}
function showSuccessMessage(message = 'Saved successfully') {
    Swal.fire({
        text: message,
        icon: "success",
        buttonsStyling: false,
        confirmButtonText: "Ok, got it!",
        customClass: {
            confirmButton: "btn btn-primary"
        }
    });
}

function onGeneralModelComplete() {
    showSuccessMessage()
    setInterval(function () {
        window.$('#Model').modal('hide');
        window.location.reload();
    }, 2000);

}
function showErrorMessage() {

    Swal.fire({
        text: 'something went wrong',
        icon: "error",
        buttonsStyling: false,
        confirmButtonText: "Ok, got it!",
        customClass: {
            confirmButton: "btn btn-primary"
        }
    });
}
$(document).ready(function () {
    if ($('.js-select2').length > 0) {
        $('.js-select2').select2({
            allowClear: true,
            /* matcher: matchCustom*/
        });
    }
    $('body').delegate('.js-Delete', 'click', function () {
        var btn = $(this);

        Swal.fire({
            title: "Do you want to save the changes?",
            showDenyButton: true,
            showCancelButton: true,
            confirmButtonText: "Save",
            denyButtonText: `Don't save`
        }).then((result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
                $.post({
                    url: btn.data('url'),
                    success: function (updatedOn) {

                        showSuccessMessage("Deleted successfully");
                        location.reload();
                    },
                    
                    error: function () {
                        showErrorMessage()
                    }
                })
            } else if (result.isDenied) {
                Swal.fire("Changes are not saved", "", "info");
            }

        });

     
    })
    //dealing with model
    $('body').delegate('.js-model-render', 'click', function () {
        var btn = $(this);
        var model = $('#Model');
        model.find('#ModelLabel').text(`${btn.data('title')}`);
        if (btn.data('update') !== undefined) {
            updatedRow = btn.parents('tr');
        }
        $.get({
            url: btn.data('url'),
            success: function (form) {
                model.find('#modelBody').html(form);
                /* if ($.validator.unobtrusive != undefined) {*/
                $.validator.unobtrusive.parse(model);
             
                /*}*/
            },
            error: function () {
                showErrorMessage();
            }
        })
        window.$('#Model').modal('show');
        // mod.model('show');

    });
});