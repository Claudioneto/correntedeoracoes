@imports CorrenteDeOracoes.LabelExtensions
@ModelType CorrenteDeOracoes.Usuario

@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.inputmask/jquery.inputmask.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.unobtrusive-ajax.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/CustomValidation.js")" type="text/javascript"></script>

<div id="fb-root"></div>
<script type="text/javascript">

    function statusChangeCallback(response) {
        if (response.status === 'connected') {
            window.location = "../home/FacebookLogin?authResponse=" + response.authResponse.accessToken;
        }
    }

    function checkLoginState() {
        FB.getLoginStatus(function (response) {
            statusChangeCallback(response);
        });
    }

    window.fbAsyncInit = function () {
        FB.init({
            appId: '723571007714206',
            cookie: true,
            xfbml: true,
            version: 'v2.0'
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

<div class="row" id="versiculo">
    <h1>Mas agora em Cristo Jesus, vós, que antes estáveis longe, já pelo sangue de Cristo chegastes perto.</h1>
    <p>Efésios 2:13</p>
</div>

<div class="col-sm-7" style="border-right:1px solid #00B9ED">
    <h1>Preencha os dados abaixo para se cadastrar</h1>

    @Using Html.BeginForm("create", "usuario", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(True)

            @<div class="form-group">
                @Html.LabelFor(Function(model) model.primeiroNome, New With {.class = "col-sm-3 control-label"})
                <div class="col-sm-9">
                    @Html.TextBoxFor(Function(model) model.primeiroNome, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.primeiroNome)
                </div>
            </div>
        
            @<div class="form-group">
                @Html.LabelFor(Function(model) model.sobrenome, New With {.class = "col-sm-3 control-label"})
                <div class="col-sm-9">
                    @Html.TextBoxFor(Function(model) model.sobrenome, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.sobrenome)
                </div>
            </div>
        
            @<div class="form-group">
                @Html.LabelFor(Function(model) model.sexo, New With {.class = "col-sm-3 control-label"})
                <div class="col-sm-9">
                    @Html.RadioButtonFor(Function(mode) Model.sexo, "female", New With {.id = "sexo_feminino"})
                    <label for="sexo_feminino">Feminino</label>

                    @Html.RadioButtonFor(Function(mode) Model.sexo, "male", New With {.id = "sexo_masculino"})
                    <label for="sexo_masculino">Masculino</label>
                </div>
            </div>

            @<div class="form-group">
                @Html.LabelFor(Function(model) model.email, New With {.class="col-sm-3 control-label"})
                <div class="col-sm-9">
                    @Html.TextBoxFor(Function(model) model.email, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.email)
                </div>
            </div>
        
            @<div class="form-group">
                @Html.LabelFor(Function(model) model.senha, New With {.class="col-sm-3 control-label"})
                <div class="col-sm-9">
                    @Html.PasswordFor(Function(model) model.senha, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.senha)
                </div>
            </div>
        
            @<div class="form-group">
                <label for="senha_repetir" class="col-sm-3 control-label">Repita sua senha</label>
                <div class="col-sm-9">
                    <input type="password" name="senha_repetir" id="senha_repetir" class="form-control" />
                </div>
            </div>

            @<div class="form-group">
                @Html.LabelFor(Function(model) model.cpf, New With {.class="col-sm-3 control-label"})
                <div class="col-sm-9">
                    @Html.TextBoxFor(Function(model) model.cpf, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.cpf)
                </div>
            </div>

            @<div class="form-group">
                @Html.LabelFor(Function(model) model.cidade, New With {.class="col-sm-3 control-label"})
                <div class="col-sm-5">
                    @Html.TextBoxFor(Function(model) model.cidade, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.cidade)
                </div>
           
                @Html.LabelFor(Function(model) model.estado, New With {.class = "col-sm-2 control-label"})
                <div class="col-sm-2">
                    @code
                    Dim itens As List(Of SelectListItem) = New List(Of SelectListItem)
                    itens.Add(New SelectListItem With {.Text = "", .Value = ""})
                    itens.Add(New SelectListItem With {.Text = "AC", .Value = "AC"})
                    itens.Add(New SelectListItem With {.Text = "AL", .Value = "AL"})
                    itens.Add(New SelectListItem With {.Text = "AM", .Value = "AM"})
                    itens.Add(New SelectListItem With {.Text = "AP", .Value = "AP"})
                    itens.Add(New SelectListItem With {.Text = "BA", .Value = "BA"})
                    itens.Add(New SelectListItem With {.Text = "CE", .Value = "CE"})
                    itens.Add(New SelectListItem With {.Text = "DF", .Value = "DF"})
                    itens.Add(New SelectListItem With {.Text = "ES", .Value = "ES"})
                    itens.Add(New SelectListItem With {.Text = "GO", .Value = "GO"})
                    itens.Add(New SelectListItem With {.Text = "MA", .Value = "MA"})
                    itens.Add(New SelectListItem With {.Text = "MG", .Value = "MG"})
                    itens.Add(New SelectListItem With {.Text = "MS", .Value = "MS"})
                    itens.Add(New SelectListItem With {.Text = "MT", .Value = "MT"})
                    itens.Add(New SelectListItem With {.Text = "PA", .Value = "PA"})
                    itens.Add(New SelectListItem With {.Text = "PB", .Value = "PB"})
                    itens.Add(New SelectListItem With {.Text = "PE", .Value = "PE"})
                    itens.Add(New SelectListItem With {.Text = "PI", .Value = "PI"})
                    itens.Add(New SelectListItem With {.Text = "PR", .Value = "PR"})
                    itens.Add(New SelectListItem With {.Text = "RJ", .Value = "RJ"})
                    itens.Add(New SelectListItem With {.Text = "RN", .Value = "RN"})
                    itens.Add(New SelectListItem With {.Text = "RS", .Value = "RS"})
                    itens.Add(New SelectListItem With {.Text = "RO", .Value = "RO"})
                    itens.Add(New SelectListItem With {.Text = "RR", .Value = "RR"})
                    itens.Add(New SelectListItem With {.Text = "SC", .Value = "SC"})
                    itens.Add(New SelectListItem With {.Text = "SP", .Value = "SP"})
                    itens.Add(New SelectListItem With {.Text = "SE", .Value = "SE"})
                    itens.Add(New SelectListItem With {.Text = "TO", .Value = "TO"})
                    End Code

                    @Html.DropDownListFor(Function(model) model.estado, itens, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.estado)
                </div>
            </div>

            @<div class="form-group">
                @Html.LabelFor(Function(model) model.igreja, New With {.class="col-sm-3 control-label"})
                <div class="col-sm-9">
                    @Html.TextBoxFor(Function(model) model.igreja, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.igreja)
                </div>
            </div>

            @<p>
                <input type="submit" value="Salvar" class="btn btn-success" />
            </p>
    End Using
</div>

<div class="col-sm-5">
    <p>Ou cadastra-se usando sua conta do Facebook</p>
    <div class="fb-login-button" data-max-rows="1" data-size="xlarge" data-show-faces="false" data-auto-logout-link="false" onlogin="checkLoginState();"></div>
</div>

<script type="text/javascript">
    $('#cpf').inputmask("999.999.999-99");
</script>