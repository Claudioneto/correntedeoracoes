@ModelType IEnumerable(Of CorrenteDeOracoes.Pedido)
@imports norm

@Code
    ViewData("Title") = Model(0).descricao & " - CorrenteDeOrações"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

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

<div id="fb-root"></div>
<script type="text/javascript">
(function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/pt_BR/sdk.js#xfbml=1&version=v2.0";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));
</script>
<script type="text/javascript" src="https://apis.google.com/js/platform.js">
    { lang: 'pt-BR' }
</script>

<div class="row" id="versiculo">
    <h1>Confessai as vossas culpas uns aos outros, e orai uns pelos outros, para que sareis. A oração feita por um justo pode muito em seus efeitos.</h1>
    <p>Tiago 5:16</p>
</div>

<div class="row col-sm-12 pedido">
    <p class="PedidoOracao">@Html.ActionLink(Model(0).data.ToString("dd/MM/yy hh:mm"), "details", New With {.id = Model(0).id}) - @Model(0).descricao</p>

    @If Not Model(0).tags Is Nothing Then
        @<ul class="list-inline">
            <li>Tags: </li>
        @For Each tag As String In Model(0).tags
            @<li><a href="../../pedido/index?tag=@tag" title="Clique aqui para visualizar pedidos semelhantes">@tag</a></li>
        Next
        </ul>
    End If

    <div class="row">
        <div class="col-sm-5">
            Ore por: <span class="Apelido">@Model(0).apelido</span>
        </div>
    
        <div class="col-sm-7 qtdOrando">
            @If Guid.Parse(User.Identity.Name) <> Model(0).usuario Then
                If mostraBotao(Model(0).id) Then
                    @<button onclick="estouOrando('@Model(0).id.ToString')" class="btn btn-xs btn-orar" title="Ore e marque que orou por esse pedido!">Estou Orando <img src="../../images/maoorando.png" alt="" /></button>
                ElseIf Request.IsAuthenticated Then
                    @<img src="../../images/maoorando.png" alt="Você orou por esse pedido!" title="Você orou por esse pedido, Deus te abençoe!" />
                End If
            End If
        
            @If Model(0).qtdOrando > 0 Then
                If Model(0).qtdOrando = 1 Then
                    @:1 pessoa orou!
                Else
                    @Model(0).qtdOrando @:pessoas(oraram!)
                End If
            ElseIf Guid.Parse(User.Identity.Name) <> Model(0).usuario Then
                @:Seja o primeiro a orar por esse pedido
            End If
        </div>
    </div>
    <div class="row col-sm-12">
        <div class="fb-like" style="float:left;" data-href="@Request.Url.AbsoluteUri" data-layout="button_count" data-action="like" data-show-faces="false" data-share="true"></div>
        <div class="fb-like" style="float:left;margin-left:30px;">
            <a href="https://twitter.com/share" class="twitter-share-button" data-text="Ore por esse pedido!" data-lang="pt" data-hashtags="CorrenteDeOracoes">Tweetar</a>
            <script>    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } } (document, 'script', 'twitter-wjs');</script>
        </div>
        <div class="g-plusone" style="float:left;margin-left:20px;" data-size="medium" data-annotation="inline" data-width="200" data-href="@Request.Url.AbsoluteUri"></div>
    </div>
</div>

@If Model.Count > 1 Then
    @<div class="row">
        <div class="col-sm-9">
            <h2>Veja outros pedidos semelhantes:</h2>
            @For i As Integer = 1 To Model.Count - 1
                @<div class="row col-sm-12 pedido">
                    <p class="PedidoOracao">@Html.ActionLink(model(i).data.ToString("dd/MM/yy hh:mm"),"details",New With{.id = Model(i).id}) - @Model(i).descricao</p>

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
                            @If mostraBotao(Model(i).id) Then
                                @<button onclick="estouOrando('@Model(0).id.ToString')" class="btn btn-xs btn-orar" title="Ore e marque que orou por esse pedido!">Estou Orando <img src="../../images/maoorando.png" alt="" /></button>
                            ElseIf Request.IsAuthenticated Then
                                @<img src="../../images/maoorando.png" alt="Você orou por esse pedido!" title="Você orou por esse pedido, Deus te abençoe!" />
                            End If
        
                            @If Model(i).qtdOrando > 0 Then
                                If Model(i).qtdOrando = 1 Then
                                    @:1 pessoa orou!
                                Else
                                    @Model(i).qtdOrando @:pessoas(oraram!)
                                End If
                            Else
                                @:Seja o primeiro a orar por esse pedido
                            End If
                        </div>
                    </div>
                </div>
            Next
        </div>
    </div>
end if