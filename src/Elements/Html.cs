using SimpleHtmlDom.Abstraction;

namespace SimpleHtmlDom.Elements
{
    public class Html : BaseElement
    {

        public Html()
            : base("", "", ElementNames.Html)
        {
        }

        public Html(IHtmlElement element)
            : base("", "", ElementNames.Html)
        {
            AddElement(element);
        }
    }
}
