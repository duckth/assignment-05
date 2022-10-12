using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace GildedRose.Tests;

public class ProgramTests
{
    [Fact]
    public void TestTheTruth()
    {
        Program.Main(Array.Empty<string>());

        true.Should().BeTrue();
    }
}