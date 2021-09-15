using Atata;
using _ = RedTenTests.CreatePlayerPage;

namespace RedTenTests
{
    public class CreatePlayerPage : Page<_>
    {
        [FindById("inputName")]
        public TextInput<_> NameInput { get; private set; }
        [FindById("inputEmail")]
        public TextInput<_> EmailInput { get; private set; }

        [FindById("savePlayer")]
        public Button<_> CreatePlayerLink { get; private set; }
    }
}
