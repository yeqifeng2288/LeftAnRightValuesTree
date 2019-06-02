using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeftAndRightOfValueTreeDemo
{
    public class TreeOperation<TTree> where TTree : ITreeNode<TTree>
    {
        /// <summary>
        /// 重新计算左右值的实现。
        /// </summary>
        /// <param name="trees">当前处理树。</param>
        /// <param name="globalLeft">当前左值。</param>
        /// <param name="depth">深度。</param>
        /// <returns>返回带有新左右值的列表。</returns>
        public virtual IEnumerable<KeyValuePair<TTree, KeyValuePair<int, int>>> RecalculatedValue(IEnumerable<TTree> trees, int depth, int globalLeft = 0, int globalRight = 0)
        {
            trees = trees.OrderBy(o => o.Left).ToArray();
            var tempTree = new List<KeyValuePair<TTree, KeyValuePair<int, int>>>();
            foreach (var node in trees)
            {
                if (node.Depth == depth)
                {
                    var nodeCount = trees.Where(t => t.Left >= node.Left && t.Right <= node.Right && t.Depth >= depth + 1).Count() + 1;
                    var right = nodeCount * 2;
                    globalLeft += 1;
                    if (depth == 0)
                    {
                        globalRight += right;
                    }
                    else
                    {
                        globalRight = globalLeft + (nodeCount * 2) - 1;
                    }

                    tempTree.Add(new KeyValuePair<TTree, KeyValuePair<int, int>>(node, new KeyValuePair<int, int>(globalLeft, globalRight)));
                    globalLeft = globalRight;
                }
            }

            var result = new List<KeyValuePair<TTree, KeyValuePair<int, int>>>();
            foreach (var node in tempTree)
            {
                result.Add(node);
                if (node.Key.IsLeaf)
                    continue;
                var tree = RecalculatedValue(trees.Where(t => t.Left >= node.Key.Left && t.Right <= node.Key.Right && t.Depth >= node.Key.Depth + 1), node.Key.Depth + 1, node.Value.Key, node.Value.Value);
                result.AddRange(tree);
            }

            return result;
        }

        /// <summary>
        /// 重新排序树，重新计算左右值。
        /// </summary>
        /// <param name="testTrees">需要重新排序的树。</param>
        /// <returns>返回重新计算左右值的树。</returns>
        public IEnumerable<TTree> BuildRecalculatedValue(IEnumerable<TTree> testTrees)
        {
            var list = RecalculatedValue(testTrees, 0, 0).OrderBy(or => or.Value.Key).ToArray();
            var results = new List<TTree>();
            foreach (var node in list)
            {
                node.Key.Left = node.Value.Key;
                node.Key.Right = node.Value.Value;
                results.Add(node.Key);
            }

            return results;
        }

        /// <summary>
        /// 在前面插入节点。
        /// </summary>
        /// <param name="tree">数据源。</param>
        /// <param name="taggerNode">需要插入的节点。</param>
        /// <param name="sourceNode">目标节点</param>
        /// <param name="IsFront">是否在前面插入,false在改节点后插入。</param>
        /// <returns></returns>
        public IEnumerable<TTree> InserNode(IEnumerable<TTree> tree, TTree sourceNode, TTree taggerNode, bool IsFront)
        {
            var position = 0;
            if (IsFront)
            {
                position = taggerNode.Right;
            }
            else
            {
                position = taggerNode.Left - 1;
            }

            var nodes = this.GetThisNodesAndChild(tree, sourceNode);
            if (nodes == null)
            {
                nodes = new[] { sourceNode };
            }

            foreach (var node in tree)
            {
                if (node.Right > position)
                {
                    node.Right += nodes.Count() * 2;
                    node.Left += nodes.Count() * 2;
                }
            }

            var depth = taggerNode.Depth;
            // 重新计算深度。
            nodes = this.BuildRecalculatedValue(nodes);
            nodes = this.RecalculateDepth(nodes);
            foreach (var node in nodes)
            {
                node.Depth += depth;
                node.Left += position;
                node.Right += position;
            }

            return this.BuildRecalculatedValue(tree);
        }

        /// <summary>
        /// 中间插入节点。
        /// </summary>
        /// <param name="tree">数据源。</param>
        /// <param name="taggerNode">需要插入的节点位置。</param>
        /// <param name="sourceNode">需要插入节点位置的数据。</param>
        /// <returns></returns>
        public IEnumerable<TTree> InsertNode(IEnumerable<TTree> tree, TTree taggerNode, IEnumerable<TTree> sourceNode)
        {
            // 获得此节点以及将要插入节点的值。
            var count = sourceNode.Count();

            // 原本左值向右移动。
            var originLeft = taggerNode.Left;
            var originRight = taggerNode.Right;
            foreach (var item in tree)
            {
                if (item.Right == originRight)
                {
                    item.Right += count * 2;
                }
                else if (item.Left > originLeft)
                {
                    item.Left += count * 2;
                    item.Right += count * 2;
                }
            }

            // 解决深度的问题。
            sourceNode = this.RecalculateDepth(sourceNode);

            // 重新排序树。
            sourceNode = this.BuildRecalculatedValue(sourceNode);
            foreach (var node in sourceNode)
            {
                node.Depth += taggerNode.Depth + 1;
            }

            // 将节点添加到节点目标。
            foreach (var node in sourceNode)
            {
                node.Left += taggerNode.Left;
                node.Right += taggerNode.Left;
            }

            var result = tree.ToList();
            result.AddRange(sourceNode);
            return this.BuildRecalculatedValue(result);
        }

        /// <summary>
        /// 从0开始计算深度。
        /// </summary>
        /// <returns>返回当前的执行结果。</returns>
        public virtual IEnumerable<TTree> RecalculateDepth(IEnumerable<TTree> tree)
        {
            var minDepth = tree.OrderBy(t => t.Depth).First().Depth;
            if (minDepth == 0)
                return tree;

            foreach (var node in tree)
            {
                node.Depth = node.Depth - minDepth;
            }

            return tree;
        }

        /// <summary>
        /// 删除节点。
        /// </summary>
        /// <param name="tree">数据源。</param>
        /// <param name="node">需要删除的节点。</param>
        /// <returns></returns>
        public virtual IEnumerable<TTree> DeleteNode(IEnumerable<TTree> tree, TestTree node)
        {
            var dataSource = tree.ToList();
            dataSource.RemoveAll(t => t.Left >= node.Left && node.Right <= node.Right);
            return this.BuildRecalculatedValue(dataSource);
        }

        /// <summary>
        /// 获得此节点下的所有成员树。
        /// </summary>
        /// <returns>返回当前的执行结果。</returns>
        private IEnumerable<TTree> GetThisNodesCount(TTree node, IEnumerable<TTree> trees)
        {
            return trees.Where(dp => dp.Left >= node.Left && dp.Right <= node.Right && dp.Depth > node.Depth);
        }

        /// <summary>
        /// 获得此节点下的所有成员树,包括此节点。
        /// </summary>
        /// <returns>返回当前的执行结果。</returns>
        private IEnumerable<TTree> GetThisNodesAndChild(IEnumerable<TTree> tree, TTree node)
        {
            return tree.Where(n => n.Left >= node.Left && n.Right <= node.Right);
        }
    }
}
