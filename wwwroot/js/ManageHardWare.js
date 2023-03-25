// ROUTINGS
const handleRoutes = (url) => {
    window.location.href = url
}

const addNewVga = () => {

    const title = $('#vgaTitle').val()
    const size = $('#vgaSize').val()
    const price = $('#vgaPrice').val()


    $.ajax({
        url: '/vga/create',
        type: 'POST',
        data: {title, price, size},
        success: function (response) {

            Swal.fire({
                title: 'Done',
                text: 'New vga added successfully !',
                icon: 'success',
                confirmButtonText: 'close'
            })

            window.location.reload()
        },
        error: function (responce) { console.error(responce.data) }
    });
}