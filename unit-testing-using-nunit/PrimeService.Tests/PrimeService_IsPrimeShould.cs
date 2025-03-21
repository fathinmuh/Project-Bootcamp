using NUnit.Framework;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class PrimeService_IsPrimeShould
    {
        private PrimeService _primeService;

        [SetUp]
        public void SetUp()
        {
            _primeService = new PrimeService();
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(0)]
        public void IsPrime_InputIs1_ReturnFalse(int test)
        {
            var result = _primeService.IsPrime(test);

            Assert.That(result , Is.EqualTo(false));
        }
    }
}