@Code
    ViewData("Title") = "CorrenteDeOrações"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<script type="text/javascript">
    function estouOrando(pedido, pagina){
        console.log(pedido);

        $.ajax({
            type: 'POST',
            url: 'home/EstouOrando/' + pedido +'?pagina='+pagina,
            dataType: 'html',
            success: function(retorno){
                $('#ultimosPedidos').html(retorno);
            }
        });
    }
</script>

<div class="row" id="versiculo">
    <h1>Confessai as vossas culpas uns aos outros, e orai uns pelos outros, para que sareis. A oração feita por um justo pode muito em seus efeitos.</h1>
    <p>Tiago 5:16</p>
</div>

<div id="ultimosPedidos" class="col-sm-8">
    @Code
        Html.RenderPartial("EstouOrando")
    End Code
</div>

<div class="col-sm-4">
    <h3>Introdução</h3>
    <p><strong>Corrente De Orações</strong> tem o intuito de intercedermos uns pelos outros, inclusive por aqueles que nem ao menos conhecemos.</p>
    <p>No versículo em detaque acima, a Palavra de Deus nos diz que a oração de um justo pode muito em seus efeitos, então que coloquemos nossa fé em prática para interceder pelas necessidades uns dos outros.</p>
    <p>Faça um pedido de oração e ore por seus irmãos, vamos aumentar cada vez mais essa corrente!</p>
</div>
    