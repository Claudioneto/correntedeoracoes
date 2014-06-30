Imports System.ComponentModel.DataAnnotations

Public Class Testemunho
    Public Sub New()
        Me.id = Guid.NewGuid
    End Sub

    Public Property id As Guid
    <Required()>
    <Display(Name:="Conte como foi")>
    Public Property descricao As String

    <Required()>
    <Display(Name:="Data")>
    Public Property data As Date
    Public Property pedido As Guid
End Class
