#light

(*
http://projecteuler.net/index.php?section=problems&id=5
---
2520 is the smallest number that can be divided by each
of the numbers from 1 to 10 without any remainder.

What is the smallest number that is evenly divisible by all
of the numbers from 1 to 20?

Answer: 232792560

*)

namespace ProjectEuler.Problem5

open System

///////////////////////////////////////////////////////////////////////////////
module Solution =

   let solution = 5*7*9*11*13*16*17*19
   printfn "solution -> %d" solution // 232792560
