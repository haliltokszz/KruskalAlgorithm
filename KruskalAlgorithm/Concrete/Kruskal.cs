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
            //Console.WriteLine("-Before-From Name: " + from.GetName() + " Group: " + from.GetVisited() + " |To Name: " + to.GetName() + " Group: " + to.GetVisited());
            if (from.GetVisited() == 0 && to.GetVisited() == 0)
            {
                groupNo++;
                from.SetVisited(groupNo);
                to.SetVisited(groupNo);

            } //Eğer herhangi bir grupta değillerse
            else if (from.GetVisited() == 0 || to.GetVisited() == 0) //Biri bir gruptaysa
            {
                if (from.GetVisited() != 0) to.SetVisited(from.GetVisited()); //Grupları eşitle
                else from.SetVisited(to.GetVisited());

            }
            else if (from.GetVisited() != 0 && to.GetVisited() != 0) //Farklı gruptalarsa..
            {
                if (from.GetVisited() == to.GetVisited()) return false;
                else
                {
                    int tempGroup = from.GetVisited();
                    foreach (Edge e in this.GetEdges())
                    {
                        if (e.GetFromVertex().GetVisited() == tempGroup) e.GetFromVertex().SetVisited(to.GetVisited()); //Fromun grubundaysa artık To grubunda
                        else if (e.GetToVertex().GetVisited() == tempGroup) e.GetToVertex().SetVisited(to.GetVisited());
                    }//Tüm edgelerde değişimi yaptık
                }
                

            }
            //Console.WriteLine("-After-From Name: "+from.GetName()+" Group: "+from.GetVisited()+" |To Name: "+ to.GetName()+" Group: "+to.GetVisited());
            return true;
        }

        public void MinimumCost(Edge edge)
        {
            cost += edge.GetWeight();
        }

        public void MST(int V) {
            Kruskal graphMST = new Kruskal();
            foreach(Edge edge in this.GetEdges())
            {
                bool cycle = CheckCycle(edge);
                if (cycle)
                {
                    graphMST.AddEdge(edge);
                    MinimumCost(edge);
                }
            }
            graphMST.Write();
            Console.WriteLine("Cost: "+cost.ToString());
            if (graphMST.GetEdges().Count == V - 1)
                Console.WriteLine("I guess everything is fine... My edge count equals (Vertex-1)");
        }
    }
}
