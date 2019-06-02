using System;
using System.Collections.Generic;
using System.Text;

namespace LeftAndRightOfValueTreeDemo
{
    public class TestTree : ITreeNode<TestTree>
    {
        /// <summary>
        /// ID。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 商品名称。
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 左值。
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// 右值。
        /// </summary>
        public int Right { get; set; }

        /// <summary>
        /// 深度。
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// 是否是叶子节点。
        /// </summary>
        public bool IsLeaf => (Right - Left) <= 1;

        /// <summary>
        /// 商店Id。
        /// </summary>
        public int StoreId { get; set; }
    }
}
