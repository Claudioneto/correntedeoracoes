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
    <!--resumo de seus pedidos-->
    <div class="col-sm-12 pedido">
        <p>@ViewBag.nomeUsuario, você tem <strong>@ViewBag.qtdPedidos pedidos</strong> feitos e já oraram por você <strong>@ViewBag.qtdOracoes vezes</strong>.</p>
        <p>Visite os pedidos de outras pessoas e retribua intercedendo por seus irmãos.</p>
        <br />
        <p class="publicidade">Publicidade</p>
        <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js" type="text/javascript"></script>
        <!-- CDO-MeusPedidos -->
        <ins class="adsbygoogle"
                style="display:block"
                data-ad-client="ca-pub-1017535286769229"
                data-ad-slot="9383934437"
                data-ad-format="auto"></ins>
        <script type="text/javascript">
            (adsbygoogle = window.adsbygoogle || []).push({});
        </script>
    </div>
</div>

<div class="col-sm-9">
    <!--listagem de seus pedidos-->
    @For i As Integer = 0 To Model.Count - 1
        @<div class="row col-sm-12 pedido">
            <div class="row">
                <div class="col-sm-8">
                    <p class="PedidoOracao">@Html.ActionLink(Model(i).data.ToString("dd/MM/yy hh:mm"), "details", "pedido", New With {.id = Model(i).id}, Nothing) - @Model(i).descricao</p>
                </div>
                <div class="col-sm-4">
                    @If Model(i).qtdOrando > 0 Then
                        If Model(i).qtdOrando = 1 Then
                            @:1 pessoa orou!
                        Else
                            @Model(i).qtdOrando @:pessoas(oraram!)
                        End If
                    End If
                </div>
            </div>
            <div class="row">
                <div class="col-sm-8">
                    @If Not Model(i).tags Is Nothing Then
                        @<ul class="list-inline">
                            <li>Tags: </li>
                        @For Each tag As String In Model(i).tags
                            @<li><a href="../../pedido/index?tag=@tag" title="Clique aqui para visualizar pedidos semelhantes">@tag</a></li>
                        Next
                        </ul>
                    End If
                </div>
                @If Not Model(i).pedidoAtendido Then
                    @<div class="col-sm-4">
                        <button class="btn btn-orar" onclick="location.href='../../testemunho/create?pedido=@Model(i).id'" title="Clique aqui para dar um testemunho">Deus atendeu meu pedido!</button>
                    </div>
                end if
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