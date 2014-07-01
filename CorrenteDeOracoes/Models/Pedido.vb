Imports System.ComponentModel.DataAnnotations

Public Class Pedido
    Public Sub New()
        Me.id = Guid.NewGuid
        Me.excluido = False
        Me.data = Date.Now
        Me.qtdOrando = 0
        Me.tags = New List(Of String)
        Me.pedidoAtendido = False
    End Sub

    Public Property id As Guid

    <Required()>
    <Display(Name:="Descreva seu pedido de oração")>
    Public Property descricao As String
    Public Property data As Date
    Public Property qtdOrando As Integer
    Public Property excluido As Boolean
    Public Property dataExclusao As Date

    <Required()>
    <Display(Name:="Como desejar ser identificado?")>
    Public Property apelido As String
    Public Property usuario As Guid

    <Display(Name:="Digite tags que identifiquem seu pedido. Ex: Emprego, doença, relacionameto, carro novo")>
    Public Property tags As List(Of String)
    Public Property pedidoAtendido As Boolean
End Class