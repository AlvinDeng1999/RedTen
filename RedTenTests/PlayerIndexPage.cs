using Atata;
using _ = RedTenTests.PlayerIndexPage;

namespace RedTenTests
{
    public class PlayerIndexPage : Page<_>
    {
        [FindById("addPlayerId")]
        public Clickable<_> AddPlayerLink { get; private set; }
    }
}
