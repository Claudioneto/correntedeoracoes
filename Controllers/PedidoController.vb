Imports System.Data.Entity
Imports CorrenteDeOracoes
Imports CorrenteDeOracoes.Models
Imports Norm

Namespace CorrenteDeOracoes
    Public Class PedidoController
        Inherits System.Web.Mvc.Controller

        Private db As MongoDBContext = New MongoDBContext

        '
        ' GET: /Pedido/

        Function Index(Optional tag As String = "") As ViewResult
            Dim pedidos As List(Of Pedido)
            Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                If tag <> "" Then
                    pedidos =
                        (From p In db.GetCollection(Of Pedido).Find
                            where p.tags.Contains(tag) And
                            p.data >= DateAdd(DateInterval.Day,-30, Date.Today)
                            ).OrderByDescending(Function(p) p.data).ToList
                Else
                    pedidos = db.GetCollection(Of Pedido).Find(Function(p) p.data >= DateAdd(DateInterval.Day, -30, Date.Today)).OrderByDescending(Function(p) p.data).ToList
                End If

            End Using
            Return View(pedidos)
        End Function

        '
        ' GET: /Pedido/Details/5

        Function Details(id As Guid) As ViewResult
            Try
                Dim pedidos As List(Of Pedido) = New List(Of Pedido)
                Dim pedidoPrincipal As Pedido
                Dim outrosPedidos As List(Of Pedido) = New List(Of Pedido)

                Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                    pedidoPrincipal = db.GetCollection(Of Pedido).AsQueryable().FirstOrDefault(Function(p) p.id = id)
                    pedidos.Add(pedidoPrincipal)

                    For Each strTag As String In pedidoPrincipal.tags
                        outrosPedidos =
                            (From p In db.GetCollection(Of Pedido).Find
                                Where p.tags.Contains(strTag) And
                                p.id <> id
                                ).OrderByDescending(Function(p) p.data).Take(5).ToList
                        For Each pedido As Pedido In outrosPedidos
                            If Not pedidos.Contains(pedido) Then pedidos.Add(pedido)
                        Next
                    Next
                End Using

                Return View(pedidos)
            Catch
                Return View()
            End Try
        End Function

        '
        ' GET: /Pedido/Create
        <Authorize()>
        Function Create() As ViewResult
            Dim apelido As String = ""
            Dim usuario As Usuario

            Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                usuario = db.GetCollection(Of Usuario).AsQueryable.FirstOrDefault(Function(u) u.id = Guid.Parse(User.Identity.Name))
            End Using

            If Not usuario Is Nothing Then
                apelido = usuario.primeiroNome

                If usuario.cidade <> "" Then apelido = apelido & " de " & usuario.cidade
                If usuario.estado <> "" Then apelido = apelido & "/" & usuario.estado
            End If

            Dim pedido As Pedido = New Pedido
            pedido.apelido = apelido

            Return View(pedido)
        End Function

        '
        ' POST: /Pedido/Create
        <HttpPost()>
        <Authorize()>
        Function Create(pedido As Pedido) As ActionResult
            If ModelState.IsValid Then
                Dim usuario As Usuario
                Dim userID As Guid = Guid.Parse(User.Identity.Name)

                Dim strTags As String = Request.Form("tagsPedido")
                Dim arrTags As Array = Split(strTags, ",")
                Dim tag As Tag

                Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())

                    If strTags <> "" Then
                        For Each strTag As String In arrTags
                            If LCase(strTag) <> "orar" And LCase(strTag) <> "oração" And LCase(strTag) <> "oracao" And LCase(strTag) <> "pedido" And LCase(strTag) <> "deus" And LCase(strTag) <> "jesus" And Len(strTag) >= 3 Then
                                tag = db.GetCollection(Of Tag).AsQueryable().FirstOrDefault(Function(t) t.tag Is strTag)

                                If Not tag Is Nothing Then
                                    tag.quantidade = tag.quantidade + 1
                                Else
                                    tag = New Tag
                                    tag.tag = strTag
                                End If

                                db.GetCollection(Of Tag).Save(tag)

                                pedido.tags.Add(strTag)
                            End If
                        Next
                    End If

                    usuario = db.GetCollection(Of Usuario).AsQueryable.FirstOrDefault(Function(u) u.id = userID)

                    pedido.usuario = usuario
                    db.GetCollection(Of Pedido).Save(pedido)
                End Using

                Return RedirectToAction("details", "pedido", New With {.id = pedido.id})
            End If

            Return View(pedido)
        End Function
        
        '
        ' GET: /Pedido/Edit/5
        Function Edit(id As Guid) As ViewResult
            Dim pedido As Pedido = db.Pedidoes.Find(id)
            Return View(pedido)
        End Function

        '
        ' POST: /Pedido/Edit/5

        <HttpPost()>
        Function Edit(pedido As Pedido) As ActionResult
            If ModelState.IsValid Then
                db.Entry(pedido).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(pedido)
        End Function

        '
        ' GET: /Pedido/Delete/5
 
        Function Delete(id As Guid) As ViewResult
            Dim pedido As Pedido = db.Pedidoes.Find(id)
            Return View(pedido)
        End Function

        '
        ' POST: /Pedido/Delete/5

        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(id As Guid) As RedirectToRouteResult
            Dim pedido As Pedido = db.Pedidoes.Find(id)
            db.Pedidoes.Remove(pedido)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace