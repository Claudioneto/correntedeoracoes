@ModelType PagedList.IPagedList(Of CorrenteDeOracoes.Testemunho)

@Code
    ViewData("Title") = "CorrenteDeOrações - Meus Testemunhos"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<div class="row" id="versiculo">
    <h1>Esperei com paciência no SENHOR, e ele se inclinou para mim, e ouviu o meu clamor.</h1>
    <p>Salmos 40:1</p>
</div>

<div class="col-sm-3">
    <!--resumo de seus pedidos-->
    <div class="col-sm-12 pedido">
        @If ViewBag.qtdTestemunhos > 0 Then
            @<p>@ViewBag.nomeUsuario, você já testemunhou <strong>@ViewBag.qtdTestemunhos vezes</strong>.</p>
            @<p>Mantenha firme sua fé, realize novos pedidos e continue orando por seus irmãos.</p>
        Else
            @<p>@ViewBag.nomeUsuario, você ainda não testemunhou nenhuma vez, mantenha-se em oração e creia que Deus realizará seu pedido.</p>
        End If
        <button class="btn btn-orar" onclick="location.href='../../testemunho/create'" title="Clique aqui para dar um testemunho">Quero testemunhar!</button>
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
            <div class="col-sm-12">
                <p class="PedidoOracao">@Model(i).descricao</p>
                <p>Data: @Html.ActionLink(Model(i).data.ToString("dd/MM/yy hh:mm"), "details", "testemunho", New With {.id = Model(i).id}, Nothing)</p>
            </div>
        </div>
    Next
    @If Model.PageCount > 1 Then
        @<div>
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
    End If
</div>
