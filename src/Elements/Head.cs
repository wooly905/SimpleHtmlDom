using System.Text;
using SimpleHtmlDom.Abstraction;

namespace SimpleHtmlDom.Elements
{
    public class Head : BaseElement
    {
        public Head()
            : base("", "", ElementNames.Head, "")
        {
        }

        public Head(IHtmlElement element)
          : base("", "", ElementNames.Head, "")
        {
            AddElement(element);
        }

        public override string ToHtml()
        {
            StringBuilder html = new StringBuilder();
            html.Append('<').Append(ElementNames.Head).Append('>');

            if (InnerElements?.Count > 0)
            {
                foreach (IHtmlElement item in InnerElements)
                {
                    html.Append(item.ToHtml());
                }
            }

            html.Append("</").Append(ElementNames.Head).Append('>');

            return html.ToString();
        }
    }
}
