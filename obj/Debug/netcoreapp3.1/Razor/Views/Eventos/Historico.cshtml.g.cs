#pragma checksum "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d32f9d5b2830b5d241f75bca903329248ff9c96c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Eventos_Historico), @"mvc.1.0.view", @"/Views/Eventos/Historico.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\_ViewImports.cshtml"
using GerenciamentoEvento;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\_ViewImports.cshtml"
using GerenciamentoEvento.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d32f9d5b2830b5d241f75bca903329248ff9c96c", @"/Views/Eventos/Historico.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee4b8b0451c58001231737cc1f3c1847b2a5d4a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Eventos_Historico : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GerenciamentoEvento.Models.Venda>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h2>Histórico de Compras</h2>

<script>
    $(document).ready( function () {
    $('#historico').DataTable({
        ""info"": true,
        ""language"":{
            ""lengthMenu"" : ""Mostrando _MENU_ registros por pagina"",
            ""zeroRecords"": ""Nada encontrado"",
            ""info"": ""Mostrando página _PAGE_ de _PAGES_"",
            ""infoEmpty"": ""Nenhum registro disponível"",
            ""search"": ""Buscar:"",
            ""paginate"":{
                ""first"": ""Primeira"",
                ""last"": ""Ultima"",
                ""next"": ""Próxima"",
                ""previous"": ""Anterior""
            }
        }

    });
    } );
</script>


   <table id=""historico"" class=""table table-striped table-bordered "" >
        <thead   style=""font-family:'Alegreya Sans'; background-color:#6E3667; color:white; text-align: center"">
            <th>
            Shows
            </th>
            <th>
            Qtd. Ingresso
            </th>
            <th>
            Nome
            </th>
");
            WriteLiteral(@"            <th>
            Capacidade
            </th>
            <th>
             Data
            </th>
            <th>
             Preço
            </th>
            <th>
             Local
            </th>
            <th>
             Gênero
            </th>
            <th>
             Total
            </th>
            </thead>

    
<tbody>
");
#nullable restore
#line 64 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
     foreach(var eventos in Model){
        if(SignInManager.IsSignedIn(User) && eventos.Usuario == ViewBag.User.ToString() ){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td >\r\n        <img");
            BeginWriteAttribute("src", " src=", 1773, "", 1793, 1);
#nullable restore
#line 68 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
WriteAttributeValue("", 1778, eventos.Imagem, 1778, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-thumbnail \" style=\"max-width: 300px;\" >\r\n        </td>\r\n           <td>\r\n            ");
#nullable restore
#line 71 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
       Write(eventos.Qtd);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n         <td>\r\n            ");
#nullable restore
#line 74 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
       Write(eventos.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n        </td>\r\n         <td>\r\n            ");
#nullable restore
#line 77 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
       Write(eventos.Capacidade);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n        </td>\r\n         <td>\r\n            ");
#nullable restore
#line 80 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
       Write(eventos.Data.ToString("dd/MM/yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n        </td>\r\n         <td>\r\n            ");
#nullable restore
#line 83 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
       Write(eventos.Preco.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 86 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
       Write(eventos.CasaDeShow.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n");
#nullable restore
#line 89 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
     if(@eventos.Estilo == "0")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>Rock</p>\r\n");
#nullable restore
#line 91 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
        }else if(@eventos.Estilo == "1"){

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>Pop</p>\r\n");
#nullable restore
#line 93 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
            }else if(@eventos.Estilo == "2"){

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>Sertanejo</p>\r\n");
#nullable restore
#line 95 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
                }else if(@eventos.Estilo == "3"){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>Samba</p>\r\n");
#nullable restore
#line 97 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
                    }else if(@eventos.Estilo == "4"){

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p>Funk</p>\r\n");
#nullable restore
#line 99 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
                        }else if(@eventos.Estilo == "5"){

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p>Forró</p>\r\n");
#nullable restore
#line 101 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
                            }else if(@eventos.Estilo == "6"){

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p>Axé</p>\r\n");
#nullable restore
#line 103 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
                                }else if(@eventos.Estilo == "7"){

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p>Eletrônica</p>\r\n");
#nullable restore
#line 105 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
                                    }else if(@eventos.Estilo == "8"){

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p>Outro</p>\r\n");
#nullable restore
#line 107 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 113 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
       Write(eventos.Total.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n       </tr>\r\n");
#nullable restore
#line 116 "C:\Users\GEDO\Desktop\New folder\Gerenciamento-Eventos\Views\Eventos\Historico.cshtml"
       }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GerenciamentoEvento.Models.Venda>> Html { get; private set; }
    }
}
#pragma warning restore 1591
