namespace SimpleHtmlDom.Elements
{
    public static class AnchorTargetExtensions
    {
        public static string ToHtml(this AnchorTarget target)
        {
            if (target == AnchorTarget.Blank)
            {
                return "_blank";
            }

            if (target == AnchorTarget.Parent)
            {
                return "_parent";
            }

            if (target == AnchorTarget.Top)
            {
                return "_top";
            }

            return "_self";
        }
    }
}
