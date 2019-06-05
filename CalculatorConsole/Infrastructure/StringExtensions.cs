using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorConsole.Infrastructure
{
  public static class StringExtensions
  {
    public static string SingleNonEmptyString(this IEnumerable<string> lines) =>
      lines.Select(line => line.Split(new[] {'\t'}, StringSplitOptions.RemoveEmptyEntries))
        .Select(segments => segments.FirstOrDefault())
        .DefaultIfEmpty(string.Empty)
        .First();

    public static int NonNegativeInteger(this IEnumerable<string> lines) =>
      lines
        .Select(line => (
          correct: int.TryParse(line, out var value) && value >= 0,
          value: value))
        .Where(tuple => tuple.correct)
        .Select(tuple => tuple.value)
        .First();
    public static decimal NonNegativeDecimal(this IEnumerable<string> lines) =>
      lines
        .Select(line => (
          correct: decimal.TryParse(line, out var value) && value >= 0,
          value: value))
        .Where(tuple => tuple.correct)
        .Select(tuple => tuple.value)
        .First();
  }
}