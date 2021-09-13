using Atata;
using _ = RedTenTests.HomePage;

namespace RedTenTests
{
    public class HomePage : Page<_>
    {
        [FindById("playersId")]
        public Clickable<_> PlayersLink { get; private set; }

        [FindById("gamesId")]
        public Clickable<_> GameLink { get; private set; }
    }
}
