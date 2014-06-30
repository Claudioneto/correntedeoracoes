Imports System.Data.Entity
Imports Norm

Imports CorrenteDeOracoes

Namespace Models

    Public Class MongoDBContext
        Inherits DbContext

        Public Sub New()
            MyBase.New()

            strCon = ConfigurationManager.ConnectionStrings("MongoConnection").ConnectionString.ToString()
        End Sub

        Private strCon As String

        Private pedido As List(Of Pedido)
        Public Property Pedidos() As List(Of Pedido)
            Get
                Dim retval As List(Of Pedido) = New List(Of Pedido)
                Using db = Mongo.Create(strCon)
                    retval = db.GetCollection(Of Pedido).Find().ToList()
                End Using

                Return retval
            End Get
            Set(value As List(Of Pedido))
                pedido = value
            End Set
        End Property

        Private tag As List(Of Tag)
        Public Property Tags() As List(Of Tag)
            Get
                Dim retval As List(Of Tag) = New List(Of Tag)
                Using db = Mongo.Create(strCon)
                    retval = db.GetCollection(Of Tag).Find().ToList()
                End Using

                Return retval
            End Get
            Set(value As List(Of Tag))
                tag = value
            End Set
        End Property

        Private Testemunho As List(Of Testemunho)
        Public Property Testemunhos() As List(Of Testemunho)
            Get
                Dim retval As List(Of Testemunho) = New List(Of Testemunho)
                Using db = Mongo.Create(strCon)
                    retval = db.GetCollection(Of Testemunho).Find().ToList()
                End Using

                Return retval
            End Get
            Set(value As List(Of Testemunho))
                Testemunho = value
            End Set
        End Property

        Private usuario As List(Of Usuario)
        Public Property Usuarios() As List(Of Usuario)
            Get
                Dim retval As List(Of Usuario) = New List(Of Usuario)
                Using db = Mongo.Create(strCon)
                    retval = db.GetCollection(Of Usuario).Find().ToList()
                End Using

                Return retval
            End Get
            Set(value As List(Of Usuario))
                usuario = value
            End Set
        End Property

        Public Property Testemunhoes As DbSet(Of Testemunho)
        Public Property Usuarioes As DbSet(Of Usuario)
        Public Property Pedidoes As DbSet(Of Pedido)
    End Class


End Namespace


