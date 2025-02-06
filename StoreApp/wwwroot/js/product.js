var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'name', "width": "20%" },
            { data: 'category.name', "width": "15%" },
            { data: 'price', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="btn-group justify-content-end" role="group">
                     <a href="/admin/product/upsert?id=${data}" class="btn btn-outline-teritary btn-sm"> <i class="bi bi-pencil-square"></i></a>               
                     <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-outline-teritary btn-sm "> <i class="bi bi-trash-fill"></i></a>
                    </div>`
                },
                "width": "5%"
            },
        ]
    });
}



function Delete(url) {
    Swal.fire({
        title: "Delete Product?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        color: "var(--bs-body-color)",
        background: "var(--bs-secondary-bg)",
        confirmButtonText: "Delete"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}