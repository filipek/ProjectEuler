#light

(*
http://projecteuler.net/index.php?section=problems&id=10
---
The sum of primes below 10 is

   2 + 3 + 5 + 7 = 17
   
Find the sum of all prime numbers less than 2000000 (two million).

Answer: 142913828922

*)

namespace ProjectEuler.Problem10

open System
open System.Collections
open System.Text

open ProjectEuler

///////////////////////////////////////////////////////////////////////////////
module Solution =

   let primesSumN n = Common.primesLessThanNL n |> Seq.sum
   printfn "solution = %d" (primesSumN 2000000L) // Answer: 142913828922
