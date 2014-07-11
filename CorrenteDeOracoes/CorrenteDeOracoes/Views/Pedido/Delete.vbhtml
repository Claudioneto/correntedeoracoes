@ModelType CorrenteDeOracoes.Pedido

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Pedido</legend>

    <div class="display-label">descricao</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.descricao)
    </div>

    <div class="display-label">data</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.data)
    </div>

    <div class="display-label">qtdOrando</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.qtdOrando)
    </div>

    <div class="display-label">excluido</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.excluido)
    </div>

    <div class="display-label">dataExclusao</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.dataExclusao)
    </div>
</fieldset>
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
