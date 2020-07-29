// Given a circular array C of integers represented by A, find the maximum possible sum of a non-empty subarray of C.
// Here, a circular array means the end of the array connects to the beginning of the array.
// (Formally, C[i] = A[i] when 0 <= i<A.length, and C[i + A.length] = C[i] when i >= 0.)
// Also, a subarray may only include each element of the fixed buffer A at most once.
// (Formally, for a subarray C[i], C[i + 1], ..., C[j], there does not exist i <= k1, k2 <= j with k1 % A.length = k2 % A.length.)

// Example 1:
// Input: [1,-2,3,-2]
// Output: 3
// Explanation: Subarray[3] has maximum sum 3

// Example 2:
// Input: [5,-3,5]
// Output: 10
// Explanation: Subarray[5, 5] has maximum sum 5 + 5 = 10

// Example 3:
// Input: [3,-1,2,-1]
// Output: 4
// Explanation: Subarray[2, -1, 3] has maximum sum 2 + (-1) + 3 = 4

// Example 4:
// Input: [3,-2,2,-3]
// Output: 3
// Explanation: Subarray[3] and[3, -2, 2] both have maximum sum 3

// Example 5:
// Input: [-2,-3,-1]
// Output: -1
// Explanation: Subarray[-1] has maximum sum -1

// Note:
// -30000 <= A[i] <= 30000
// 1 <= A.length <= 30000

using System;
using System.Linq;

namespace MayThird {
    public class MaximumSumCircularSubarray {
        public static void Main(string[] args) {
            int[] A = new int[] { 1, -2, 3, -2 };
            Console.WriteLine(MaxSubarraySumCircular(A));
        }

        public static int MaxSubarraySumCircular(int[] A) {
            int curMaxSum = A[0];
            int maxSum = A[0];
            int curMinSum = A[0];
            int minSum = A[0];
            int totalSum = A[0];
            for (int i = 1; i < A.Length; i++) {
                curMaxSum = Math.Max(A[i], curMaxSum + A[i]);
                maxSum = Math.Max(maxSum, curMaxSum);
                curMinSum = Math.Min(A[i], curMinSum + A[i]);
                minSum = Math.Min(minSum, curMinSum);
                totalSum += A[i];
            }
            return maxSum > 0 ? Math.Max(maxSum, totalSum - minSum) : maxSum;
        }
    }
}

// Given a singly linked list, group all odd nodes together followed by the even nodes.
// Please note here we are talking about the node number and not the value in the nodes.
// You should try to do it in place.The program should run in O(1) space complexity and O(nodes) time complexity.

// Example 1:
// Input: 1->2->3->4->5->NULL
// Output: 1->3->5->2->4->NULL

// Example 2:
// Input: 2->1->3->5->6->4->7->NULL
// Output: 2->3->6->7->1->5->4->NULL

// Constraints:
// The relative order inside both the even and odd groups should remain as it was in the input.
// The first node is considered odd, the second node even and so on...
// The length of the linked list is between[0, 10 ^ 4].

using System;

namespace MayThird {
    public class OddEvenLinkedList {
        public static void Main(string[] args) {
            ListNode node = new ListNode {
                val = 2,
                next = new ListNode {
                    val = 1,
                    next = new ListNode {
                        val = 3,
                        next = new ListNode {
                            val = 5,
                            next = new ListNode {
                                val = 6,
                                next = new ListNode {
                                    val = 4,
                                    next = new ListNode {
                                        val = 7,
                                        next = null
                                    }
                                }
                            }
                        }
                    }
                }
            };
            Cw(OddEvenList(node));
        }

        private static void Cw(ListNode node) {
            Console.Write(node.val + "->");
            if (node.next != null) {
                Cw(node.next);
            }
        }

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode OddEvenList(ListNode head) {
            if (head == null) {
                return head;
            }
            ListNode oddHead = head;
            ListNode evenHead = head.next;
            ListNode even = evenHead;
            while (evenHead != null && evenHead.next != null) {
                oddHead.next = evenHead.next;
                oddHead = oddHead.next;
                evenHead.next = oddHead.next;
                evenHead = evenHead.next;
            }
            oddHead.next = even;
            return head;
        }
    }
}

//Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.

//Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100.

//The order of output does not matter.

//Example 1:

//Input:
//s: "cbaebabacd" p: "abc"

//Output:
//[0, 6]

//Explanation:
//The substring with start index = 0 is "cba", which is an anagram of "abc".
//The substring with start index = 6 is "bac", which is an anagram of "abc".
//Example 2:

//Input:
//s: "abab" p: "ab"

//Output:
//[0, 1, 2]

//Explanation:
//The substring with start index = 0 is "ab", which is an anagram of "ab".
//The substring with start index = 1 is "ba", which is an anagram of "ab".
//The substring with start index = 2 is "ab", which is an anagram of "ab".

using System;
using System.Collections.Generic;

namespace MayThird {
    public class FindAllAnagramsInAString {
        public static void Main(string[] args) {
            IList<int> val = FindAnagrams("cbaebabacd", "abc");
            foreach (int item in val) {
                Console.WriteLine(item);
            }
        }

        public static int SIZE = 26;

        public static IList<int> FindAnagrams(string s, string p) {
            if (s == null || p == null || s.Length < p.Length) {
                return new List<int>();
            }
            int sLength = s.Length;
            int pLength = p.Length;
            int[] source = GetCountingSort(p);
            int[] counting = GetCountingSort(s.Substring(0, pLength));
            List<int> anagrams = new List<int>();
            if (CheckAnagram(source, counting)) {
                anagrams.Add(0);
            }
            for (int i = 1; i < sLength && (pLength + i - 1) < sLength; i++) {
                counting[s[i - 1] - 'a']--;
                counting[s[pLength + i - 1] - 'a']++;
                if (CheckAnagram(source, counting)) {
                    anagrams.Add(i);
                }
            }
            return anagrams;
        }

        private static bool CheckAnagram(int[] source, int[] second) {
            for (int i = 0; i < SIZE; i++) {
                if (source[i] != second[i]) {
                    return false;
                }
            }
            return true;
        }

        private static int[] GetCountingSort(string p) {
            if (p == null) {
                return new int[0];
            }
            int[] counting = new int[SIZE];
            foreach (var item in p) {
                counting[item - 'a']++;
            }
            return counting;
        }
    }
}

//Given two strings s1 and s2, write a function to return true if s2 contains the permutation of s1.
//In other words, one of the first string's permutations is the substring of the second string.

//Example 1:
//Input: s1 = "ab" s2 = "eidbaooo"
//Output: True
//Explanation: s2 contains one permutation of s1 ("ba").

//Example 2:
//Input:s1= "ab" s2 = "eidboaoo"
//Output: False

//Constraints:
//The input strings only contain lower case letters.
//The length of both given strings is in range[1, 10, 000].

using System;
using System.Linq;

namespace MayThird {
    public class PermutationInString {
        public static void Main(string[] args) {
            Console.WriteLine(CheckInclusion("ab", "eidbaooo"));
        }

        public static bool CheckInclusion(string s1, string s2) {
            if (s1.Length > s2.Length) {
                return false;
            }
            int[] s1arr = new int[26];
            int[] s2arr = new int[26];
            for (int i = 0; i < s1.Length; i++) {
                s1arr[s1[i] - 'a']++;
                s2arr[s2[i] - 'a']++;
            }
            for (int i = 0; i < s2.Length - s1.Length; i++) {
                if (Enumerable.SequenceEqual(s1arr, s2arr)) {
                    return true;
                }
                s2arr[s2[i] - 'a']--;
                s2arr[s2[i + s1.Length] - 'a']++;
            }
            return Enumerable.SequenceEqual(s1arr, s2arr);
        }
    }
}

// Write a class StockSpanner which collects daily price quotes for some stock, and returns the span of that stock's price for the current day.
// The span of the stock's price today is defined as the maximum number of consecutive days (starting from today and going backwards)
// for which the price of the stock was less than or equal to today's price.
// For example, if the price of a stock over the next 7 days were [100, 80, 60, 70, 60, 75, 85], then the stock spans would be [1, 1, 1, 2, 1, 4, 6].
   
// Example 1:
// Input: ["StockSpanner","next","next","next","next","next","next","next"], [[], [100], [80], [60], [70], [60], [75], [85]]
// Output: [null,1,1,1,2,1,4,6]
// Explanation: 
// First, S = StockSpanner() is initialized.Then:
// S.next(100) is called and returns 1,
// S.next(80) is called and returns 1,
// S.next(60) is called and returns 1,
// S.next(70) is called and returns 2,
// S.next(60) is called and returns 1,
// S.next(75) is called and returns 4,
// S.next(85) is called and returns 6.
// Note that(for example) S.next(75) returned 4, because the last 4 prices
// (including today's price of 75) were less than or equal to today's price.
   
// Note:
// Calls to StockSpanner.next(int price) will have 1 <= price <= 10^5.
// There will be at most 10000 calls to StockSpanner.next per test case.
// There will be at most 150000 calls to StockSpanner.next across all test cases.
// The total time limit for this problem has been reduced by 75% for C++, and 50% for all other languages.

using System;
using System.Collections.Generic;

namespace MayThird {
    public class OnlineStockSpan {
        public static void Main(string[] args) {
            StockSpanner S = new StockSpanner();
            Console.WriteLine(S.Next(100));
            Console.WriteLine(S.Next(80));
            Console.WriteLine(S.Next(60));
            Console.WriteLine(S.Next(70));
            Console.WriteLine(S.Next(60));
            Console.WriteLine(S.Next(75));
            Console.WriteLine(S.Next(85));
        }
    }

    public class StockSpanner {
        Stack<int> prices, weighs;
        public StockSpanner() {
            prices = new Stack<int>();
            weighs = new Stack<int>();
        }

        public int Next(int price) {
            int w = 1;
            while (prices.Count > 0 && prices.Peek() <= price) {
                prices.Pop();
                w += weighs.Pop();
            }
            prices.Push(price);
            weighs.Push(w);
            return w;
        }
    }
}

// Given a binary search tree, write a function kthSmallest to find the kth smallest element in it.

// Example 1:
// Input: root = [3,1,4,null,2], k = 1
//    3
//   / \
//  1   4
//   \
//    2
// Output: 1

// Example 2:
// Input: root = [5,3,6,2,4,null,null,1], k = 3
//        5
//       / \
//      3   6
//     / \
//    2   4
//   /
//  1
// Output: 3
// Follow up:
// What if the BST is modified(insert/delete operations) often and you need to find the kth smallest frequently? How would you optimize the kthSmallest routine?

// Constraints:
// The number of elements of the BST is between 1 to 10^4.
// You may assume k is always valid, 1 ≤ k ≤ BST's total elements.

using System;

namespace MayThird {
    public class KthSmallestElementInABST {
        public static void Main(string[] args) {
            TreeNode node = new TreeNode {
                val = 5,
                left = new TreeNode {
                    val = 3,
                    left = new TreeNode {
                        val = 2,
                        left = new TreeNode {
                            val = 1,
                            left = null,
                            right = null
                        },
                        right = null
                    },
                    right = new TreeNode {
                        val = 4,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode {
                    val = 6,
                    left = null,
                    right = null
                }
            };
            Console.WriteLine(KthSmallest(node, 3));
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public static int KthSmallest(TreeNode root, int k) {
            return helper(root, ref k);
        }

        private static int helper(TreeNode root, ref int k) {
            if (root == null) return -1;
            int x = helper(root.left, ref k);
            if (k == 0) return x;
            if (--k == 0) return root.val;
            return helper(root.right, ref k);
        }
    }
}

// Given a m* n matrix of ones and zeros, return how many square submatrices have all ones.

// Example 1:
// Input: matrix =
// [
//   [0,1,1,1],
//   [1,1,1,1],
//   [0,1,1,1]
// ]
// Output: 15
// Explanation: 
// There are 10 squares of side 1.
// There are 4 squares of side 2.
// There is  1 square of side 3.
// Total number of squares = 10 + 4 + 1 = 15.

// Example 2:
// Input: matrix = 
// [
//   [1,0,1],
//   [1,1,0],
//   [1,1,0]
// ]
// Output: 7
// Explanation: 
// There are 6 squares of side 1.  
// There is 1 square of side 2. 
// Total number of squares = 6 + 1 = 7.

// Constraints:
// 1 <= arr.length <= 300
// 1 <= arr[0].length <= 300
// 0 <= arr[i][j] <= 1

using System;

namespace MayThird {
    public class CountSquareSubmatricesWithAllOnes {
        public static void Main(string[] args) {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 1, 0, 1 };
            matrix[1] = new int[] { 1, 1, 0 };
            matrix[2] = new int[] { 1, 1, 0 };
            Console.WriteLine(CountSquares(matrix));
        }

        public static int CountSquares(int[][] matrix) {
            int n = matrix.Length;
            int n1 = matrix[0].Length;
            int[][] m = matrix;
            int sum = 0;
            for (int i = 1; i < n; i++) {
                for (int j = 1; j < n1; j++) {
                    if (m[i][j] == 1) {
                        m[i][j] = Math.Min(Math.Min(m[i - 1][j], m[i][j - 1]), m[i - 1][j - 1]) + 1;
                        sum += m[i][j];
                    }
                }
            }
            for (int i = 0; i < n; i++) {
                sum += m[i][0];
            }
            for (int j = 1; j < n1; j++) {
                sum += m[0][j];
            }
            return sum;
        }
    }
}