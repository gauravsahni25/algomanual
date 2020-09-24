using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace AlgoManual.Chapter7.BasicBacktracks
{
    public class AllSubset : BackTrackingDfs
    {
        public void GenerateSubsets(int maxNumberOfElements)
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
            StringBuilder result = new StringBuilder("{");
            for (int i = 1; i <= k; i++)
            {
                if (a[i] == 1)
                {
                    result.Append($" {i}");
                }
            }

            result.Append(" }");
            Console.WriteLine(result.ToString());
        }

        protected override int[] ConstructCandidates(int[] a, int k, dynamic input)
        {
            var c = new int[2];
            c[0] = 1;
            c[1] = 0;
            return c;
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
