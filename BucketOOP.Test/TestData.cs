using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Test
{
    public static class TestData
    {
        public static IEnumerable<object[]> BucketFilling
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{1, 1},
                    new object[]{0, 0},
                    new object[]{12, 12},
                    new object[]{14, 12},
                };
            }
        }
    }
}
