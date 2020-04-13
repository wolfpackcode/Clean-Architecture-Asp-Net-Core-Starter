using NUnit.Framework;
using System.Threading.Tasks;

namespace Clean_Architecture_Asp_Net_Core_Starter.Application.IntegrationTests
{
    using static Testing;

    public class TestBase
    {
        
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}
