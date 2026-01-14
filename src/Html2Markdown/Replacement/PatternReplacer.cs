using System.Text.RegularExpressions;

namespace Html2Markdown.Replacement;

/// <summary>
/// Allows replacement with a regular expression.
/// </summary>
public class PatternReplacer : IReplacer
{
    /// <summary>
    /// Gets the pattern to match in the HTML.
    /// </summary>
#if NET10_0_OR_GREATER
    public string Pattern { get; init; }
#elif NET481
    public string Pattern { get; set; }
#endif
    /// <summary>
    /// Gets the replacement string for the matched pattern.
    /// </summary>

#if NET10_0_OR_GREATER
public string Replacement { get; init; }
#elif NET481
    public string Replacement { get; set; }
#endif

    /// <summary>
    /// Replaces occurrences of the pattern in the provided HTML with the replacement string.
    /// </summary>
    /// <param name="html">The HTML content to process.</param>
    /// <returns>The processed HTML with replacements.</returns>
    public string Replace(string html)
    {
        // SECURITY: https://sonarcloud.io/organizations/baynezy/rules?open=csharpsquid%3AS6444&rule_key=csharpsquid%3AS6444
        var regex = new Regex(Pattern, RegexOptions.None, TimeSpan.FromSeconds(1));

        return regex.Replace(html, Replacement);
    }
}