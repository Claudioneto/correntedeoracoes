@ModelType CorrenteDeOracoes.Usuario

@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Usuario</legend>

    <div class="display-label">nome</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.primeiroNome)
    </div>

    <div class="display-field">
        @Html.DisplayFor(Function(model) model.sobrenome)
    </div>

    <div class="display-label">email</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.email)
    </div>

    <div class="display-label">senha</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.senha)
    </div>

    <div class="display-label">cpf</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.cpf)
    </div>

    <div class="display-label">idFacebook</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.idFacebook)
    </div>

    <div class="display-label">ativo</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.ativo)
    </div>

    <div class="display-label">dataCadastro</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.dataCadastro)
    </div>

    <div class="display-label">dataUltimoAcesso</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.dataUltimoAcesso)
    </div>

    <div class="display-label">foto</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.foto)
    </div>

    <div class="display-label">cidade</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.cidade)
    </div>

    <div class="display-label">estado</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.estado)
    </div>

    <div class="display-label">igreja</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.igreja)
    </div>
</fieldset>
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
