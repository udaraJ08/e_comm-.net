const routeHandler = (url) => {

    window.location.href = url
}

const registerCustomer = () => {

    const email = $("#txtUsername").val()
    const name = $("#txtName").val()
    const address = $("#txtAddress").val()
    const dob = $("#txtDob").val()
    const nic = $("#txtNic").val()

    const password = $("#pwPassword").val()
    const confirmPassword = $("#pwConfirmPassword").val()

    const data = {
        email, name, address, dob, nic, password
    }

    if (password !== confirmPassword) {
        Swal.fire({
            title: 'Failed !',
            text: 'Passwords missmatch, please try again !',
            icon: 'error',
            confirmButtonText: 'close',
        })
        return
    }

    $.ajax({
        url: '/customer/register',
        type: 'POST',
        data,
        async: false,
        success: function (response) {

            Swal.fire({
                title: 'Done',
                text: 'You have successfully registered !',
                icon: 'success',
                confirmButtonText: 'close',
                onclose: () => {
                    window.location.href = "https://localhost:7184"
                }
            })
        },
        error: function (responce) { console.error(responce.data) }
    });
}

const login = () => {

    const USER = 'CUSTOMER';
    const ADMIN = 'ADMIN';

    const username = $("#txtLoginUsername").val();
    const password = $("#txtLoginPassword").val();

    $.ajax({
        url: '/customer/login',
        type: 'GET',
        data: {username, password},
        async: false,
        success: function (response) {
            const data = response.data[0];
            const role = response.role;

            if (!response.role) {
                Swal.fire({
                    title: 'Failed !',
                    text: 'Wrong credentials, please check again !',
                    icon: 'error',
                    confirmButtonText: 'close',
                })
                return
            }

            console.log(data)

            window.localStorage.setItem('user', JSON.stringify(data));
            window.localStorage.setItem('role', role);

            if (role === ADMIN) window.location.href = "https://localhost:7184/manager"
            else if (role === USER) window.location.href = "https://localhost:7184/"

        },
        error: function (responce) { console.error(responce.data) }
    });
}