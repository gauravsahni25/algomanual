using System;

namespace AlgoManual.Chapter5.BreadthFirstSearch
{
    public class ConnectedComponents : BreadthFirstSearch
    {
        public ConnectedComponents(Graph graph) : base(graph)
        {
        }

        public int FindConnectedComponents()
        {
            int numberOfComponents = 0;
            InitializeSearch();

            for (int i = 0; i < Graph.MaxV; i++)
            {
                // This is common in both CC and Bipartite i.e. keep running search until all are discovered.
                // which makes sense
                if (Discovered[i] == false)
                {
                    numberOfComponents++;
                    Console.WriteLine($"Component {numberOfComponents}:");
                    PerformSearch(i);
                }
            }

            return numberOfComponents;
        }

        protected override void Process_Vertex_Early(int vertex)
        {
            Console.WriteLine($"Processing Vertex: {vertex}");
        }

        protected override void ProcessEdge(int vertex, int connectedVertex)
        {
        }

        protected override void Process_Vertex_Late(int vertex)
        {
        }
    }
}
