#pragma checksum "C:\Users\lconner\source\repos\ClassroomConnect.Web\ClassroomConnect.Web\Views\Classroom\_EnrollmentRecord.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7317db3830d01ae149325a6e713907ab8ff35900"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Classroom__EnrollmentRecord), @"mvc.1.0.view", @"/Views/Classroom/_EnrollmentRecord.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Classroom/_EnrollmentRecord.cshtml", typeof(AspNetCore.Views_Classroom__EnrollmentRecord))]
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
#line 1 "C:\Users\lconner\source\repos\ClassroomConnect.Web\ClassroomConnect.Web\Views\_ViewImports.cshtml"
using ClassroomConnect.Web;

#line default
#line hidden
#line 2 "C:\Users\lconner\source\repos\ClassroomConnect.Web\ClassroomConnect.Web\Views\_ViewImports.cshtml"
using ClassroomConnect.Core.Models;

#line default
#line hidden
#line 3 "C:\Users\lconner\source\repos\ClassroomConnect.Web\ClassroomConnect.Web\Views\_ViewImports.cshtml"
using ClassroomConnect.Web.Models.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7317db3830d01ae149325a6e713907ab8ff35900", @"/Views/Classroom/_EnrollmentRecord.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30740da07626fb00fab332e3245517e0d80c00dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Classroom__EnrollmentRecord : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EnrollmentRecordVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Enrollment_Child", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Enrollment_Guardian", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Enrollment_Contact", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\lconner\source\repos\ClassroomConnect.Web\ClassroomConnect.Web\Views\Classroom\_EnrollmentRecord.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
            BeginContext(69, 39, true);
            WriteLiteral("\r\n\r\n\r\n    <div id=\"enrollment-tabs\" >\r\n");
            EndContext();
            BeginContext(384, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(398, 36, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7317db3830d01ae149325a6e713907ab8ff359004940", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(434, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(448, 39, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7317db3830d01ae149325a6e713907ab8ff359006207", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(487, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(501, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7317db3830d01ae149325a6e713907ab8ff359007474", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(539, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(597, 608, true);
            WriteLiteral(@"            
</div>
<script type=""text/javascript"">
    $(document).ready(function () {

        $('.ui-dialog-title').html($(""#Child_FirstName"").val() + "" "" +  $(""#Child_MiddleName"").val() + "" "" +  $(""#Child_LastName"").val());

        $('.phone').mask('(000) 000-0000', { 'translation': { 0: { pattern: /[0-9*]/ } } });
        
    });
    $(document.body).on('click', '.edit-btn', function () {
            var current = $(this);
            $(current).fadeOut(500);           
            setTimeout(function () { $(current).siblings('.save-record').fadeIn(500); }, 500);
        });


");
            EndContext();
            BeginContext(2603, 4875, true);
            WriteLiteral(@"
        $('.create-phone').on('click', function () {
            
            if ($(this).data('person') == 'primary') {
                $(this).parent().hide();
                $('#primWorkPh').html('<input type=""hidden"" name=""PrimaryGuardian.WorkPhone.PhoneType"" value=""Work"" /><div class=""float-container top bottom left right""><label name=""PrimaryGuardian.WorkPhone.PhoneNum"" class=""""></label><input name=""PrimaryGuardian.WorkPhone.PhoneNum"" class=""phone"" data-placeholder="""" /><span asp-validation-for=""PrimaryGuardian.WorkPhone.PhoneNum"" class=""text-danger""></span></div>');                          
            } else if ($(this).data('person') == 'secondary') {
                $(this).parent().hide();
                $('#secWorkPh').html('<input type=""hidden"" name=""SecondaryGuardian.WorkPhone.PhoneType"" value=""Work"" /><div class=""float-container top bottom left right""><label name=""SecondaryGuardian.WorkPhone.PhoneNum"" class=""""></label><input name=""SecondaryGuardian.WorkPhone.PhoneNum"" class=""phone"" ");
            WriteLiteral(@"data-placeholder="""" /><span asp-validation-for=""SecondaryGuardian.WorkPhone.PhoneNum"" class=""text-danger""></span></div>');
            }
        });

        $('.create-address').on('click', function () {
            if ($(this).data('person') == 'primary') {
                $(this).parent().hide();
                $('#primWorkAddr').html('<input type=""hidden"" name=""PrimaryGuardian.WorkAddress.AdrType"" value=""Work"" /><div class=""float-container top left right""><label asp-for=""PrimaryGuardian.WorkAddress.Adr1"" class=""""></label><input asp-for=""PrimaryGuardian.WorkAddress.Adr1"" data-placeholder="""" /><span asp-validation-for=""PrimaryGuardian.WorkAddress.Adr1"" class=""text-danger""></span></div><div class=""float-container top left right""><label asp-for=""PrimaryGuardian.WorkAddress.Adr2"" class=""""></label><input asp-for=""PrimaryGuardian.WorkAddress.Adr2"" data-placeholder="""" /><span asp-validation-for=""PrimaryGuardian.WorkAddress.Adr2"" class=""text-danger""></span></div><div class=""float-container top left right"">");
            WriteLiteral(@"<label asp-for=""PrimaryGuardian.WorkAddress.City"" class=""""></label><input asp-for=""PrimaryGuardian.WorkAddress.City"" data-placeholder="""" /><span asp-validation-for=""PrimaryGuardian.WorkAddress.City"" class=""text-danger""></span></div><div class=""side-by-side""><div class=""float-container top bottom left  next-to""><label asp-for=""PrimaryGuardian.WorkAddress.State"" class=""""></label><input asp-for=""PrimaryGuardian.WorkAddress.State"" data-placeholder="""" /><span asp-validation-for=""PrimaryGuardian.WorkAddress.State"" class=""text-danger""></span></div><div class=""float-container top bottom left right next-to""><label asp-for=""PrimaryGuardian.WorkAddress.PostalCode"" class=""""></label><input asp-for=""PrimaryGuardian.WorkAddress.PostalCode"" data-placeholder="""" /><span asp-validation-for=""PrimaryGuardian.WorkAddress.PostalCode"" class=""text-danger""></span></div></div>');
                $('#PrimaryGuardian_WorkPhone_PhoneNum').parent().removeClass('bottom');
            } else if ($(this).data('person') == 'secondary') {
  ");
            WriteLiteral(@"              $(this).parent().hide();
                $('#secWorkAddr').html('<input type=""hidden"" name=""SecondaryGuardian.WorkAddress.AdrType"" value=""Work"" /><div class=""float-container top left right""><label asp-for=""SecondaryGuardian.WorkAddress.Adr1"" class=""""></label><input asp-for=""SecondaryGuardian.WorkAddress.Adr1"" data-placeholder="""" /><span asp-validation-for=""SecondaryGuardian.WorkAddress.Adr1"" class=""text-danger""></span></div><div class=""float-container top left right""><label asp-for=""SecondaryGuardian.WorkAddress.Adr2"" class=""""></label><input asp-for=""SecondaryGuardian.WorkAddress.Adr2"" data-placeholder="""" /><span asp-validation-for=""SecondaryGuardian.WorkAddress.Adr2"" class=""text-danger""></span></div><div class=""float-container top left right""><label asp-for=""SecondaryGuardian.WorkAddress.City"" class=""""></label><input asp-for=""SecondaryGuardian.WorkAddress.City"" data-placeholder="""" /><span asp-validation-for=""SecondaryGuardian.WorkAddress.City"" class=""text-danger""></span></div><div class=""side-");
            WriteLiteral(@"by-side""><div class=""float-container top bottom left  next-to""><label asp-for=""SecondaryGuardian.WorkAddress.State"" class=""""></label><input asp-for=""SecondaryGuardian.WorkAddress.State"" data-placeholder="""" /><span asp-validation-for=""SecondaryGuardian.WorkAddress.State"" class=""text-danger""></span></div><div class=""float-container top bottom left right next-to""><label asp-for=""SecondaryGuardian.WorkAddress.PostalCode"" class=""""></label><input asp-for=""SecondaryGuardian.WorkAddress.PostalCode"" data-placeholder="""" /><span asp-validation-for=""SecondaryGuardian.WorkAddress.PostalCode"" class=""text-danger""></span></div></div>');
                $('#SecondaryGuardian_WorkPhone_PhoneNum').parent().removeClass('bottom');
            }
            
        });
</script>


");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EnrollmentRecordVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
