

$( document ).ready( function () {

    bindDataTable();

    $( '#search' ).on( 'click', function () {
        var form = $( '#recordSearchForm' ).serializeArray();
        $.get( '/Home/RecordDetails', form, function ( result ) {
            $( '#recordDetails' ).html( result );
            bindDataTable();
        }, 'html' );
    } );

    function bindDataTable() {
        $( '#records' ).DataTable( {
            searching: false,
            lengthChange: false,            
            language: {
                "paginate": {                    
                    "next": "下一頁",
                    "previous": "上一頁"
                },
                "emptyTable": "無資料",
                "info": "顯示 _START_ 到 _END_ 總共 _TOTAL_ 筆"
            }
        } );
    }

} );