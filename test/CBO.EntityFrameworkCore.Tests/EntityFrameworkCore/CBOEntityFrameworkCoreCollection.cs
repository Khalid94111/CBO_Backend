using Xunit;

namespace CBO.EntityFrameworkCore;

[CollectionDefinition(CBOTestConsts.CollectionDefinitionName)]
public class CBOEntityFrameworkCoreCollection : ICollectionFixture<CBOEntityFrameworkCoreFixture>
{

}
