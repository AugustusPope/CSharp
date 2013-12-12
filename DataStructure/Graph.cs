using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{
    public class GraphVertex
    {
        public GraphVertex(System.Object label, System.Object value = null)
        {
            Label = label;
            Value = value;
        }

        public System.Object Label { get; private set; }
        public System.Object Value { get; private set; }

    }

    public class GraphEdge
    {
        public GraphEdge(GraphVertex from, GraphVertex to, double? weight)
        {
            FromVertex = from;
            ToVertex = to;
            Weight = weight;
        }

        public double? Weight { get; set; }
        public GraphVertex FromVertex { get; private set; }
        public GraphVertex ToVertex { get; private set; }
    }


    public class Graph
    {

        public enum GraphType { IsUndirected = 1, IsDirected = 2 }


        public Graph(GraphType graphType)
        {
            Vertexes = new HashSet<GraphVertex>();
            Edges = new HashSet<GraphEdge>();
            _graphType = graphType;
        }

        public void AddVertex(GraphVertex vertex)
        {
            Vertexes.Add(vertex);
        }

        public void AddVertex(List<GraphVertex> list)
        {
            foreach (GraphVertex vertex in list)
            {
                Vertexes.Add(vertex);
            }

        }

        public void AddEdge(GraphVertex from, GraphVertex to, double? weight = null)
        {
            if (_graphType == GraphType.IsDirected)
            {
                Edges.Add(new GraphEdge(from, to, weight));

            }

            if (_graphType == GraphType.IsUndirected)
            {
                Edges.Add(new GraphEdge(from, to, weight));
                Edges.Add(new GraphEdge(to, from, weight));
            }
        }

        private GraphType _graphType { get; set; }
        public HashSet<GraphVertex> Vertexes { get; private set; }
        public HashSet<GraphEdge> Edges { get; private set; }
    }

    public static class GraphAlgorithm
    {
        public static List<GraphVertex> BreadthFirstSearch(Graph g, GraphVertex v)
        {

            HashSet<GraphVertex> foundVertexes = new HashSet<GraphVertex>();
            Queue<GraphVertex> queue = new Queue<GraphVertex>();
            List<GraphVertex> resultList = new List<GraphVertex>();


            foundVertexes.Add(v);//found the source vertex
            queue.Enqueue(v);

            while (queue.Count > 0)
            {

                GraphVertex current = queue.Dequeue();
               
                resultList.Add(current);//add to result

                List<GraphVertex> adjacents = (from Edge in g.Edges
                                               where Edge.FromVertex == current
                                               select  Edge.ToVertex).ToList<GraphVertex>();

                foreach (GraphVertex vertex in adjacents)
                {
                    if (!foundVertexes.Contains(vertex))
                    {
                        queue.Enqueue(vertex);
                        foundVertexes.Add(vertex);//mark the vertex has been found
                    }
                }
            }

            return resultList;
        }

        public static List<GraphVertex> DepthFirstSearch(Graph g) {
            List<GraphVertex> resultList = new List<GraphVertex>();
            HashSet<GraphVertex> visited = new HashSet<GraphVertex>();
            foreach(GraphVertex vertex in g.Vertexes){
                if (!visited.Contains(vertex)) {
                    DepthFirstSearch_Visit(g,vertex,visited,resultList);
                }
            
            }

            return resultList;

        }

        private static void DepthFirstSearch_Visit(Graph g,GraphVertex v,HashSet<GraphVertex> visited,List<GraphVertex> resultList)
        { 
            List<GraphVertex> adjacents =  (from edge in g.Edges
                                            where edge.FromVertex == v
                                            select edge.ToVertex
                                                ).ToList<GraphVertex>();

            foreach(GraphVertex vertex in adjacents){
                if (!visited.Contains(vertex)) {
                    visited.Add(vertex);
                    DepthFirstSearch_Visit(g,v,visited,resultList);
                }
            }

            resultList.Add(v);


        
        }



    }








}//end
