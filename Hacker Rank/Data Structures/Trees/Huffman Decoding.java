/*  
   class Node
      public  int frequency; // the frequency of this tree
       public  char data;
       public  Node left, right;
    
*/ 

void decode(String S ,Node root) {
    
    Node current = root;
    StringBuilder builder = new StringBuilder();
  
    
    for (int i = 0; i < S.length(); i++) {
        
        if (S.charAt(i) == '0') {
            current = current.left;
        }
        else {
            current = current.right;
        }
        
        if (current.data != '\0') {
            builder.append(current.data);
            current = root;
        }    
        
    }
    
    System.out.println(builder);
}