package Observer_Bsp;

public class Schule_Observer extends Observer{


	public Schule_Observer(Subject subject){
	      this.subject = subject;
	      this.subject.attach(this);
	}
	
	
	double heizleistung = 1.20;
	
	
	@Override
	public void update() {
		System.out.println("Schule: HZ(20%)");
		System.out.println("Heizung: "+ (subject.getState()+10) * heizleistung);
		System.out.println("-----------------");
	}

}
