<script language="javascript", type="text/javascript">
    $(document).ready(function()
{
        
    var SessionID = null;
    
    var oSetsTable = $('#sessionSets').dataTable(
    {
        "sScrollY": "100px",
        "bJQueryUI": true,
        "bServerSide": true,
        "sAjaxSource": "MasterDetailsAjaxHandler",
        "bProcessing": true,
                "fnServerData": function (sSource, aoData, fnCallback) {
            aoData.push({ "name": "SessionID", "value": SessionID });
            $.getJSON(sSource, aoData, function (json)
                {
                        fnCallback(json)
                });
            }
        });

        $(".masterlink").click(function (e) {
        SessionID = $(this).attr("SessionId");
            oEmployeesTable.fnDraw();
    });
});
</script>