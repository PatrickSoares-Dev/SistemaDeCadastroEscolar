#pragma checksum "C:\Users\patrick.oliveira\Desktop\Projeto Escolar\SistemaDeCadastroEscolar\Views\Shared\_Header.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e319f21a20a6da460fca0de62d69e5307ed82b16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Header), @"mvc.1.0.view", @"/Views/Shared/_Header.cshtml")]
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
#line 1 "C:\Users\patrick.oliveira\Desktop\Projeto Escolar\SistemaDeCadastroEscolar\Views\_ViewImports.cshtml"
using Sistema_Escolar;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\patrick.oliveira\Desktop\Projeto Escolar\SistemaDeCadastroEscolar\Views\_ViewImports.cshtml"
using Sistema_Escolar.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e319f21a20a6da460fca0de62d69e5307ed82b16", @"/Views/Shared/_Header.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b0f27a909e4c9a0e9afa295c0d53a63ea3d100c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__Header : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/logo-hdr2.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("max-width: 380%;\r\n    max-height: 380%; margin-top: 20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- begin #header -->\r\n<div id=\"header\" class=\"header navbar-default d-\">\t\r\n\t<input id=\"viewbagUsuario\" style=\"display: none;\" type=text");
            BeginWriteAttribute("value", " value=", 137, "", 160, 1);
#nullable restore
#line 3 "C:\Users\patrick.oliveira\Desktop\Projeto Escolar\SistemaDeCadastroEscolar\Views\Shared\_Header.cshtml"
WriteAttributeValue("", 144, ViewBag.Usuario, 144, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"TipoUser\" readonly />\r\n\t<!-- begin navbar-header -->\r\n    <div class=\"navbar-header\">\r\n");
#nullable restore
#line 6 "C:\Users\patrick.oliveira\Desktop\Projeto Escolar\SistemaDeCadastroEscolar\Views\Shared\_Header.cshtml"
         if (ViewData["PageWithTwoSidebar"] != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <button type=""button"" class=""navbar-toggle pull-left"" data-click=""sidebar-toggled"">
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
            </button>
");
#nullable restore
#line 13 "C:\Users\patrick.oliveira\Desktop\Projeto Escolar\SistemaDeCadastroEscolar\Views\Shared\_Header.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a href=\"/home\" class=\"navbar-brand justify-content-center\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e319f21a20a6da460fca0de62d69e5307ed82b165471", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a>

        <button type=""button"" class=""navbar-toggle"" data-click=""sidebar-toggled"">
            <span class=""icon-bar""></span>
            <span class=""icon-bar""></span>
            <span class=""icon-bar""></span>
        </button>

    </div>
	<!-- end navbar-header -->
");
#nullable restore
#line 25 "C:\Users\patrick.oliveira\Desktop\Projeto Escolar\SistemaDeCadastroEscolar\Views\Shared\_Header.cshtml"
     if (ViewData["PageWithMegaMenu"] != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"	<!-- begin navbar-collapse -->
	<div class=""collapse navbar-collapse"" id=""top-navbar"">
		<ul class=""nav navbar-nav"">
			<li class=""dropdown"">
				<a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">
					<i class=""fa fa-database fa-fw mr-1 mr-md-0""></i> New <b class=""caret ml-1 ml-md-0""></b>
				</a>
			</li>
		</ul>
	</div>
	<!-- end navbar-collapse -->
");
#nullable restore
#line 37 "C:\Users\patrick.oliveira\Desktop\Projeto Escolar\SistemaDeCadastroEscolar\Views\Shared\_Header.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"	<!-- begin header-nav -->
	<ul class=""navbar-nav navbar-right"">
		<li class=""dropdown navbar-user"">

			<a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">
				<span class=""d-none d-md-inline"" style='font-size: 18.5px; margin-bottom: 30px;'>Diretor. Patrick Oliveira</span>
			</a>
		</li>
	</ul>
	<!-- end header-nav -->
</div>
<!-- end #header -->");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
