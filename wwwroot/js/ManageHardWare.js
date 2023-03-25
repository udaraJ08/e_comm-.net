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

const addNewRam= () => {

    const title = $('#ramTitle').val()
    const size = $('#ramSize').val()
    const price = $('#ramPrice').val()


    $.ajax({
        url: '/ram/create',
        type: 'POST',
        data: { title, price, size },
        success: function (response) {

            Swal.fire({
                title: 'Done',
                text: 'New Ram added successfully !',
                icon: 'success',
                confirmButtonText: 'close'
            })

            window.location.reload()
        },
        error: function (responce) { console.error(responce.data) }
    });
}

const addNewProcessor= () => {

    const title = $('#processorTitle').val()
    const Clock_speed = $('#processorClockSpeed').val()
    const price = $('#processorPrice').val()


    $.ajax({
        url: '/processor/create',
        type: 'POST',
        data: { title, price, Clock_speed },
        success: function (response) {

            Swal.fire({
                title: 'Done',
                text: 'New Processor added successfully !',
                icon: 'success',
                confirmButtonText: 'close'
            })

            window.location.reload()
        },
        error: function (responce) { console.error(responce.data) }
    });
}

const addNewHard= () => {

    const title = $('#hardTitle').val()
    const storage = $('#hardStorage').val()
    const price = $('#hardPrice').val()


    $.ajax({
        url: '/hard/create',
        type: 'POST',
        data: { title, price, storage },
        success: function (response) {

            Swal.fire({
                title: 'Done',
                text: 'New Hard added successfully !',
                icon: 'success',
                confirmButtonText: 'close'
            })

            window.location.reload()
        },
        error: function (responce) { console.error(responce.data) }
    });
}