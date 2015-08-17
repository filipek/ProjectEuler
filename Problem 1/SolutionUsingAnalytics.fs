namespace ProjectEuler.Problem1

open ProjectEuler

///////////////////////////////////////////////////////////////////////////////
module SolutionUsingAnalytics =

   ///Count of numbers divisible by 3 less than n.
   let sup_3 n = n / 3
   ///Count of numbers divisible by 5 less than n.
   let sup_5 n = n / 5
   ///Count of numbers divisible by 15 less than n.
   let sup_15 n = n / 15

   ///Solution using analytics.
   let sum_divisibleby_3_5 n =
      let sum_divby_3 = 3 * Common.sumOfN (sup_3 n)
      let sum_divby_5 = 5 * Common.sumOfN (sup_5 n)
      let sum_divby_15 = 15 * Common.sumOfN (sup_15 n)
      // Note how we do not count multiples of
      // 3 and 5 (ie 15) twice.
      sum_divby_3 + sum_divby_5 - sum_divby_15
