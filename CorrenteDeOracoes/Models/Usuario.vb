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

    <Display(Name:="Insira uma senha")>
    <RegularExpression("^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage:="Sua senha precisa ter no mínimo 8 caracteres e possuir pelo menos um número e uma letra")>
    <Required(ErrorMessage:="O campo senha é de preenchimento obrigatório")>
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
    Public Property dataPenultimoAcesso As Date
    Public Property foto As String

    <Display(Name:="Cidade")>
    Public Property cidade As String

    <Display(Name:="Estado")>
    Public Property estado As String

    <Display(Name:="Frequenta alguma igreja? Qual?")>
    Public Property igreja As String

    Public Property oreiPor As New List(Of Guid)

    Public Function geraSenha()
        Dim a, i, s
        For i = 48 To 90
            If i < 58 Or i > 64 Then
                a = a & Chr(i) & " "
            End If
        Next

        a = Split(LCase(a) & a)
        Randomize()
        For i = 1 To 8
            s = s & a(Int(UBound(a) * Rnd()))
        Next

        Dim v As Match = Regex.Match(s, "^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", RegexOptions.IgnoreCase)
        Do Until v.Success
            s = Mid(s, 1, Len(s) - 1) & "1"
            v = Regex.Match(s, "^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", RegexOptions.IgnoreCase)
        Loop

        Return s
    End Function
End Class
