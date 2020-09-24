using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoManual.Chapter7
{
    public abstract class BackTrackingDfs
    {
        public bool IsFinished { get; set; } = false;

        /// <summary>
        /// Backtracking Algorithm
        /// </summary>
        /// <param name="a">This is the result array</param>
        /// <param name="k">Represent the number of elements to be considered in solution
        /// i.e. a[0] to a[k]</param>
        /// <param name="input">Auxiliary Data | Allows us to pass general information in the routine</param>
        public void ExecuteBackTrack(int[] a, int k, dynamic input)
        {
            if (IsASolution(a, k, input))
            {
                ProcessSolution(a, k, input);
            }
            else
            {
                k = k + 1;
                int[] candidatesForNextPosition = ConstructCandidates(a, k, input);
                
                // Consider all of Candidates for Next Position and Backtrack on it - DFS
                for (int i = 0; i < candidatesForNextPosition.Length; i++)
                {
                    a[k] = candidatesForNextPosition[i]; // Considering next element| K | K+1 | K+1+1... so on dfs
                    MakeMove(a, k, input);
                    
                    ExecuteBackTrack(a,k,input);
                    
                    UnMakeMove(a,k,input);
                    if (IsFinished)
                    {
                        return;
                    }
                }
            }
            
        }

        /// <param name="a">This is the result array</param>
        /// <param name="k">Represent the number of elements to be considered in solution
        /// i.e. a[0] to a[k]</param>
        /// <param name="input">Auxiliary Data | Allows us to pass general information in the routine</param>
        /// <returns></returns>
        protected abstract bool IsASolution(int[] a, int k, dynamic input);

        /// <summary>
        /// Do something to the solution
        /// </summary>
        /// <param name="a">This is the result array</param>
        /// <param name="k">Represent the number of elements to be considered in solution
        /// i.e. a[0] to a[k]</param>
        /// <param name="input">Auxiliary Data | Allows us to pass general information in the routine</param>
        protected abstract void ProcessSolution(int[] a, int k, dynamic input);


        /// <summary>
        /// Fills up candidatesForNextPosition for te kth Position of 'a' | Depending on values of first k-1 positions
        /// </summary>
        /// <param name="a">This is the result array</param>
        /// <param name="k">Represent the number of elements to be considered in solution
        /// i.e. a[0] to a[k]</param>
        /// <param name="input">Auxiliary Data | Allows us to pass general information in the routine</param>
        /// <returns>Returns the number of values in the array candidatesForNextPosition</returns>
        protected abstract int[] ConstructCandidates(int[] a, int k, dynamic input);

        /// <summary>
        /// Modify Data if needed
        /// </summary>
        /// <param name="a">This is the result array</param>
        /// <param name="k">Represent the number of elements to be considered in solution
        /// i.e. a[0] to a[k]</param>
        /// <param name="input">Auxiliary Data | Allows us to pass general information in the routine</param>
        protected abstract void MakeMove(int[] a, int k, dynamic input);

        /// <summary>
        /// Un-modify Data if needed 
        /// </summary>
        /// <param name="a">This is the result array</param>
        /// <param name="k">Represent the number of elements to be considered in solution
        /// i.e. a[0] to a[k]</param>
        /// <param name="input">Auxillary Data | Allows us to pass general information in the routine</param>
        protected abstract void UnMakeMove(int[] a, int k, dynamic input);

    }
}
