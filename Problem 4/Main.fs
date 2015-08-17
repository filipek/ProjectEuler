#light

(*
http://projecteuler.net/index.php?section=problems&id=4
---
A palindromic number reads the same both ways. The largest
palindrome made from the product of two 2-digit numbers is 9009 = 91*99.

Find the largest palindrome made from the product of two 3-digit numbers.

Answer: 906609

*)

namespace ProjectEuler.Problem4

open System
open System.Diagnostics
open System.Collections
open System.Text

open Microsoft.FSharp.Collections
open Microsoft.FSharp.Math

open ProjectEuler

///////////////////////////////////////////////////////////////////////////////
module Solution =

   let isPalindromeS inpSeq b e =
      let rec is_palindrome ib ie =
         if (ib = ie) || ((ie-ib) = 1) then
            true
         else
            let sib = Seq.item ib inpSeq
            let sie = Seq.item ie inpSeq
            if sib <> sie then
               false
            else
               is_palindrome (ib+1) (ie-1)
      // body
      Debug.Assert( e >= b && b >= 0 )
      is_palindrome b e

   let isPalindromeI i =
      let istr = string i
      isPalindromeS istr 0 (istr.Length-1)
   
   let revStr (s:String) =
      new String(Array.rev (s.ToCharArray()))

   let palindromesLen n =
      let pals = new ResizeArray<int>()
      let isNOdd = (n % 2 = 1)
      let gen_pal hn =
         let rec internal_gen k (s:String) =
            // Use this to ensure a leading 0
            // (zero) is not generated.
            let zeroOrOne =
               (if s.Length = 0 then 1 else 0)
            // If this is the last digit
            // create the palindrom, add it
            // to our collection and end recursion.
            if k = 1 then
               for digit in zeroOrOne..9 do
                  let ps = s + (string digit)
                  // Reverse our generated (1st) half
                  // and combine the halves into a palindrome.
                  // Also, for odd-length palindromes, eat up
                  // the first digit.
                  let half1 = ps.ToString()
                  let half2 =
                     let mutable tmp = revStr half1
                     if n > 1 then
                        if isNOdd && half1.Length <> 1 then
                           tmp <- tmp.Remove (0,1)
                        tmp
                     else
                        String.Empty
                  // Convert from string to int
                  // and add to collection.
                  let palindrome = Int32.Parse (half1 + half2)
                  Debug.Assert (isPalindromeI palindrome)
                  pals.Add palindrome
            else
               for digit in zeroOrOne..9 do
                  // 
                  internal_gen (k-1) (s + (string digit))
         internal_gen hn String.Empty
         pals :> seq<int>
      let halfN =
         (if isNOdd then (n+1)/2 else n/2)
      gen_pal halfN

   let palindromes x y =
      Debug.Assert (x>=0 && y>x)
      let lenx =
         let logx = int(Math.Log10(float x))
         (if logx > 0 then 1+logx else 1)
      let logy = int(Math.Log10(float y))
      let leny = (if logy > 0 then 1+logy else 1)
      let mutable pals : seq<int> = Seq.empty
      if logy = 0 then
         for i in x..y do
            pals <- Seq.append pals [i]
      else
         for i in lenx..leny do
            pals <- Seq.append pals (palindromesLen i)
      pals |> Seq.filter (fun i -> (x<=i && i<y))

   // driver
   
   let factorsByDigiCount dn p =
      let pfactorsdn =
         (Common.factorize p) |> Seq.filter (fun i -> dn=(Common.digitCount i))
      if (Seq.length pfactorsdn) > 1 then
         let secondFactorSameDN f1 =
            let f2 = p/f1
            ((Common.digitCount f2) = dn)
         let resSeq =
            pfactorsdn |> Seq.filter (secondFactorSameDN)
         ((Seq.length resSeq) > 0)
      else
         false

   //let argv = System.Environment.GetCommandLineArgs()
   let DN = 3 // Int32.Parse(argv.[1])
   let INF = 10000 // Int32.Parse(argv.[2])
   let SUP = 1000000 // Int32.Parse(argv.[3])

   let palSeq = palindromes INF SUP
   let palSeqDigiCount =
      Seq.filter (factorsByDigiCount DN) palSeq

   let solSeq =
      palindromes INF SUP
      |> Seq.filter (factorsByDigiCount DN)
      |> Seq.sortBy (fun i -> -i)
      
   /// Return the time taken to execute f(x).
   let solution =
      let (dur,res) = Common.timeF (Seq.head) solSeq
      printfn "solution took: %A" dur
      res
               
   printfn "solution palindrome -> %d" solution
   
   let solF = Common.factorize solution
   printfn "sol factors:\n%s" (Common.seq2str solF)
   printfn ""
   // 3 digits answer 906609
