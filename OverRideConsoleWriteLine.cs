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

private static void Cw(TreeNode node) {
    if (node != null) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(node);
        while (queue.Count > 0) {
            TreeNode item = queue.Dequeue();
            if (item == null) {
                Console.Write("null ");
            }
            else {
                Console.Write(item.val + " ");
                queue.Enqueue(item.left);
                queue.Enqueue(item.right);
            }
        }
    }
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

private static void Cw(ListNode node) {
    Console.WriteLine(node.val);
    if (node.next != null) {
        Cw(node.next);
    }
}