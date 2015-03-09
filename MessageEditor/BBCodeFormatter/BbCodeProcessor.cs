using System.Collections.Generic;

namespace MessageEditor
{
  /// <summary>
  /// BBCode Helper allows formatting of text
  /// without the need to use html
  /// </summary>
  public class BbCodeProcessor
  {
    #region  Private Class Member Declarations

    static List<IHtmlFormatter> _formatters;

    #endregion  Private Class Member Declarations

    #region  Static Constructors

    static BbCodeProcessor()
    {
      _formatters = new List<IHtmlFormatter>();

      _formatters.Add(new RegexFormatter(@"<(.|\n)*?>", string.Empty));

      _formatters.Add(new SearchReplaceFormatter("\r", ""));
      _formatters.Add(new SearchReplaceFormatter("\n\n", "</p><p>"));
      _formatters.Add(new SearchReplaceFormatter("\n", "<br />"));

      _formatters.Add(new RegexFormatter(@"\[b(?:\s*)\]((.|\n)*?)\[/b(?:\s*)\]", "<strong>$1</strong>"));
      _formatters.Add(new RegexFormatter(@"\[i(?:\s*)\]((.|\n)*?)\[/i(?:\s*)\]", "<em>$1</em>"));
      _formatters.Add(new RegexFormatter(@"\[u(?:\s*)\]((.|\n)*?)\[/u(?:\s*)\]", "<u>$1</u>"));

      _formatters.Add(new RegexFormatter(@"\[center(?:\s*)\]((.|\n)*?)\[/center(?:\s*)]", "<div style=\"text-align:center\">$1</div>"));

      _formatters.Add(new RegexFormatter(@"\[quote=((.|\n)*?)(?:\s*)\]", "<div class=\"bbc-quotetitle\">$1 said:</div><div class=\"bbc-quotecontent\"><p>"));
      _formatters.Add(new RegexFormatter(@"\[quote(?:\s*)\]", "<div class=\"bbc-quotecontent\"><p>"));
      _formatters.Add(new RegexFormatter(@"\[/quote(?:\s*)\]", "</p></div>"));

      _formatters.Add(new RegexFormatter(@"\[url=""((.|\n)*?)(?:\s*)""\]((.|\n)*?)\[/url(?:\s*)\]", "<a href=\"$1\" target=\"_blank\" title=\"$1\">$2</a>"));
      _formatters.Add(new RegexFormatter(@"\[url=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/url(?:\s*)\]", "<a href=\"$1\" target=\"_blank\" title=\"$1\">$2</a>"));

      _formatters.Add(new RegexFormatter(@"\[img(?:\s*)\]((.|\n)*?)\[/img(?:\s*)\]", "<img src=\"$1\" border=\"0\" alt=\"\" />"));

      _formatters.Add(new RegexFormatter(@"\[color=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/color(?:\s*)\]", "<span style=\"color:$1;\">$2</span>"));

      _formatters.Add(new RegexFormatter(@"\[WHITE]((.|\n)*?)\[/FONT(?:\s*)]", "<span style=\"color:WHITE;\">$1</span>"));
      _formatters.Add(new RegexFormatter(@"\[BLUE]((.|\n)*?)\[/FONT(?:\s*)]", "<span style=\"color:BLUE;\">$1</span>"));
      _formatters.Add(new RegexFormatter(@"\[GREEN]((.|\n)*?)\[/FONT(?:\s*)]", "<span style=\"color:GREEN;\">$1</span>"));
      _formatters.Add(new RegexFormatter(@"\[RED]((.|\n)*?)\[/FONT(?:\s*)]", "<span style=\"color:RED;\">$1</span>"));
      _formatters.Add(new RegexFormatter(@"\[CYAN]((.|\n)*?)\[/FONT(?:\s*)]", "<span style=\"color:CYAN;\">$1</span>"));
      _formatters.Add(new RegexFormatter(@"\[ORANGE]((.|\n)*?)\[/FONT(?:\s*)]", "<span style=\"color:ORANGE;\">$1</span>"));
      _formatters.Add(new RegexFormatter(@"\[BROWN]((.|\n)*?)\[/FONT(?:\s*)]", "<span style=\"color:BROWN;\">$1</span>"));
      _formatters.Add(new RegexFormatter(@"\[MAGENTA]((.|\n)*?)\[/FONT(?:\s*)]", "<span style=\"color:MAGENTA;\">$1</span>"));
      _formatters.Add(new RegexFormatter(@"\[YELLOW]((.|\n)*?)\[/FONT(?:\s*)]", "<span style=\"color:YELLOW;\">$1</span>"));
      _formatters.Add(new RegexFormatter(@"\[LIMEGREEN]((.|\n)*?)\[/FONT(?:\s*)]", "<span style=\"color:LIMEGREEN;\">$1</span>"));

      _formatters.Add(new RegexFormatter(@"\[indent(?:\s*)\]((.|\n)*?)\[/indent(?:\s*)]", "<div class=\"bbc-indent\">$1</div>"));

      _formatters.Add(new RegexFormatter(@"\[email=""((.|\n)*?)(?:\s*)""\]((.|\n)*?)\[/email(?:\s*)\]", "<a href=\"mailto:$1\" title=\"$2\">$2</a>"));
      _formatters.Add(new RegexFormatter(@"\[email=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/email(?:\s*)\]", "<a href=\"mailto:$1\" title=\"$2\">$2</a>"));

      _formatters.Add(new RegexFormatter(@"\[SIZE=+((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/FONT(?:\s*)\]", "<span style=\"font-size:$1em\">$2</span>"));
      _formatters.Add(new RegexFormatter(@"\[SIZE=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/FONT(?:\s*)\]", "<span style=\"font-size:$1\">$2</span>"));
     
    
    }

    #endregion  Static Constructors

    #region  Public Class Methods

    public static string Format(string data)
    {
      foreach (IHtmlFormatter formatter in _formatters)
        data = formatter.Format(data);

      return "<p>" + data + "</p>";
    }

    #endregion  Public Class Methods
  }
}
