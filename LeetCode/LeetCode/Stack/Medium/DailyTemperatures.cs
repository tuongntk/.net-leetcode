﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Stack.Medium
{
    /*
     * 根据每日 气温 列表，请重新生成一个列表，对应位置的输入是你需要再等待多久温度才会升高超过该日的天数。如果之后都不会升高，请在该位置用 0 来代替。

        例如，给定一个列表 temperatures = [73, 74, 75, 71, 69, 72, 76, 73]，你的输出应该是 [1, 1, 4, 2, 1, 1, 0, 0]。

        提示：气温 列表长度的范围是 [1, 30000]。每个气温的值的均为华氏度，都是在 [30, 100] 范围内的整数。


     */

    public class DailyTemperatures
    {
        public int[] Solution(int[] T)
        {
            var stack = new Stack<int>();
            var res = new int[T.Length];
            for (var i = 0; i < T.Length; i++)
            {
                while (stack.Any() && T[stack.Peek()] < T[i])
                {
                    int t = stack.Peek();
                    stack.Pop();
                    res[t] = i - t;
                }

                stack.Push(i);
            }
            return res;
        }
    }
}
