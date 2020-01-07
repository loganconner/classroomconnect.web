$(function () {
    $(document).ready(function () {
        $("#dialog-form").dialog({
            autoOpen: false,
            height: "100%",
            width: "50%",
            modal: true,
            title: "Does the guardian have other children that have previously enrolled?",
            close: function () {
                $('#guardianSearch').empty().removeClass("ui-state-error");
            }
        });

        
    });
    

    $(document.body).on("click", "#create-user", function () {
        $("#dialog-form").dialog("open");
    });
    $(document.body).on("click", "button.ui-dialog-titlebar-close", function () {
        $(".ui-dialog-title").html("Does the guardian have other children that have previously enrolled?");
        $("#dialog-form").html('<fieldset style="margin-top:10px; text-align:center"><button class="btn btn-blue btn-shadow" name="existingGuardian" id="existingYes">Yes</button> <button class="btn btn-coral btn-shadow" name="existingGuardian" id="existingNo">No</button></fieldset>');
    });
    $(document.body).on("click", "#getGuardian", function () {
        $('#guardianResult').empty();
        searchGuardian();
    });
    $(document.body).on("click", ".guardian-detail", function () {
        var id = $(this).children('td').last().children('input').val();
        getGuardianChildren(id);
    });
    $(document.body).on("click", "#filter", function () {
        filterStudents();
    });
    


    function filterStudents() {
        var searchTerm = $('#search').val();
        var filterValue = "Reset";
        if (searchTerm == "") { searchTerm = "All"; filterValue = "Filter" };
            $.ajax({
                type: 'GET',
                url: 'Enrollment/Index',
                contenttype: "application/json; charset=utf-8",
                data: {
                    searchString: searchTerm
                },
                success: function (data) {
                    if (data.status == "error") {
                        $('#search').val("");
                        alert(data.message);
                    } else {
                        $('#filter').val(filterValue);
                        $('#search').val("");
                        $('section.detail-list').html(data);
                    }
                },
                error: function (error) {
                    console.log(error);
                }
            });
         
        
    }

    function getGuardianChildren(guardianId) {
        
        $.ajax({
            type: 'GET',
            url: 'Enrollment/GetChildren',
            contenttype: "application/json; charset=utf-8",
            data: {
                id: guardianId
            },
            success: function (data) {
                if (data.status == "error") {
                    $('#search').val("");
                    alert(data.message);
                } else {
                    $('#filter').val(filterValue);
                    $('#search').val("");
                    $('section.detail-list').html(data);
                }
            },
            error: function (error) {
                console.log(error);
            }
        });


    }

});

