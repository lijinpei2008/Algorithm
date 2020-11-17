// Given a non-empty, singly linked list with head node head, return a middle node of linked list.
// If there are two middle nodes, return the second middle node.

// Example 1:
// Input: [1,2,3,4,5]
// Output: Node 3 from this list (Serialization: [3,4,5])
// The returned node has value 3.  (The judge's serialization of this node is [3,4,5]).
// Note that we returned a ListNode object ans, such that:
// ans.val = 3, ans.next.val = 4, ans.next.next.val = 5, and ans.next.next.next = NULL.

// Example 2:
// Input: [1,2,3,4,5,6]
// Output: Node 4 from this list (Serialization: [4,5,6])
// Since the list has two middle nodes with values 3 and 4, we return the second one.

// Note:
// The number of nodes in the given list will be between 1 and 100.

using System;

namespace AprilSecond {
    public class MiddleOfTheLinkedList {
        public static void Main(string[] args) {
            ListNode node = new ListNode {
                val = 1,
                next = new ListNode {
                    val = 2,
                    next = new ListNode {
                        val = 3,
                        next = new ListNode {
                            val = 4,
                            next = new ListNode {
                                val = 5,
                                next = new ListNode {
                                    val = 6,
                                    next = null
                                }
                            }
                        }
                    }
                }
            };
            ListNode nodeVal1 = MiddleNode1(node);
            Console.WriteLine(nodeVal1.val);
            ListNode nodeVal2 = MiddleNode2(node);
            Console.WriteLine(nodeVal2.val);
        }

        public static ListNode MiddleNode1(ListNode head) {
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        public static ListNode MiddleNode2(ListNode head) {
            int length = 1;
            ListNode current = head;
            while (current.next != null) {
                current = current.next;
                length++;
            }
            int mid = length / 2;
            current = head;
            int i = 0;
            while (i < mid) {
                current = current.next;
                i++;
            }
            return current;
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
}

// Given two strings S and T, return if they are equal when both are typed into empty text editors. # means a backspace character.
// Note that after backspacing an empty text, the text will continue empty.
   
// Example 1:
// Input: S = "ab#c", T = "ad#c"
// Output: true
// Explanation: Both S and T become "ac".
   
// Example 2:
// Input: S = "ab##", T = "c#d#"
// Output: true
// Explanation: Both S and T become "".
   
// Example 3:
// Input: S = "a##c", T = "#a#c"
// Output: true
// Explanation: Both S and T become "c".
   
// Example 4:
// Input: S = "a#c", T = "b"
// Output: false
// Explanation: S becomes "c" while T becomes "b".
   
// Note:
// 1 <= S.length <= 200
// 1 <= T.length <= 200
// S and T only contain lowercase letters and '#' characters.
   
// Follow up:
// Can you solve it in O(N) time and O(1) space?

using System;
using System.Collections.Generic;

namespace AprilSecond {
    public class BackspaceStringCompare {
        public static void Main(string[] args) {
            string str1 = "a###a";
            string str2 = "###a";
            bool val = BackspaceCompare(str1, str2);
            Console.WriteLine(val);
        }

        public static bool BackspaceCompare(string S, string T) {
            Stack<char> ansS = new Stack<char>();
            foreach (char item in S) {
                if (item != '#') {
                    ansS.Push(item);
                }
                else {
                    if (ansS.Count > 0) {
                        ansS.Pop();
                    }
                }
            }
            Stack<char> ansT = new Stack<char>();
            foreach (char item in T) {
                if (item != '#') {
                    ansT.Push(item);
                }
                else {
                    if (ansT.Count > 0) {
                        ansT.Pop();
                    }
                }
            }
            return (string.Join(string.Empty, ansS)).Equals(string.Join(string.Empty, ansT));
        }
    }
}

// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
// push(x) -- Push element x onto stack.
// pop() -- Removes the element on top of the stack.
// top() -- Get the top element.
// getMin() -- Retrieve the minimum element in the stack.

// Example 1:
// Input
// ["MinStack", "push", "push", "push", "getMin", "pop", "top", "getMin"]
// [[], [-2], [0], [-3], [], [], [], []]
// Output
// [null, null, null, null, -3, null, 0, -2]
// Explanation
// MinStack minStack = new MinStack();
// minStack.push(-2);
// minStack.push(0);
// minStack.push(-3);
// minStack.getMin(); // return -3
// minStack.pop();
// minStack.top();    // return 0
// minStack.getMin(); // return -2

// Constraints:
// Methods pop, top and getMin operations will always be called on non-empty stacks.

using System;
using System.Collections.Generic;

namespace AprilSecond {
    public class MinStack {
        public static void Main(string[] args) {
            Push(-2);
            Push(0);
            Push(-3);
            Console.WriteLine(GetMin()); // return -3
            Pop();
            Console.WriteLine(Top());    // return 0
            Console.WriteLine(GetMin()); // return -2
        }

        public static List<List<int>> list = new List<List<int>>();

        public MinStack() {

        }

        public static void Push(int x) {
            if (list.Count == 0 || list[list.Count - 1][0] > x) {
                list.Add(new List<int>() { x, x });
            }
            else {
                list.Add(new List<int> { list[list.Count - 1][0], x });
            }
        }

        public static void Pop() {
            list.RemoveAt(list.Count - 1);
        }

        public static int Top() {
            return list[list.Count - 1][1];
        }

        public static int GetMin() {
            return list[list.Count - 1][0];
        }
    }
}

//Given a binary tree, you need to compute the length of the diameter of the tree.The diameter of a binary tree is the length of the longest path between any two nodes in a tree.This path may or may not pass through the root.

//Example:
//Given a binary tree
//          1
//         / \
//        2   3
//       / \
//      4   5
//Return 3, which is the length of the path[4, 2, 1, 3] or [5,2,1,3].

//Note: The length of path between two nodes is represented by the number of edges between them.

using System;

namespace AprilSecond {
    public class DiameterOfBinaryTrees {
        public static void Main(string[] args) {
            TreeNode treeNode = new TreeNode {
                val = 1,
                left = new TreeNode {
                    val = 2,
                    left = new TreeNode {
                        val = 4,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 5,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode {
                    val = 3,
                    left = null,
                    right = null
                }
            };
            Console.WriteLine(DiameterOfBinaryTree(treeNode));
        }

        public static int ans;

        public static int DiameterOfBinaryTree(TreeNode root) {
            ans = 1;
            depth(root);
            return ans - 1;
        }

        public static int depth(TreeNode node) {
            if (node == null) {
                return 0;
            }
            int L = depth(node.left);
            int R = depth(node.right);
            ans = Math.Max(ans, L + R + 1);
            return Math.Max(L, R) + 1;
        }
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
}

// We have a collection of stones, each stone has a positive integer weight.
// Each turn, we choose the two heaviest stones and smash them together.  Suppose the stones have weights x and y with x <= y.The result of this smash is:
// If x == y, both stones are totally destroyed;
// If x != y, the stone of weight x is totally destroyed, and the stone of weight y has new weight y-x.
// At the end, there is at most 1 stone left.Return the weight of this stone (or 0 if there are no stones left.)
   
// Example 1:
// Input: [2,7,4,1,8,1]
// Output: 1
// Explanation: 
// We combine 7 and 8 to get 1 so the array converts to[2, 4, 1, 1, 1] then,
// we combine 2 and 4 to get 2 so the array converts to[2, 1, 1, 1] then,
// we combine 2 and 1 to get 1 so the array converts to[1, 1, 1] then,
// we combine 1 and 1 to get 0 so the array converts to[1] then that's the value of last stone.
   
// Note:
// 1 <= stones.length <= 30
// 1 <= stones[i] <= 1000

using System;
using System.Collections.Generic;
using System.Linq;

namespace AprilSecond {
    public class LastStoneWeight {
        public static void Main(string[] args) {
            int[] stones = { 2, 7, 4, 1, 8, 1 };
            Console.WriteLine(Weight(stones));
        }

        public static int Weight(int[] stones) {
            if (stones.Length == 2) {
                return Math.Abs(stones[1] - stones[0]);
            }
            Array.Sort(stones);
            List<int> s = new List<int>(stones);
            while (s.Count > 1) {
                int first = s.ElementAt(s.Count - 1);
                int second = s.ElementAt(s.Count - 2);
                int smash = first - second;
                s.RemoveAt(s.Count - 1);
                s.RemoveAt(s.Count - 1);
                if (smash != 0) {
                    int index = s.BinarySearch(smash);
                    if (index < 0) {
                        index = ~index;
                    }
                    s.Insert(index, smash);
                }
            }
            return s.FirstOrDefault();
        }
    }
}

// Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.
   
// Example 1:
// Input: [0,1]
// Output: 2
// Explanation: [0, 1] is the longest contiguous subarray with equal number of 0 and 1.

// Example 2:
// Input: [0,1,0]
// Output: 2
// Explanation: [0, 1] (or[1, 0]) is a longest contiguous subarray with equal number of 0 and 1.

// Note: The length of the given binary array will not exceed 50,000.

using System;
using System.Collections.Generic;

namespace AprilSecond {
    public class FindMaxLength {
        public static void Main(string[] args) {
            int[] nums = { 0, 1, 0, 1, 0, 1, 2, 2, 3, 1, 0 };
            Console.WriteLine(MaxLength(nums));
        }

        public static int MaxLength(int[] nums) {
            Dictionary<int, int> map = new Dictionary<int, int> {
                { 0, -1 }
            };
            int maxlen = 0, count = 0;
            for (int i = 0; i < nums.Length; i++) {
                count += (nums[i] == 1 ? 1 : -1);
                if (map.ContainsKey(count)) {
                    maxlen = Math.Max(maxlen, i - map[count]);
                }
                else {
                    map.Add(count, i);
                }
            }
            return maxlen;
        }
    }
}