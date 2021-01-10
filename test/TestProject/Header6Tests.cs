using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class Header6Tests
    {
        [Fact]
        public void SingleElementTest()
        {
            string id = "id1";
            string name = "name1";
            string text = "text";
            string style = "color:red";
            Header6 h6 = new Header6(text, id, name, style);
            Assert.Equal($"<h6 id=\"{id}\" name=\"{name}\" style=\"{style}\">{text}</h6>", h6.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            string text = "text";
            Header6 h6 = new Header6(text);
            Paragraph p = new Paragraph($"This is a text ");
            p.AddElement(h6);
            Assert.Equal($"<p>This is a text <h6>{text}</h6></p>", p.ToHtml());
        }
    }
}
