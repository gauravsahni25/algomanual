using System;
using AlgoManual.Chapter5.Common;

namespace AlgoManual.Chapter5.DepthFirstSearch
{
    public class DepthFirstSearch : SearchCommons, IPerformSearch
    {
        
        public int TotalTime { get; protected set; }
        public bool IsSearchTerminated { get; protected set; }
        public int[] EntryTime { get; }
        public int[] ExitTime { get; }

        public DepthFirstSearch(Graph candidateGraph) : base(candidateGraph)
        {
            EntryTime = new int[candidateGraph.MaxV];
            ExitTime = new int[candidateGraph.MaxV];
            ResetSearchResults();
        }

        public override void PerformSearch(int vertex)
        {
            DepthFirstSearchOperation(vertex);
        }

        public void DepthFirstSearchOperation(int vertex)
        {
            if (IsSearchTerminated)
            {
                return;
            }

            Discovered[vertex] = true;
            TotalTime++;
            EntryTime[vertex] = TotalTime;
            Process_Vertex_Early(vertex);

            var edgeAdjacencyList = CandidateGraph.Edges[vertex];
            while (edgeAdjacencyList != null)
            {
                int connectedVertex = edgeAdjacencyList.YValue;
                if (Discovered[connectedVertex] == false)
                {
                    Parent[connectedVertex] = vertex; // Tree Edges are determined by this Parent Array
                    ProcessEdge(vertex, connectedVertex);
                    DepthFirstSearchOperation(connectedVertex);
                }
                else if ((Processed[connectedVertex] == false && Parent[vertex] != connectedVertex) ||
                         CandidateGraph.IsDirected)
                {
                    // As per book
                    // ProcessEdge(vertex, connectedVertex);
                    // Back Edges are determined here.

                    // i.e. for DFS(5), for Edge [5-2]
                    // Processes[2] == false && Parent[5] i.e. 4 != 2)


                    // As per me: I think it should be this:
                    ProcessBackEdge(vertex, connectedVertex);
                }

                if (IsSearchTerminated)
                {
                    return;
                }

                edgeAdjacencyList = edgeAdjacencyList.Next;
            }

            Process_Vertex_Late(vertex, null);
            TotalTime++;
            ExitTime[vertex] = TotalTime;

            Processed[vertex] = true;
        }

        protected virtual void ProcessBackEdge(int vertex, int connectedVertex)
        {
            Console.WriteLine($"Processing back edge {vertex} to {connectedVertex}");
        }

        public void TerminateSearch()
        {
            IsSearchTerminated = true;
        }
        public void ResetSearchResults()
        {
            // Initialize Search
            for (int i = 0; i < this.CandidateGraph.MaxV; i++)
            {
                Parent[i] = -1;
                Processed[i] = Discovered[i] = false;
                EntryTime[i] = -1;
            }
            TotalTime = 0;
        }
    }
}
