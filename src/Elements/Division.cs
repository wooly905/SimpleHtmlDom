using SimpleHtmlDom.Abstraction;

namespace SimpleHtmlDom.Elements
{
    public class Division : BaseElement
    {
        public Division(string id = "", string name = "", string style = "")
            : base(id, name, ElementNames.Dvision, style)
        {
        }

        public Division(IHtmlElement element)
           : base("", "", ElementNames.Dvision, "")
        {
            AddElement(element);
        }
    }
}
