namespace ProjectEuler.Problem1

open ProjectEuler

///////////////////////////////////////////////////////////////////////////////
module SolutionUsingRec =

   ///Solution using recursion.
   let rec sum_divisibleby_3_5 n =
      if n < 3 then
         0
      else if LocalCommon.is_divisibleby_3_or_5 n then
         n + sum_divisibleby_3_5 (n-1)
      else
         sum_divisibleby_3_5 (n-1)
