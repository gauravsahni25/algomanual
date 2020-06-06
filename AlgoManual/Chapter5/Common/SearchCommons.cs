using System;

namespace AlgoManual.Chapter5.Common
{
    public class SearchCommons
    {
        public Graph CandidateGraph { get; }
        public bool[] Processed { get; }
        public bool[] Discovered { get; }
        public int[] Parent { get; }
        public SearchCommons(Graph candidateGraph)
        {
            CandidateGraph = candidateGraph;
            Processed = new bool[candidateGraph.MaxV];
            Discovered = new bool[candidateGraph.MaxV];
            Parent = new int[candidateGraph.MaxV];
        }
        protected virtual void Process_Vertex_Early(int vertex)
        {
            Console.WriteLine($"Processing Vertex Early: {vertex}");
        }

        protected virtual void ProcessEdge(int vertex, int connectedVertex)
        {
            Console.WriteLine($"Processing Edge: {(vertex, connectedVertex)}");
        }

        protected virtual void Process_Vertex_Late(int vertex)
        {
            Console.WriteLine($"Done Processing: {vertex}");
        }
    }
}
