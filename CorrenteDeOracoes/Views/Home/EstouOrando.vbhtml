@imports norm
@ModelType PagedList.IPagedList(Of CorrenteDeOracoes.Pedido)

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

<h2>Últimos pedidos feitos, ore por eles:</h2>

@For Each pedido As CorrenteDeOracoes.Pedido In Model
    @<div class="col-sm-12 pedido">
        <span class="PedidoOracao">@Html.ActionLink(pedido.data.ToString("dd/MM/yy hh:mm"), "details", "pedido", New With {.id = pedido.id}, New With {.title = "Clique!"}) - @pedido.descricao</span><br />

        @If Not pedido.tags Is Nothing Then
            @<ul class="list-inline">
                <li>Tags: </li>
            @For Each tag As String In pedido.tags
              @<li><a href="../../pedido/index?tag=@tag" title="Clique aqui para visualizar pedidos semelhantes">@tag</a></li>
            Next
            </ul>
        End If

        <div class="col-sm-5">
            Ore por: <span class="Apelido">@pedido.apelido</span>
        </div>

        <div class="col-sm-7 qtdOrando">
        @If mostraBotao(pedido.id) Then
            @<button onclick="estouOrando('@pedido.id.ToString',@Model.PageNumber)" class="btn btn-xs btn-orar" title="Ore e marque que orou por esse pedido!">Estou Orando <img src="../../images/maoorando.png" alt="" /></button>
        ElseIf Request.IsAuthenticated Then
            @<img src="../../images/maoorando.png" alt="Você orou por esse pedido!" title="Você orou por esse pedido, Deus te abençoe!" />
        End If
        
                
        @If pedido.qtdOrando > 0 Then
            If pedido.qtdOrando = 1 Then
                @<span>1 pessoa orou!</span>
            Else
                @<span>@pedido.qtdOrando pessoas oraram!</span>
            End If
        Else
            @<span>Seja o primeiro a orar por esse pedido</span>
        End If
        </div>
    </div>
Next

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