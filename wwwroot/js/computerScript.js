let _selectedItem;
let _selectedItemPrice = 0;
let _vgaPrice = 0;
let _ramPrice = 0;
let _processorPrice = 0;
let _hardPrice = 0;

const CUSTOM = 'CUSTOM'
const STANDARD = 'STANDARD'

/*ROUTINGS*/

const routeToDesktop = () => {

    window.location.href = 'https://localhost:7184/computer/desktop'
}

const routeToNotebook = () => {

    window.location.href = 'https://localhost:7184/computer/notebook'
}

const categoryRoute = (id) => {

    window.location.href = `https://localhost:7184/computer/category?id=${id}&name=${name}`
}

const routeToComputers = () => {

    window.location.href = 'https://localhost:7184/computer'
}

/*COMMON FUNCTIONS*/

const getSpecPrice = () => _selectedItemPrice + _vgaPrice + _ramPrice + _hardPrice + _processorPrice

const doPayment = (type) => {

    const data = {
        device_id: _selectedItem?.deviceId,
        user_id: 1,
        shipping_address: $('#txtShippingAddress').val(),

        
        billing_address: $('#chkSameAddress').is(":checked") ? $('#txtShippingAddress').val() : $('#txtBillingAddress').val(),

        shipping_method: $('#drpdwnShippingMethod').val(),
        order_type: type,
        vga: type === CUSTOM ? Number($('#drpdwnVga').val()) : null,

        ram: type === CUSTOM ? Number($('#drpdwnMemory').val()) : null,
        hard: type === CUSTOM ? Number($('#drpdwnHard').val()) : null,
        processor: type === CUSTOM ? Number($('#drpdwnProcessor').val()) : null,
        amount: type === CUSTOM ? getSpecPrice() : _selectedItem.total,

    }

    $.ajax({
        url: '/ComputerController/order',
        type: 'POST',
        data,
        async: false,
        success: function (response) {

            Swal.fire({
                title: 'Done',
                text: 'Your order placed successfully !',
                icon: 'success',
                confirmButtonText: 'close'
            })
        },
        error: function (responce) { console.error(responce.data) }
    });
}


/*EVENTS*/

const handleClick = (id) => {
    $.ajax({
        url: '/ComputerController/GetDeviceById',
        contentType: "application/x-www-form-urlencoded",
        data: {id},
        method: 'GET',
        success: function (responce) {

            const data = responce.data[0]

            $('#exampleModalLabel').text(data.deviceTitle)

            $('#detDeviceImg').attr('src', data.device_img)
            $('#detPrice').text(`price: rs.${data?.total} /=`)
            $('#detDescription').text(data?.deviceDescription)
            $('#detVga').text(`VGA: ${data?.vga_title} - ${data?.vga_size}gb`)
            $('#detRam').text(`RAM: ${data?.ram_title} - ${data?.ram_size}gb`)
            $('#detProcessor').text(`Processor: ${data?.processor_title} - ${data?.processor_clock_speed}`)
            $('#detHard').text(`Hard: ${data?.hard_title} - ${data?.hard_storage}Tb`)
        },
        error: function (responce) { console.error(responce.data) }
    });
}

const handleBuyNow = (id) => {
    $.ajax({
        url: '/ComputerController/GetDeviceById',
        data: { id },
        contentType: "application/x-www-form-urlencoded",
        method: 'GET',
        success: function (responce) {

            _selectedItemPrice = responce.data[0]?.device_base_price
            _selectedItem = responce.data[0]

            $("#lblCustomPrice").text(`Rs.${_selectedItemPrice}/=`)

            const data = responce.data[0]

            $('#buyModalLabel').text(data.deviceTitle)

            $('#buyDeviceImg').attr('src', data.device_img)
            $('#buyPrice').text(`price: rs.${data?.total} /=`)
            $('#buyDescription').text(data?.deviceDescription)
            $('#buyVga').text(`VGA: ${data?.vga_title} - ${data?.vga_size}gb`)
            $('#buyRam').text(`RAM: ${data?.ram_title} - ${data?.ram_size}gb`)
            $('#buyProcessor').text(`Processor: ${data?.processor_title} - ${data?.processor_clock_speed}`)
            $('#buyHard').text(`Hard: ${data?.hard_title} - ${data?.hard_storage}Tb`)
        },
        error: function (responce) { console.error(responce.data) }
    });
}

const fetchHardWare = () => {
    $.ajax({
        url: '/ComputerController/vga',
        method: 'GET',
        success: function (responce) {

            const data = responce.data

            var $dropdown = $("#drpdwnVga");
            $.each(data, function (index, item) {
                $dropdown.append(`<option value=${item.id} data-cost=${item.price}>${item.title}</option>`);
            });
        },
        error: function (responce) { console.error(responce.data) }
    });

    $.ajax({
        url: '/ComputerController/processor',
        method: 'GET',
        success: function (responce) {

            const data = responce.data

            var $dropdown = $("#drpdwnProcessor");
            $.each(data, function (index, item) {
                $dropdown.append(`<option value=${item.id} data-cost=${item.price}>${item.title}</option>`);
            });
        },
        error: function (responce) { console.error(responce.data) }
    });

    $.ajax({
        url: '/ComputerController/hard',
        method: 'GET',
        success: function (responce) {

            const data = responce.data

            var $dropdown = $("#drpdwnHard");
            $.each(data, function (index, item) {
                $dropdown.append(`<option value=${item.id} data-cost=${item.price}>${item.title}</option>`);
            });
        },
        error: function (responce) { console.error(responce.data) }
    });

    $.ajax({
        url: '/ComputerController/ram',
        method: 'GET',
        success: function (responce) {

            const data = responce.data

            var $dropdown = $("#drpdwnMemory");
            $.each(data, function (index, item) {
                $dropdown.append(`<option value=${item.id} data-cost=${item.price}>${item.title}</option>`);
            });
        },
        error: function (responce) { console.error(responce.data) }
    });
}

$("#drpdwnVga").change(function () {
    $('#drpdwnVga :selected').each(function () {    

        let cost = Number($(this).data('cost'));

        _vgaPrice = cost

        $('#lblCustomPrice').text(`Rs.${getSpecPrice()}/=`)
    });
});

$("#drpdwnMemory").change(function () {
    $('#drpdwnMemory :selected').each(function () {

        let cost = Number($(this).data('cost'));

        _ramPrice = cost

        $('#lblCustomPrice').text(`Rs.${getSpecPrice()}/=`)
    });
});

$("#drpdwnHard").change(function () {
    $('#drpdwnHard :selected').each(function () {

        let cost = Number($(this).data('cost'));

        _hardPrice = cost

        $('#lblCustomPrice').text(`Rs.${getSpecPrice()}/=`)
    });
});

$("#drpdwnProcessor").change(function () {
    $('#drpdwnProcessor :selected').each(function () {

        let cost = Number($(this).data('cost'));

        _processorPrice = cost

        $('#lblCustomPrice').text(`Rs.${getSpecPrice()}/=`)
    });
});

$("#chkSameAddress").change(function () {

    const value = $("#txtShippingAddress").val()
    const disabled = $("#txtBillingAddress").is(':disabled')

    $("#txtBillingAddress").attr('value', value)
    $("#txtBillingAddress").attr('disabled', !disabled)
});


const init = async () => {
    await fetchHardWare()
}

init()