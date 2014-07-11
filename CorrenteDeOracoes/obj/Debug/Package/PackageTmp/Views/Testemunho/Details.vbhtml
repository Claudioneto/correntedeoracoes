@ModelType CorrenteDeOracoes.Testemunho

@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

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
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
