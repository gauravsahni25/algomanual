using System;
using System.Collections.Generic;

namespace AlgoManual.Chapter5.BreadthFirstSearch
{
    public class PathFinding : BreadthFirstSearch
    {
        public PathFinding(Graph candidateGraph) : base(candidateGraph)
        {
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

        protected override void ProcessEdge(int vertex, int connectedVertex)
        {
            //base.ProcessEdge(vertex, connectedVertex);
        }

        protected override void Process_Vertex_Late(int vertex, List<int> data)
        {
            //base.Process_Vertex_Late(vertex, data);
        }

        protected override void Process_Vertex_Early(int vertex)
        {
            //base.Process_Vertex_Early(vertex);
        }
    }
}
