@ModelType CorrenteDeOracoes.Pedido
@imports norm

@Code
    ViewData("Title") = "CorrenteDeOrações - Realizar um pedido"
End Code

@section styles
    <link href="@Url.Content("~/Content/jquery.tagsinput.css")" rel="stylesheet" type="text/css" />
End Section

<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.tagsinput.min.js")" type="text/javascript"></script>

<div class="row" id="versiculo">
    <h1>E, tudo o que pedirdes em oração, crendo, o recebereis</h1>
    <p>Mateus 21:22</p>
</div>

@Using Html.BeginForm("create", "pedido", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
    @Html.ValidationSummary(True)
    @<div class="col-sm-12">
        <div class="form-group">
            @Html.LabelFor(Function(model) model.descricao)

            @Html.TextAreaFor(Function(model) model.descricao, 5, 10, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.descricao)
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.apelido)

            @Html.TextBoxFor(Function(model) model.apelido, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.apelido)
        </div>
        <div class="form-group">
            <label for="tagsPedido">Digite tags que identifiquem seu pedido. Ex: Emprego, doença, relacionamento, carro novo</label>
            <input type="text" name="tagsPedido" id="tagsPedido" />
        </div>
        <p>
            <input type="submit" value="Confirmar" class="btn btn-success" />
        </p>
    </div>
End Using

<div style="width:728px;margin:0 auto;">
    <p class="publicidade">Publicidade</p>
    <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
    <!-- CDO-NovoPedido -->
    <ins class="adsbygoogle"
         style="display:inline-block;width:728px;height:90px"
         data-ad-client="ca-pub-1017535286769229"
         data-ad-slot="9244333631"></ins>
    <script>
        (adsbygoogle = window.adsbygoogle || []).push({});
    </script>
</div>

<script type="text/javascript">
    $('#tagsPedido').tagsInput({
        'width':'100%',
        'height':'40px',
        'defaultText':'Add Tags',
        'interactive':true,
    });

    $('#tagsPedido_tagsinput').addClass("form-control");
</script>