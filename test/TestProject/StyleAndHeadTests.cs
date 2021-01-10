using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class StyleAndHeadTests
    {
        [Fact]
        public void StyleSingleElementTest()
        {
            string content = "table { font - family: arial }";
            Style style = new Style(content);

            Assert.Equal($"<style type=\"text/css\">{content}</style>", style.ToHtml());
        }

        [Fact]
        public void HeadSingleElementTest()
        {
            Head head = new Head();

            Assert.Equal("<head></head>", head.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            string content = "table { font - family: arial }";
            Style style = new Style(content);
            Head head = new Head(style);
            Html html = new Html(head);
            Assert.Equal($"<html><head><style type=\"text/css\">{content}</style></head></html>", html.ToHtml());
        }
    }
}
