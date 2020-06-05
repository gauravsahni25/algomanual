using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace AlgoManual.Chapter5
{
    [DebuggerDisplay("Edge: ({XThatComesFromEdgeIndexHereForDebugging} - {YValue})")]
    public class EdgeNode
    {
        public int YValue { get; set; }
        public int? Weight { get; set; }
        public EdgeNode Next { get; set; }
        public int XThatComesFromEdgeIndexHereForDebugging { get; set; }
    }
    

    //Adjacency List
    public class Graph
    {
        public Graph(int MAXV)
        {
            Edges = new EdgeNode[MAXV];
            Degree = new int[MAXV];
            MaxV = MAXV;
        }

        public int MaxV { get; }
        // Array of Linked Lists, denotes adj. list of vertex at a given index.
        public EdgeNode[] Edges { get; set; }
        // Array of degree, denotes degree of vertex at a given index
        public int[] Degree { get; set; }
        public int NVertices => MaxV; // this works because we do not create a random sized list
        public int NEdges { get; set; }
        public bool IsDirected { get; set; }

        public void ReadGraph(List<Point> edges, bool directed)
        {
            InitializeGraph(directed);
            // NEdges = edges.Count;

            for (int i = 0; i < edges.Count; i++)
            {
                InsertEdge(edges[i].X, edges[i].Y, directed);
            }
        }

        private void InitializeGraph(bool directed)
        {
            NEdges = 0;
            IsDirected = directed;
            for (int i = 0; i < MaxV; i++)
            {
                Degree[i] = 0;
            }

            for (int i = 0; i < MaxV; i++)
            {
                Edges[i] = null;
            }
        }

        //We parametrize our insertion with the directed Boolean flag
        // This is to identify whether we need to insert two copies of each edge or only one.
        // Because Edges by themselves are always directional in Adjacency List
        // So if (x,y) is an edge, in Undirected we need to add (y,x) too
        private void InsertEdge(int x, int y, bool directed)
        {
            // create a node | We represent | Directed Edge (x, y) by an EdgeNode y in x's Adjacency List
            EdgeNode edgeNode = new EdgeNode
            {
                // point the new Node to Edges[x]'s linked list
                Next = Edges[x],
                YValue =y,
                Weight = null,

                XThatComesFromEdgeIndexHereForDebugging= x
            };

           // Put the new node at the HEAD of the Adjacency Linked list
            Edges[x] = edgeNode;

            // Increase the degree
            Degree[x] = Degree[x] + 1;
            NEdges++;

            if (!directed)
            {
                // The same edge has to appear in Y's Adjacency List | Thus graph is Undirected
                InsertEdge(y, x, true);
            }
        }

        public void PrintGraph()
        {
            for (int i = 0; i < NVertices; i++)
            {
                Console.WriteLine(i);
                EdgeNode edge = this.Edges[i];
                while (edge!=null)
                {
                    Console.WriteLine($"{edge.YValue}");
                    edge = edge.Next;
                }
                Console.WriteLine("--");
            }
        }
    }
}
