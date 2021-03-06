using System;
using System.Net;
using System.Web.Mvc;

namespace Eighty.AspNet.Mvc.ActionResults
{
    /// <summary>
    /// An <see cref="ActionResult"/> which renders some <see cref="Eighty.Html"/>
    /// </summary>
    public class HtmlResult : ActionResult
    {
        /// <summary>
        /// The <see cref="Eighty.Html"/>
        /// </summary>
        /// <returns>The <see cref="Eighty.Html"/></returns>
        public Html Html { get; }
        /// <summary>
        /// A custom status code
        /// </summary>
        /// <returns>A custom status code</returns>
        public HttpStatusCode? StatusCode { get; }

        /// <summary>
        /// Creates an <see cref="HtmlResult"/>
        /// </summary>
        /// <param name="html">The <see cref="Eighty.Html"/></param>
        /// <param name="statusCode">A custom status code</param>
        public HtmlResult(Html html, HttpStatusCode? statusCode = null)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }
            Html = html;
            StatusCode = statusCode;
        }

        /// <inheritdoc/>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var response = context.HttpContext.Response;

            if (StatusCode != null)
            {
                response.StatusCode = (int)StatusCode.Value;
            }
            response.ContentType = "text/html; charset=utf-8";

            Html.Write(response.Output);
        }
    }
}