using System;
using System.Collections.Generic;
using System.Text;

namespace LeftAndRightOfValueTreeDemo
{
    public interface ITreeNode<tree>
    {
        /// <summary>
        /// 左值。
        /// </summary>
        int Left { get; set; }

        /// <summary>
        /// 右值。
        /// </summary>
        int Right { get; set; }

        /// <summary>
        /// 深度。
        /// </summary>
        int Depth { get; set; }
        /// <summary>
        /// 是否是叶子节点。
        /// </summary>
        /// <returns></returns>
        bool IsLeaf { get; }
    }
}
