using Atata;
using NUnit.Framework;

namespace RedTenTests
{
    public class PlayerTests : UITestFixture
    {
        [Test]
        public void PlayerTest()
        {
            string playerName;
            var page = Go.To<HomePage>()
                .PageTitle.Should.Contain("RedTen")
                .PlayersLink.ClickAndGo<PlayerIndexPage>()
                .AddPlayerLink.ClickAndGo<CreatePlayerPage>()
                .Wait(1)
                .NameInput.SetRandom(out playerName)
                .Wait(1)
                .EmailInput.Set($"{playerName}@Email")
                .Wait(1)
                .CreatePlayerLink.ClickAndGo<PlayerIndexPage>();       
        }
    }
}
