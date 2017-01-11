/* Node is defined as :
 class Node 
    int data;
    Node left;
    Node right;
    
    */

static Node Insert(Node root,int value) {
    
    
    
    if (root == null) {
        
        Node insert = new Node();
        insert.data = value;
        insert.left = null;
        insert.right = null;
        
        return insert;
        
    }
    
    if (value == root.data) {
        return root;
    }
    
    if (value < root.data) {
        root.left = Insert(root.left, value);
    } 
    else {
        root.right = Insert(root.right, value);
    }
    
    return root;
}
