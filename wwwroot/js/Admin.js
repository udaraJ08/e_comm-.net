let _curOrderStatus;
let _curOrderId;

const giveStatusName = (status) => {

    switch (status) {
        case 0:
            return "PENDING"
        case 1:
            return "PROCESSING"
        case 2:
            return "SHIPPED"
        case 3:
            return "COMPLETED"
        case -1:
            return "CANCELLED"
        default:
            return "PENDING"
    }
}

const selectOrderStatus = (status, id) => {

    _curOrderStatus = status
    _curOrderId = id

    const orderStatus = _curOrderStatus


    const t = true;
    const f = false;

    if (status !== 3) $('#lblOrderCompleted').attr('hidden', true)

    switch (orderStatus) {
        case 0:
            handleButtonVisibility(t, f, f, t)
            break
        case 1:
            handleButtonVisibility(f, t, f, t)
            break
        case 2:
            handleButtonVisibility(f, f, t, t)
            break
        default:
            handleButtonVisibility(f, f, f, f)
            break
    }
}


//Use this to handle visibilty of modal buttons
const handleButtonVisibility = (process, shipped, completed, cancelled) => {
    $("#btnProcessing").attr("hidden", !process)
    $("#btnShipped").attr("hidden", !shipped)
    $("#btnCompleted").attr("hidden", !completed)
    $("#btnCancelled").attr("hidden", !cancelled)
}

const handlePaymentState = (state) => {

    $.ajax({
        url: '/order/status-update',
        type: 'PATCH',
        data: { status: state, id: _curOrderId},
        async: false,
        success: function () {

            Swal.fire({
                title: 'Done',
                text: `Order is now ${giveStatusName(state)}`,
                icon: 'success',
                confirmButtonText: 'close',
                onClose: () => {
                    window.location.reload()
                }
            })
        },
        error: function (responce) { console.error(responce.data) }
    });
}