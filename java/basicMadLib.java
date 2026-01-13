//Joshua Rough and Patrick Christmas
//Java Basics HACKBI IX

import java.util.Scanner; //Allows for Interaction

public class basicMadLib {
   public static void main(String[] args) {
      Scanner kb = new Scanner(System.in); 
      
      String noun1 = ""; //Initialize
      System.out.println("Please enter a noun: "); //Asks for a noun
      noun1 = kb.next(); //Allows for words
           
      int num1 = 0;
      System.out.println("Please enter a whole number: "); //Asks for a number
      num1 = kb.nextInt(); //Allows for numbers
         
      String adj1 = "";
      System.out.println("Please enter an adjective: "); //Asks for an adjective
      adj1 = kb.next(); //Allows for words
      
      String noun2 = "";
      System.out.println("Please enter a plural noun: ");
      noun2 = kb.next();
      
      String verb1 = "";
      System.out.println("Please enter a verb ending in -ed: "); //Asks for a verb
      verb1 = kb.next(); //Allows for words
      
      String adj2 = "";
      System.out.println("Please enter an adjective: ");
      adj2 = kb.next();
      
      String verb2 = "";
      System.out.println("Please enter a verb ending in -ed: ");
      verb2 = kb.next();
                 
      double decNum1 = 0;
      System.out.println("Please enter a decimal: "); //Asks for a decimal
      decNum1 = kb.nextDouble(); //Allows for a decimal
           
      int num2 = 0;
      System.out.println("Please enter a whole number: ");
      num2 = kb.nextInt();
           
      String noun3 = "";
      System.out.println("Please enter a noun: ");
      noun3 = kb.next();    
      
      String verb3 = "";
      System.out.println("Please enter a verb: ");
      verb3 = kb.next();
      
      int num3 = 0;
      System.out.println("Please enter a whole number: ");
      num3 = kb.nextInt();
           
      String adj3 = "";
      System.out.println("Please enter an adjective: ");
      adj3 = kb.next();
      
      String adj4 = "";
      System.out.println("Please enter an adjective: ");
      adj4 = kb.next();
           
      String noun4 = "";
      System.out.println("Please enter a noun: ");
      noun4 = kb.next();
            
      double decNum3 =  0;
      System.out.println("Please enter a decimal: ");
      decNum3 = kb.nextDouble();
            
      String finalNoun = "";
      System.out.println("Please enter a noun: ");
      finalNoun = kb.next();
           
      String finalVerb = "";
      System.out.println("Please enter a verb ending in -ed: ");
      finalVerb = kb.next();
            
      double finalDouble = 0;
      System.out.println("Please enter a decimal: ");
      finalDouble = kb.nextDouble();
         
      String finalAdj = "";
      System.out.println("Please enter an adjective: ");
      finalAdj = kb.next();
      
      //Story
      System.out.println("It was a normal, sunny day for the " + noun1 + " until the " + num1 + " " + adj1 + " evil " + noun2 + " " + verb1 + "!");
      System.out.println("Before the " + noun1 + " could react, the " + adj2 + " " + noun2 + " " + verb2 + " into " + decNum1 + " different pieces!");
      System.out.println("Luckily, the nearby " + noun3 + " was able to defeat the " + num2 + " " + noun2 + " and " + verb3 + " back " + noun1 + " " + num3 + " into a functional being!");
      System.out.println("In a change of events, the sky turned " + adj3 + " " + adj4 + " as " + noun4 + " descended onto the city!");
      System.out.println("To save the day, the legendary " + finalNoun + " " + finalVerb + " about " + finalDouble + " chocolates and threw them into a " + finalAdj + " pit!");
      System.out.println();
      System.out.println("In this workshop, you will learn how to code a MadLib using some basic Java tools.");
      System.out.println("You will create your own story, as well as variables to add! Try to be creative!");
      
      
      
   }
}
