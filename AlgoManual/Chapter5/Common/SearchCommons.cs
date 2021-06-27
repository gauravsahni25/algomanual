using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoManual.Chapter5.Common
{
    public interface IPerformSearch
    {
        void PerformSearch(int start);
    }

    public interface IFindPathViaParent : IPerformSearch
    {
        IEnumerable<int> FindPathWith_PrintWithStrategyA(int start, int end);
        void FindPathWith_PrintWithStrategyB(int start, int end);
    }
    public abstract class SearchCommons : IFindPathViaParent
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
                Console.WriteLine(Commons.ListPrinter("Data: ", data));
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

        public IEnumerable<int> FindPathWith_PrintWithStrategyA(int start, int end)
        {
            PerformSearch(start);

            return TraceFromStartToEnd(start, end);
        }

        protected IEnumerable<int> TraceFromStartToEnd(int start, int end)
        {
            // we do this because we have to trace from End to start, so using stack
            Stack<int> pathStack = new Stack<int>();
            pathStack.Push(end); // push end first to stack, thus will be popped last
            var node = Parent[end];
            while (node != -1)
            {
                if (node == start)
                {
                    pathStack.Push(node);
                    break;
                }
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

        public abstract void PerformSearch(int start);
    }

    public class Commons
    {
        public static string ListPrinter(string label, List<int> data)
        {
            StringBuilder builder = new StringBuilder($"{label}: ");
            data.ForEach(a => builder.Append($" {a} "));
            return builder.ToString();
        }
    }
}
