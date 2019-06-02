using System;
using System.Collections.Generic;
using System.Text;

namespace LeftAndRightOfValueTreeDemo
{
    class Config
    {
        /// <summary>
        /// 获得测试使用的插入节点。
        /// </summary>
        /// <returns>返回测试使用的测试节点。</returns>
        public static IEnumerable<TestTree> GetTestDepthTree()
        {
            return new List<TestTree>
            {
                new TestTree{
                    Depth=3,
                    Left=1,
                    Right=6,
                    GoodsName="深度重置"
                },
                new TestTree
                {
                    Depth=4,
                    Left=2,
                    Right=5,
                    GoodsName="深度重置1"
                },
                new TestTree
                {
                    Depth=5,
                    Left=3,
                    Right=4,
                    GoodsName="深度重置2"
                }
            };
        }

        /// <summary>
        /// 获得测试使用的插入节点树。
        /// </summary>
        /// <returns>返回测试插入节点使用时使用的树。</returns>
        public static IEnumerable<TestTree> GetTestInsertTree()
        {
            return new List<TestTree>
            {
                new TestTree
                {
                    Depth = 0,
                    Left = 1,
                    Right = 8,
                    GoodsName = "测试节点1-8"
                },
                new TestTree
                {
                    Depth = 1,
                    Left = 2,
                    Right = 7,
                    GoodsName = "测试节点2-7"
                },
                new TestTree
                {
                    Depth = 2,
                    Left = 3,
                    Right = 4,
                    GoodsName = "测试节点3-4"
                },
                new TestTree
                {
                    Depth = 2,
                    Left = 5,
                    Right = 6,
                    GoodsName = "测试节点5-6"
                },
                new TestTree
                {
                    Depth = 0,
                    Left = 9,
                    Right =10,
                    GoodsName = "测试节点9-10"
                },
                // 以下是用于交换的数据。
                new TestTree
                {
                    Depth = 0,
                    Left = 11,
                    Right = 16,
                    GoodsName = "用于交换的测试11-16"
                },
                new TestTree
                {
                    Depth = 1,
                    Left = 12,
                    Right = 15,
                    GoodsName = "用于交换的测试11-16"
                },
                new TestTree
                {
                    Depth = 2,
                    Left = 13,
                    Right = 14,
                    GoodsName = "用于交换的测试11-16"
                }
            };
        }

        /// <summary>
        /// 获取测试树。
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TestTree> GetTestSortTrees()
        {
            return new List<TestTree>
            {
                new TestTree
                {
                    Depth = 0,
                    Left = 4,
                    Right = 7,
                    GoodsName = "苹果",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 0,
                    Left = 8,
                    Right = 9,
                    GoodsName = "栗子",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 0,
                    Left = 10,
                    Right = 15,
                    GoodsName = "香蕉",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 0,
                    Left = 16,
                    Right = 17,
                    GoodsName = "风扇",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 0,
                    Left = 18,
                    Right = 21,
                    GoodsName = "显卡",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 0,
                    Left = 22,
                    Right = 23,
                    GoodsName = "CPU",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 0,
                    Left = 26,
                    Right = 27,
                    GoodsName = "硬盘",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 1,
                    Left = 5,
                    Right = 6,
                    GoodsName = "键盘",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 1,
                    Left = 11,
                    Right = 14,
                    GoodsName = "电影",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 1,
                    Left = 19,
                    Right = 20,
                    GoodsName = "内存",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 2,
                    Left = 12,
                    Right = 13,
                    GoodsName = "显示器",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 0,
                    Left = 44,
                    Right = 46,
                    GoodsName = "显示器3",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 0,
                    Left = 48,
                    Right = 47,
                    GoodsName = "显示器3",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 0,
                    Left = 52,
                    Right = 99,
                    GoodsName = "显示器3",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 1,
                    Left = 57,
                    Right = 88,
                    GoodsName = "显示器3",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 2,
                    Left = 62,
                    Right = 72,
                    GoodsName = "显示器3",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 0,
                    Left = 123214,
                    Right = 323214,
                    GoodsName = "显示器3",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 1,
                    Left = 183214,
                    Right = 293214,
                    GoodsName = "显示器4",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 0,
                    Left = 1183214,
                    Right = 1293214,
                    GoodsName = "显示器4",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 1,
                    Left = 53214,
                    Right = 793214,
                    GoodsName = "显示器4",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 0,
                    Left = 100,
                    Right = 160,
                    GoodsName = "显示器6",
                    StoreId = 1
                },new TestTree
                {
                    Depth = 1,
                    Left = 101,
                    Right = 159,
                    GoodsName = "显示器7",
                    StoreId = 1
                },new TestTree
                {
                    Depth = 2,
                    Left = 102,
                    Right = 158,
                    GoodsName = "显示器8",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 3,
                    Left = 103,
                    Right = 157,
                    GoodsName = "显示器9",
                    StoreId = 1
                },
                new TestTree
                {
                    Depth = 3,
                    Left = 103,
                    Right = 157,
                    GoodsName = "显示器119",
                    StoreId = 1
                },
            };
        }
    }
}
