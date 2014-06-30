Imports System.Data.Entity
Imports CorrenteDeOracoes
Imports CorrenteDeOracoes.Models

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

        Function Create As ViewResult
            return View()
        End Function

        '
        ' POST: /Testemunho/Create

        <HttpPost()>
        Function Create(testemunho As Testemunho) As ActionResult
            If ModelState.IsValid Then
                testemunho.id = Guid.NewGuid()
                db.Testemunhoes.Add(testemunho)
                db.SaveChanges()
                Return RedirectToAction("Index")
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