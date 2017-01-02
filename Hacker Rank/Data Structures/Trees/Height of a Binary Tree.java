/*
    class Node 
    	int data;
    	Node left;
    	Node right;
	*/
	static int height(Node root) {
        
        if (root == null) {
            return -1;
        }
        
        int leftHeight = height(root.left);
        int rightHeight = height(root.right);
        
        return Math.max(leftHeight, rightHeight) + 1;
    }