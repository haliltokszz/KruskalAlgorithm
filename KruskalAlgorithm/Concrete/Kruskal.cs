using KruskalAlgorithm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruskalAlgorithm.Concrete
{
    class Kruskal : Graph
    {
        private int cost=0;
        private int groupNo = 0;

        public bool CheckCycle(Edge edge)
        {
            Vertex from = edge.GetFromVertex();
            Vertex to = edge.GetToVertex();
            if (from.GetVisited() != 0 && to.GetVisited() != 0) //İkisi de bir grupta ise
            {
                if (from.GetVisited() == to.GetVisited()) return false; //Ve grupları aynıysa
            }
            return true;
        }

        public void SetCycle(Edge edge)
        {
            Vertex from = edge.GetFromVertex();
            Vertex to = edge.GetToVertex();
            if (from.GetVisited() == 0 && to.GetVisited() == 0)//Eğer herhangi bir grupta değillerse
            {
                groupNo++;
                from.SetVisited(groupNo);
                to.SetVisited(groupNo);
            } 
            else if (from.GetVisited() == 0 || to.GetVisited() == 0) //Biri bir gruptaysa grupları eşitle
            {
                if (from.GetVisited() != 0) to.SetVisited(from.GetVisited());
                else from.SetVisited(to.GetVisited());
            }
            else if (from.GetVisited() != 0 && to.GetVisited() != 0) //İkisi de bir gruptaysa
            {
                if (from.GetVisited() != to.GetVisited()) //Ve grupları farklıysa gruplarını eşitle
                {
                    int tempGroup = from.GetVisited();
                    foreach (Edge e in this.GetEdges())
                    {
                        if (e.GetFromVertex().GetVisited() == tempGroup) e.GetFromVertex().SetVisited(to.GetVisited()); //Fromun grubundaysa artık To grubunda
                        else if (e.GetToVertex().GetVisited() == tempGroup) e.GetToVertex().SetVisited(to.GetVisited()); //To grubundaysa artık From grubunda
                    }//Tüm edgelerde değişimi yaptık
                }
            }
        }

        public void MST(int V) {
            Kruskal graphMST = new Kruskal();
            foreach(Edge edge in this.GetEdges())
            {
                bool cycle = CheckCycle(edge);
                if (cycle)
                {
                    graphMST.AddEdge(edge);
                    SetCycle(edge);
                    cost += edge.GetWeight();
                }
            }
            graphMST.Write();
            Console.WriteLine("Cost: "+cost.ToString());
            if (graphMST.GetEdges().Count == V - 1)
                Console.WriteLine("I guess everything is fine... My edge count equals (Vertex-1)");
        }
    }
}
