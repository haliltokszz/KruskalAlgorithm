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
        public override void MST(int V) {
            Kruskal graphMST = new Kruskal();
            foreach(Edge edge in this.GetEdges())
            {
                bool cycle = CheckCycle(edge);
                if (cycle)
                {
                    graphMST.AddEdge(edge);
                    SetCycle(edge);
                    Cost += edge.GetWeight();
                }
            }
            graphMST.Write();
            Console.WriteLine("Cost: "+Cost.ToString());
            if (graphMST.GetEdges().Count == V - 1)
                Console.WriteLine("I guess everything is fine... My edge count equals (Vertex-1)");
        }
    }
}
