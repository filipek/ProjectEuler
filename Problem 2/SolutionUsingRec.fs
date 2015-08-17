namespace ProjectEuler.Problem2

///////////////////////////////////////////////////////////////////////////////
module SolutionUsingRec =

   ///Return true if divisible by 2 ie even, false otherwise
   let is_even n = (n % 2 = 0)
   
   ///Returns the n-th Fibonacci number
   let rec fib n =
      if n = 1 then 1
      elif n = 2 then 2
      else fib(n-1) + fib(n-2)
      
(*if ( solutionUsingAnalytics <> expectedSolution ) then
   failwith (String.Format("SolutionUsingAnalytics wrong: '{0}'", solutionUsingAnalytics))*)

   let sum_of_even_n_fibs n =
      let is_even_fib k =
         let f = fib k
         if is_even f then f else 0
         
      let the_set = seq { for i in 3..n -> is_even_fib i }
      Seq.sum the_set