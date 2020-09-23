using System;
using System.Collections.Generic;
using System.Text;
using AlgoManual.Chapter5;

namespace AlgoManual.Chapter6.MinimumSpanningTree
{
    public class Kruskal
    {
        public Graph CandidateGraph { get; }
        public Kruskal(Graph candidateGraph)
        {
            CandidateGraph = candidateGraph;
        }

        public void Execute()
        {
            EdgeNode[] edgePair = new EdgeNode[CandidateGraph.MaxV];

        }
    }
}
