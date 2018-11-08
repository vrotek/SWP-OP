package Observer_Bsp;

public class Mensa_Observer extends Observer {
	
	public Mensa_Observer(Subject subject){
	      this.subject = subject;
	      this.subject.attach(this);
	}
	
	
	double heizleistung = 1.3;
	
	
	@Override
	public void update() {
		System.out.println("Mensa: HZ(30%)");
		System.out.println("Heizung: "+ (subject.getState()+10) * heizleistung);
		System.out.println("-----------------");
	}
}
