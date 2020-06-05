using System;

namespace AlgoManual.Chapter5.Common
{
    public class EdgeAndVertexProcessor
    {
        protected virtual void Process_Vertex_Early(int vertex)
        {
            Console.WriteLine($"Processing Vertex Early: {vertex}");
        }

        protected virtual void ProcessEdge(int vertex, int connectedVertex)
        {
            Console.WriteLine($"Processing Edge: {(vertex, connectedVertex)}");
        }

        protected virtual void Process_Vertex_Late(int vertex)
        {
            Console.WriteLine($"Done Processing: {vertex}");
        }
    }
}
