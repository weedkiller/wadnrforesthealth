﻿using System;

namespace ProjectFirma.Web.Common
{
    public static class ProjectFirmaMathUtilities
    {
        /// <summary>
        /// Raises b to the power of n. Wraps the double-only function Math.Pow for decimal inputs and output.
        /// </summary>
        
        public static decimal Pow(this decimal b, decimal n)
        {
            return Convert.ToDecimal(Math.Pow(Convert.ToDouble(b), Convert.ToDouble(n)));
        }

        /// <summary>
        /// Calculation for the future value of a present sum as described at <see cref="https://en.wikipedia.org/wiki/Time_value_of_money#Future_value_of_a_present_sum"/>
        /// </summary>
        /// <param name="pv">The value at time = 0 (present value)</param>
        /// <param name="i">The interest rate at which the amount compounds each period</param>
        /// <param name="currentYear">The year represent time = 0</param>
        /// <param name="futureYear">The year at time = n</param>
        /// <returns>The future value FV of PV</returns>
        public static decimal FutureValueOfPresentSum(decimal pv, decimal i, int currentYear, int futureYear)
        {
            return FutureValueOfPresentSum(pv, i, futureYear - currentYear);
        }

        /// <summary>
        /// Calculation for the future value of a present sum as described at <see cref="https://en.wikipedia.org/wiki/Time_value_of_money#Future_value_of_a_present_sum"/>
        /// </summary>
        /// <param name="pv">The value at time = 0 (present value)</param>
        /// <param name="i">The interest rate at which the amount compounds each period</param>
        /// <param name="n">The number of periods</param>
        /// <returns>The future value FV of PV</returns>
        public static decimal FutureValueOfPresentSum(decimal pv, decimal i, int n)
        {
            return pv * (1 + i).Pow(n);
        }
    }
}