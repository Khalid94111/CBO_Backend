using CBO.Samples;
using Xunit;

namespace CBO.EntityFrameworkCore.Domains;

[Collection(CBOTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<CBOEntityFrameworkCoreTestModule>
{

}
