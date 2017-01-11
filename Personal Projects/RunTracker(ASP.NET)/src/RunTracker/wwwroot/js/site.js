(function () {



    // Shoes/Edit: Toggle switch.
    $("#InUse").bootstrapSwitch();

    // Runs/Create: Dropdown date picker
    $('#datetimepicker').datetimepicker();

    // Home/Index: Show all runs
    $("#showAllButton").click(function () {
        $("#allRunsSwitch").checked(false);
    });

})();

