using System;
using System.Threading;
using AlgoManual.Chapter5;

namespace AlgoManual.Chapter6.MinimumSpanningTree
{
    public class Prims
    {
        public Graph CandidateGraph { get; }
        public int StartVertex { get; }
        public bool[] InTree { get; }
        public int[] Parent { get; }

        public Prims(Graph candidateGraph, int startVertex)
        {
            CandidateGraph = candidateGraph;
            StartVertex = startVertex;
            InTree = new bool[candidateGraph.MaxV];
            Parent = new int[candidateGraph.MaxV];

            for (int i = 0; i < candidateGraph.MaxV; i++)
            {
                Parent[i] = -1;
            }
        }

        public void Execute()
        {
            // variables and init
            var distanceCostOfAddingToTree = new int[CandidateGraph.MaxV];
            for (int i = 0; i < CandidateGraph.MaxV; i++)
            {
                distanceCostOfAddingToTree[i] = int.MaxValue;
            }

            // Starts here
            distanceCostOfAddingToTree[StartVertex] = 0;
            var currentVertex = StartVertex;

            while (InTree[currentVertex] == false)
            {
                InTree[currentVertex] = true;
                var edgeAdjacencyList = CandidateGraph.Edges[currentVertex];
                
                while (edgeAdjacencyList !=null)
                {
                    var nextVertex = edgeAdjacencyList.YValue;
                    var currentEdgeWeight = edgeAdjacencyList.Weight.Value;

                    // Collect Cost Distance of Adding all vertices[connected to current vertex] to tree.
                    if ((distanceCostOfAddingToTree[nextVertex] > currentEdgeWeight) && !InTree[nextVertex])
                    {
                        distanceCostOfAddingToTree[nextVertex] = currentEdgeWeight;
                        Parent[nextVertex] = currentVertex;
                    }

                    edgeAdjacencyList = edgeAdjacencyList.Next;
                }

                // currentVertex = 1; -- no need for this
                int currentBestDistanceFromStart = int.MaxValue;

                // Since we collected the distances of all vertices from current vertices above
                // now let us select the vertex that is NOT InTree and
                // is closest to the CurrentVertex
                for (int i = 0; i < CandidateGraph.MaxV; i++)
                {
                    if (!InTree[i] && (currentBestDistanceFromStart > distanceCostOfAddingToTree[i]))
                    {
                        currentBestDistanceFromStart = distanceCostOfAddingToTree[i];
                        currentVertex = i;
                    }
                }
            }
        }

    }
}
