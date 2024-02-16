//Branches

function addNewBranch(btn) {
    var table = document.getElementById('tbl-comapny-branches');
    var rows = table.getElementsByTagName('tr');
    var rowOuterHtml = rows[rows.length - 1].outerHTML;

    var lastRowIdx = 0;
    if (rows.length >= 2)
        lastRowIdx = rows.length - 2;
    else if (rows.length >= 1)
        lastRowIdx = rows.length - 1;    
    var nextRowIdx = eval(lastRowIdx) + 1;    
    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastRowIdx + '_', '_' + nextRowIdx + '_');
    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastRowIdx + ']', '[' + nextRowIdx + ']');
    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastRowIdx, '-' + nextRowIdx);
       
    var newRow = table.insertRow();
    newRow.innerHTML = rowOuterHtml;

    var InputselementsCells = newRow.cells;
    for (var x = 0; x < InputselementsCells.length; x++) {
        if (x == 1 || x == 6) {
            InputselementsCells[6].querySelector('INPUT').checked = 'checked';
        }
        else {
            if (InputselementsCells[x].querySelector('INPUT') != null)
            InputselementsCells[x].querySelector('INPUT').value = '';
        }
    }   
    rebindValidators();
}

function DeleteBranch(btn) {
        var table = document.getElementById('tbl-comapny-branches');
        var rows = table.getElementsByTagName('tr');

        var numberOfShownRows = 0;
    
    
        for (var x = 0; x < rows.length; x++) {
            var rowStyle = window.getComputedStyle(rows[x]);
            if (rowStyle.display !== 'none') {
                numberOfShownRows++;
            }       
        }
    if (numberOfShownRows == 2) {

        document.querySelector('.modal').style.display = 'block';
        msgCannotDeleteField();
        return;
    }
    
    
    //var btnIdx = btn.id.replaceAll('btn-delete-branch-', '');
    //var idofIsDeleted = btnIdx + "__IsCompanyBranchDeleted";
    //var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
    //document.getElementById(hidIsDelId).value = "true";

    var currentRow = $(btn).closest('tr');
    
    currentRow[0].cells[1].querySelector('INPUT').checked = 'checked';
    currentRow[0].cells[1].querySelector('INPUT').value = 'true';
    currentRow.hide();
}

function rebindValidators() {
    var $form = $('#myForm');
    $form.unbind();
    $form.data('validator', null);
    $.validator.unobtrusive.parse($form);
    $form.validate($form.data('unobtrusiveValidation').options);
}


//Phones

function addNewPhone(btn) {
    var table = document.getElementById('tbl-comapny-phones');
    var rows = table.getElementsByTagName('tr');
    var rowOuterHtml = rows[rows.length - 1].outerHTML;

    var lastRowIdx = 0;
    if (rows.length >= 2)
        lastRowIdx = rows.length - 2;
    else if (rows.length >= 1)
        lastRowIdx = rows.length - 1;
    var nextRowIdx = eval(lastRowIdx) + 1;
    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastRowIdx + '_', '_' + nextRowIdx + '_');
    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastRowIdx + ']', '[' + nextRowIdx + ']');
    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastRowIdx, '-' + nextRowIdx);

    var newRow = table.insertRow();
    newRow.innerHTML = rowOuterHtml;

    var InputselementsCells = newRow.cells;
    for (var x = 0; x < InputselementsCells.length; x++) {
       
            if (InputselementsCells[x].querySelector('INPUT') != null)
                InputselementsCells[x].querySelector('INPUT').value = '';
        
    }
    rebindValidators();
}


function DeletePhone(btn) {
    var table = document.getElementById('tbl-comapny-phones');
    var rows = table.getElementsByTagName('tr');

    var numberOfShownRows = 0;


    for (var x = 0; x < rows.length; x++) {
        var rowStyle = window.getComputedStyle(rows[x]);
        if (rowStyle.display !== 'none') {
            numberOfShownRows++;
        }
    }
    if (numberOfShownRows == 2) {

        document.querySelector('.modal').style.display = 'block';

        msgCannotDeleteField();
        return;
    }


    //var btnIdx = btn.id.replaceAll('btn-delete-branch-', '');
    //var idofIsDeleted = btnIdx + "__IsCompanyBranchDeleted";
    //var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
    //document.getElementById(hidIsDelId).value = "true";

    var currentRow = $(btn).closest('tr');

    currentRow[0].cells[1].querySelector('INPUT').checked = 'checked';
    currentRow[0].cells[1].querySelector('INPUT').value = 'true';
    currentRow.hide();
}



(function () {
        let KeyModelId = document.getElementById('IsNullOrNot').value;
        if (KeyModelId   == 0) {
            $('.btn-save').removeAttr('disabled');
            $('.btn-edit').attr('disabled', 'disabled');
            $('.btn-delete').attr('disabled', 'disabled');
        }
        else {
            $('.btn-save').attr('disabled', 'disabled');
            $('.btn-edit').removeAttr('disabled');
            $('.btn-delete').removeAttr('disabled');
        }
    }());



