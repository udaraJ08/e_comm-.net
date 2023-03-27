const handleLogin = () => {

    window.location.href = "https://localhost:7184/home/login"
}

const handleLogout= () => {

    localStorage.removeItem('user')
    localStorage.removeItem('role')

    window.location.reload(0)
}

const handleAuth = () => {

    const role = localStorage.getItem('role')

    if (role === null) {
        $("#btnLogin").attr("hidden", false)
        $("#btnLogout").attr("hidden", true)
    } else {
        $("#btnLogin").attr("hidden", true)
        $("#btnLogout").attr("hidden", false)
    }
}

const handleRoute = (url) => {

    window.location.href = url
}

handleAuth();