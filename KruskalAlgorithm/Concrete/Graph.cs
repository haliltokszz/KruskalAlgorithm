using KruskalAlgorithm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruskalAlgorithm.Concrete
{
    abstract class Graph
    {
        List<Edge> edges = new List<Edge>();

        public void AddEdge(int fromName, int toName, int weight)
        {
            Edge edge;
            if(GetVertex(fromName)!=null && GetVertex(toName) != null)
            {
                edge = new Edge(GetVertex(fromName), GetVertex(toName), weight);
            }else if (GetVertex(fromName) != null)
            {
                Vertex toVertex = new Vertex(toName);
                edge = new Edge(GetVertex(fromName), toVertex, weight);
            }else if (GetVertex(toName) != null)
            {
                Vertex fromVertex = new Vertex(fromName);
                edge = new Edge(fromVertex, GetVertex(toName), weight);
            }
            else
            {
                Vertex toVertex = new Vertex(toName);
                Vertex fromVertex = new Vertex(fromName);
                edge = new Edge(fromVertex, toVertex, weight);
            }

            edge.GetFromVertex().AddSubset(edge.GetToVertex());
            //edge.From.AddSubset(To);
            edges.Add(edge);
        }

        public void AddEdge(Edge edge)
        {
            edges.Add(edge);
        }

        public Vertex GetVertex(int vertexName)
        {
            foreach(Edge edge in edges)
            {
                if (edge.GetToVertexName() == vertexName)
                    return edge.GetToVertex();
                else if (edge.GetFromVertexName() == vertexName)
                    return edge.GetFromVertex();
            }
            return null;
        }

        public void Write()
        {
            foreach (Edge edge in edges)
            {
                Console.Write(edge.GetFromVertexName());
                Console.Write(" -> "+edge.GetToVertexName());
                Console.Write(" : " + edge.GetWeight().ToString());
                Console.Write(" Subsets: ");
                List<Vertex> subsets = edge.GetFromVertex().GetSubsets();
                foreach (Vertex subset in subsets)
                {
                    Console.Write(subset.GetName().ToString()+" ");
                }
                Console.WriteLine();
            }
        }

        public void SortGraph()
        {
            edges.Sort();
        }

        public List<Edge> GetEdges()
        {
            return this.edges;
        }

        /*public List<Vertex> GetSubsets(int vertexName)
        {
            Vertex vertex;
            
            return vertex.GetSubsets();
        }*/

        /*void AddVertex(int name, bool from)
        {
            if (from)
                vertexFrom.Name = name;
            else
                vertexTo.Name = name;
        }*/
    }
}
