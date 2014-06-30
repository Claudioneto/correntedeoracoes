Public Class Tag
    Public Sub New()
        Me.id = Guid.NewGuid
        Me.quantidade = 1
    End Sub

    Public Property id As Guid
    Public Property tag As String
    Public Property quantidade As Long
End Class
