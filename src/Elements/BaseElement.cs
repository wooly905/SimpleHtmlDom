using System.Collections.Generic;
using System.Text;
using SimpleHtmlDom.Abstraction;

namespace SimpleHtmlDom.Elements
{
    public abstract class BaseElement : IHtmlElementWithChild
    {
        private List<IHtmlElement> _elements;
        private readonly string _htmlElementName;
        private string _postText;

        protected BaseElement(string id, string name, string htmlElementName, string style = "")
        {
            Id = id;
            Name = name;
            Style = style;
            _htmlElementName = htmlElementName;
        }

        public string Id { get; }

        protected IReadOnlyList<IHtmlElement> InnerElements => _elements;

        public string Name { get; }

        public string Style { get; }

        public void AddElement(IHtmlElement element)
        {
            if (element == null)
            {
                return;
            }

            (_elements ?? (_elements = new List<IHtmlElement>())).Add(element);
        }

        public void AddText(string text)
        {
            _postText = text;
        }

        public virtual string ToHtml()
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

            if (InnerElements != null)
            {
                foreach (IHtmlElement element in InnerElements)
                {
                    html.Append(element.ToHtml());
                }
            }

            if (!string.IsNullOrWhiteSpace(_postText))
            {
                html.Append(_postText);
            }

            html.Append("</").Append(_htmlElementName).Append('>');

            return html.ToString();
        }
    }
}
