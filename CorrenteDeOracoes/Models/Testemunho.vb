Public Class Testemunho
    Public Sub New()
        Me.id = Guid.NewGuid
    End Sub

    Public Property id As Guid
    Public Property descricao As String
    Public Property data As Date
    Public Property pedido As Pedido
End Class
