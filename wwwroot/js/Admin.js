let _curOrderStatus;
let _curOrderId;
let _vgaDataSet;
let _ramDataset;
let _processorDataSet;
let _hardDataSet;
let _ordersDataSet;
let _customerDataSet;
let _categoriesDataSet;
let _deviceDataSet;

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

const addNewCategory = () => {

    const type = $("#drpdwnType").val()
    const title = $("#txtTitle").val()
    const image = $("#txtImgUrl").val()

    $.ajax({
        url: '/category/add',
        type: 'POST',
        data: { type, title, image },
        async: false,
        success: function () {

            Swal.fire({
                title: 'Done',
                text: `New Category Created`,
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

const addNewDevice = () => {

    const vga = $("#drpdwnDeviceVga").val()
    const ram = $("#drpdwnDeviceMemory").val()
    const processor = $("#drpdwnDeviceProcessor").val()
    const hard = $("#drpdwnDeviceHard").val()

    const catType = $("#drpdwnDeviceType").val()
    const title = $("#txtDeviceTitle").val()
    const os = $("#txtDeviceOs").val()

    const description = $("#txtrDeviceDescription").val()
    const basePrice = $("#txtDeviceBasePrice").val()
    const image = $("#txtDeviceImgUrl").val()

    const data = {
        vga,
        ram,
        processor,
        hard,
        catType,
        title,
        os,
        image,
        description,
        basePrice,
    }


    $.ajax({
        url: '/device/add',
        type: 'POST',
        data,
        async: false,
        success: function () {

            Swal.fire({
                title: 'Done',
                text: `New Device Added`,
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

const fetchDeviceHardWare = () => {
    $.ajax({
        url: '/ComputerController/vga',
        method: 'GET',
        success: function (responce) {

            const data = responce.data

            _vgaDataSet = data

            var $dropdown = $("#drpdwnDeviceVga");
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

            _processorDataSet = data;

            var $dropdown = $("#drpdwnDeviceProcessor");
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
            _hardDataSet = data

            var $dropdown = $("#drpdwnDeviceHard");
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
            _ramDataset = data

            var $dropdown = $("#drpdwnDeviceMemory");
            $.each(data, function (index, item) {
                $dropdown.append(`<option value=${item.id} data-cost=${item.price}>${item.title}</option>`);
            });
        },
        error: function (responce) { console.error(responce.data) }
    });

    $.ajax({
        url: "/category/fetch",
        method: 'GET',
        success: function (responce) {

            const data = responce.data
            _categoriesDataSet = data

            var $dropdown = $("#drpdwnDeviceType");
            $.each(data, function (index, item) {
                $dropdown.append(`<option value=${item.id}>${item.title}</option>`);
            });
        },
        error: function (responce) { console.error(responce.data) }
    });
}

const downloadReport = (filename, tabName, dataset) => {
    var ws = XLSX.utils.json_to_sheet(dataset);
    var wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, tabName);
    XLSX.writeFile(wb, `${filename}.xlsx`);
}

$("#btnVgaReportDownload").click(function () {
    downloadReport("vga-report", "vga", _vgaDataSet);
});

$("#btnRamReportDownload").click(function () {
    downloadReport("ram-report", "ram", _ramDataset);
});

$("#btnProcessorReportDownload").click(function () {
    downloadReport("processor-report", "processor", _processorDataSet);
});

$("#btnHardReportDownload").click(function () {
    downloadReport("hard-report", "hard", _hardDataSet);
});

/*$("#btnOrdersReportDownload").click(function () {
    $.ajax({
        url: "/order/fetch",
        method: 'GET',
        success: function (responce) {

            const data = responce.data
            _ordersDataSet = data
        },
        error: function (responce) { console.error(responce.data) }
    });
    downloadReport("order-report", "order", _ordersDataSet);
});

$("#btnCustomerReportDownload").click(function () {
    $.ajax({
        url: "/order/fetch",
        method: 'GET',
        success: function (responce) {

            const data = responce.data
            _ordersDataSet = data
        },
        error: function (responce) { console.error(responce.data) }
    });
    downloadReport("order-report", "order", _ordersDataSet);
});*/

$("#btnCategoryReportDownload").click(function () {
    downloadReport("category-report", "category", _categoriesDataSet);
});


$("#btnDevicesReportDownload").click(function () {
    downloadReport("device-report", "devices", _deviceDataSet);
});

const test = (data) => {
    console.log()
}


fetchDeviceHardWare();