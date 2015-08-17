#light

(*
http://projecteuler.net/index.php?section=problems&id=7
---
By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13
we can see that the 6th prime is 13.

What is the 10001st prime number?

Answer: 104743

*)

namespace ProjectEuler.Problem7

open System
open System.Text

open ProjectEuler

///////////////////////////////////////////////////////////////////////////////
module Solution =
   
   // let argv = System.Environment.GetCommandLineArgs()
   let N = 10001 // Int32.Parse(argv.[1])
   
   let nPrimes = Common.primesFirstN N
   let solution = Seq.item ((Seq.length nPrimes)-1) nPrimes
   printfn "solution: %d" solution // Answer: 104743
