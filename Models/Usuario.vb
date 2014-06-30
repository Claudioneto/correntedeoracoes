Imports System.ComponentModel.DataAnnotations

Public Class Usuario
    Public Sub New()
        Me.id = Guid.NewGuid
        Me.ativo = True
        Me.dataCadastro = Date.Now
        Me.dataUltimoAcesso = Date.Now
    End Sub

    Public Property id As Guid

    <Display(Name:="Primeiro nome")> _
    <Required(ErrorMessage:="Por favor, preencha seu nome")>
    Public Property primeiroNome As String

    <Display(Name:="Sobrenome")> _
    <Required(ErrorMessage:="Por favor, preencha seu sobrenome")>
    Public Property sobrenome As String

    <Display(Name:="Sexo")> _
    <Required(ErrorMessage:="Por favor, selecione seu sexo")>
    Public Property sexo As String

    <Display(Name:="E-mail")> _
    <RegularExpression("^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$", ErrorMessage:="Por favor, digite um e-mail válido")> _
    <Required(ErrorMessage:="O e-mail não pode ficar em branco")>
    Public Property email As String

    <Display(Name:="Insira uma senha")> _
    <Required(ErrorMessage:="Por favor, preencha sua senha")>
    Public Property senha As String

    <Display(Name:="CPF")> _
    <Required(ErrorMessage:="Por favor, preencha seu CPF")> _
    <CustomValidationCPF(ErrorMessage:="CPF inválido")>
    Public Property cpf As String

    Public Property idFacebook As String
    Public Property idGoogle As String
    Public Property linkFacebook As String
    Public Property ativo As Boolean
    Public Property dataCadastro As Date
    Public Property dataUltimoAcesso As Date
    Public Property foto As String

    <Display(Name:="Cidade")>
    Public Property cidade As String

    <Display(Name:="Estado")>
    Public Property estado As String

    <Display(Name:="Frequenta alguma igreja? Qual?")>
    Public Property igreja As String

    Public Property oreiPor As List(Of Guid)
End Class
