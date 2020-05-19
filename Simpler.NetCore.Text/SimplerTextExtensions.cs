using System;
using System.Text;

// ReSharper disable UnusedMember.Global

namespace Simpler.NetCore.Text {
  /// <summary>
  /// Various extensions to simplify working with <see cref="String"/>s.
  /// </summary>
  public static class SimplerTextExtensions {
    /// <summary>
    /// Repeat a given <see cref="String"/> a number of times.
    /// </summary>
    /// <param name="text">Text to repeat.</param>
    /// <param name="times">Number of times to repeat.</param>
    /// <returns>Resulting repeated text.</returns>
    public static String Repeat(this String text, Int32 times)
    {
      if (times < 1)
        return String.Empty;
      var sb = new StringBuilder();
      for (var a = 0; a < times; a++)
        sb.Append(text);
      return sb.ToString();
    }

    
    /// <summary>
    /// Return a non-null version of a given <see cref="String"/>.
    /// A syntactic shorthand for doing <c>text ?? ""</c>. 
    /// </summary>
    /// <param name="text">String to check.</param>
    /// <returns>String if it is non-null, <see cref="string.Empty"/> otherwise.</returns>
    public static String Text(this String? text) =>
      text ?? String.Empty;


    /// <summary>
    /// Remove a substring from the end of a <see cref="String"/>.
    /// </summary>
    /// <param name="text">Text containing the suffix.</param>
    /// <param name="suffix">Suffix to remove.</param>
    /// <param name="comparisonType">
    /// One of the enumeration values that determines how <paramref name="text"/> and <paramref name="suffix"/>
    /// are compared.
    /// </param>
    /// <returns><paramref name="text"/> without the <paramref name="suffix"/>.</returns>
    public static String TrimSuffix(
      this String text,
      String suffix,
      StringComparison comparisonType = StringComparison.Ordinal
    ) {
      text ??= "";
      return text.EndsWith(suffix, comparisonType)
        ? text.Part(0, -suffix.Length)
        : text;
    }


    /// <summary>
    /// Return a part of a <see cref="String"/>.
    /// A more versatile version of <see cref="string.Substring(int, int)"/> that
    /// supports negative arguments (offsets from the end of the string) and doesn't throw an exception if the
    /// resulting string is shorter than <paramref name="offset"/>. 
    /// </summary>
    /// <param name="text">Text to get the part of.</param>
    /// <param name="startIndex">
    /// If positive, zero-based starting character position where to begin the substring.
    /// If negative, offset from the end of the string where to begin the substring.
    /// </param>
    /// <param name="offset">
    /// If positive, the maximum number of characters in the substring.
    /// If negative, the number of characters from the end of the string to discard.
    /// If <c>null</c>, include all characters starting with <paramref name="startIndex"/>. 
    /// </param>
    /// <returns></returns>
    public static String Part(this String text, Int32 startIndex, Int32? offset = null) {
      startIndex = startIndex < 0 ? text.Length + startIndex : startIndex;
      var length = offset ?? text.Length;
      if (length < 1)
        length = text.Length + length - startIndex;
      length = Math.Min(length, text.Length - startIndex);
      return startIndex >= text.Length
        ? String.Empty
        : text.Substring(startIndex, length);
    }


    /// <summary>
    /// Return a <see cref="String"/> if it isn't blank (according to <see cref="string.IsNullOrWhiteSpace"/>),
    /// or a different, nullable <see cref="String"/> if it is.
    /// </summary>
    /// <param name="text">Text to check.</param>
    /// <param name="ifBlank">Value to return if <paramref name="text"/> is blank.</param>
    /// <returns><paramref name="text"/> if not blank, <paramref name="ifBlank"/> otherwise.</returns>
    public static String? NonBlank(this String? text, String? ifBlank = null) =>
      text.IsBlank() ? ifBlank : text;

    /// <inheritdoc cref="String.IsNullOrWhiteSpace"/>.
    public static Boolean IsBlank(this String? value) =>
      String.IsNullOrWhiteSpace(value);

    /// <summary>
    /// Checks that a string is not <c>null</c> or composed entirely of white-space.
    /// Shorthand for <c>!String.IsNullOrWhiteSpace(value)</c>.
    /// </summary>
    public static Boolean NotBlank(this String? value) => 
      !value.IsBlank();
  }
}
