using Atata;
using NUnit.Framework;

namespace RedTenTests
{
    public class SampleTests : UITestFixture
    {
        [Test]
        public void SampleTest()
        {
            Go.To<OrdinaryPage>()
                .PageTitle.Should.Contain("Atata");
        }
    }
}
