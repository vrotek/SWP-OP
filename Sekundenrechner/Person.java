
public class Person {

	private static Person instance = null;
	private static final int months = 12;
	private static final int days = 365;
	private static final int hours = 24;
	private static final int minutes = 60;
	private static final int seconds = 60;




	private Person(int age){
		secl(age);




	}

	public static Person getInstance(int age){

		if(instance == null){
			instance = new Person(age);
		}

		return instance;
	}

	private int secl(int age){
		int result = age * days * hours * minutes * seconds;
		int month = age * months;
		System.out.print("");
		System.out.println("Sie haben schon "+ result+" Sekunden gelebt \n");
		System.out.println();
		System.out.println("              Time Table              ");
		System.out.println("--------------------------------------");
		System.out.println("years:   \t\t"+age);
		System.out.println("months:  \t\t"+month);
		System.out.println("days:    \t\t"+(result/(hours*minutes*seconds)));
		System.out.println("hours: 	 \t\t"+(result/(minutes*seconds)));
		System.out.println("minutes: \t\t"+(result/seconds));
		System.out.println("seconds: \t\t"+result);
		System.out.println();
		System.out.println("Sekunden bis alter 100:\t"+ (result - (100 * days * hours * minutes * seconds)));
		return result;
	}


}
