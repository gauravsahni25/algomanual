using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            Console.WriteLine($"Early Processing Vertex: {vertex}");
        }

        protected virtual void ProcessEdge(int vertex, int connectedVertex)
        {
            Console.WriteLine($"Processing Edge: {(vertex, connectedVertex)}");
        }

        protected virtual void Process_Vertex_Late(int vertex, List<int> data)
        {
            Console.WriteLine($"Late Processing Vertex: {vertex}");
            
            if (data != null)
            {
                StringBuilder builder = new StringBuilder("Data: ");
                data.ForEach(a => builder.Append($" {a} "));
                Console.WriteLine(builder.ToString());
            }
            Console.WriteLine();
        }

        public virtual void PrintSearchState()
        {
            StringBuilder builder = new StringBuilder("Parents: \n");
            for (int i = 0; i < Parent.Length; i++)
            {
                builder.Append($"{i} - {Parent[i]} \n");
            }
            Console.WriteLine(builder.ToString());
        }
    }
}
