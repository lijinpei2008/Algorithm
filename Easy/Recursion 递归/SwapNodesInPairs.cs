// Given a linked list, swap every two adjacent nodes and return its head.

// You may not modify the values in the list's nodes, only nodes itself may be changed.

// Example:
// Given 1->2->3->4, you should return the list as 2->1->4->3.

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *   public int val;
 *   public ListNode next;
 *   public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
  public ListNode SwapPairs(ListNode head) {
    HelpFunction(head,0);
    return head;
  }

  public void HelpFunction(ListNode head, int index){
    if( index == 0 && head.next != null ){
      head.val = head.val ^ head.next.val;
      head.next.val = head.next.val ^ head.val;
      head.val = head.val ^ head.next.val;
      index++;
      HelpFunction(head.next,index);
    }
    else{
      if(head.next == null){
        return;
      }
      HelpFunction(head.next,0);
    }
  }
}