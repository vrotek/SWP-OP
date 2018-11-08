package Observer_Bsp;

public class Client {

	public static void main(String[] args) {
		 Subject subject = new Subject();

	      new Schule_Observer(subject);
	      new Klasse_Observer(subject);
	      new Mensa_Observer(subject);
	      
	      for(int i = 1;i <= 5; i++){
	      int r = (int) ((Math.random()) * 15);
	      System.out.println("=================");
	      System.out.println("= Day "+i+": "+r+"°C  =");	
	      System.out.println("=================");
	      subject.setState(r);
	     
	      }

	}

}
