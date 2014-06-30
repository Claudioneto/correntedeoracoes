Imports System.ComponentModel.DataAnnotations

Public Class CustomValidationCPFAttribute
    Inherits ValidationAttribute
    

    Public Sub New()

    End Sub

    Public Overrides Function IsValid(value As Object) As Boolean
        If value Is Nothing Or String.IsNullOrEmpty(value) Then
            Return True
        End If

        Dim valido As Boolean = validaCPF(value.ToString)
        Return valido
    End Function

    Public Function GetClientValidationRules(metadata As ModelMetadata, context As ControllerContext) As IEnumerable(Of ModelClientValidationRule)
        Return New ModelClientValidationRule() With {.ErrorMessage = Me.FormatErrorMessage(Nothing), .ValidationType = "customvalidationcpf"}
    End Function

    Private Function RemoveNaoNumericos(text As String) As String
        Dim reg As New System.Text.RegularExpressions.Regex("[^0-9]")
        Dim ret As String = reg.Replace(text, String.Empty)
        Return ret
    End Function

    Private Function ValidaCPF(cpf As String) As Boolean
        'Remove formatação do número, ex: "123.456.789-01" vira: "12345678901"
        cpf = RemoveNaoNumericos(cpf)

        If cpf.Length > 11 Then
            Return False
        End If

        While cpf.Length <> 11
            cpf = "0" & cpf
        End While

        Dim igual As Boolean = True
        Dim i As Integer = 1
        While i < 11 AndAlso igual
            If cpf(i) <> cpf(0) Then
                igual = False
            End If
            i += 1
        End While

        If igual OrElse cpf = "12345678909" Then
            Return False
        End If

        Dim numeros As Integer() = New Integer(10) {}

        For i = 0 To 10
            numeros(i) = Integer.Parse(cpf(i).ToString())
        Next

        Dim soma As Integer = 0
        For i = 0 To 8
            soma += (10 - i) * numeros(i)
        Next

        Dim resultado As Integer = soma Mod 11

        If resultado = 1 OrElse resultado = 0 Then
            If numeros(9) <> 0 Then
                Return False
            End If
        ElseIf numeros(9) <> 11 - resultado Then
            Return False
        End If

        soma = 0
        For i = 0 To 9
            soma += (11 - i) * numeros(i)
        Next

        resultado = soma Mod 11

        If resultado = 1 OrElse resultado = 0 Then
            If numeros(10) <> 0 Then
                Return False
            End If
        ElseIf numeros(10) <> 11 - resultado Then
            Return False
        End If

        Return True
    End Function

End Class
