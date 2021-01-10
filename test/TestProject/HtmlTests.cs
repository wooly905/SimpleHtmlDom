using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class HtmlTests
    {
        [Fact]
        public void SingleElementTest()
        {
            Html html = new Html();
            Assert.Equal("<html></html>", html.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            Html html = new Html();

            string headerId = "id1";
            string headerName = "name1";
            string headerText = "text";
            string headerStyle = "color:red";

            Header1 h1 = new Header1(headerText, headerId, headerName, headerStyle);
            html.AddElement(h1);
            Assert.Equal($"<html><h1 id=\"{headerId}\" name=\"{headerName}\" style=\"{headerStyle}\">{headerText}</h1></html>", html.ToHtml());
        }
    }
}
