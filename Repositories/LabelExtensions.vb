Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Linq.Expressions
Imports System.Runtime.CompilerServices


Public Module LabelExtensions
    Sub New()
    End Sub

    <Extension()> _
    Public Function LabelFor(Of TModel, TValue)(html As HtmlHelper(Of TModel), expression As Expression(Of Func(Of TModel, TValue)), htmlAttributes As Object) As MvcHtmlString
        Return LabelFor(html, expression, New RouteValueDictionary(htmlAttributes))
    End Function

    <Extension()> _
    Public Function LabelFor(Of TModel, TValue)(html As HtmlHelper(Of TModel), expression As Expression(Of Func(Of TModel, TValue)), htmlAttributes As IDictionary(Of String, Object)) As MvcHtmlString
        Dim metadata As ModelMetadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData)
        Dim htmlFieldName As String = ExpressionHelper.GetExpressionText(expression)
        Dim labelText As String = If(metadata.DisplayName, If(metadata.PropertyName, htmlFieldName.Split("."c).Last()))

        If [String].IsNullOrEmpty(labelText) Then
            Return MvcHtmlString.Empty
        End If

        Dim tag As New TagBuilder("label")
        tag.MergeAttributes(htmlAttributes)
        tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName))
        tag.SetInnerText(labelText)

        Return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal))
    End Function
End Module


