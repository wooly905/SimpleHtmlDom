using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class Header4Tests
    {
        [Fact]
        public void SingleElementTest()
        {
            string id = "id1";
            string name = "name1";
            string text = "text";
            string style = "color:red";
            Header4 h4 = new Header4(text, id, name, style);
            Assert.Equal($"<h4 id=\"{id}\" name=\"{name}\" style=\"{style}\">{text}</h4>", h4.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            string text = "text";
            Header4 h4 = new Header4(text);
            Paragraph p = new Paragraph($"This is a text ");
            p.AddElement(h4);
            Assert.Equal($"<p>This is a text <h4>{text}</h4></p>", p.ToHtml());
        }
    }
}
