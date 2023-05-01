using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace KJBTech.Livestorm.IntegrationTests
{
    [Trait("Category", "Livestorm API V1 - Sessions")]
    public partial class SessionLivestormApiUnitTests : LivestormApiUnitTests
    {
        #region Tests

        [Fact]
        public async Task ListSessions_AtLeastOne()
        {
            var result = await _api.ListUpcomingSessionsAsync();

            Assert.True(result.Any());
            Assert.Contains(result, c => c.Id != Guid.Empty);
            Assert.Contains(result, c => c.Attributes.EventId != Guid.Empty);
        }

        #endregion Tests
    }
}
