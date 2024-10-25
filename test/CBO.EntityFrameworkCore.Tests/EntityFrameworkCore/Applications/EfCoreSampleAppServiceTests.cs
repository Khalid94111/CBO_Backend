using CBO.Samples;
using Xunit;

namespace CBO.EntityFrameworkCore.Applications;

[Collection(CBOTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<CBOEntityFrameworkCoreTestModule>
{

}
