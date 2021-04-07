using CurrencyProject.Services.MathFinanceService;
using System;
using System.Collections.Generic;
using Xunit;

namespace CurrencyServiceTests
{
    public class FinanceServiceTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void AverageCalcTest(List<decimal?> data, decimal expectedResult)
        {
            var financialService = new MathFinanceService();

            var result = financialService.GetAverage(data);

            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> Data =>
              new List<object[]>
                   {
                       new object[] {
                       new List<decimal?> {2,3,4},
                       3},
                       new object[] {
                          new List<decimal?> {5,3,4},
                          4},
     };

        [Theory]
        [MemberData(nameof(Data2))]
        public void StandardDerivationCalcTest(List<decimal?> data, decimal expectedResult)
        {
            var financialService = new MathFinanceService();

            var result = financialService.GetStandardDerivation(data);

            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> Data2 =>
              new List<object[]>
                   {
                       new object[] {
                       new List<decimal?> {2,2,2},
                       0},
                       new object[] {
                          new List<decimal?> {5,3,4},
                          0.816496580927726},
     };

    }
}

