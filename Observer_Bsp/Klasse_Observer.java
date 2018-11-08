package Observer_Bsp;

public class Klasse_Observer extends Observer{
	
	public Klasse_Observer(Subject subject){
	      this.subject = subject;
	      this.subject.attach(this);
	}
	
	
	double heizleistung = 1.5;
	
	
	@Override
	public void update() {
		System.out.println("Klasse: HZ(50%)");
		System.out.println("Heizung: "+ (subject.getState()+10) * heizleistung);
		System.out.println("-----------------");
		
	}
}
