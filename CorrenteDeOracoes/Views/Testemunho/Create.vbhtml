@ModelType CorrenteDeOracoes.Testemunho

@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Create</h2>

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

<div class="row" id="versiculo">
    <h1>E, tudo o que pedirdes em oração, crendo, o recebereis</h1>
    <p>Mateus 21:22</p>
</div>

@If ViewBag.descricaoPedido <> "" Then
    @<div class="row pedido">
        @ViewBag.descricaoPedido <br />
        @ViewBag.dataPedido <br />
        @ViewBag.qtdOraram <br />
    </div>
End if

<div class="row col-sm-10">
    @Using Html.BeginForm("create", "testemunho", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
        @Html.ValidationSummary(True)
            @<div class="form-group">
                @Html.LabelFor(Function(model) model.descricao)
        
                @Html.TextAreaFor(Function(model) model.descricao, 5, 10, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.descricao)
            </div>

            @<div class="editor-label">
                @Html.LabelFor(Function(model) model.data)
            </div>
            @<div class="editor-field">
                @Html.TextBoxFor(Function(model) model.data, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.data)
            </div>

            @<p>
                <input type="submit" value="Salvar" class="btn btn-success" />
            </p>
    End Using
</div>