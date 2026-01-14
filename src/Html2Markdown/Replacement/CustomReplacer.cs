namespace Html2Markdown.Replacement;

/// <summary>
/// Allows custom replacement of HTML tags utilizing external functions.
/// </summary>
public class CustomReplacer : IReplacer
{
    /// <summary>
    /// Replaces the HTML string using the custom action.
    /// </summary>
    /// <param name="html">The HTML string to process.</param>
    /// <returns>The processed HTML string with the custom replacement applied.</returns>
    public string Replace(string html)
    {
        return CustomAction.Invoke(html);
    }

    /// <summary>
    /// Gets or sets the custom action to be used for replacing HTML tags.
    /// </summary>
// ReSharper disable once MemberCanBeProtected.Global
#if NET10_0_OR_GREATER
    public Func<string, string> CustomAction { get; init; }
#elif NET481
    public Func<string, string> CustomAction { get; set; }
#endif
}