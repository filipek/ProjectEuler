(*
http://projecteuler.net/index.php?section=problems&id=3
---
The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143?

Answer: 6857

*)

namespace ProjectEuler.Problem3

open System
open System.Collections
open System.Text

open Microsoft.FSharp.Collections
open Microsoft.FSharp.Math

open ProjectEuler

///////////////////////////////////////////////////////////////////////////////
module Solution =

   //let n = 13195
   let n = 600851475143L
   let fsn = Common.factorizeL n
   printfn "factors of %d       -> %s" n (Common.seq2str fsn)
   let pfsn =
      fsn |> Seq.filter (Common.isPrimeOptL) |> Seq.sortBy (fun i -> -i)
   printfn
      "prime factors of %d -> %s\n  biggest= %d"
         n (Common.seq2str pfsn) (Seq.head pfsn) // Answer: 6857
   printfn "done"