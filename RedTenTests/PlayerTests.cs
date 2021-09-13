using Atata;
using NUnit.Framework;

namespace RedTenTests
{
    public class PlayerTests : UITestFixture
    {
        [Test]
        public void PlayerTest()
        {
            var page = Go.To<HomePage>()
                .PageTitle.Should.Contain("RedTen")
                .PlayersLink.ClickAndGo<PlayerIndexPage>()
                .AddPlayerLink.ClickAndGo<CreatePlayerPage>();       
        }
    }
}
