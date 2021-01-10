using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class BoldTests
    {
        [Fact]
        public void SingleElementTest()
        {
            string text = "bold text";
            Bold body = new Bold(text);
            Assert.Equal($"<b>{text}</b>", body.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            Bold bold = new Bold("bold text");
            Paragraph p = new Paragraph("This is a text ");
            p.AddElement(bold);

            Assert.Equal("<p>This is a text <b>bold text</b></p>", p.ToHtml());
        }
    }
}
