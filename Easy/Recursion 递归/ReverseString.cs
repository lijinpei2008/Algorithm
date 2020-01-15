// Write a function that reverses a string. The input string is given as an array of characters char[].

// Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

// You may assume all the characters consist of printable ascii characters.

// The entire logic for reversing a string is based on using the opposite directional two-pointer approach!

// Input: ["H","e","l","l","o"]
// Output: ["o","l","l","e","H"]

// Function 1
public class Solution {
  public void ReverseString(char[] charList){
    char key;
    int left = 0;
    int right = charList.Length - 1;
    while( left <= right ){
      key = charList[left];
      charList[left++] = charList[right];
      charList[right--] = key;
    }
  }
}

// Function 2
public class Solution {
  public void ReverseString(char[] charList){
    HelpFounction(charList,0,charList.Length-1);
  }

  public void HelpFounction(char[] charList, int left, int right){
    if( left >= right){
      return;
    }
    char key = charList[left];
    charList[left++] = charList[right];
    charList[right--] = key;
    HelpFounction(charList,left,right);
  }
}

// Python
class Solution:
    def reverseString(self, s):
        s.reverse()

// Java
class Solution {
  public void helper(char[] s, int left, int right) {
    if (left >= right) return;
    char tmp = s[left];
    s[left++] = s[right];
    s[right--] = tmp;
    helper(s, left, right);
  }

  public void reverseString(char[] s) {
    helper(s, 0, s.length - 1);
  }
}

// Python
class Solution:
    def reverseString(self, s):
        def helper(left, right):
            if left < right:
                s[left], s[right] = s[right], s[left]
                helper(left + 1, right - 1)

        helper(0, len(s) - 1)

// Java
class Solution {
    public void reverseString(char[] s) {
        int left = 0, right = s.length - 1;
        while (left < right) {
            char tmp = s[left];
            s[left++] = s[right];
            s[right--] = tmp;
        }
    }
}

// Python
class Solution:
    def reverseString(self, s):
        left, right = 0, len(s) - 1
        while left < right:
            s[left], s[right] = s[right], s[left]
            left, right = left + 1, right - 1