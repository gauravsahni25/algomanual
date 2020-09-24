using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace AlgoManual.Chapter7.BasicBacktracks
{
    public class AllPermutations : BackTrackingDfs
    {

        public void GeneratePermutations(int maxNumberOfElements)
        {
            dynamic input = new ExpandoObject();
            input.MaxNumberOfElements = maxNumberOfElements;

            ExecuteBackTrack(new int[maxNumberOfElements + 1], 0, input);
        }

        protected override bool IsASolution(int[] a, int k, dynamic input)
        {
            return k == input.MaxNumberOfElements;                                                                                                                                                                         
        }

        protected override void ProcessSolution(int[] a, int k, dynamic input)
        {
            StringBuilder result = new StringBuilder("Permutation-> ");
            for (int i = 0; i < k; i++)
            {
                result.Append($" {a[i]}");
            }
            Console.WriteLine(result.ToString());
        }

        protected override int[] ConstructCandidates(int[] a, int k, dynamic input)
        {
            var candidatesToBeReturned = new int[input.MaxNumberOfElements];
            
            bool[] inPerm = new bool[input.MaxNumberOfElements];
            for (int i = 0; i < input.MaxNumberOfElements; i++)
            {
                inPerm[i] = false;
            }

            for (int i = 0; i < k; i++)
            {
                // a[i] -> tells us the actual number, say 23
                // So we mark that 23 is in the set already -> inPerm[23] = true;
                inPerm[a[i]] = true;
            }

            for (int i = 1; i <= input.MaxNumberOfElements; i++) // from 1 to Max because we do not want 0 and we want Max
            {
                if (inPerm[i] == false)
                {
                    candidatesToBeReturned[i] = i;
                }
            }
            return candidatesToBeReturned;
        }

        protected override void MakeMove(int[] a, int k, dynamic input)
        {
            // throw new NotImplementedException();
        }

        protected override void UnMakeMove(int[] a, int k, dynamic input)
        {
            // throw new NotImplementedException();
        }
    }
}
