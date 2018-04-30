using NUnit.Framework;
using GateKeeper.Api.Mapping;
using AutoMapper;

namespace GateKeeper.Api.Tests.Mapping
{
    [TestFixture]
    public class MappingProfileTests
    {
        [Test]
        public void MappingProfile_VerifyMappings()
        {
            var mappingProfile = new MappingProfile();

            var config = new MapperConfiguration(mappingProfile);
            var mapper = new Mapper(config);

            (mapper as IMapper).ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}