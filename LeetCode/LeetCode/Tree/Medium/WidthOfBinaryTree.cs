﻿using LeetCode.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium.Tree
{
    /*
     * 给定一个二叉树，编写一个函数来获取这个树的最大宽度。树的宽度是所有层中的最大宽度。这个二叉树与满二叉树（full binary tree）结构相同，但一些节点为空。

        每一层的宽度被定义为两个端点（该层最左和最右的非空节点，两端点间的null节点也计入长度）之间的长度。

        示例 1:

        输入: 

                   1
                 /   \
                3     2
               / \     \  
              5   3     9 

        输出: 4
        解释: 最大值出现在树的第 3 层，宽度为 4 (5,3,null,9)。
        示例 2:

        输入: 

                  1
                 /  
                3    
               / \       
              5   3     

        输出: 2
        解释: 最大值出现在树的第 3 层，宽度为 2 (5,3)。
        示例 3:

        输入: 

                  1
                 / \
                3   2 
               /        
              5      

        输出: 2
        解释: 最大值出现在树的第 2 层，宽度为 2 (3,2)。
        示例 4:

        输入: 

                  1
                 / \
                3   2
               /     \  
              5       9 
             /         \
            6           7
        输出: 8
        解释: 最大值出现在树的第 4 层，宽度为 8 (6,null,null,null,null,null,null,7)。


     */

    public class WidthOfBinaryTree
    {
        public int Solution(TreeNode root)
        {
            if (root.left == null && root.right == null)
                return 1;
            if (root == null)
                return 0;
            var queue = new Queue<TreeNode>();
            var max = 1;
            queue.Enqueue(root);
            TreeNode node = null;
            List<int> list = new List<int>();
            list.Add(1);
            int size = 1;
            while (queue.Any())
            {
                node = queue.Dequeue();
                size--;                         //层次遍历
                int index = list[0];           
                list.Remove(list[0]);
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                    list.Add(2 * index);        //每个左节点的索引是父节点的索引*2
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    list.Add(2 * index + 1);    //每个右节点的索引是父节点的索引*2+1
                }
                if (size == 0)                  //当层次遍历完
                {
                    {
                        if (list.Count >= 2)    //如果本层有两个或以上非空节点
                            max = Math.Max(list.Last() - list.First() + 1, max); //拿到索引差作为宽度
                    }
                    size = queue.Count;         //开始进行下一层的遍历
                }



            }
            return max;
        }
    }
}
