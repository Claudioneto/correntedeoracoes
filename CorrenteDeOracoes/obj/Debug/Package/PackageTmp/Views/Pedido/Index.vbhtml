@ModelType PagedList.IPagedList(Of CorrenteDeOracoes.Pedido)
@imports norm

@functions
    Function mostraBotao(id As Guid) As Boolean
        If Request.IsAuthenticated Then
            Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                Dim usuario As CorrenteDeOracoes.Usuario = db.GetCollection(Of CorrenteDeOracoes.Usuario).AsQueryable.FirstOrDefault(Function(u) u.id = Guid.Parse(User.Identity.Name))
                If Not usuario Is Nothing Then
                    If Not usuario.oreiPor Is Nothing Then
                        If Not usuario.oreiPor.Contains(id) Then
                            Return True
                        End If
                    Else
                        Return True
                    End If
                End If
            End Using
        End If
        
        Return False
    End Function
End Functions

@Code
    ViewData("Title") = "CorrenteDeOrações - Ore por esses pedidos"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<div class="row" id="versiculo">
    <h1>Confessai as vossas culpas uns aos outros, e orai uns pelos outros, para que sareis. A oração feita por um justo pode muito em seus efeitos.</h1>
    <p>Tiago 5:16</p>
</div>

@If Model.Count > 0 Then
    @<h2>Ore por esses pedidos</h2>
    For Each item In Model
        @<div class="row col-sm-12 pedido">
            <p class="PedidoOracao">@Html.ActionLink(item.data.ToString("dd/MM/yy hh:mm"),"details",New With{.id = item.id}) - @item.descricao</p>

            @If Not item.tags Is Nothing Then
                @<ul class="list-inline">
                    <li>Tags: </li>
                @For Each tag As String In item.tags
                    @<li><a href="../../pedido/index?tag=@tag" title="Clique aqui para visualizar pedidos semelhantes">@tag</a></li>
                Next
                </ul>
            End If
            <div class="row">
                <div class="col-sm-5">
                    Ore por: <span class="Apelido">@item.apelido</span>
                </div>
                
                <div class="col-sm-7 qtdOrando">
                    @If mostraBotao(item.id) Then
                        @<button onclick="estouOrando('@Model(0).id.ToString')" class="btn btn-xs btn-orar" title="Ore e marque que orou por esse pedido!">Estou Orando <img src="../../images/maoorando.png" alt="" /></button>
                    ElseIf Request.IsAuthenticated Then
                        @<img src="../../images/maoorando.png" alt="Você orou por esse pedido!" title="Você orou por esse pedido, Deus te abençoe!" />
                    End If
        
                    @If item.qtdOrando > 0 Then
                        If item.qtdOrando = 1 Then
                            @:1 pessoa orou!
                        Else
                            @item.qtdOrando @:pessoas(oraram!)
                        End If
                    Else
                        @:Seja o primeiro a orar por esse pedido
                    End If
                </div>
            </div>
        </div>    
    Next
Else
    @<p>Nenhum pedido encontrado com a <strong>tag</strong> informada</p>
End If

@If Model.PageCount > 1 Then
    @<div>
        Página @(If(Model.PageCount < Model.PageNumber, 0, Model.PageNumber)) de @Model.PageCount
     
        @If (Model.HasPreviousPage) Then
            @Html.ActionLink("<<", "Index", New With {.pagina = 1})
            @Html.Raw(" ")
            @Html.ActionLink("< Anterior", "Index", New With {.pagina = Model.PageNumber - 1})
        else
            @:<<
            @Html.Raw(" ")
            @:< Anterior
        End If
     
        @If (Model.HasNextPage) Then
            @Html.ActionLink("Próxima >", "Index", New With {.pagina = Model.PageNumber + 1})
            @Html.Raw(" ")
            @Html.ActionLink(">>", "Index", New With {.pagina = Model.PageCount})
        else
            @:Próxima >
            @Html.Raw(" ")
            @:>>
        End If
    </div>
End If