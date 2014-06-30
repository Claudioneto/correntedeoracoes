@ModelType PagedList.IPagedList(Of CorrenteDeOracoes.Pedido)

@Code
    ViewData("Title") = "Meus Pedidos - CorrenteDeOrações"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<div class="row" id="versiculo">
    <h1>Ó Deus, ouve a minha oração, inclina os teus ouvidos às palavras da minha boca.</h1>
    <p>Salmos 54:2</p>
</div>

<div class="col-sm-3">
    <!--Aqui deverá vir um resumo de seus pedidos-->
    <div class="col-sm-12 pedido">
        <p>@Model(0).usuario.primeiroNome, você tem <strong>@ViewBag.qtdPedidos pedidos</strong> feitos e já oraram por você <strong>@ViewBag.qtdOracoes vezes</strong>.</p>
        <p>Visite os pedidos de outras pessoas e retribua intercedendo por seus irmãos.</p>
    </div>
</div>

<div class="col-sm-9">
    <!--Aqui deverá vir uma listagem de seus pedidos-->
    @For i As Integer = 0 To Model.Count - 1
        @<div class="row col-sm-12 pedido">
            <p class="PedidoOracao">@Html.ActionLink(Model(i).data.ToString("dd/MM/yy hh:mm"), "details", "pedido", New With {.id = Model(i).id}, Nothing) - @Model(i).descricao</p>

            @If Not Model(i).tags Is Nothing Then
                @<ul class="list-inline">
                    <li>Tags: </li>
                @For Each tag As String In Model(i).tags
                    @<li><a href="../../pedido/index?tag=@tag" title="Clique aqui para visualizar pedidos semelhantes">@tag</a></li>
                Next
                </ul>
            End If
            <div class="row">
                <div class="col-sm-5">
                    Ore por: <span class="Apelido">@Model(i).apelido</span>
                </div>
                
                <div class="col-sm-7 qtdOrando">
                    @If Model(i).qtdOrando > 0 Then
                        If Model(i).qtdOrando = 1 Then
                            @:1 pessoa orou!
                        Else
                            @Model(i).qtdOrando @:pessoas(oraram!)
                        End If
                    End If
                </div>
            </div>
        </div>
    Next
    <div>
        Página @(If(Model.PageCount < Model.PageNumber, 0, Model.PageNumber)) de @Model.PageCount
     
        @If (Model.HasPreviousPage) Then
            @Html.ActionLink("<<", "meusPedidos", New With {.pagina = 1})
            @Html.Raw(" ")
            @Html.ActionLink("< Anterior", "meusPedidos", New With {.pagina = Model.PageNumber - 1})
        else
            @:<<
            @Html.Raw(" ")
            @:< Anterior
        End If
     
        @If (Model.HasNextPage) Then
            @Html.ActionLink("Próxima >", "meusPedidos", New With {.pagina = Model.PageNumber + 1})
            @Html.Raw(" ")
            @Html.ActionLink(">>", "meusPedidos", New With {.pagina = Model.PageCount})
        else
            @:Próxima >
            @Html.Raw(" ")
            @:>>
        End If
    </div>
</div>