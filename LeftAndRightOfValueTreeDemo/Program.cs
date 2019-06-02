using System;
using System.Collections.Generic;
using System.Linq;

namespace LeftAndRightOfValueTreeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var testTrees = Config.GetTestSortTrees();
            var operation = new TreeOperation<TestTree>();
            var first = testTrees.OrderBy(o => o.Left).First();
            var result = operation.BuildRecalculatedValue(testTrees);
            Console.WriteLine("-------");
            //result = operation.BuildRecalculatedValue(result.ToList()); foreach (var item in result)
            //{
            //    Console.WriteLine($"{++count} {item.Left} {item.Right} {item.Depth} {item.GoodsName}");
            //}

            // var testDepth = Config.GetTestDepthTree();
            // result = operation.RecalculateDepth(testDepth);
            // foreach (var item in result.OrderBy(o => o.Left))
            // {
            //     Console.WriteLine($"{++count} {item.Left} {item.Right} {item.Depth} {item.GoodsName}");
            // }

            // System.Console.WriteLine("测试节点插入功能。");
            // var insertTree = Config.GetTestInsertTree();
            // var depthTree = Config.GetTestDepthTree();
            // var insert = insertTree.LastOrDefault();
            // result = operation.InsertNode(insertTree, insert, depthTree);
            // ShowResult(result);

            // result = operation.DeleteNode(result, result.First());
            // System.Console.WriteLine("测试是否能够删除。");
            // ShowResult(result);
            ShowResult(result);
            System.Console.WriteLine("测试节点树用于交换。");
            var firstNode = testTrees.First();
            var lastNode = testTrees.First(o => o.Left == 33);
            result = operation.InserNode(testTrees, firstNode, lastNode, false);
            ShowResult(result);
            Console.Read();
        }

        public static void ShowResult(IEnumerable<TestTree> tree)
        {
            var count = 0;
            foreach (var item in tree.OrderBy(o => o.Left))
            {
                Console.WriteLine($"{++count} {item.Left} {item.Right} {item.Depth} {item.GoodsName}");
            }
        }
    }
}
