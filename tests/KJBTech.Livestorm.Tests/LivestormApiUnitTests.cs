using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KJBTech.Livestorm.Tests
{
    [TestClass, TestCategory("Livestorm API V1")]
    public class LivestormApiUnitTests
    {
        protected LivestormApi _api;

        [TestInitialize]
        public void Initialize()
        {
            _api = new LivestormApi(
                new Logger<LivestormApi>(new NullLoggerFactory())
                , Options.Create(new LivestormSettings()
                {
                    ApiKey = "ApiKey"
                }));
        }

        [TestMethod]
        public async Task Ping_Success()
        {
            bool result = await _api.PingAsync();

            Assert.IsTrue(result);
        }
    }
}
