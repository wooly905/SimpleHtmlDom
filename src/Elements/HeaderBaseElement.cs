using System;
using System.Text;
using SimpleHtmlDom.Abstraction;

namespace SimpleHtmlDom.Elements
{
    public abstract class HeaderBaseElement : BaseElement
    {
        private readonly string _htmlElementName;
        private readonly string _text;

        protected HeaderBaseElement(string text, string htmlElementName, string id = "", string name = "", string style = "")
            : base(id, name, htmlElementName, style)
        {
            _htmlElementName = htmlElementName;
            _text = text ?? throw new ArgumentNullException("Text is null.");
        }

        public override string ToHtml()
        {
            StringBuilder html = new StringBuilder();
            html.Append('<').Append(_htmlElementName);

            if (!string.IsNullOrWhiteSpace(Id))
            {
                html.Append(" id=\"").Append(Id).Append('\"');
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                html.Append(" name=\"").Append(Name).Append('\"');
            }

            if (!string.IsNullOrWhiteSpace(Style))
            {
                html.Append(" style=\"").Append(Style).Append('\"');
            }

            html.Append(">");
            html.Append(_text);

            if (InnerElements != null)
            {
                foreach (IHtmlElement element in InnerElements)
                {
                    html.Append(element.ToHtml());
                }
            }

            html.Append("</").Append(_htmlElementName).Append('>');

            return html.ToString();
        }
    }
}
