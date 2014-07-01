@ModelType CorrenteDeOracoes.Testemunho

@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@section styles
    <link href="@Url.Content("~/Content/jquery-ui-1.10.4.custom.min.css")" rel="stylesheet" type="text/css" />
End Section

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery-ui-1.10.4.custom.min.js")" type="text/javascript"></script>

<div class="row" id="versiculo">
    <h1>E, tudo o que pedirdes em oração, crendo, o recebereis</h1>
    <p>Mateus 21:22</p>
</div>

<div class="col-sm-9">
    @If ViewBag.descricaoPedido <> "" Then
        @<div class="row pedido">
            <p style="font-weight:bold;font-size:16px;">@ViewBag.descricaoPedido</p>
            <p>Data: @ViewBag.dataPedido </p>
            <p>Você recebeu @ViewBag.qtdOraram orações por seu pedido</p>
        </div>
    End if
    <br />
    @Using Html.BeginForm("create", "testemunho", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
        @Html.ValidationSummary(True)
            @<div class="form-group">
                @Html.LabelFor(Function(model) model.descricao)
        
                @Html.TextAreaFor(Function(model) model.descricao, 5, 10, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.descricao)
            </div>

            @<div class="form-group">
                @Html.LabelFor(Function(model) model.data)

                <input type="text" name="data" id="data" value="@Model.data.ToString("dd/MM/yyyy")" class="form-control" />
                @Html.ValidationMessageFor(Function(model) model.data)
            </div>

            @<p>
                <input type="submit" value="Salvar" class="btn btn-success" />
            </p>
    End Using
</div>

<div class="col-sm-3">
    <p class="publicidade">Publicidade</p>

    <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
    <!-- CDO-NovoTestemunho -->
    <ins class="adsbygoogle cdo-novotestemunho"
         style="display:inline-block"
         data-ad-client="ca-pub-1017535286769229"
         data-ad-slot="5217760035"></ins>
    <script>
        (adsbygoogle = window.adsbygoogle || []).push({});
    </script>
</div>

<script type="text/javascript">
    $('#data').datepicker({ dateFormat: "dd/mm/yy"});
</script>