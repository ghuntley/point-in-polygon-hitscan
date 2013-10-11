using System;
using System.Collections.Generic;

using DotSpatial.Topology;

namespace PointInsidePolygonDemo
{
    class Program
    {
        #region Properties

        public static Coordinate Point
        {
            get; set;
        }

        public static Polygon Polygon
        {
            get; set;
        }

        public static List<Coordinate> PolygonVertices
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        private static void AddVertice(double x, double y)
        {
            PolygonVertices.Add(new Coordinate(x, y));
        }

        /// <summary>
        /// example of how to do point in polygon (aka hit test)
        /// </summary>
        /// <see cref="http://i.stack.imgur.com/vCFl0.png"/>
        /// <see cref="http://stackoverflow.com/a/218081/496857"/>
        /// <see cref="http://erich.realtimerendering.com/ptinpoly/"/>
        private static void Main(string[] args)
        {
            PolygonVertices = new List<Coordinate>();

            // see: http://i.stack.imgur.com/vCFl0.png
            AddVertice(13.5, 41.5);
            AddVertice(42.5, 56.5);
            AddVertice(39.5, 69.5);
            AddVertice(42.5, 84.5);
            AddVertice(13.5, 100.0);
            AddVertice(6.0, 70.5);

            Point = new Coordinate(23.0, 70.0);

            Polygon = new Polygon(PolygonVertices);

            if (PointInPolygon(Polygon, Point))
            {
                Console.WriteLine("Point {0} is within polygon.", Point.ToString());
            }
            else
            {
                Console.WriteLine("Point {0} does not intersect polygon.", Point.ToString());
            }
        }

        private static bool PointInPolygon(Polygon polygon, Coordinate point)
        {
            return polygon.Envelope.Intersects(point);
        }

        #endregion Methods
    }
}