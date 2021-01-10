using System.Text;
using SimpleHtmlDom.Abstraction;

namespace SimpleHtmlDom.Elements
{
    public class Bold : BaseElement
    {
        private readonly string _text;

        public Bold(string text)
            : base("", "", ElementNames.Bold, "")
        {
            _text = text;
        }

        public override string ToHtml()
        {
            StringBuilder html = new StringBuilder();
            html.Append('<')
                .Append(ElementNames.Bold)
                .Append('>')
                .Append(_text);

            if (InnerElements != null)
            {
                foreach (IHtmlElement element in InnerElements)
                {
                    html.Append(element.ToHtml());
                }
            }

            html.Append("</")
                .Append(ElementNames.Bold)
                .Append('>');

            return html.ToString();
        }
    }
}
