#light

(*
http://projecteuler.net/index.php?section=problems&id=14
---
The following iterative sequence is defined for the set of positive integers:

   n -> n/2, if n is even
   n -> 3n + 1, if n is odd

Using the rule above and starting with 13, we generate the following sequence:

   13 -> 40 -> 20 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1

It can be seen that this sequence (starting at 13 and finishing at 1)
contains 10 terms. Although it has not been proved yet (Collatz Problem),
it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.

Answer: 837799

*)

namespace ProjectEuler.Problem14

open System
open System.Collections
open System.Numerics
open System.Text

open ProjectEuler

///////////////////////////////////////////////////////////////////////////////
module Solution =
   
//   let argv = System.Environment.GetCommandLineArgs()
//   let N = BigInteger (Int32.Parse(argv.[1]))
   let N = BigInteger 1000000

   let Zero = BigInteger.Zero
   let One = BigInteger.One
   let Two = BigInteger 2
   let Three = BigInteger 3

   let collatzValue n =
      let mutable res = Zero
      if n % Two = Zero then
         res <- n / Two
      else
         res <- Three * n + One
      res

   let collatzSeq n =
      let cseq =
         Seq.unfold (fun i -> Some(i, collatzValue i)) n
            |> Seq.takeWhile (fun i -> i > One)
      Seq.append cseq [One]

   let collatzLen n = collatzSeq n |> Seq.length
      
   printfn "this will take a few minutes..."

   let res =
      seq { for i in One..N do yield (i, collatzLen i) }
         |> Seq.maxBy (Common.second)
   
   printfn "solution = %A" res // Answer: 837799 with len=525
   