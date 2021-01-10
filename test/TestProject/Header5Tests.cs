using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class Header5Tests
    {
        [Fact]
        public void SingleElementTest()
        {
            string id = "id1";
            string name = "name1";
            string text = "text";
            string style = "color:red";
            Header5 h5 = new Header5(text, id, name, style);
            Assert.Equal($"<h5 id=\"{id}\" name=\"{name}\" style=\"{style}\">{text}</h5>", h5.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            string text = "text";
            Header5 h5 = new Header5(text);
            Paragraph p = new Paragraph($"This is a text ");
            p.AddElement(h5);
            Assert.Equal($"<p>This is a text <h5>{text}</h5></p>", p.ToHtml());
        }
    }
}
