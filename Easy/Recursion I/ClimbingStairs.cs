// You are climbing a stair case. It takes n steps to reach to the top.
// Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
// Note: Given n will be a positive integer.

// Example 1:
// Input: 2
// Output: 2
// Explanation: There are two ways to climb to the top.
// 1. 1 step + 1 step
// 2. 2 steps

// Example 2:
// Input: 3
// Output: 3
// Explanation: There are three ways to climb to the top.
// 1. 1 step + 1 step + 1 step
// 2. 1 step + 2 steps
// 3. 2 steps + 1 step

// To reach nth step, what could have been your previous steps? (Think about the step sizes)

using System;

namespace ClimbingStairs {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int num = solution.ClimbStairs(2);
            Console.WriteLine(num);
        }
    }

    public class Solution {
        public int ClimbStairs(int n) {
            int a = 1, b = 1;
            while (n-- > 0)
                a = (b += a) - a;
            return a;
        }
    }
}

using System;
using System.Collections.Generic;

namespace ClimbingStairs {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int num = solution.ClimbStairs(2);
            Console.WriteLine(num);
        }
    }

    public class Solution {
        public int ClimbStairs(int n) {
            List<int> list = new List<int>() { 1, 1 };
            for (int i = 2; i <= n; i++) {
                list.Add(list[i - 1] + list[i - 2]);
            }
            return list[n];
        }
    }
}


// Each time you can either climb 1 , 2 or 3 steps.In how many distinct ways can you climb to the top?
// It's still a varient of the Fibonacci sequence.
// 1,2,4,7,13,24……The value is equal to the sum of three numbers before the number.

