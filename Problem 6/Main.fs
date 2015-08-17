#light

(*
http://projecteuler.net/index.php?section=problems&id=6
---
The sum of the squares of the first ten natural numbers is,

   12 + 22 + ... + 102 = 385

The square of the sum of the first ten natural numbers is,

   (1 + 2 + ... + 10)2 = 552 = 3025

Hence the difference between the sum of the squares of the
first ten natural numbers and the square of the sum is

   3025-385 = 2640.

Find the difference between the sum of the squares of the
first one hundred natural numbers and the square of the sum.

Answer: 25164150

*)

namespace ProjectEuler.Problem6

open System

///////////////////////////////////////////////////////////////////////////////
module Solution =

   let firstN n = seq { 1..n }
   let sq n = n*n
   
   let firstNSumOfSq n =
      firstN n |> Seq.map (sq) |> Seq.sum
      
   let firstNSqOfSum n = sq (firstN n |> Seq.sum)
   let solution n = (firstNSqOfSum n) - (firstNSumOfSq n)
   
   //let argv = System.Environment.GetCommandLineArgs()
   let N = 100 // Int32.Parse(argv.[1])
   
   printfn "solution -> %d" (solution N) // Answer: 25164150
