Imports System.ComponentModel.DataAnnotations

Public Class Testemunho
    Public Sub New()
        Me.id = Guid.NewGuid
        Me.data = Date.Today
    End Sub

    Public Property id As Guid
    <Required()>
    <Display(Name:="Descreva seu testemunho")>
    Public Property descricao As String

    <Required()>
    <Display(Name:="Data")>
    Public Property data As Date
    Public Property pedido As Guid
End Class
