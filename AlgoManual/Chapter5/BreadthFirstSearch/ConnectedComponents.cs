﻿using System;
using System.Collections.Generic;

namespace AlgoManual.Chapter5.BreadthFirstSearch
{
    public class ConnectedComponents : BreadthFirstSearch
    {
        public ConnectedComponents(Graph candidateGraph) : base(candidateGraph)
        {
        }

        public int FindConnectedComponents()
        {
            int numberOfComponents = 0;
            InitializeSearch();

            for (int i = 0; i < CandidateGraph.MaxV; i++)
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
    }
}
