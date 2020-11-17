// Say you have an array for which the ith element is the price of a given stock on day i.
// Design an algorithm to find the maximum profit. 
// You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:
// You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
// After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)

// Example:
// Input:[1,2,3,0,2]
// Output: 3
// Explanation: transactions = [buy, sell, cooldown, buy, sell]

using System;

namespace JulyFifth {
    public class BestTimeToBuyAndSellStockWithCooldown {
        public static void Main(string[] args) {
            int[] prices = new int[] { 1, 2, 3, 0, 2 };
            Console.WriteLine(MaxProfit(prices));
        }

        public static int MaxProfit(int[] prices) {
            int n = prices.Length;
            int inOrder0 = 0, inOrder1 = int.MinValue;
            int postOrder = 0;
            for (int i = 0; i < n; i++) {
                int temp = inOrder0;
                inOrder0 = Math.Max(inOrder0, inOrder1 + prices[i]);
                inOrder1 = Math.Max(inOrder1, postOrder - prices[i]);
                postOrder = temp;
            }
            return inOrder0;
        }
    }
}

// Given a non-empty string s and a dictionary wordDict containing a list of non-empty words,
// add spaces in s to construct a sentence where each word is a valid dictionary word. Return all such possible sentences.

// Note:
// The same word in the dictionary may be reused multiple times in the segmentation.
// You may assume the dictionary does not contain duplicate words.

// Example 1:
// Input:
// s = "catsanddog"
// wordDict = ["cat", "cats", "and", "sand", "dog"]
// Output:
// [
//   "cats and dog",
//   "cat sand dog"
// ]

// Example 2:
// Input:
// s = "pineapplepenapple"
// wordDict = ["apple", "pen", "applepen", "pine", "pineapple"]
// Output:
// [
//   "pine apple pen apple",
//   "pineapple pen apple",
//   "pine applepen apple"
// ]
// Explanation: Note that you are allowed to reuse a dictionary word.

// Example 3:
// Input:
// s = "catsandog"
// wordDict = ["cats", "dog", "sand", "and", "cat"]
// Output:
// []

using System;
using System.Collections.Generic;

namespace JulyFifth {
    public class WordBreakII {
        public static void Main(string[] args) {
            string s = "catsanddog";
            string[] wordDict = new string[] { "cat", "cats", "and", "sand", "dog" };
            foreach (string item in WordBreak(s, wordDict)) {
                Console.WriteLine(item);
            }
        }

        public static IList<string> WordBreak(string s, IList<string> wordDict) {
            HashSet<string> hash = new HashSet<string>(wordDict);
            if (string.IsNullOrEmpty(s)) {
                return new List<string>();
            }
            return WordBreakFunction(s, 0, hash);
        }

        static Dictionary<int, List<string>> Dict = new Dictionary<int, List<string>>();

        private static List<string> WordBreakFunction(string s, int index, HashSet<string> hash) {
            if (Dict.ContainsKey(index)) {
                return Dict[index];
            }
            List<string> result = new List<string>();
            for (int i = index; i < s.Length; i++) {
                string word = s.Substring(index, i - index + 1);
                if (hash.Contains(word)) {
                    if (i == s.Length - 1) {
                        result.Add(word);
                    }
                    else {
                        List<string> newResult = WordBreakFunction(s, i + 1, hash);
                        for (int j = 0; j < newResult.Count; j++) {
                            result.Add($"{word} {newResult[j]}");
                        }
                    }
                }
            }
            Dict.Add(index, result);
            return result;
        }
    }
}