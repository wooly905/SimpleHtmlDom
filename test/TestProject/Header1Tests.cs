using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class Header1Tests
    {
        [Fact]
        public void SingleElementTest()
        {
            string id = "id1";
            string name = "name1";
            string text = "text";
            string style = "color:red";
            Header1 h1 = new Header1(text, id, name, style);
            Assert.Equal($"<h1 id=\"{id}\" name=\"{name}\" style=\"{style}\">{text}</h1>", h1.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            string text = "text";
            Header1 h1 = new Header1(text);
            Paragraph p = new Paragraph("This is a text ");
            p.AddElement(h1);
            Assert.Equal($"<p>This is a text <h1>{text}</h1></p>", p.ToHtml());
        }
    }
}
