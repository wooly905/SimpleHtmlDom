using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class Header3Tests
    {
        [Fact]
        public void SingleElementTest()
        {
            string id = "id1";
            string name = "name1";
            string text = "text";
            string style = "color:red";
            Header3 h3 = new Header3(text, id, name, style);
            Assert.Equal($"<h3 id=\"{id}\" name=\"{name}\" style=\"{style}\">{text}</h3>", h3.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            string text = "text";
            Header3 h3 = new Header3(text);
            Paragraph p = new Paragraph($"This is a text ");
            p.AddElement(h3);
            Assert.Equal($"<p>This is a text <h3>{text}</h3></p>", p.ToHtml());
        }
    }
}
