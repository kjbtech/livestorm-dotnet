using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KJBTech.Livestorm.Tests
{
    [TestClass, TestCategory("Livestorm API V1 - Sessions")]
    public partial class SessionLivestormApiUnitTests : LivestormApiUnitTests
    {
        #region Tests

        [TestMethod]
        public async Task ListSessions_AtLeastOne()
        {
            var result = await _api.ListUpcomingSessionsAsync();

            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.Any(c => c.Id != Guid.Empty));
            Assert.IsTrue(result.Any(c => c.Attributes.EventId != Guid.Empty));
        }

        #endregion Tests
    }
}
