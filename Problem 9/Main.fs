#light

(*
http://projecteuler.net/index.php?section=problems&id=9
---
A Pythagorean triplet is a set of three natural numbers a < b < c
for which a^2 + b^2 = c^2, eg:

   3^2 + 4^2 = 25 = 5^2
   
There exists exactly one Pythagorean triplet such that

   a + b + c = 1000
   
Find product a*b*c.

Answer: 31875000

*)

namespace ProjectEuler.Problem9

open System
open System.Collections
open System.Text

open ProjectEuler

///////////////////////////////////////////////////////////////////////////////
(*
The important condition (Common.isFactor (a*b) 1000) is derived as follows:

1) a^2 + b^2 = c^2
2) a + b + c = 1000

If we square both sides of 2, and re-arrange the LHS substituting the RHS for
the LHS of 1, along the way, we eventually get:

   c = 500 - a*b/1000

which means 1000 is a factor of a*b, since a,b,c are all natural numbers.
*)
///////////////////////////////////////////////////////////////////////////////

module Solution =

   let seqOfABC = seq {
      for a in 1..998 do
         for b in a..999 do
            if Common.isFactor (a*b) 1000 then
               yield (a,b,1000 - a - b)
   }
   
   let isPythagoreanTriple (a,b,c) =
      (Math.Pow(float a,2.0) + Math.Pow(float b,2.0)) = Math.Pow(float c,2.0)
      
   let seqWithOneSolution = seqOfABC |> Seq.filter (isPythagoreanTriple)
   let (a,b,c) = Seq.head seqWithOneSolution
   
   printfn "solution = %d" (a*b*c)
   printfn "solution = %A" (a,b,c) // Answer: 31875000
