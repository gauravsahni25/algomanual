using System;
using System.Collections.Generic;

namespace AlgoManual.Chapter5.BreadthFirstSearch
{
    public class PathFinding : BreadthFirstSearch
    {
        public PathFinding(Graph candidateGraph) : base(candidateGraph)
        {
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
