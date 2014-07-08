Imports System.Data.Entity
Imports CorrenteDeOracoes
Imports CorrenteDeOracoes.Models
Imports Norm
Imports PagedList

Namespace CorrenteDeOracoes
    Public Class UsuarioController
        Inherits System.Web.Mvc.Controller

        Private db As MongoDBContext = New MongoDBContext

        '
        ' GET: /Usuario/
        <Authorize()>
        Function Index() As ViewResult
            Dim usuario As Usuario
            Dim userID As Guid = Guid.Parse(User.Identity.Name)

            Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                usuario = db.GetCollection(Of Usuario).AsQueryable().FirstOrDefault(Function(u) u.id = userID)

                ViewBag.qtdPedidos = db.GetCollection(Of Pedido).Find().Count(Function(p) p.usuario = Guid.Parse(User.Identity.Name))
                ViewBag.qtdTestemunhos = db.GetCollection(Of Testemunho).Find().Count(Function(t) t.usuario = Guid.Parse(User.Identity.Name))
                ViewBag.qtdOraramPorMim =
                    (From p In db.GetCollection(Of Pedido).Find
                        Where p.usuario = usuario.id).Sum(Function(p) p.qtdOrando)

            End Using

            Return View(usuario)
        End Function

        '
        ' GET: /Usuario/Create
        Function Create As ViewResult
            Return View(New Usuario)
        End Function

        '
        ' POST: /Usuario/Create

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(usuario As Usuario) As ActionResult
            If ModelState.IsValid Then
                Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                    db.GetCollection(Of Usuario).Save(usuario)
                End Using

                Return RedirectToAction("Index", "Home")
            End If

            Return View(usuario)
        End Function
        
        '
        ' GET: /Usuario/Edit/5
        <Authorize()>
        Function Edit() As ViewResult
            Dim usuario As Usuario
            Dim userID As Guid = Guid.Parse(User.Identity.Name)

            Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                usuario = db.GetCollection(Of Usuario).AsQueryable().FirstOrDefault(Function(u) u.id = userID)
            End Using

            Return View(usuario)
        End Function

        '
        ' POST: /Usuario/Edit/5
        <Authorize()>
        <HttpPost()>
        Function Edit(usuario As Usuario) As ActionResult
            If ModelState.IsValid Then
                Dim userID As Guid = Guid.Parse(User.Identity.Name)
                Dim userRep As New UsuarioRepositorio
                usuario = userRep.getUsuarioLogado

                Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                    db.GetCollection(Of Usuario).Save(usuario)
                End Using

                Return RedirectToAction("Index")
            End If

            Return View(Usuario)
        End Function

        <Authorize()>
        Function meusPedidos(Optional pagina As Integer = 1) As ActionResult
            Dim pedidos As List(Of Pedido)
            Dim userRep As New UsuarioRepositorio
            Dim usuario As Usuario = userRep.getUsuarioLogado

            ViewBag.nomeUsuario = usuario.primeiroNome

            Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                pedidos =
                    (From p In db.GetCollection(Of Pedido).Find
                     Where p.usuario = Guid.Parse(User.Identity.Name)
                     ).OrderByDescending(Function(p) p.data).ToList()

                ViewBag.qtdPedidos = pedidos.Count
                ViewBag.qtdOracoes =
                    (From p In db.GetCollection(Of Pedido).Find
                     Where p.usuario = Guid.Parse(User.Identity.Name)
                     ).Sum(Function(p) p.qtdOrando)
            End Using

            Return View(pedidos.ToPagedList(pagina, 10))
        End Function

        Function meusTestemunhos(Optional pagina As Integer = 1) As ActionResult
            Dim testemunho As List(Of Testemunho)
            Dim userRep As New UsuarioRepositorio
            Dim usuario As Usuario = userRep.getUsuarioLogado

            ViewBag.nomeUsuario = usuario.primeiroNome

            Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                testemunho =
                    (From t In db.GetCollection(Of Testemunho).Find
                     Where t.usuario = Guid.Parse(User.Identity.Name)
                     ).OrderByDescending(Function(t) t.data).ToList()

                ViewBag.qtdTestemunhos = testemunho.Count
            End Using

            Return View(testemunho.ToPagedList(pagina, 10))
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace