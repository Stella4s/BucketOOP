using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Test
{
    public static class TestData
    {
        public static IEnumerable<object[]> BucketFillData
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
        public static IEnumerable<object[]> BucketEmptyData
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{1, 11},
                    new object[]{0, 12},
                    new object[]{12, 0},
                    new object[]{14, 0},
                };
            }
        }
    }
}
