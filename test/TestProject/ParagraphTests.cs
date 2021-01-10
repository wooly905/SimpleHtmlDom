using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class ParagraphTests
    {
        [Fact]
        public void SingleElementTest()
        {
            string id = "id1";
            string name = "name1";
            string style = "color:red";
            string text = "This is website 1";

            Paragraph para = new Paragraph(text, id, name, style);
            Assert.Equal($"<p id=\"{id}\" name=\"{name}\" style=\"{style}\">{text}</p>", para.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            string id = "id1";
            string name = "name1";
            string style = "color:red";
            string href = "#";
            string text = "Website 1";

            Anchor anchor = new Anchor(id, name, href, text, AnchorTarget.Self, style);
            string value = "This is a text for ";
            Paragraph para = new Paragraph(value);
            para.AddElement(anchor);
            Body body = new Body(para);

            Assert.Equal($"<body><p>This is a text for <a id=\"{id}\" name=\"{name}\" href=\"{href}\" style=\"{style}\">{text}</a></p></body>", body.ToHtml());
        }
    }
}
