using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace trycodeHere.html
{
    public class mtagBuilder
    {       
        public static void test()
        {
            string link = "abc.com";
            string cssClass = "none";

            var sb = new StringBuilder();
            sb.Append("<a href='");
            sb.Append("link");
            sb.Append("' class = '");
            sb.Append("ccsClass");
            sb.Append("'/>");
            var t = sb.ToString();


            var tb = new TagBuilder("a");
            tb.MergeAttribute("href", link);
            tb.AddCssClass(cssClass);
            var tt = tb.ToString(TagRenderMode.SelfClosing);

            var mm = GenerateForm();
        }

        //public static string GenerateFormForContact(this HtmlHelper helper, string method, string action, bool includeMailTag)
        public static string GenerateForm()
        {
            //form tag
             string action="clik";
             string method = "method";

            TagBuilder form = new TagBuilder("form");
            form.Attributes.Add("action", action);
            form.Attributes.Add("method", method);

            //label and input tag

            TagBuilder labelClientName = new TagBuilder("label");
            labelClientName.Attributes.Add("for", "clientName");
            TagBuilder inputClientName = new TagBuilder("input");
            inputClientName.Attributes.Add("name", "clientName");
            inputClientName.Attributes.Add("type", "text");
            inputClientName.Attributes.Add("placeholder", "Your name");
            inputClientName.Attributes.Add("required", "required");

            //how to insert inside form

            TagBuilder labelEmailName = new TagBuilder("label");
            labelEmailName.Attributes.Add("for", "emailName");
            TagBuilder inputEmailName = new TagBuilder("input");
            inputEmailName.Attributes.Add("name", "emailName");
            inputEmailName.Attributes.Add("type", "email");
            inputEmailName.Attributes.Add("placeholder", "Your mail");
            inputEmailName.Attributes.Add("required", "required");

            //how to insert again inside form the second label and input

            //how to insert again inside form the n-th label and input 

            form.InnerHtml += labelEmailName.ToString();
            form.InnerHtml += inputEmailName.ToString();

            return form.ToString(TagRenderMode.Normal);
           // return "";
        }

    }
}


