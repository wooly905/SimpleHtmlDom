using System.Text;

namespace SimpleHtmlDom.Elements
{
    public class Style : BaseElement
    {
        private readonly string _content;

        public Style(string content)
            : base("", "", ElementNames.Style, "")
        {
            _content = content;
        }

        public override string ToHtml()
        {
            StringBuilder html = new StringBuilder();
            html.Append('<').Append(ElementNames.Style).Append(" type=\"text/css\">");
            html.Append(_content);
            html.Append("</").Append(ElementNames.Style).Append('>');

            return html.ToString();
        }
    }
}
