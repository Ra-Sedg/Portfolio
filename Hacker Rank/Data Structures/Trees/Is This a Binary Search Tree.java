boolean checkBST(Node root) {
    
    return checkBST(root, Integer.MIN_VALUE, Integer.MAX_VALUE);
}

boolean checkBST(Node current, int min, int max) {
    
    if (current == null) {
        return true;
    }
    
    if (current.data < min || current.data > max) {
        return false;
    }
    
    return checkBST(current.left, min, current.data - 1) &&
           checkBST(current.right, current.data + 1, max);
}