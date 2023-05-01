using System;
using System.Threading.Tasks;
using Xunit;

namespace KJBTech.Livestorm.IntegrationTests
{
    [Trait("Category", "Livestorm API V1 - Events")]
    public partial class SessionLivestormApiUnitTests : LivestormApiUnitTests
    {
        #region Tests

        [Fact]
        public async Task GetEvent()
        {
            var id = new Guid("cbeeb26f-082d-4f25-b862-d2b2b11dd9a1");
            var result = await _api.GetEventAsync(id);

            Assert.NotNull(result);
            Assert.Equal(id, result.Event.Id);
        }

        #endregion Tests
    }
}
