﻿@imports norm

<!DOCTYPE html>
<html>
<head>
    <title>@ViewData("Title")</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/bootstrap.css")" rel="stylesheet" type="text/css" />
    
    @RenderSection("styles", required:=false)
    <script src="@Url.Content("~/Scripts/jquery-1.9.0.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/bootstrap.js")" type="text/javascript"></script>
    
    <meta name="keywords" content="Oracoes, cristianismo, Deus, orar, clamar, pedidos, testemunhos, cristao" />
    <meta name="company" content="CorrenteDeOracoes" />
    <meta name="revisit-after" content="1 day" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="Description" content="Ore por quem necessita!" />
    <meta name="title" content="Corrente de Orações" />
    <meta name="author" content="Claudio Rodrigues" />

    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
      m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-52383912-1', 'auto');
            ga('send', 'pageview');

    </script>
</head>

<body>
    <div class="container">
        <header>
            <div class="navbar navbar-default" role="navigation">
                <div class="container-fluid">
                <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-navbar-collapse-1">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        </button>
                        <a  href="/"><img src="../../Images/logo.png" alt="Corrente de Orações" /></a>
                    </div>

                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div class="collapse navbar-collapse navbar-right" id="bs-navbar-collapse-1">
                        <ul class="nav navbar-nav navbar-right">
                            <li><center><button onclick="location.href='../../pedido/create'" class="btn btn-default btn-lg navbar-btn">Peça uma oração!</button></center></li>
                            <li class="divider"></li>
                        @If Not Request.IsAuthenticated Then
                            @<li><a href="../../home/logar">Entrar</a></li>
                            @<li><a href="../../usuario/create">Cadastrar</a></li>
                        Else
                            Dim rep As New CorrenteDeOracoes.UsuarioRepositorio
                            Dim usuario As CorrenteDeOracoes.Usuario = rep.getUsuarioLogado
                            Dim nomeUsuario As String = ""
        
                            If Not usuario Is Nothing Then
                                nomeUsuario = usuario.primeiroNome
                            Else
                                
                            End If
                            @<li>@Html.ActionLink("Graça e Paz, " & nomeUsuario & "!", "index", "usuario")</li>
                            @<li class="divider"></li>
                            @<li>@Html.ActionLink("Seus pedidos", "meusPedidos", "usuario")</li>
                            @<li>@Html.ActionLink("Seus Testemunhos", "meusTestemunhos", "usuario")</li>
                            @<li>@Html.ActionLink("Sair","loggout","home")</li>
                        End If
                        </ul>
                    </div><!-- /.navbar-collapse -->
                </div><!-- /.container-fluid -->
            </div>
        </header>
        <div id="corpo">
            @RenderBody()
            <div style="clear:both"></div>
        </div>

        <div class="footer">
            <ul class="list-inline">
                <li><a href="../../home/termos">Termos de Uso</a></li>
                <li><a href="../../home/privacidade">Privacidade</a></li>
                <li><a href="../../home/missao">Nossa Missão</a></li>
                <li><a href="../../home/quemsomos">Quem Somos</a></li>
            </ul>
        </div>
    </div>
</body>
</html>