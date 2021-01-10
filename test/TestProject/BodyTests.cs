using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class BodyTests
    {
        [Fact]
        public void SingleElementTest()
        {
            Body body = new Body();
            Assert.Equal("<body></body>", body.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            Body body = new Body();

            string headerId = "id1";
            string headerName = "name1";
            string headerText = "text";
            string headerStyle = "color:red";

            Header2 h2 = new Header2(headerText, headerId, headerName, headerStyle);
            body.AddElement(h2);
            Assert.Equal($"<body><h2 id=\"{headerId}\" name=\"{headerName}\" style=\"{headerStyle}\">{headerText}</h2></body>", body.ToHtml());
        }
    }
}
