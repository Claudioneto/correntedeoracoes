@ModelType IEnumerable(Of CorrenteDeOracoes.Pedido)

@Code
    ViewData("Title") = "CorrenteDeOrações - Ore por esses pedidos"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Ore por esses pedidos</h1>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table>
    <tr>
        <th>
            descricao
        </th>
        <th>
            data
        </th>
        <th>
            qtdOrando
        </th>
        <th>
            excluido
        </th>
        <th>
            dataExclusao
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.descricao)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.data)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.qtdOrando)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.excluido)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.dataExclusao)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.id}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.id}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.id})
        </td>
    </tr>
Next

</table>
