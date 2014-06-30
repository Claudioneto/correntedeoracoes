@ModelType CorrenteDeOracoes.Usuario

@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Edit</h2>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Usuario</legend>

        @Html.HiddenFor(Function(model) model.id)

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.primeiroNome)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.primeiroNome)
            @Html.ValidationMessageFor(Function(model) model.primeiroNome)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.sobrenome)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.sobrenome)
            @Html.ValidationMessageFor(Function(model) model.sobrenome)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.email)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.email)
            @Html.ValidationMessageFor(Function(model) model.email)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.senha)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.senha)
            @Html.ValidationMessageFor(Function(model) model.senha)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.cpf)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.cpf)
            @Html.ValidationMessageFor(Function(model) model.cpf)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.idFacebook)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.idFacebook)
            @Html.ValidationMessageFor(Function(model) model.idFacebook)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.ativo)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.ativo)
            @Html.ValidationMessageFor(Function(model) model.ativo)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.dataCadastro)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.dataCadastro)
            @Html.ValidationMessageFor(Function(model) model.dataCadastro)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.dataUltimoAcesso)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.dataUltimoAcesso)
            @Html.ValidationMessageFor(Function(model) model.dataUltimoAcesso)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.foto)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.foto)
            @Html.ValidationMessageFor(Function(model) model.foto)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.cidade)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.cidade)
            @Html.ValidationMessageFor(Function(model) model.cidade)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.estado)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.estado)
            @Html.ValidationMessageFor(Function(model) model.estado)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.igreja)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.igreja)
            @Html.ValidationMessageFor(Function(model) model.igreja)
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
