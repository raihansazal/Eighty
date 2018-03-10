using System.IO;
using System.Threading.Tasks;

namespace Eighty
{
    internal class Raw : Html
    {
        private string _rawHtml;

        public Raw(string rawHtml)
        {
            _rawHtml = rawHtml;
        }

        internal override void WriteImpl(ref HtmlEncodingTextWriter writer)
        {
            writer.WriteRaw(_rawHtml);
        }

        internal override Task WriteAsyncImpl(AsyncHtmlEncodingTextWriter writer)
            => writer.WriteRaw(_rawHtml);
    }
}