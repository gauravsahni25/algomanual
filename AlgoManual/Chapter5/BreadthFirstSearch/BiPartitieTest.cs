using System.Diagnostics;

namespace AlgoManual.Chapter5.BreadthFirstSearch
{
    [DebuggerDisplay("Status: {IsGraphBipartite}")]
    public class BipartitieTest : BreadthFirstSearch
    {
        public enum Color
        {
            UNCOLORED, WHITE, BLACK
        }
        public Color[] Colors { get; set; }
        public bool IsGraphBipartite { get; set; }
        public BipartitieTest(Graph candidateGraph) : base(candidateGraph)
        {
            Colors = new Color[candidateGraph.MaxV];
        }

        public void RunTest()
        {
            for (int i = 0; i < CandidateGraph.MaxV; i++)
            {
                Colors[i] = Color.UNCOLORED;
            }
            IsGraphBipartite = true;

            for (int i = 0; i < CandidateGraph.MaxV; i++)
            {
                // This is common in both CC and Bipartite i.e. keep running search until all are discovered.
                // which makes sense
                if (Discovered[i]==false)
                {
                    Colors[i] = Color.WHITE;
                    PerformSearch(i);
                }
            }
        }

        protected override void ProcessEdge(int vertex, int connectedVertex)
        {
            if (Colors[vertex] == Colors[connectedVertex])
            {
                IsGraphBipartite = false;
            }

            // we did it here becasue ProcessEdge is the only place where we have the connecting vertex
            Colors[connectedVertex] = Complement(Colors[vertex]);
        }
        private Color Complement(Color color)
        {
            if (color == Color.WHITE)
            {
                return Color.BLACK;
            }
            if (color == Color.BLACK)
            {
                return Color.WHITE;
            }

            return Color.UNCOLORED;
        }
    }
}