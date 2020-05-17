using System;
using FluentAssertions;
using Xunit;
// ReSharper disable ArrangeTypeMemberModifiers

namespace Simpler.NetCore.Text.Tests {
  public class ExtensionTests {
    [Fact]
    void Part() {
      "OffsetSub".Part(0, -3).Should().Be("Offset");
      "123SubRegular".Part(3, 3).Should().Be("Sub");
      "NotEverything".Part(3).Should().Be("Everything");
      "UnMoored".Part(2, 99).Should().Be("Moored");
      "Empty".Part(10, -99).Should().Be("");
      "LastOne".Part(-3).Should().Be("One");
      "TrickOrTreat".Part(-7, -5).Should().Be("Or");
    }

    [Fact]
    void TrimSuffix() {
      "markdown.md".TrimSuffix(".md").Should().Be("markdown");
    }
  }
}