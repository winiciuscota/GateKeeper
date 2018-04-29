using NUnit.Framework;
using GateKeeper.Domain.Entities;

namespace GateKeeper.Domain.Tests.Entities
{
    [TestFixture]
    public class ResidentTests
    {
        [Test]
        public void Instatiate() {
            new Resident();
        }
    }
}