package Factory_pattern;

public class Factory_ofen {
	
	public Pizza generate_Pizza(String pizza){
		
		if(pizza == null){
			
	         return null;
	      }		
		if(pizza.equals("funghi")){
			
			return new Funghi();
			
		}if(pizza.equals("diavolo")){
			
			return new Diavolo();
			
		}
		return null;
	}
	

}
