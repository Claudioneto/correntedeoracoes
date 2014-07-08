@ModelType CorrenteDeOracoes.Usuario

@Code
    ViewData("Title") = Model.primeiroNome & " - CorrenteDeOrações"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<div class="row" id="versiculo">
    <h1>Mas agora em Cristo Jesus, vós, que antes estáveis longe, já pelo sangue de Cristo chegastes perto.</h1>
    <p>Efésios 2:13</p>
</div>

<div class="row pedido">
    <h1 style="color:black">@Model.primeiroNome @Model.sobrenome</h1>
    <p>Cadastrado desde: @Model.dataCadastro.ToString("dd/MM/yy")</p>

    <div class="col-sm-4">
        <h2 style="color:Black">Seus Dados:</h2>
        <p>E-mail: @Model.email</p>
        <p>CPF: @Model.cpf</p>
        <p>Cidade: @Model.cidade / @MOdel.estado</p>
        <p>Sua igreja: @Model.igreja</p>
        <p><button class="btn btn-primary btn-sm" onclick="window.location = '../../usuario/edit'">Editar dados</button></p>
    </div>

    <div class="col-sm-6">
        <h2 style="color:Black">Estatísticas:</h2>
        <p>Seu último acesso: @Model.dataUltimoAcesso</p>
        @If Year(Model.dataPenultimoAcesso) > 1 Then
            @<p>Penúltimo acesso: @Model.dataPenultimoAcesso</p>
        end if

        <p>Você realizou @ViewBag.qtdPedidos pedido(s) até o momento.
            @If ViewBag.qtsPedidos > 0 Then
                @: - <a href="../../usuario/meusPedidos">Ver seus pedidos</a>
            End If
        </p>
        <p>Você realizou @ViewBag.qtdPedidos testemunho(s) até o momento.
            @If ViewBag.qtdTestemunhos > 0 Then
                @: - <a href="../../usuario/meusTestemunhos">Ver seus testemunhos</a>
            End If
        </p>
        <p>Você já orou por @Model.oreiPor.Count pedido(s) até o momento</p>
        <p>@ViewBag.qtdOraramPorMim pessoas oraram por seus pedidos</p>
    </div>
    <div class="col-sm-2">
        <p class="publicidade">Publicidade</p>
        <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
        <!-- CDO-PerfilUsuario -->
        <ins class="adsbygoogle"
             style="display:block"
             data-ad-client="ca-pub-1017535286769229"
             data-ad-slot="4763114832"
             data-ad-format="auto"></ins>
        <script>
            (adsbygoogle = window.adsbygoogle || []).push({});
        </script>
    </div>
</div>