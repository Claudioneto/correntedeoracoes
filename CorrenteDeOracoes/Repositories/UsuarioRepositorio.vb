Imports Norm

Public Class UsuarioRepositorio
    Public Function AutenticarUsuario(email As String, senha As String) As Boolean
        Dim user As Usuario

        Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
            user =
                (From u In db.GetCollection(Of Usuario).AsQueryable
                Where u.email Is email And
                u.senha Is senha
                Select u).FirstOrDefault

            If Not user Is Nothing Then
                If user.email <> email Or user.senha <> senha Then user = Nothing

                user.dataPenultimoAcesso = user.dataUltimoAcesso
                user.dataUltimoAcesso = Date.Now
                db.GetCollection(Of Usuario).Save(user)
            End If
        End Using

        If user Is Nothing Then
            Return False
        End If

        FormsAuthentication.SetAuthCookie(user.id.ToString, False)
        Return True
    End Function

    Public Function getUsuarioLogado() As Usuario
        Dim idUsuario As String = HttpContext.Current.User.Identity.Name

        If idUsuario Is Nothing Then
            Return Nothing
        Else
            Dim user As Usuario
            Using db = Mongo.Create(ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString())
                user = db.GetCollection(Of Usuario).AsQueryable().FirstOrDefault(Function(u) u.id = Guid.Parse(idUsuario))
            End Using

            If user Is Nothing Then
                deslogar()
                Return Nothing
            End If

            Return user
        End If
    End Function

    Public Sub deslogar()
        FormsAuthentication.SignOut()
    End Sub
End Class