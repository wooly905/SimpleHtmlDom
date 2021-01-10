using SimpleHtmlDom.Abstraction;

namespace SimpleHtmlDom.Elements
{
    public class LineBreak : IHtmlElement
    {
        public string ToHtml()
        {
            return $"<{ElementNames.LinkBreak}>";
        }
    }
}
