using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class DivisionTests
    {
        [Theory]
        [InlineData("", "", "", "<div></div>")]
        [InlineData("id1", "name1", "color:red", "<div id=\"id1\" name=\"name1\" style=\"color:red\"></div>")]
        [InlineData("id1", "name1", "", "<div id=\"id1\" name=\"name1\"></div>")]
        public void SingleElementTest(string id, string name, string style, string expected)
        {
            Division div = new Division(id, name, style);
            Assert.Equal(expected, div.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            string text = "This is a paragraph";
            Paragraph para = new Paragraph(text);
            Division div1 = new Division(para);
            Division div2 = new Division(div1);

            Assert.Equal($"<div><div><p>{text}</p></div></div>", div2.ToHtml());
        }

        [Fact]
        public void PostTextTest()
        {
            string text = "This is a paragraph";
            Paragraph para = new Paragraph(text);
            string postText = "Post text";
            Division div1 = new Division(para);
            div1.AddText(postText);

            Assert.Equal($"<div><p>{text}</p>{postText}</div>", div1.ToHtml());
        }
    }
}
