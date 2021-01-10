using System.Text;
using SimpleHtmlDom.Abstraction;

namespace SimpleHtmlDom.Elements
{
    public class Paragraph : BaseElement
    {
        private readonly string _text;

        public Paragraph(string text, string id = "", string name = "", string style = "")
            : base(id, name, ElementNames.Paragraph, style)
        {
            _text = text;
        }

        public override string ToHtml()
        {
            StringBuilder html = new StringBuilder();
            html.Append('<').Append(ElementNames.Paragraph);

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

            html.Append('>');
            html.Append(_text);

            if (InnerElements?.Count > 0)
            {
                foreach (IHtmlElement item in InnerElements)
                {
                    html.Append(item.ToHtml());
                }
            }

            html.Append("</").Append(ElementNames.Paragraph).Append('>');

            return html.ToString();
        }
    }
}
