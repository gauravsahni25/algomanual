using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoManual.Chapter5.BreadthFirstSearch
{
    public class PathFinding : BreadthFirstSearch
    {
        public PathFinding(Graph graph) : base(graph)
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
    }
}
