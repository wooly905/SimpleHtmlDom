using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class Header2Tests
    {
        [Fact]
        public void SingleElementTest()
        {
            string id = "id1";
            string name = "name1";
            string text = "text";
            string style = "color:red";
            Header2 h2 = new Header2(text, id, name, style);
            Assert.Equal($"<h2 id=\"{id}\" name=\"{name}\" style=\"{style}\">{text}</h2>", h2.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            string text = "text";
            Header2 h2 = new Header2(text);
            Paragraph p = new Paragraph($"This is a text ");
            p.AddElement(h2);
            Assert.Equal($"<p>This is a text <h2>{text}</h2></p>", p.ToHtml());
        }
    }
}
