namespace ProjectEuler.Problem1

open ProjectEuler

///////////////////////////////////////////////////////////////////////////////
module SolutionUsingSeq =

   ///Return n if it is divisible by 3 or 5, but not both,
   ///and 0 otherwise.
   let divisibleby_3_5 n =
      let isdiv_k = LocalCommon.is_divisibleby n 3
      let isdiv_j = LocalCommon.is_divisibleby n 5
      if (isdiv_k || isdiv_j) then n else 0

   ///Solution using sequences.
   let sum_divisibleby_3_5 n =
      // start with 3 as it = min(3 5)
      let the_set = seq { for i in 3..n -> divisibleby_3_5 i }
      Seq.sum the_set
