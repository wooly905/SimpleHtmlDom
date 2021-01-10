using System;
using System.Text;
using SimpleHtmlDom.Abstraction;

namespace SimpleHtmlDom.Elements
{
    public class Anchor : BaseElement
    {
        private readonly string _text;
        private readonly string _href;
        private readonly AnchorTarget _target;

        public Anchor(string id, string name, string href, string text, AnchorTarget target = AnchorTarget.Self, string style = "")
            : base(id, name, ElementNames.Anchor, style)
        {
            if (string.IsNullOrWhiteSpace(href) || string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException("Either href or text is null.");
            }

            _href = href;
            _text = text;
            _target = target;
        }

        public override string ToHtml()
        {
            StringBuilder html = new StringBuilder();
            html.Append('<').Append(ElementNames.Anchor);

            if (!string.IsNullOrEmpty(Id))
            {
                html.Append(" id=\"").Append(Id).Append('\"');
            }

            if (!string.IsNullOrEmpty(Name))
            {
                html.Append(" name=\"").Append(Name).Append('\"');
            }

            html.Append(" href=\"").Append(_href).Append('\"');

            if (!string.IsNullOrWhiteSpace(Style))
            {
                html.Append(" style=\"").Append(Style).Append('\"');
            }

            // self is default target of anchor. So do not display self target
            if (_target != AnchorTarget.Self)
            {
                html.Append(" target=\"").Append(_target.ToHtml()).Append('\"');
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

            html.Append("</").Append(ElementNames.Anchor).Append('>');

            return html.ToString();
        }
    }
}
