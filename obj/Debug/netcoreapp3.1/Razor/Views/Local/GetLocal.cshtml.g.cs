#pragma checksum "C:\Users\GEDO\Desktop\Visual Studio Code\Projeto-Casa\Views\Local\GetLocal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c692f2bb448cbbf90e015d0020df2f29ccc043c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Local_GetLocal), @"mvc.1.0.view", @"/Views/Local/GetLocal.cshtml")]
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
#line 1 "C:\Users\GEDO\Desktop\Visual Studio Code\Projeto-Casa\Views\_ViewImports.cshtml"
using GerenciamentoEvento;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\GEDO\Desktop\Visual Studio Code\Projeto-Casa\Views\_ViewImports.cshtml"
using GerenciamentoEvento.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c692f2bb448cbbf90e015d0020df2f29ccc043c8", @"/Views/Local/GetLocal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee4b8b0451c58001231737cc1f3c1847b2a5d4a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Local_GetLocal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\GEDO\Desktop\Visual Studio Code\Projeto-Casa\Views\Local\GetLocal.cshtml"
    
    ViewData["Title"] = "API - Locais";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"  <script>
    $(document).ready( function () {
    $('#local').DataTable({
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
  
   <h2>Locais Disponivéis na <h4 id=""titulo"">Eventos.com</h2>
 

    <table id=""local"" class=""table table-striped table-bordered"">
        <thead style="" font-family:'Alegreya Sans'; background-color:#6E3667; color:white; text-align: center"">
            <th>
            Nome
            </th>
            <th>
             Endereço
            </thead>

    
<tbody>
");
#nullable restore
#line 40 "C:\Users\GEDO\Desktop\Visual Studio Code\Projeto-Casa\Views\Local\GetLocal.cshtml"
     foreach(var local in Model)
    {  

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            \r\n         <td>\r\n            ");
#nullable restore
#line 45 "C:\Users\GEDO\Desktop\Visual Studio Code\Projeto-Casa\Views\Local\GetLocal.cshtml"
       Write(local.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n        </td>\r\n         <td>\r\n            ");
#nullable restore
#line 48 "C:\Users\GEDO\Desktop\Visual Studio Code\Projeto-Casa\Views\Local\GetLocal.cshtml"
       Write(local.Endereco);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n        </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 52 "C:\Users\GEDO\Desktop\Visual Studio Code\Projeto-Casa\Views\Local\GetLocal.cshtml"
       
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
