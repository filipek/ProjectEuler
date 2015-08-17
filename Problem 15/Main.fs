(*
http://projecteuler.net/index.php?section=problems&id=15
---
Starting in the top left corner of a 2x2 grid, there are
6 routes (without backtracking) to the bottom right corner.
   __  _    _
     |  |_   |
     |    |  |_

  |__  |_   |
     |   |_ |__

How many routes are there through a 20x20 grid?

Solution: 137846528820

This question resolves to the number of combinations of n
among 2n items: C(2n,n)=(2n)!/(n!)^2

This is sometimescalled the staircase walk, see
   http://mathworld.wolfram.com/StaircaseWalk.html
The actual number can be found at
   http://oeis.org/A000984
*)

namespace ProjectEuler.Problem15

open System
open System.Collections
open System.ComponentModel
open System.Text

//open Microsoft.FSharp.Collections

open ProjectEuler

///////////////////////////////////////////////////////////////////////////////
module Solution =
      
   printfn "\npaths for 20x20 grid = %d"  137846528820L
