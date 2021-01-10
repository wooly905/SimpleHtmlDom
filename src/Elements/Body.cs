using SimpleHtmlDom.Abstraction;

namespace SimpleHtmlDom.Elements
{
    public class Body : BaseElement
    {
        public Body()
            : base(string.Empty, string.Empty, ElementNames.Body, string.Empty)
        {
        }

        public Body(IHtmlElement element)
            : base(string.Empty, string.Empty, ElementNames.Body, string.Empty)
        {
            AddElement(element);
        }
    }
}
