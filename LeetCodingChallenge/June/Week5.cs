// A robot is located at the top-left corner of a m x n grid(marked 'Start' in the diagram below).
// The robot can only move either down or right at any point in time.The robot is trying to reach the bottom-right corner of the grid
// (marked 'Finish' in the diagram below).
// How many possible unique paths are there?
// Above is a 7 x 3 grid.How many possible unique paths are there?

// Example 1:
// Input: m = 3, n = 2
// Output: 3
// Explanation:
// From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
// 1. Right -> Right -> Down
// 2. Right -> Down -> Right
// 3. Down -> Right -> Right

// Example 2:
// Input: m = 7, n = 3
// Output: 28

// Constraints:
// 1 <= m, n <= 100
// It's guaranteed that the answer will be less than or equal to 2 * 10^9.

using System;

namespace JuneFifth {
    public class UniquePaths {
        public static void Main(string[] args) {
            Console.WriteLine(UniquePathss(3, 2));
        }

        public static int UniquePathss(int m, int n) {
            int[,] path = new int[m, n];
            for (int i = 0; i < path.GetLength(0); i++)
                for (int j = 0; j < path.GetLength(1); j++) {
                    int up = i == 0 ? 0 : path[i - 1, j], left = j == 0 ? 0 : path[i, j - 1];
                    path[i, j] = up + left != 0 ? up + left : 1;
                }
            return path[m - 1, n - 1];
        }
    }
}

// Given a 2D board and a list of words from the dictionary, find all words in the board.
// Each word must be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring.
// The same letter cell may not be used more than once in a word.

// Example:
// Input: 
// board = [
//   ['o', 'a', 'a', 'n'],
//   ['e','t','a','e'],
//   ['i','h','k','r'],
//   ['i','f','l','v']
// ]
// words = ["oath","pea","eat","rain"]
// Output: ["eat","oath"]

// Note:
// All inputs are consist of lowercase letters a-z.
// The values of words are distinct.

using System;
using System.Collections.Generic;
using System.Linq;

namespace JuneFifth {
    public class WordSearchII {
        public static void Main(string[] args) {
            char[][] board = new char[4][];
            board[0] = new char[4] { 'o', 'a', 'a', 'n' };
            board[1] = new char[4] { 'e', 't', 'a', 'e' };
            board[2] = new char[4] { 'i', 'h', 'k', 'r' };
            board[3] = new char[4] { 'i', 'f', 'l', 'v' };
            string[] words = new string[] {
                "oath",
                "pea",
                "eat",
                "rain"
            };
            Console.WriteLine(string.Join(" ", FindWords(board, words).ToList()));
        }

        public class TrieNode {
            public TrieNode[] Children = new TrieNode[26];
            public bool IsWord;
            public string Word;
            public static void Insert(TrieNode root, string word) {
                TrieNode node = root;
                foreach (char c in word) {
                    int index = c - 'a';
                    if (node.Children[index] == null) {
                        node.Children[index] = new TrieNode();
                    }
                    node = node.Children[index];
                }
                node.IsWord = true;
                node.Word = word;
            }
        }

        public static IList<string> FindWords(char[][] board, string[] words) {
            List<string> result = new List<string>();
            if (words == null || words.Length == 0 || board == null || board.Length == 0) {
                return result;
            }
            TrieNode root = new TrieNode();
            foreach (string word in words) {
                TrieNode.Insert(root, word);
            }
            (int x, int y)[] directions = new (int, int)[] { (1, 0), (0, 1), (-1, 0), (0, -1) };
            bool[,] visited = new bool[board.Length, board[0].Length];
            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[i].Length; j++) {
                    Dfs(root, board, i, j, result, directions, visited);
                }
            }
            return result;
        }

        private static void Dfs(TrieNode root, char[][] board, int x, int y, List<string> result, (int x, int y)[] directions, bool[,] visited) {
            TrieNode node = root;
            int index = board[x][y] - 'a';
            if (node.Children[index] == null) {
                return;
            }
            node = node.Children[index];
            if (node.IsWord) {
                result.Add(node.Word);
                node.IsWord = false;
            }
            visited[x, y] = true;
            foreach ((int x, int y) d in directions) {
                int newx = d.x + x;
                int newy = d.y + y;
                if (newx >= 0 && newy >= 0 && newx < board.Length && newy < board[x].Length && !visited[newx, newy]) {
                    Dfs(node, board, newx, newy, result, directions, visited);
                }
            }
            visited[x, y] = false;
        }
    }
}