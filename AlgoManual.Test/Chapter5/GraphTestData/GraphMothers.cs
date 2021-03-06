﻿using System.Collections.Generic;
using System.Drawing;
using AlgoManual.Chapter5;

namespace AlgoManual.Test.Chapter5.GraphTestData
{
    public static class GraphMothers
    {
        private static Graph _figure59Graph = null;
        private static Graph _figure59GraphBipartitie = null;
        private static Graph _zeroBasedHandDrawnPage167 = null;
        private static Graph _fig511Graph = null;

        public static Graph Figure59Graph
        {
            get
            {
                if (_figure59Graph == null)
                {
                    List<Point> edges = new List<Point>()
                    {
                        new Point(1, 6),
                        new Point(1, 5),
                        new Point(1, 2),
                        new Point(2, 5),
                        new Point(2, 3),
                        new Point(3, 4),
                        new Point(4, 5),
                    };
                    _figure59Graph = new Graph(6 + 1); // We do MaxV+1 when we are using Index starting from 1 
                    _figure59Graph.ReadGraph(edges, false);
                }
                return _figure59Graph;
            }
        }

        public static Graph Figure59GraphBipartitie
        {
            get
            {
                if (_figure59GraphBipartitie == null)
                {
                    List<Point> edges = new List<Point>()
                    {
                        new Point(1, 2),
                        new Point(1, 5),
                        new Point(1, 6),
                        new Point(2, 3),
                        new Point(4, 5),
                    };
                    _figure59GraphBipartitie = new Graph(6 + 1); // We do MaxV+1 when we are using Index starting from 1 
                    _figure59GraphBipartitie.ReadGraph(edges, false);
                }
                return _figure59GraphBipartitie;
            }
        }

        public static Graph ZeroBasedHandDrawnOnPage167
        {
            get
            {
                if (_zeroBasedHandDrawnPage167 == null)
                {
                    List<Point> edges = new List<Point>()
                    {
                        new Point(0, 1),
                        new Point(1, 2),
                        new Point(2, 0),
                        new Point(3, 4),
                        new Point(4, 5),
                        new Point(5, 3),
                    };
                    _zeroBasedHandDrawnPage167 = new Graph(6); // Here just MaxV, We do MaxV+1 when we are using Index starting from 1 
                    _zeroBasedHandDrawnPage167.ReadGraph(edges, false);
                }
                return _figure59Graph;
            }
        }

        public static Graph Fig511Graph
        {
            get
            {
                if (_fig511Graph == null)
                {
                    List<Point> edges = new List<Point>()
                    {
                        new Point(1, 10),
                        new Point(1, 2),
                        
                        new Point(2, 3),
                        new Point(3, 10),
                        new Point(3, 4),
                        new Point(3, 9),
                        new Point(9, 8),
                        new Point(4, 8),
                        new Point(4, 5),
                        new Point(5, 7),
                        new Point(5, 6),
                        new Point(7, 8),
                        new Point(7, 6),
                    };
                    _fig511Graph = new Graph(10 + 1); // We do MaxV+1 when we are using Index starting from 1 
                    _fig511Graph.ReadGraph(edges, false);
                }
                return _fig511Graph;
            }
        }
    }
}
