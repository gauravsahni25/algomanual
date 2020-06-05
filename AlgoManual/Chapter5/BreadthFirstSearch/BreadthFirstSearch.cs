using System.Collections.Generic;
using AlgoManual.Chapter5.Common;

namespace AlgoManual.Chapter5.BreadthFirstSearch
{
    public class BreadthFirstSearch : EdgeAndVertexProcessor
    {
        public bool[] Processed { get; }
        public bool[] Discovered { get; }
        public int[] Parent { get; }
        public Stack<int> ShortestPath { get; }
        public Graph Graph { get; }
        public BreadthFirstSearch(Graph graph)
        {
            Processed = new bool[graph.MaxV];
            Discovered = new bool[graph.MaxV];
            Parent = new int[graph.MaxV];
            ShortestPath = new Stack<int>();
            Graph = graph;
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

                var edgeAdjacencyList = Graph.Edges[vertex];
                while (edgeAdjacencyList != null)
                {
                    int connectedVertex = edgeAdjacencyList.YValue;
                    if (Processed[connectedVertex] == false || Graph.IsDirected)
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
            for (int i = 0; i < this.Graph.MaxV; i++)
            {
                Parent[i] = -1;
                Processed[i] = Discovered[i] = false;
            }
        }
    }
}
