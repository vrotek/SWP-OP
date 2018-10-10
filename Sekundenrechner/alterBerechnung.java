import java.util.Scanner;

public class alterBerechnung {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		int alter = 0;
		System.out.println("Geben Sie ihr alter an:");
		alter = scan.nextInt();
		Person.getInstance(alter);

	}

}
