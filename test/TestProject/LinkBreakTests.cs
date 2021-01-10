using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class LinkBreakTests
    {
        [Fact]
        public void SingleElementTest()
        {
            LineBreak br = new LineBreak();
            Assert.Equal("<br>", br.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            Paragraph p = new Paragraph("This is a text ");
            p.AddElement(new Bold("bold text"));
            p.AddElement(new LineBreak());

            Assert.Equal("<p>This is a text <b>bold text</b><br></p>", p.ToHtml());
        }
    }
}
