using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Sol_Employee_List_MVC.Models;

namespace Sol_Employee_List_MVC.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("employee-card-view")]
    public class EmployeeViewTagHelper : TagHelper
    {

        private readonly IHtmlHelper htmlHelper = null;

        private const string MovieListAttributeName = "item-source";

       

        public EmployeeViewTagHelper(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeName(MovieListAttributeName)]
        public ModelExpression ItemSource { get; set; }


        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

            var employeeTagHelperModel = new EmployeeTagHelperModel()
            {
                Employee = ItemSource.Model as EmployeeModel
            };

            var employeeCardTemplate = await htmlHelper.PartialAsync("~/Views/Employee/TagHelpersPartialView/_EmployeeCardViewTagHelperPartialView.cshtml", employeeTagHelperModel);

            output.Content.SetHtmlContent(employeeCardTemplate);

            //return base.ProcessAsync(context, output);
        }
    }
}
