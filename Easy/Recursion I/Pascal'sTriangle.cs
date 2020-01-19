// Pascal's triangle are a series of numbers arranged in the shape of triangle.
// In Pascal's triangle, the leftmost and the rightmost numbers of each row are always 1.
// For the rest, each number is the sum of the two numbers directly above it in the previous row.

//     1
//    1 1
//   1 2 1
//  1 3 3 1
// 1 4 6 4 1

// i => row  j => colum
// f(i,j)=f(i−1,j−1)+f(i−1,j)

// Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.

// Input: 5
// Output:
// [
//      [1],
//     [1,1],
//    [1,2,1],
//   [1,3,3,1],
//  [1,4,6,4,1]
// ]

//                   numRows(numRows + 1)       numRows^2 + numRows       numRows^2       numRows
// Time complexity:-----------------------  = ----------------------- = ------------- + ----------- = O(numRows^2)
//                           2                             2                   2              2

using System;
using System.Collections.Generic;

namespace PascalsTriangle {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int key = 10;
            IList<IList<int>> triangle = solution.Generate(key);
            for (int i = 0; i < key; i++) {
                for (int j = 0; j <= i; j++) {
                    Console.Write(triangle[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Solution {
        public IList<IList<int>> Generate(int numRows) {
            IList<IList<int>> triangle = new List<IList<int>>();
            if (numRows <= 0) {
                return triangle;
            }
            triangle.Add(new List<int> { 1 });
            for (int i = 1; i < numRows; i++) {
                // Get last row data
                IList<int> prevRow = triangle[i - 1];
                // In every row the first element was always 1
                List<int> row = new List<int> { 1 };
                for (int j = 1; j < i; j++) {
                    row.Add(prevRow[j - 1] + prevRow[j]);
                }
                // In every row the first element was always 1
                row.Add(1);
                triangle.Add(row);
            }
            return triangle;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace PascalsTriangle {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int key = 1;
            IList<IList<int>> triangle = solution.Generate(key);
            for (int i = 0; i < key; i++) {
                for (int j = 0; j <= i; j++) {
                    Console.Write(triangle[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Solution {
        public IList<IList<int>> Generate(int numRows) {
            // use recursion, depth is num of elements
            // the first and last item must be a 1
            // then loop through previous depth row elements
            // add each pair together to populate elements in new depth
            IList<IList<int>> results = new List<IList<int>>();
            if (numRows == 0) {
                return results;
            }
            results.Add(new int[] { 1 });
            // use numRows-1 because we've already added the first row manually
            for (var i = 0; i < numRows - 1; i++) {
                results.Add(getRow(results[i].ToArray()));
            }
            return results;
        }

        private int[] getRow(int[] prevRow) {
            int[] newRow = new int[prevRow.Length + 1];
            newRow[0] = 1;
            newRow[newRow.Length - 1] = 1;
            for (var i = 0; i < prevRow.Length - 1; i++) {
                newRow[i + 1] = prevRow[i] + prevRow[i + 1];
            }
            return newRow;
        }
    }
}

using System;
using System.Collections.Generic;

namespace PascalsTriangle {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int key = 5;
            IList<IList<int>> triangle = solution.Generate(key);
            for (int i = 0; i < key; i++) {
                string clean = new string(' ', key - i);
                Console.Write($"{clean}");
                for (int j = 0; j <= i; j++) {
                    Console.Write(triangle[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Solution {
        public IList<IList<int>> Generate(int numRows) {
            IList<IList<int>> list = new List<IList<int>>(numRows);
            for (int line = 1; line <= numRows; line++) {
                int key = 1;
                List<int> inner = new List<int>();
                for (int i = 1; i <= line; i++) {
                    inner.Add(key);
                    // a=[1,4,6,4,1]   
                    // 在下标为 2 的地方计算下标为 3 的值 a[3] = a[2] * (row - 2) / 2
                    // 在下标为 3 的地方计算下标为 4 的值 a[4] = a[3] * (row - 3) / 3
                    key = key * (line - i) / i;
                }
                list.Add(inner);
            }
            return list;
        }
    }
}

// Java
class Solution {
    public List<List<Integer>> generate(int numRows) {
        List<List<Integer>> triangle = new ArrayList<List<Integer>>();
        // First base case; if user requests zero rows, they get zero rows.
        if (numRows == 0) {
            return triangle;
        }
        // Second base case; first row is always [1].
        triangle.add(new ArrayList<>());
        triangle.get(0).add(1);
        for (int rowNum = 1; rowNum < numRows; rowNum++) {
            List<Integer> row = new ArrayList<>();
            List<Integer> prevRow = triangle.get(rowNum - 1);
            // The first row element is always 1.
            row.add(1);
            // Each triangle element (other than the first and last of each row)
            // is equal to the sum of the elements above-and-to-the-left and
            // above-and-to-the-right.
            for (int j = 1; j < rowNum; j++) {
                row.add(prevRow.get(j - 1) + prevRow.get(j));
            }
            // The last row element is always 1.
            row.add(1);
            triangle.add(row);
        }

        return triangle;
    }
}

// Python
class Solution :
    def generate(self, num_rows):
        triangle = []
        for row_num in range(num_rows) :
            # The first and last row elements are always 1.
            row = [None for _ in range(row_num + 1)]
            row[0], row[-1] = 1, 1
            # Each triangle element is equal to the sum of the elements
            # above-and-to-the-left and above-and-to-the-right.
            for j in range(1, len(row)-1) :
                row[j] = triangle[row_num - 1][j - 1] + triangle[row_num - 1][j]
                triangle.append(row)
        return triangle

// Given a non-negative index k where k ≤ 33, return the kth index row of the Pascal's triangle.
// Note that the row index starts from 0.

// Input: 3
// Output: [1,3,3,1]

// Could you optimize your algorithm to use only O(k) extra space?
using System;
using System.Collections.Generic;

namespace PascalsTriangle {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int key = 1;
            IList<int> val = solution.Generate(key);
            foreach (int item in val) {
                Console.Write(item + " ");
            }
        }
    }

    public class Solution {
        public IList<int> Generate(int rowIndex) {
            IList<int> triangle = new List<int>();
            IList<IList<int>> triangleList = new List<IList<int>>();
            if (rowIndex < 0) {
                return triangle;
            }
            triangle.Add(1);
            if (rowIndex == 0) {
                return triangle;
            }
            triangleList.Add(new List<int> { 1 });
            for (int i = 1; i <= rowIndex; i++) {
                // Get last row data
                IList<int> prevRow = triangleList[i - 1];
                // In every row the first element was always 1
                List<int> row = new List<int> { 1 };
                for (int j = 1; j < i; j++) {
                    row.Add(prevRow[j - 1] + prevRow[j]);
                }
                // In every row the first element was always 1
                row.Add(1);
                triangleList.Add(row);
                if (i == rowIndex) {
                    triangle = row;
                }
            }
            return triangle;
        }
    }
}

// Use Queue 
using System;
using System.Collections.Generic;
using System.Linq;

namespace PascalsTriangle {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int key = 6;
            IList<int> val = solution.Generate(key);
            foreach (int item in val) {
                Console.Write(item + " ");
            }
        }
    }

    public class Solution {
        public IList<int> Generate(int rowIndex) {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            for (int i = 0; i < rowIndex; i++) {
                int key = 0;
                for (int j = 0; j <= i; j++) {
                    int tmp = queue.Dequeue();
                    queue.Enqueue(tmp + key);
                    key = tmp;
                }
                queue.Enqueue(key);
            }
            return queue.ToList();
        }
    }
}

using System;
using System.Collections.Generic;

namespace PascalsTriangle {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int key = 1;
            IList<int> val = solution.Generate(key);
            foreach (int item in val) {
                Console.Write(item + " ");
            }
        }
    }

    public class Solution {
        public IList<int> Generate(int rowIndex) {
            var ret = new List<int>();
            ret.Add(1);
            for (int i = 1; i <= rowIndex; i++) {
                //move backwards to be able to rewrite the same row in-place as it uses only pre elems
                for (int j = i; j > 0; j--) {
                    if (j == i)
                        ret.Add(1);
                    else
                        ret[j] = (ret[j - 1] + ret[j]);
                }
            }
            return ret;
        }
    }
}

// On the first row, we write a 0. Now in every subsequent row.
// we look at the previous row and replace each occurrence of 0 with 01, and each occurrence of 1 with 10.
// Given row N and index K, return the K-th indexed symbol in row N. (The values of K are 1-indexed.) (1 indexed).

// Examples:
// Input: N = 1, K = 1
// Output: 0

// Input: N = 2, K = 1
// Output: 0

// Input: N = 2, K = 2
// Output: 1

// Input: N = 4, K = 5
// Output: 1

// Explanation:
// row 1: 0
// row 2: 01        row 1 : 0 => 01
// row 3: 0110      row 2 : 0 => 01, 1 => 10
// row 4: 01101001  row 3 : 0 => 01, 1 => 10, 1 => 10, 0 => 01
using System;

namespace PascalsTriangle {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int num = solution.KthGrammar(3, 1);
            Console.WriteLine(num);
        }
    }

    public class Solution {
        public int KthGrammar(int N, int K) {
            if (N == 1) {
                return 0;
            }
            if (K % 2 == 0) {
                return (KthGrammar(N - 1, K / 2) == 0 ? 1 : 0);
            }
            return (KthGrammar(N - 1, (K + 1) / 2) == 0 ? 0 : 1);
        }
    }
}

using System;

namespace PascalsTriangle {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int num = solution.KthGrammar(3, 1);
            Console.WriteLine(num);
        }
    }

    public class Solution {
        public int KthGrammar(int N, int K) {
            if (N == 1) {
                return 0;
            }
            int parentGrammar = KthGrammar(N - 1, (K + 1) / 2);
            if (parentGrammar == 0) {
                return K % 2 == 1 ? 0 : 1;
            }
            else {
                return K % 2 == 1 ? 1 : 0;
            }
        }
    }
}
