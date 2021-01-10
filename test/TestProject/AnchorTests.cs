using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class AnchorTests
    {
        [Fact]
        public void SingleElementTest()
        {
            string id = "id1";
            string name = "name1";
            string style = "color:red";
            string href = "#";
            string text = "Website 1";

            Anchor anchor = new Anchor(id, name, href, text, AnchorTarget.Self, style);
            Assert.Equal($"<a id=\"{id}\" name=\"{name}\" href=\"{href}\" style=\"{style}\">{text}</a>", anchor.ToHtml());

            Anchor anchor1 = new Anchor(id, name, href, text, AnchorTarget.Top, style);
            Assert.Equal($"<a id=\"{id}\" name=\"{name}\" href=\"{href}\" style=\"{style}\" target=\"_top\">{text}</a>", anchor1.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            string id = "id1";
            string name = "name1";
            string style = "color:red";
            string href = "#";
            string text = "Website 1";

            Anchor anchor = new Anchor(id, name, href, text, AnchorTarget.Self, style);
            Division div = new Division();
            div.AddElement(anchor);

            Assert.Equal($"<div><a id=\"{id}\" name=\"{name}\" href=\"{href}\" style=\"{style}\">{text}</a></div>", div.ToHtml());
        }
    }
}
