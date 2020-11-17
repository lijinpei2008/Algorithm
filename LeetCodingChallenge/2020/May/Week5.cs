// There are a total of numCourses courses you have to take, labeled from 0 to numCourses-1.
// Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
// Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?

// Example 1:
// Input: numCourses = 2, prerequisites = [[1,0]]
// Output: true
// Explanation: There are a total of 2 courses to take.
//              To take course 1 you should have finished course 0. So it is possible.

// Example 2:
// Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
// Output: false
// Explanation: There are a total of 2 courses to take.
//              To take course 1 you should have finished course 0, and to take course 0 you should
//              also have finished course 1. So it is impossible.

// Constraints:
// The input prerequisites is a graph represented by a list of edges, not adjacency matrices.Read more about how a graph is represented.
// You may assume that there are no duplicate edges in the input prerequisites.
// 1 <= numCourses <= 10^5

using System;
using System.Collections.Generic;

namespace MayFifth {
    public class CourseSchedule {
        public static void Main(string[] args) {
            int numCourses = 2;
            int[][] prerequisites = new int[2][];
            prerequisites[0] = new int[] { 1, 0 };
            prerequisites[1] = new int[] { 0, 1 };
            Console.WriteLine(CanFinish(numCourses, prerequisites));
        }

        public static bool CanFinish(int numCourses, int[][] prerequisites) {
            int[] indegree = new int[numCourses];
            List<List<int>> adj = new List<List<int>>();
            for (int i = 0; i < numCourses; ++i) {
                adj.Add(new List<int>());
            }
            foreach (int[] pair in prerequisites) {
                indegree[pair[0]]++;
                adj[pair[1]].Add(pair[0]);
            }
            Queue<int> q = new Queue<int>();
            for (int i = 0; i < numCourses; ++i) {
                if (indegree[i] == 0 && adj[i].Count != 0) {
                    q.Enqueue(i);
                }
            }
            while (q.Count != 0) {
                int curr = q.Dequeue();
                foreach (int k in adj[curr]) {
                    indegree[k]--;
                    if (indegree[k] == 0 && adj[k].Count != 0) {
                        q.Enqueue(k);
                    }
                }
            }
            foreach (int a in indegree) {
                if (a != 0) {
                    return false;
                }
            }
            return true;
        }
    }
}

// We have a list of points on the plane.Find the K closest points to the origin(0, 0).
// (Here, the distance between two points on a plane is the Euclidean distance.)
// You may return the answer in any order.The answer is guaranteed to be unique (except for the order that it is in.)
   
// Example 1:
// Input: points = [[1,3],[-2,2]], K = 1
// Output: [[-2,2]]
// Explanation: 
// The distance between(1, 3) and the origin is sqrt(10).
// The distance between(-2, 2) and the origin is sqrt(8).
// Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
// We only want the closest K = 1 points from the origin, so the answer is just[[-2, 2]].
   
// Example 2:
// Input: points = [[3,3],[5,-1],[-2,4]], K = 2
// Output: [[3,3],[-2,4]]
// (The answer [[-2, 4],[3,3]] would also be accepted.)
   
// Note:
// 1 <= K <= points.length <= 10000
// -10000 < points[i][0] < 10000
// -10000 < points[i][1] < 10000

using System;
using System.Collections.Generic;

namespace MayFifth {
    public class KClosestPointsToOrigin {
        public static void Main(string[] args) {
            int K = 2;
            int[][] points = new int[3][];
            points[0] = new int[] { 3, 3 };
            points[1] = new int[] { 5, -1 };
            points[2] = new int[] { -2, 4 };
            int[][] result = KClosest(points, K);
            foreach (int[] item in result) {
                foreach (int i in item) {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        private static double CalculateDistance(int x1, int y1) {
            return Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
        }

        public static int[][] KClosest(int[][] points, int K) {
            SortedDictionary<double, List<int[]>> Sd = new SortedDictionary<double, List<int[]>>();
            foreach (int[] curr in points) {
                double dist = CalculateDistance(curr[0], curr[1]);
                if (!Sd.ContainsKey(dist)) {
                    Sd[dist] = new List<int[]>();
                }
                Sd[dist].Add(curr);
            }
            int[][] res = new int[K][];
            int k = 0;
            foreach (double key in Sd.Keys) {
                foreach (int[] p in Sd[key]) {
                    if (k == K) {
                        break;
                    }
                    res[k++] = p;
                }
            }
            return res;
        }
    }
}

// Given two words word1 and word2, find the minimum number of operations required to convert word1 to word2.
// You have the following 3 operations permitted on a word:
// Insert a character
// Delete a character
// Replace a character

// Example 1:
// Input: word1 = "horse", word2 = "ros"
// Output: 3
// Explanation: 
// horse -> rorse(replace 'h' with 'r')
// rorse -> rose(remove 'r')
// rose -> ros(remove 'e')

// Example 2:
// Input: word1 = "intention", word2 = "execution"
// Output: 5
// Explanation: 
// intention -> inention(remove 't')
// inention -> enention(replace 'i' with 'e')
// enention -> exention(replace 'n' with 'x')
// exention -> exection(replace 'n' with 'c')
// exection -> execution(insert 'u')

using System;

namespace MayFifth {
    public class EditDistance {
        public static void Main(string[] args) {
            Console.WriteLine(MinDistance("horse", "ros"));
        }

        public static int MinDistance(string word1, string word2) {
            if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2)) {
                return 0;
            }
            int[,] d = new int[word1.Length + 1, word2.Length + 1];
            for (int i = 0; i < word1.Length + 1; i++) {
                d[i, 0] = i;
            }
            for (int j = 0; j < word2.Length + 1; j++) {
                d[0, j] = j;
            }
            for (int i = 1; i < word1.Length + 1; i++) {
                for (int j = 1; j < word2.Length + 1; j++) {
                    int cout = 1;
                    if (word1[i - 1] == word2[j - 1]) {
                        cout = 0;
                    }
                    d[i, j] = Math.Min(d[i - 1, j] + 1, Math.Min(d[i, j - 1] + 1, d[i - 1, j - 1] + cout));
                }
            }
            return d[word1.Length, word2.Length];
        }
    }
}