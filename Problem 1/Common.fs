(*
** Problem 1:
**
** http://projecteuler.net/index.php?section=problems&id=1
**
** If we list all the natural numbers below 10 that are multiples of
** 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
**
** Find the sum of all the multiples of 3 or 5 below 1000.
**
** Solution = 233168
**
*)
namespace ProjectEuler.Problem1

open System

module LocalCommon =

   ///Return true if n is divisible by k, false otherwise.
   let is_divisibleby n k = (n % k = 0)

   ///Rturn true if n is divisible by 3 or 5, but not both,
   ///false otherwise.
   let is_divisibleby_3_or_5 n =
      let isdivby_3 = is_divisibleby n 3
      let isdivby_5 = is_divisibleby n 5
      // NOTE: we rely on the || operator optimizing the
      // the second check away and thus preventing us from
      // counting multiples of 15 (3*5) twice
      isdivby_3 || isdivby_5

   ///Count of numbers divisible by 3 less than n.
   let sup_3 n = n / 3
   ///Count of numbers divisible by 5 less than n.
   let sup_5 n = n / 5
   ///Count of numbers divisible by 15 less than n.
   let sup_15 n = n / 15
