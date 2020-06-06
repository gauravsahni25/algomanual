using System.Collections.Generic;
using AlgoManual.Chapter5.Common;

namespace AlgoManual.Chapter5.BreadthFirstSearch
{
    public class BreadthFirstSearch : SearchCommons
    {
        public Stack<int> ShortestPath { get; }
        public BreadthFirstSearch(Graph candidateGraph) : base(candidateGraph)
        {
            ShortestPath = new Stack<int>();
        }

        public void PerformSearch(int start)
        {
            InitializeSearch();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            Discovered[start] = true;

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                Process_Vertex_Early(vertex);
                Processed[vertex] = true;

                var edgeAdjacencyList = CandidateGraph.Edges[vertex];
                while (edgeAdjacencyList != null)
                {
                    int connectedVertex = edgeAdjacencyList.YValue;
                    if (Processed[connectedVertex] == false || CandidateGraph.IsDirected)
                    {
                        // If connectedVertex is not Processed, Process the Edge
                        ProcessEdge(vertex, connectedVertex);
                    }

                    if (Discovered[connectedVertex] == false)
                    {
                        queue.Enqueue(connectedVertex);
                        Discovered[connectedVertex] = true;
                        Parent[connectedVertex] = vertex;
                    }

                    edgeAdjacencyList = edgeAdjacencyList.Next;
                }
                Process_Vertex_Late(vertex);
            }
        }
       
        protected void InitializeSearch()
        {
            // Initialize Search
            for (int i = 0; i < this.CandidateGraph.MaxV; i++)
            {
                Parent[i] = -1;
                Processed[i] = Discovered[i] = false;
            }
        }
    }
}
