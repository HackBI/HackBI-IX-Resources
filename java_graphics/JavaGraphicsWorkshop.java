import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class JavaGraphicsWorkshop extends JPanel implements ActionListener, KeyListener {

   // Window dimensions
   private int screenWidth, screenHeight;
   private Timer timer;
   
   // Keyboard example variable
   private boolean spacePressed;
   
   // Example animation variables
   private int movingX = 50; // Example x-coordinate that can move
   private int movingDirection = 1;
   
   public JavaGraphicsWorkshop(int width, int height) { 
      super();
      screenWidth = width;
      screenHeight = height;
      spacePressed = false;
      
      // Set up the JFrame window
      JFrame frame = new JFrame("Java Graphics Workshop");
      frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
      frame.setSize(screenWidth + 17, screenHeight + 40);
      frame.setLocationRelativeTo(null);
      frame.setVisible(true);
      
      // Attach KeyListener to JFrame for keyboard input
      frame.addKeyListener(this);
      
      // Set up content pane (canvas)
      Container content = frame.getContentPane();
      content.setBackground(Color.WHITE);
      content.add(this);
      
      // Timer for animation (fires every 10 milliseconds)
      timer = new Timer(10, this);
      timer.start();
   }
   
   @Override
      public void paintComponent(Graphics g) { 
      super.paintComponent(g);
         
      // -------------------------
      // 1. Background 
      // -------------------------
      g.setColor(Color.WHITE);
      g.fillRect(0, 0, screenWidth, screenHeight);
         
      // -------------------------
      // 2. Basic Shapes 
      // -------------------------
      // Rectangle
      g.setColor(Color.RED);
      g.drawRect(50, 50, 100, 50); // outline
      g.setColor(Color.PINK);
      g.fillRect(200, 50, 100, 50); // filled rectangle
         
      // Oval / Circle
      g.setColor(Color.BLUE);
      g.drawOval(50, 150, 80, 80); // outline
      g.setColor(Color.CYAN);
      g.fillOval(200, 150, 80, 80); // filled oval
         
      // Line
      g.setColor(Color.BLACK);
      g.drawLine(50, 250, 150, 300);
         
      // Polygon (triangle example)
      int[] xPoints = {250, 300, 350};
      int[] yPoints = {250, 200, 250};
      g.setColor(Color.MAGENTA);
      g.drawPolygon(xPoints, yPoints, 3); // outline
      g.setColor(Color.ORANGE);
      g.fillPolygon(xPoints, yPoints, 3); // filled
         
      // -------------------------
      // 3. Text
      // -------------------------
      g.setColor(Color.BLACK);
      g.drawString("Press SPACE to show text", 50, 380);
         
      if (spacePressed) { 
         g.setColor(Color.GREEN);
         g.drawString("SPACE is pressed!", 200, 380);
      }
         
      // -------------------------
      // 4. Animation Example
      // -------------------------
      g.setColor(Color.YELLOW);
      g.fillOval(movingX, 320, 50, 50); // a moving circle
   }
     
   @Override
     public void actionPerformed(ActionEvent e) { 
     // Move the animation circle back and forth
      movingX += movingDirection;
      if (movingX > screenWidth - 50 || movingX < 0) { 
         movingDirection *= -1; // reverse direction
      } 
     
      repaint();
     
   }
     
   // ----------------------------
   // Keyboard input
   // ----------------------------
   @Override
    public void keyPressed(KeyEvent e) {
      if(e.getKeyCode() == KeyEvent.VK_SPACE) {
         spacePressed = true;
      }
   }

   @Override
    public void keyReleased(KeyEvent e) {
      if(e.getKeyCode() == KeyEvent.VK_SPACE) {
         spacePressed = false;
      }
   }

   @Override
    public void keyTyped(KeyEvent e) {}

   // ----------------------------
   // Main method
   // ----------------------------
   public static void main(String[] args) {
      new JavaGraphicsWorkshop(500, 400);
   }
}

