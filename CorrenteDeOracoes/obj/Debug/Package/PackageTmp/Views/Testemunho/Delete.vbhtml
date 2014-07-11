@ModelType CorrenteDeOracoes.Testemunho

@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Testemunho</legend>

    <div class="display-label">descricao</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.descricao)
    </div>

    <div class="display-label">data</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.data)
    </div>
</fieldset>
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
