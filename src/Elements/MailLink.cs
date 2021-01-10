namespace SimpleHtmlDom.Elements
{
    public class MailLink : Anchor
    {
        public MailLink(string mailTo,
                        string subject,
                        string text,
                        string id = "",
                        string name = "",
                        string style = "")
            : base(id, name, $"{ElementNames.MailLink}:{mailTo}?subject={subject}", text, style: style)
        {
        }
    }
}
