
using cyber_protection.Models;
using static cyber_protection.Utils.JsonUtil;
using static cyber_protection.Utils.SeverityUtil;
using static cyber_protection.Utils.BalanceTreeUtil;
using System.Linq;
namespace cyber_protection
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("---Creating the binary tree by importing a JSON file with a Severity range and entering the tree...\n");
            var allNodes = ReadFromJsonAsync<List<Data>>("..\\..\\..\\Jsons\\defenceStrategies.json");
            BSTree tree = new BSTree();
            allNodes?.ForEach(tree.Insert);

            Console.Write("---Is the tree balanced? ");
            Thread.Sleep(1000);
            bool isBalanced = tree.IsBalanced();
            Console.WriteLine(isBalanced);
            Console.WriteLine();

            Thread.Sleep(4000);
            Console.WriteLine(tree.ToString());
            Console.WriteLine();

            if (!isBalanced)
            {
                Console.WriteLine("---Balance the tree...\n");
                tree = tree.BildBalanceTree();
                Thread.Sleep(4000);

                Console.WriteLine(tree.ToString());
                Thread.Sleep(4000);

                Console.WriteLine("---Print the tree as a list to show that the order is preserved.\n");
                tree.GetAllNodesInOrder().ForEach(x => Console.WriteLine(x.Value.ToString()));
                Console.WriteLine();
                Thread.Sleep(4000);

                Console.WriteLine("---The system saves the data\n");
                await WriteToJsonFileAsync("..\\..\\..\\Jsons\\balancedTree-node.json", tree.GetAllNodesPreOrder());
                await WriteToJsonFileAsync("..\\..\\..\\Jsons\\balancedTree-data.json", tree.GetAllNodesPreOrder().Select(n => n.Value));
                Thread.Sleep(4000);
            }

            Console.WriteLine("---The system receives threats...\n");
            var allThreat = ReadFromJsonAsync<List<Threat>>("..\\..\\..\\Jsons\\threats.json");
            Thread.Sleep(4000);

            Console.WriteLine("---The system calculates the severity of the attacks...\n");
            var severityOfAttacks = allThreat.Select(t => t.SeverityLevel()).ToList();
            Thread.Sleep(4000);

            Console.WriteLine("---The system implements protections...\n");
            var defenses = severityOfAttacks.Select(s => tree.PreOrderSearch(s)).ToList();
            defenses.ForEach(dList => dList.ForEach(d => { Console.WriteLine(d); Thread.Sleep(2000); }));

            Console.WriteLine();
            Console.WriteLine("---goodbye...");
        }
    }
}
//