using FluentAssertions;

namespace ResistanceTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        true.Should().BeTrue();
    }
}