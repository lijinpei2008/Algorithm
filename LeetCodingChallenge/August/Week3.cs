// Given a collection of intervals, find the minimum number of intervals you need to remove to make the rest of the intervals non-overlapping.

// Example 1:
// Input:[[1,2],[2,3],[3,4],[1,3]]
// Output: 1
// Explanation:[1,3] can be removed and the rest of intervals are non-overlapping.

// Example 2:
// Input:[[1,2],[1,2],[1,2]]
// Output: 2
// Explanation: You need to remove two [1,2] to make the rest of intervals non-overlapping.

// Example 3:
// Input:[[1,2],[2,3]]
// Output: 0
// Explanation: You don't need to remove any of the intervals since they're already non-overlapping.

// Note:
// You may assume the interval's end point is always bigger than its start point.
// Intervals like [1,2] and[2, 3] have borders "touching" but they don't overlap each other.

using System;

namespace AugThird {
    public class NonOverlappingIntervals {
        public static void Main(string[] args) {
            int[][] intervals = new int[3][];
            intervals[0] = new int[] { 1, 2 };
            intervals[1] = new int[] { 1, 2 };
            intervals[2] = new int[] { 1, 2 };
            Console.WriteLine(EraseOverlapIntervals(intervals));
        }

        public static int EraseOverlapIntervals(int[][] intervals) {
            int N = intervals.Length;
            if (N == 0) {
                return 0;
            }
            Array.Sort(intervals, (a, b) => a[0] - b[0]);
            int result = 0;
            int minEnd = intervals[0][1];
            for (int i = 1; i < N; i++) {
                int[] curr = intervals[i];
                if (minEnd > curr[0]) {
                    minEnd = Math.Min(minEnd, curr[1]);
                    result++;
                }
                else {
                    minEnd = curr[1];
                }
            }
            return result;
        }
    }
}

// Say you have an array for which the ith element is the price of a given stock on day i.
// Design an algorithm to find the maximum profit. You may complete at most two transactions.
// Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).

// Example 1:
// Input: prices = [3, 3, 5, 0, 0, 3, 1, 4]
// Output: 6
// Explanation: Buy on day 4(price = 0) and sell on day 6 (price = 3), profit = 3 - 0 = 3.
// Then buy on day 7 (price = 1) and sell on day 8 (price = 4), profit = 4 - 1 = 3.

// Example 2:
// Input: prices = [1, 2, 3, 4, 5]
// Output: 4
// Explanation: Buy on day 1(price = 1) and sell on day 5 (price = 5), profit = 5 - 1 = 4.
// Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are engaging multiple transactions at the same time.
// You must sell before buying again.

// Example 3:
// Input: prices = [7, 6, 4, 3, 1]
// Output: 0
// Explanation: In this case, no transaction is done, i.e. max profit = 0.

// Example 4:
// Input: prices = [1]
// Output: 0

// Constraints:
// 1 <= prices.length <= 10^5
// 0 <= prices[i] <= 10^5

using System;

namespace AugThird {
    public class BestTimeToBuyAndSellStockIII {
        public static void Main(string[] args) {
            int[] prices = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(MaxProfit(prices));
        }

        public static int MaxProfit(int[] prices) {
            int sell1 = 0, sell2 = 0, buy1 = int.MinValue, buy2 = int.MinValue;
            foreach (int price in prices) {
                sell2 = Math.Max(sell2, buy2 + price);
                buy2 = Math.Max(buy2, sell1 - price);
                sell1 = Math.Max(sell1, buy1 + price);
                buy1 = Math.Max(buy1, -price);
            }
            return sell2;
        }
    }
}

// We distribute some number of candies, to a row of n = num_people people in the following way:
// We then give 1 candy to the first person, 2 candies to the second person, and so on until we give n candies to the last person.
// Then, we go back to the start of the row, giving n + 1 candies to the first person, n + 2 candies to the second person,
// and so on until we give 2 * n candies to the last person.
// This process repeats (with us giving one more candy each time, and moving to the start of the row after we reach the end) until we run out of candies.
// The last person will receive all of our remaining candies (not necessarily one more than the previous gift).
// Return an array (of length num_people and sum candies) that represents the final distribution of candies.

// Example 1:
// Input: candies = 7, num_people = 4
// Output:[1,2,3,1]
// Explanation:
// On the first turn, ans[0] += 1, and the array is [1,0,0,0].
// On the second turn, ans[1] += 2, and the array is [1,2,0,0].
// On the third turn, ans[2] += 3, and the array is [1,2,3,0].
// On the fourth turn, ans[3] += 1 (because there is only one candy left), and the final array is [1,2,3,1].

// Example 2:
// Input: candies = 10, num_people = 3
// Output:[5,2,3]
// Explanation:
// On the first turn, ans[0] += 1, and the array is [1,0,0].
// On the second turn, ans[1] += 2, and the array is [1,2,0].
// On the third turn, ans[2] += 3, and the array is [1,2,3].
// On the fourth turn, ans[0] += 4, and the final array is [5,2,3].

// Constraints:
// 1 <= candies <= 10 ^ 9
// 1 <= num_people <= 1000

using System;

namespace AugThird {
    public class DistributeCandiesToPeople {
        public static void Main(string[] args) {
            foreach (int i in DistributeCandies(10, 3)) {
                Console.Write(i + " ");
            }
        }

        public static int[] DistributeCandies(int candies, int num_people) {
            int[] arr1 = new int[num_people];
            if (candies <= 0 || num_people <= 0) {
                return arr1;
            }
            int count = 1;
            while (candies != 0) {
                for (int i = 0; i < arr1.Length; i++) {
                    int candyToAssign = Math.Min(count, candies);
                    arr1[i] = arr1[i] + candyToAssign;
                    candies -= candyToAssign;
                    if (candies == 0) {
                        break;
                    }
                    count++;
                }
            }
            return arr1;
        }
    }
}

// Return all non-negative integers of length n such that the absolute difference between every two consecutive digits is k.
// Note that every number in the answer must not have leading zeros except for the number 0 itself.
// For example, 01 has one leading zero and is invalid, but 0 is valid.
// You may return the answer in any order.

// Example 1:
// Input: n = 3, k = 7
// Output:[181,292,707,818,929]
// Explanation: Note that 070 is not a valid number, because it has leading zeroes.

// Example 2:
// Input: n = 2, k = 1
// Output:[10,12,21,23,32,34,43,45,54,56,65,67,76,78,87,89,98]

// Example 3:
// Input: n = 2, k = 0
// Output:[11,22,33,44,55,66,77,88,99]

// Example 4:
// Input: n = 2, k = 1
// Output:[10,12,21,23,32,34,43,45,54,56,65,67,76,78,87,89,98]

// Example 5:
// Input: n = 2, k = 2
// Output:[13,20,24,31,35,42,46,53,57,64,68,75,79,86,97]

// Constraints:
// 2 <= n <= 9
// 0 <= k <= 9

using System;
using System.Collections.Generic;

namespace AugThird {
    public class NumbersWithSameConsecutiveDifferences {
        public static void Main(string[] args) {
            foreach (int i in NumsSameConsecDiff(2, 2)) {
                Console.Write(i + " ");
            }
        }

        public static int[] NumsSameConsecDiff(int n, int k) {
            List<int> result = new List<int>();
            if (n == 1) {
                return new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            }
            for (int i = 1; i <= 9; i++) {
                HelpNumsSame(n, k, i, result);
            }
            return result.ToArray();
        }

        private static void HelpNumsSame(int n, int k, int current, List<int> result) {
            if (current.ToString().Length == n) {
                result.Add(current);
                return;
            }
            int lastNumber = current % 10;
            if (lastNumber + k <= 9) {
                HelpNumsSame(n, k, (current * 10) + (lastNumber + k), result);
            }
            int differnce = lastNumber - k;
            if (differnce >= 0 && k != 0) {
                HelpNumsSame(n, k, (current * 10) + (differnce), result);
            }
        }
    }
}

// A sentence S is given, composed of words separated by spaces. Each word consists of lowercase and uppercase letters only.
// We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.)
// The rules of Goat Latin are as follows:
// If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of the word.
// For example, the word 'apple' becomes 'applema'.
// If a word begins with a consonant (i.e. not a vowel), remove the first letter and append it to the end, then add "ma".
// For example, the word "goat" becomes "oatgma".
// Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
// For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
// Return the final sentence representing the conversion from S to Goat Latin. 

// Example 1:
// Input: "I speak Goat Latin"
// Output: "Imaa peaksmaaa oatGmaaaa atinLmaaaaa"

// Example 2:
// Input: "The quick brown fox jumped over the lazy dog"
// Output: "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa"

// Notes:
// S contains only uppercase, lowercase and spaces. Exactly one space between each word.
// 1 <= S.length <= 150.

using System;
using System.Text;

namespace AugThird {
    public class GoatLatin {
        public static void Main(string[] args) {
            Console.WriteLine(ToGoatLatin("I speak goat Latin"));
        }

        public static string ToGoatLatin(string S) {
            string vowels = "aeiouAEIOU";
            string[] words = S.Split(' ');
            for (int i = 0; i < words.Length; i++) {
                string word = words[i];
                StringBuilder goatLatingWord = new StringBuilder();
                if (vowels.IndexOf(word[0]) > -1) {
                    goatLatingWord.Append(word);
                }
                else {
                    goatLatingWord.Append(word.Substring(1));
                    goatLatingWord.Append(word[0]);
                }
                goatLatingWord.Append("ma");
                goatLatingWord.Append(new string('a', i + 1));
                words[i] = goatLatingWord.ToString();
            }
            return string.Join(" ", words);
        }
    }
}

// Given a singly linked list L: L0→L1→…→Ln - 1→Ln,
// reorder it to: L0→Ln→L1→Ln - 1→L2→Ln - 2→…
// You may not modify the values in the list's nodes, only nodes itself may be changed.

// Example 1:
// Given 1->2->3->4, reorder it to 1->4->2->3.

// Example 2:
// Given 1->2->3->4->5, reorder it to 1->5->2->4->3.

using System;

namespace AugThird {
    public class ReorderList {
        public static void Main(string[] args) {
            ListNode head = new ListNode {
                val = 1,
                next = new ListNode {
                    val = 2,
                    next = new ListNode {
                        val = 3,
                        next = new ListNode {
                            val = 4,
                            next = new ListNode {
                                val = 5,
                                next = null
                            }
                        }
                    }
                }
            };
            ReorderList(head);
            Cw(head);
        }

        private static void Cw(ListNode node) {
            Console.Write(node.val + " => ");
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


        public static void ReorderList(ListNode head) {
            if (head == null) {
                return;
            }
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;
            }
            ListNode secondHalfHead = slow.next;
            slow.next = null;
            ListNode newSecondHead = ReverseList(secondHalfHead);
            ListNode cur = head;
            ListNode curSecond = newSecondHead;
            while (cur != null && curSecond != null) {
                ListNode next = cur.next;
                cur.next = curSecond;
                curSecond = curSecond.next;
                if (cur.next == null) {
                    break;
                }
                cur.next.next = next;
                cur = next;
            }
        }

        private static ListNode ReverseList(ListNode head) {
            if (head == null) {
                return null;
            }
            ListNode dummy = new ListNode(-1) {
                next = head
            };
            while (head.next != null) {
                ListNode tempHead = head.next;
                head.next = head.next.next;
                tempHead.next = dummy.next;
                dummy.next = tempHead;
            }
            ListNode newHead = dummy.next;
            dummy.next = null;
            return newHead;
        }
    }
}

// Given an array A of non-negative integers, return an array consisting of all the even elements of A, followed by all the odd elements of A.
// You may return any answer array that satisfies this condition.

// Example 1:
// Input:[3,1,2,4]
// Output:[2,4,3,1]
// The outputs[4, 2, 3, 1], [2, 4, 1, 3], and[4, 2, 1, 3] would also be accepted.

// Note:
// 1 <= A.length <= 5000
// 0 <= A[i] <= 5000

using System;
using System.Collections.Generic;
using System.Linq;

namespace AugThird {
    public class SortArrayByParity {
        public static void Main(string[] args) {
            int[] A = new int[] { 3, 1, 2, 4, 5, 6, 8, 7, 9, 10 };
            foreach (int i in SortArrayByParityFunction(A)) {
                Console.Write(i + " ");
            }
        }

        public static int[] SortArrayByParityFunction(int[] A) {
            LinkedList<int> ret = new LinkedList<int>();
            foreach (int a in A) {
                if (0 == a % 2) {
                    ret.AddFirst(a);
                    continue;
                }
                ret.AddLast(a);
            }
            return ret.ToArray();
        }
    }
}