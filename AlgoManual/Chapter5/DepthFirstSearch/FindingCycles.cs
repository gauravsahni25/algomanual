using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlgoManual.Chapter5.BreadthFirstSearch;
using AlgoManual.Chapter5.Common;

namespace AlgoManual.Chapter5.DepthFirstSearch
{
    public class FindingCycles : DepthFirstSearch
    {

        public List<List<int>> Cycles { get; set; } = new List<List<int>>();
        private bool _findAllCycles;
        public FindingCycles(Graph candidateGraph, bool findAllCycles) : base(candidateGraph)
        {
            _findAllCycles = findAllCycles;
        }

        protected override void ProcessBackEdge(int vertex, int connectedVertex)
        {
            var cycle = base.TraceFromStartToEnd(connectedVertex, vertex).ToList();

            Console.WriteLine($"Cycle found from {connectedVertex}" +
                              $"to {vertex}: {Commons.ListPrinter("Cycle", cycle)}");


            Cycles.Add(cycle);

            Console.WriteLine();

            if (!_findAllCycles)
            {
                TerminateSearch(); 
            }
        }
    }
}
