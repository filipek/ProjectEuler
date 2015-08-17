(*
http://projecteuler.net/index.php?section=problems&id=1
---
If we list all the natural numbers below 10 that are multiples
of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

Find the sum of all the multiples of 3 or 5 below 1000.

Answer: 233168

*)

namespace ProjectEuler.Problem1

open System
open SolutionUsingRec
open SolutionUsingSeq
open SolutionUsingAnalytics

module Solution =

   let below_1000 = 1000 - 1
   let expectedSolution = 233168

   // SolutionUsingRec
   let solutionUsingRec =
      SolutionUsingRec.sum_divisibleby_3_5 below_1000

   if ( solutionUsingRec <> expectedSolution ) then
      failwith (String.Format("SolutionUsingRec wrong: '{0}'", solutionUsingRec))

   // SolutionUsingSeq
   let solutionUsingSeq =
      SolutionUsingSeq.sum_divisibleby_3_5 below_1000

   if ( solutionUsingSeq <> expectedSolution ) then
      failwith (String.Format("SolutionUsingSeq wrong: '{0}'", solutionUsingSeq))

   // SolutionUsingAnalytics
   let solutionUsingAnalytics =
      SolutionUsingAnalytics.sum_divisibleby_3_5 below_1000

   if ( solutionUsingAnalytics <> expectedSolution ) then
      failwith (String.Format("SolutionUsingAnalytics wrong: '{0}'", solutionUsingAnalytics))

   printfn "solution = %d" expectedSolution
