using dominoesGame;

namespace DominoesGame.Tests;
[TestFixture]
public class Tests
{
    private Display _display;
    [SetUp]
    public void Setup()
    {
        _display = new Display();
    }

    [Test]
            [TestCase(1)]
        [TestCase(2)]
        [TestCase(0)]
        [TestCase(5)]
    public void SetupPlayers_InputInteger_2Until4(int test)
    {
        int result = _display.SetupPlayers(test);
        Assert.That(result, Is.AtLeast(2));
        Assert.That(result, Is.AtMost(4));
    }
}