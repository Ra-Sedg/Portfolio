/*
  Insert Node at the end of a linked list 
  head pointer input could be NULL as well for empty list
  Node is defined as 
  class Node {
     int data;
     Node next;
  }
*/
int FindMergeNode(Node headA, Node headB) {
    
    int lengthA = 0;
    int lengthB = 0;
    
    Node nodeA = headA;
    Node nodeB = headB;
    
    // Get length of lists.
    while (nodeA != null) {
        lengthA++;
        nodeA = nodeA.next;
    }
    nodeA = headA;
    
    while (nodeB != null) {
        lengthB++;
        nodeB = nodeB.next;
    }
    nodeB = headB;
    
    // Move pointer of longer list forward.
    int lengthC;
    
    if (lengthA < lengthB) {
        lengthC = lengthB - lengthA;
        for (int i = 0; i < lengthC; i++) {
            nodeB = nodeB.next;
        }
    }
    else {
        lengthC = lengthA - lengthB;
        for (int i = 0; i < lengthC; i++) {
            nodeA = nodeA.next;
        }
    }
    
    // Both pointers are now an equal distance from the end of the list.
    // The merge point will be where both pointers referance the same Node.
    while (nodeA != null) {
        
        if (nodeA.equals(nodeB)) {
            return nodeA.data;
        }
        
        nodeA = nodeA.next;
        nodeB = nodeB.next;
    }
    
    // Dummy return, since the lists merge this shuold not be reached.
    return -1;
}