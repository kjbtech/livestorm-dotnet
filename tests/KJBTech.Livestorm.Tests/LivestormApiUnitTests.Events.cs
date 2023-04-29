using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KJBTech.Livestorm.Tests
{
    [TestCategory("Livestorm API V1 - Events")]
    public partial class SessionLivestormApiUnitTests : LivestormApiUnitTests
    {
        #region Tests

        [TestMethod]
        public async Task GetEvent()
        {
            var id = new Guid("cbeeb26f-082d-4f25-b862-d2b2b11dd9a1");
            var result = await _api.GetEventAsync(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Event.Id);
        }

        #endregion Tests
    }
}
