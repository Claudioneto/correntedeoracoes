Imports Norm
Imports System.Net
Imports Newtonsoft.Json.Linq
Imports PagedList

Namespace CorrenteDeOracoes
    Public Class HomeController
        Inherits System.Web.Mvc.Controller

        ' GET: /Home

        Function Index(Optional pagina As Integer = 1) As ActionResult
            Dim pedidos As List(Of Pedido)
            Dim tamanhoPagina As Integer = 10

            Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                pedidos = db.GetCollection(Of Pedido).Find().OrderByDescending(Function(u) u.data).ToList
            End Using

            Return View(pedidos.ToPagedList(pagina, tamanhoPagina))
        End Function

        Function Logar() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Logar(email As String, senha As String, Optional returnURL As String = "") As ActionResult
            Dim user As New UsuarioRepositorio

            If user.AutenticarUsuario(email, senha) = False Then
                ViewBag.msgError = "Usuário ou senha inválidos"
                Return View()
            End If

            If returnURL <> "" Then
                Dim qtd As Integer = returnURL.ToString.Count - returnURL.ToString.Replace("/", "").Count
                Dim acao As String
                Dim controller As String
                If qtd = 1 Then
                    acao = "index"
                    controller = Replace(returnURL, "/", "")
                Else
                    Dim arrAcao As Array = Split(returnURL, "/")
                    controller = arrAcao(1)
                    acao = arrAcao(2)
                End If
                Return RedirectToAction(acao, controller)
            End If

            Return RedirectToAction("index")
        End Function

        Public Function loggout()
            Dim user As New UsuarioRepositorio

            user.deslogar()

            Return RedirectToAction("index")
        End Function

        Public Function FacebookLogin(authResponse As String, Optional returnURL As String = "") As ActionResult

            Dim client As WebClient = New WebClient()
            Dim JsonResult As String = client.DownloadString(String.Concat("https://graph.facebook.com/me?access_token=", authResponse))

            Dim jsonUserInfo As JObject = JObject.Parse(JsonResult)

            Dim idFacebook As String = jsonUserInfo.Value(Of String)("id")

            Dim user As Usuario

            Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                user =
                    (From u In db.GetCollection(Of Usuario).AsQueryable
                    Where u.idFacebook Is idFacebook
                    Select u).FirstOrDefault()

                If user Is Nothing Then
                    user = New Usuario
                End If
                user.primeiroNome = jsonUserInfo.Value(Of String)("first_name")
                user.sobrenome = jsonUserInfo.Value(Of String)("last_name")
                user.idFacebook = idFacebook
                user.linkFacebook = jsonUserInfo.Value(Of String)("link")
                user.sexo = IIf(jsonUserInfo.Value(Of String)("gender") <> jsonUserInfo.Value(Of String)("gender"), jsonUserInfo.Value(Of String)("gender"), user.sexo)
                user.email = IIf(jsonUserInfo.Value(Of String)("email") <> "", jsonUserInfo.Value(Of String)("email"), user.email)
                user.dataPenultimoAcesso = user.dataUltimoAcesso
                user.dataUltimoAcesso = Date.Now

                db.GetCollection(Of Usuario).Save(user)
            End Using

            FormsAuthentication.SetAuthCookie(user.id.ToString, False)

            If returnURL <> "" Then
                Dim qtd As Integer = returnURL.ToString.Count - returnURL.ToString.Replace("/", "").Count
                Dim acao As String
                Dim controller As String
                If qtd = 1 Then
                    acao = "index"
                    controller = Replace(returnURL, "/", "")
                Else
                    Dim arrAcao As Array = Split(returnURL, "/")
                    controller = arrAcao(1)
                    acao = arrAcao(2)
                End If
                Return RedirectToAction(acao, controller)
            End If

            Return RedirectToAction("index")
        End Function

        <HttpPost()>
        Public Function EstouOrando(Optional id As String = "", Optional pagina As Integer = 1) As PartialViewResult
            Dim pedidos As List(Of Pedido)
            Dim tamanhoPagina As Integer = 10

            If Request.IsAuthenticated And Not id Is Nothing Then
                Dim usuario As Usuario
                Dim pedidoOrado As Pedido
                Dim userId As Guid = Guid.Parse(User.Identity.Name)
                Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                    'Pega usuário logado
                    usuario = db.GetCollection(Of Usuario).AsQueryable.FirstOrDefault(Function(u) u.id = userId)

                    'Pega pedido marcado como orando
                    pedidoOrado = db.GetCollection(Of Pedido).AsQueryable.FirstOrDefault(Function(p) p.id = Guid.Parse(id))

                    'Adiciona mais uma oração na contagem e atualiza o banco
                    pedidoOrado.qtdOrando = pedidoOrado.qtdOrando + 1
                    db.GetCollection(Of Pedido).Save(pedidoOrado)

                    'Adiciona o pedido na lista de orações e atualiza o banco
                    If usuario.oreiPor Is Nothing Then
                        usuario.oreiPor = New List(Of Guid)
                    End If
                    usuario.oreiPor.Add(Guid.Parse(id))
                    db.GetCollection(Of Usuario).Save(usuario)

                    pedidos = db.GetCollection(Of Pedido).Find().OrderByDescending(Function(u) u.data).ToList
                End Using
            Else
                Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                    pedidos = db.GetCollection(Of Pedido).Find().OrderByDescending(Function(u) u.data).ToList
                End Using
            End If

            Return PartialView(pedidos.ToPagedList(pagina, tamanhoPagina))
        End Function

        Function termos() As ActionResult

            Return View()
        End Function

        Function privacidade() As ActionResult

            Return View()
        End Function

        Function missao() As ActionResult

            Return View()
        End Function

        Function quemsomos() As ActionResult

            Return View()
        End Function
    End Class
End Namespace
