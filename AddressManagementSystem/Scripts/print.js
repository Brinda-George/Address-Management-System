function PrintDetailsView() {
    debugger;
    var detailsview = document.getElementById('DetailsViewUser');
    var printWindow = window.open('', '', 'width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
    printWindow.document.write(detailsview.outerHTML);
    printWindow.document.close();
    printWindow.focus();
    printWindow.print();
    printWindow.close();
};