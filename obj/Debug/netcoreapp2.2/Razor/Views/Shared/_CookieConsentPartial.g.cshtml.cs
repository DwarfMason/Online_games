#pragma checksum "D:\downloads\Online_games-AlkoniorBranch-Don-t_touch-\AdmonistratorPage\Views\Shared\_CookieConsentPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d5017fc5659a6b9531a1fe57a06ef384ef4212b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CookieConsentPartial), @"mvc.1.0.view", @"/Views/Shared/_CookieConsentPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_CookieConsentPartial.cshtml", typeof(AspNetCore.Views_Shared__CookieConsentPartial))]
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
#line 1 "D:\downloads\Online_games-AlkoniorBranch-Don-t_touch-\AdmonistratorPage\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#line 2 "D:\downloads\Online_games-AlkoniorBranch-Don-t_touch-\AdmonistratorPage\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#line 1 "D:\downloads\Online_games-AlkoniorBranch-Don-t_touch-\AdmonistratorPage\Views\Shared\_CookieConsentPartial.cshtml"
using Microsoft.AspNetCore.Http.Features;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d5017fc5659a6b9531a1fe57a06ef384ef4212b", @"/Views/Shared/_CookieConsentPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"064e135c76b5720e663dda48346e50a6e2dba531", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CookieConsentPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "D:\downloads\Online_games-AlkoniorBranch-Don-t_touch-\AdmonistratorPage\Views\Shared\_CookieConsentPartial.cshtml"
  
    var consentFeature = Context.Features.Get<ITrackingConsentFeature>();
    var showBanner = !consentFeature?.CanTrack ?? false;
    var cookieString = consentFeature?.CreateConsentCookie();

#line default
#line hidden
            BeginContext(241, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 9 "D:\downloads\Online_games-AlkoniorBranch-Don-t_touch-\AdmonistratorPage\Views\Shared\_CookieConsentPartial.cshtml"
 if (showBanner)
{

#line default
#line hidden
            BeginContext(261, 213, true);
            WriteLiteral("    <div id=\"cookieConsent\" class=\"alert alert-info alert-dismissible fade show\" role=\"alert\">\n        <button type=\"button\" class=\"accept-policy close\" data-dismiss=\"alert\" aria-label=\"Close\" data-cookie-string=\"");
            EndContext();
            BeginContext(475, 12, false);
#line 12 "D:\downloads\Online_games-AlkoniorBranch-Don-t_touch-\AdmonistratorPage\Views\Shared\_CookieConsentPartial.cshtml"
                                                                                                                 Write(cookieString);

#line default
#line hidden
            EndContext();
            BeginContext(487, 391, true);
            WriteLiteral(@""">
            <span aria-hidden=""true"">Accept</span>
        </button>
    </div>
    <script>
        (function () {
            var button = document.querySelector(""#cookieConsent button[data-cookie-string]"");
            button.addEventListener(""click"", function (event) {
                document.cookie = button.dataset.cookieString;
            }, false);
        })();
    </script>
");
            EndContext();
#line 24 "D:\downloads\Online_games-AlkoniorBranch-Don-t_touch-\AdmonistratorPage\Views\Shared\_CookieConsentPartial.cshtml"
}

#line default
#line hidden
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