using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoManual.Chapter5
{
    enum State
    {
        Undiscovered,
        Discovered,
        Processed
    }

    public class BreadthFirstSearch
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

        private void InitializeSearch(Graph graph)
        {
            // Initialize Search
            for (int i = 0; i < graph.MaxV; i++)
            {
                Parent[i] = -1;
                Processed[i] = Discovered[i] = false;
            }
        }

        public void PerformSearch(int start)
        {
            InitializeSearch(this.Graph);
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

        public List<int> FindPathWith_PrintWithStrategyA(int start, int end)
        {
            
            PerformSearch(start);
            
            // we do this because we have to trace from End to start, so using stack
            Stack<int> pathStack = new Stack<int>();
            pathStack.Push(end); // push end first to stack, thus will be popped last
            var node = Parent[end];
            while (node != -1)
            {
                pathStack.Push(node);
                node = Parent[node];
            }

            List<int> path = new List<int>();
            while (pathStack.Count > 0)
            {
                path.Add(pathStack.Pop());
            }

            return path;
        }

        public void FindPathWith_PrintWithStrategyB(int start, int end)
        {
            // this updates the Parents array
            PerformSearch(start);
            if (start == end || end == -1)
            {
               Console.WriteLine(start); 
            }
            else
            {
                FindPathWith_PrintWithStrategyB(start, Parent[end]);
                Console.WriteLine(end);
            }
        }

        private void Process_Vertex_Late(int vertex)
        {
            Console.WriteLine($"Done Processing: {vertex}");
        }

        private void ProcessEdge(int vertex, int connectedVertex)
        {
            Console.WriteLine($"Processing Edge: {(vertex, connectedVertex)}");
        }

        private void Process_Vertex_Early(int vertex)
        {
            Console.WriteLine($"Processing Vertex Early: {vertex}");
        }
    }
}
