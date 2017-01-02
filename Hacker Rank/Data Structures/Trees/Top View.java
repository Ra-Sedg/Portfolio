/*
   class Node 
       int data;
       Node left;
       Node right;
*/
void top_view(Node root){
    
    Node current = root;
    Stack<Node> stack = new Stack<Node>();
    
    while(current != null) {
        stack.push(current);
        current = current.left;
    }
    
    while(!stack.isEmpty()){
        Node node = stack.pop();
        System.out.print(node.data + " ");
    }
    
    current = root.right;
    
    while(current != null){
        System.out.print(current.data + " ");
        current = current.right;
    }
}
