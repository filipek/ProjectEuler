#light

namespace ProjectEuler

open System
open System.Collections
open System.Numerics
open System.Text

open Microsoft.FSharp.Collections

///////////////////////////////////////////////////////////////////////////////
module Common =

   let timeF f x =
      let startT = DateTime.Now
      let res = f x
      let dur = DateTime.Now - startT
      (dur,res)

   let first (a,b) = a
   let second (a,b) = b

   let lastOfSeq s =
      if Seq.isEmpty s then
         failwith "Empty seq has no elements."
      else
         Seq.item ((Seq.length s)-1) s

   let seq2strSep (sep:Char) s =
      let sb = new StringBuilder()
      ignore (sb.Append "seq {")
      let endi = (Seq.length s)-1
      let addItem i =
         let vis = (Seq.item i s).ToString()
         ignore (sb.Append vis)
         if i <> endi then ignore (sb.Append sep)
      seq { 0..endi } |> Seq.iter (fun i -> addItem i)
      ignore (sb.Append "}")
      sb.ToString()

   let seq2str s = seq2strSep ';' s

   ///Return the sum of numbers from 1 to n.
   let sumOfN n = n * (n + 1) / 2

   let isFactor n k = (n % k = 0)
   let isFactorL n k = (n % k = 0L)
   let notFactor n k = not (isFactor n k)
   let notFactorL n k = not (isFactorL n k)
   
   let isEven n = isFactor n 2
   
   let seqLessSqrtN n =
      let sqrtn = int(0.5 + sqrt (float n))
      seq { 2..sqrtn }

   let seqLessSqrtNL n =
      let sqrtn = int64(0.5 + sqrt (float n))
      seq { 2L..sqrtn }

   let factorize n =
      let bf = (seqLessSqrtN n) |> Seq.filter (isFactor n)
      Seq.append bf (bf |> Seq.map (fun i -> n/i))
         |> Seq.distinct
         |> Seq.sortBy (fun i -> -i)

   let factorizeL n =
      let bf = (seqLessSqrtNL n) |> Seq.filter (isFactorL n)
      Seq.append bf (bf |> Seq.map (fun i -> n/i))
         |> Seq.distinct
         |> Seq.sortBy (fun i -> -i)

   let isPrimeFull n =
      (seqLessSqrtN n) |> Seq.forall (notFactor n)

   let isPrimeFullL n =
      (seqLessSqrtNL n) |> Seq.forall (notFactorL n)

   ///Count of digits in n.
   let digitCount n =
      let logn = int(Math.Log10(float n))
      if logn = 0 then 1 else (1+logn)
      
   let digitValue = string >> Int32.Parse
   let digitValueL = string >> Int64.Parse

   let sumOfDigits n =
      if n < 10 then
         n
      else
         Seq.sumBy digitValue (string n)

   let sumOfDigitsL n =
      if n < 10L then
         n
      else
         Seq.sumBy digitValueL (string n)
   
   let lastDigit n =
      if n < 10 then
         n
      else
         let nstr = string n
         digitValue nstr.[nstr.Length-1]

   let lastDigitL n =
      if n < 10L then
         n
      else
         let nstr = string n
         digitValueL nstr.[nstr.Length-1]
   
   let isDiv2 n = (n % 2 = 0)
   let isDiv3 n = (n % 3 = 0)
   let isDiv5 n = (n % 5 = 0)
   let isDiv2L n = (n % 2L = 0L)
   let isDiv3L n = (n % 3L = 0L)
   let isDiv5L n = (n % 5L = 0L)

   let isPrimeOpt n =
      if n = 3 || n = 5 || n = 2 then
         true
      else
         not(isDiv3 n)
         && not(isDiv5 n)
         && not(isDiv2 n)
         && (isPrimeFull n)

   let isPrimeOptL n =
      if n = 3L || n = 5L || n = 2L then
         true
      else
         not(isDiv3L n)
         && not(isDiv5L n)
         && not(isDiv2L n)
         && (isPrimeFullL n)
      
   let primeSeqInit = Seq.ofList [2]

   ///Return the sequence of the first n prime numbers.
   let primesFirstN n =
      let res = new ResizeArray<int>()
      if n > 0 then
         let mutable k = n
         let mutable i = 3
         while k > 1 do
            if isPrimeOpt i then
               res.Add i
               k <- k - 1
            i <- i + 2
      res

   ///Return the sequence of prime numbers less than n.
   let primesLessThanN n =
      let res = new ResizeArray<int>()
      if n > 2 then
         let mutable i = 3
         res.Add 2
         while i < n do
            if isPrimeOpt i then
               res.Add i
            i <- i + 2
      res

   let primesLessThanNL (n:int64) =
      let res = new ResizeArray<int64>()
      if n > 2L then
         let mutable i = 3L
         res.Add 2L
         while i < n do
            if isPrimeOptL i then
               res.Add i
            i <- i + 2L
      res

   ///Return true if n is divisible by 3 or 5, but not both,
   ///false otherwise.
   let isFactor_3_or_5 n =
      let isdivby_3 = isFactor n 3
      let isdivby_5 = isFactor n 5
      // NOTE: we rely on the || operator optimizing the
      // the second check away and thus preventing us from
      // counting multiples of 15 (3*5) twice
      isdivby_3 || isdivby_5
