// The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, 
// such that each number is the sum of the two preceding ones, starting from 0 and 1. That is:
// F(0) = 0,   F(1) = 1
// F(N) = F(N - 1) + F(N - 2), for N > 1.
// Given N, calculate F(N).
using System;
using System.Collections.Generic;

namespace PascalsTriangle {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int num = solution.Fib(10);
            Console.WriteLine(num);
        }
    }

    public class Solution {
        public int Fib(int N) {
            if (N < 2) {
                return N;
            }
            return Fib(N - 1) + Fib(N - 2);
        }
    }
}

using System;
using System.Collections.Generic;

namespace PascalsTriangle {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int num = solution.Fib(10);
            Console.WriteLine(num);
        }
    }

    public class Solution {
        public int Fib(int N) {
            List<int> list = new List<int>() { 0, 1, 1 };
            for (int i = 3; i <= N; i++) {
                list.Add(list[i - 1] + list[i - 2]);
            }
            return list[N];
        }
    }
}

// Intuition Using the golden ratio, a.k.a Binet's forumula: φ= (1 + √5) / 2 ≈1.6180339887....
// We can derive the most efficient solution to this problem using only constant time and constant space!
// Use the golden ratio formula to calculate the Nth Fibonacci number.
// Java
class Solution {
    public int fib(int N) {
        double goldenRatio = (1 + Math.sqrt(5)) / 2;
        return (int)Math.round(Math.pow(goldenRatio, N) / Math.sqrt(5));
    }
}

// Python
# Contributed by LeetCode user mereck.
class Solution :
  def fib(self, N):

      golden_ratio = (1 + 5 ** 0.5) / 2
  	return int((golden_ratio** N + 1) / 5 ** 0.5)

// Go
func fib(N int) int {
    var goldenRatio float64 = float64((1 + math.Sqrt(5)) / 2);
    return int (math.Round(math.Pow(goldenRatio, float64(N)) / math.Sqrt(5)));
}