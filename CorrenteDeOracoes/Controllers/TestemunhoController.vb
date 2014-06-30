Imports System.Data.Entity
Imports CorrenteDeOracoes
Imports CorrenteDeOracoes.Models
Imports Norm

Namespace CorrenteDeOracoes
    Public Class TestemunhoController
        Inherits System.Web.Mvc.Controller

        Private db As MongoDBContext = New MongoDBContext

        '
        ' GET: /Testemunho/

        Function Index() As ViewResult
            Return View(db.Testemunhoes.ToList())
        End Function

        '
        ' GET: /Testemunho/Details/5

        Function Details(id As Guid) As ViewResult
            Dim testemunho As Testemunho = db.Testemunhoes.Find(id)
            Return View(testemunho)
        End Function

        '
        ' GET: /Testemunho/Create

        Function Create(Optional pedido As String = "") As ViewResult
            Dim testemunho As New Testemunho

            If pedido <> "" Then
                Dim ped As Pedido
                Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                    ped = db.GetCollection(Of Pedido).AsQueryable().FirstOrDefault(Function(p) p.id = Guid.Parse(pedido))

                    If Not ped Is Nothing Then
                        testemunho.pedido = Guid.Parse(pedido)

                        ViewBag.descricaoPedido = ped.descricao
                        ViewBag.dataPedido = ped.data.ToString("dd/MM/yy hh:mm")
                        ViewBag.qtdOraram = ped.qtdOrando
                    End If
                End Using
            End If

            Return View(testemunho)
        End Function

        '
        ' POST: /Testemunho/Create

        <HttpPost()>
        Function Create(testemunho As Testemunho) As ActionResult
            If ModelState.IsValid Then


                Return RedirectToAction("meusTestemunhos", "usuario")
            End If

            Return View(testemunho)
        End Function
        
        '
        ' GET: /Testemunho/Edit/5
 
        Function Edit(id As Guid) As ViewResult
            Dim testemunho As Testemunho = db.Testemunhoes.Find(id)
            Return View(testemunho)
        End Function

        '
        ' POST: /Testemunho/Edit/5

        <HttpPost()>
        Function Edit(testemunho As Testemunho) As ActionResult
            If ModelState.IsValid Then
                db.Entry(testemunho).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(testemunho)
        End Function

        '
        ' GET: /Testemunho/Delete/5
 
        Function Delete(id As Guid) As ViewResult
            Dim testemunho As Testemunho = db.Testemunhoes.Find(id)
            Return View(testemunho)
        End Function

        '
        ' POST: /Testemunho/Delete/5

        <HttpPost()>
        <ActionName("Delete")>
        Function DeleteConfirmed(id As Guid) As RedirectToRouteResult
            Dim testemunho As Testemunho = db.Testemunhoes.Find(id)
            db.Testemunhoes.Remove(testemunho)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace