﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VL1.Pages.Extensions {
    public static class TableRowForHtmlExtension
    {
        public static IHtmlContent TableRowFor(
            this IHtmlHelper htmlHelper, string page, object index,
            params IHtmlContent[] values)
        {
            var htmlStrings = new List<object>();
            foreach (var value in values) addValue(htmlStrings, value);
            htmlStrings.Add(new HtmlString("<td>"));
            htmlStrings.Add(new HtmlString($"<a href=\"{page}/Edit?id={index}\">{Constants.EditLinkTitle}</a>"));
            htmlStrings.Add(" | ");
            htmlStrings.Add(new HtmlString($"<a href=\"{page}/Details?id={index}\">{Constants.DetailsLinkTitle}</a>"));
            htmlStrings.Add(" | ");
            htmlStrings.Add(new HtmlString($"<a href=\"{page}/Delete?id={index}\">{Constants.DeleteLinkTitle}</a>"));
            htmlStrings.Add(new HtmlString("</td>"));
            return new HtmlContentBuilder(htmlStrings);
        }
        public static IHtmlContent TableRowFor(
            this IHtmlHelper htmlHelper, string page, object index,
            string fixedFilter, string fixedValue,

            params IHtmlContent[] values)
        {
            var htmlStrings = new List<object>();
            foreach (var value in values) addValue(htmlStrings, value);
            htmlStrings.Add(new HtmlString("<td>"));
            htmlStrings.Add(new HtmlString($"<a href=\"{page}/Edit?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.EditLinkTitle}</a>"));
            htmlStrings.Add(" | ");
            htmlStrings.Add(new HtmlString($"<a href=\"{page}/Details?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.DetailsLinkTitle}</a>"));
            htmlStrings.Add(" | ");
            htmlStrings.Add(new HtmlString($"<a href=\"{page}/Delete?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.DeleteLinkTitle}</a>"));
            htmlStrings.Add(new HtmlString("</td>"));
            return new HtmlContentBuilder(htmlStrings);
        }

        internal static void addValue(List<object> htmlStrings, IHtmlContent value)
        {
            if (htmlStrings is null) return;
            if (value is null) return;
            htmlStrings.Add(new HtmlString("<td>"));
            htmlStrings.Add(value);
            htmlStrings.Add(new HtmlString("</td>"));
        }
    }
}
