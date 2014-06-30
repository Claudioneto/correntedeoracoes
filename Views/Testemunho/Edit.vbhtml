@ModelType CorrenteDeOracoes.Testemunho

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
        <legend>Testemunho</legend>

        @Html.HiddenFor(Function(model) model.id)

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.descricao)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.descricao)
            @Html.ValidationMessageFor(Function(model) model.descricao)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.data)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.data)
            @Html.ValidationMessageFor(Function(model) model.data)
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
