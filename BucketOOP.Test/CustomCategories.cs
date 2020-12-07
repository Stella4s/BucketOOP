using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace BucketOOP.Test
{
    public class BucketTestAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Bucket" };
    }
    public class OilDrumTestAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "OilDrum" };
    }
    public class RegentonTestAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Regenton" };
    }
    public class CapacityReachedAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "CapacityReached" };
    }

    public class OverCapacityAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "OverCapacity" };
    }

    public class NearCapacityAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "NearCapacity" };
    }
}
