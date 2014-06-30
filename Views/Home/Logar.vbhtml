@Code
    ViewData("Title") = "CorrenteDeOrações - Entrar"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<div id="fb-root"></div>
<script type="text/javascript">

    // This is called with the results from from FB.getLoginStatus().
    function statusChangeCallback(response) {
        if (response.status === 'connected') {
            // Logged into your app and Facebook.
            window.location = "../home/FacebookLogin?authResponse=" + response.authResponse.accessToken;
        }
    }

    // This function is called when someone finishes with the Login
    // Button.  See the onlogin handler attached to it in the sample
    // code below.
    function checkLoginState() {
        FB.getLoginStatus(function (response) {
            statusChangeCallback(response);
        });
    }

    window.fbAsyncInit = function () {
        FB.init({
            appId: '723571007714206',
            cookie: true,  // enable cookies to allow the server to access 
            // the session
            xfbml: true,  // parse social plugins on this page
            version: 'v2.0' // use version 2.0
        });

        FB.getLoginStatus(function (response) {
            statusChangeCallback(response);
        });

    };

    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/pt_BR/sdk.js#xfbml=1&appId=723571007714206&version=v2.0";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));

    function testAPI() {
        FB.api('/me', function (response) {
            console.log(response)
        });
    }
</script>

<h1>Entre para continuar</h1>

@Code
    ViewData("Title") = "Logar"
    Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<p>
        E-mail: @Html.TextBox("email")
        Senha: @Html.Password("senha")
        <input type="submit" value="Ok" />
    </p>
    End Using
End Code

Ou entre usando sua conta do Facebook:

<div class="fb-login-button" data-max-rows="1" data-size="medium" data-show-faces="false" data-auto-logout-link="true" onlogin="checkLoginState();"></div>

<div id="status">
</div>