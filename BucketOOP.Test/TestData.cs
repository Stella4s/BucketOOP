using BucketOOP.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Test
{
    public static class TestData
    {
        #region TestData BucketTest
        public static IEnumerable<object[]> BucketConstructCapacityData
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{0, 12, true},
                    new object[]{0, 10, false},
                    new object[]{6, 10, false},
                    new object[]{14, 14, false}
                };
            }
        }
        public static IEnumerable<object[]> BucketConstructContentData
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{12, 12, 12},
                    new object[]{6, 10, 10},
                    new object[]{10, 12, 10},
                    new object[]{14, 6, 6},
                    new object[]{12, 0, 0}
                };
            }
        }
        public static IEnumerable<object[]> BucketFillData
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{1, 1},
                    new object[]{0, 0},
                    new object[]{12, 12},
                    new object[]{14, 12}
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
                    new object[]{14, 0}
                };
            }
        }
        public static IEnumerable<object[]> BucketFillFromBucketData
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{1, 12, 1, 11},
                    new object[]{0, 12, 0, 12},
                    new object[]{12, 12, 12, 0},
                    new object[]{6, 10, 6, 4},
                    new object[]{8, 7, 7, 0}
                };
            }
        }
        #endregion
        #region TestData OilDrumTest & RegenTonTest
        public static IEnumerable<object[]> OilDrumConstructContentData
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{0, 0},
                    new object[]{50, 50},
                    new object[]{160, 159}
                };
            }
        }
        public static IEnumerable<object[]> RegentonConstructCapacitytData
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{RegentonSizes.Small, 80},
                    new object[]{RegentonSizes.Medium, 120},
                    new object[]{RegentonSizes.Large, 160},
                    new object[]{null, 80}
                };
            }
        }
        #endregion
    }
}
