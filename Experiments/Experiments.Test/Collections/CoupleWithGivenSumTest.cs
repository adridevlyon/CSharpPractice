using System.Collections.Generic;
using Xunit;

namespace Experiments.Test.Collections
{
    public class CoupleWithGivenSumTest
    {
        [Fact]
        public void Given_Values_When_Sorting_Then_SortIsOk()
        {
            int[] values = new int[] { 3, 5, 2, -4, 8, 11 };
            int[] expectedValues = new int[] { -4, 2, 3, 5, 8, 11 };

            CoupleWithGivenSum.MergeSort(values);
            Assert.Equal(expectedValues, values);
        }

        [Fact]
        public void Given_Values_When_GetCouplesWithGivenSum_Then_ResultIsOk()
        {
            List<string> expectedCouples = new List<string>
            {
                "[-4, 11]",
                "[2, 5]"
            };

            var couples = CoupleWithGivenSum.GetCouples(new[] { 3, 5, 2, -4, 8, 11 }, 7);
            Assert.Equal(expectedCouples, couples);
        }
    }
}