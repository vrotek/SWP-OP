package Factory_pattern;

import java.util.Scanner;

public class Pizzaria_Restaurant {

	
	//static Scanner scan = new Scanner(System.in);
	//static String p;
	public static void main(String[] args) {
		Factory_ofen f = new Factory_ofen();
		Scanner scan = new Scanner(System.in);
		String p;
		System.out.println("Was wollen sie bestellen? [diavolo][funghi]");
		 p = scan.next();
		 Pizza p1 = f.generate_Pizza(p);
		 p1.backen();
		//f.generate_Pizza(p);
		

	}
	
}
