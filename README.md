# SWP-OP

# Survive

##  Description
Survive ist ein simples Textadventure in welchen man pro Tag eine Entscheidung treffen muss welche die 4 Faktoren des Überlebens beeinflusst: Menschen, Verteidigung, Glaube, Verpflegung

Der Spieler hat nun die Aufgabe diese 4 Werte so zu verwalten, dass keiner auf 0 sinkt und das Spiel beendet. Er kann Geld verdienen welches im Shop gegen Prozente der 4 Überlebenswerte eingetauscht werden kann.

## Verwendete Patterns
In dem Spiel werden folgende Patterns verwendet

| Patterns        | Ussage      |
| ------------- |:-------------|
| **Singeltonpattern**      | Wird verwendet um das Mehrmalige entstehen des GameManagers zu verhindern |
| **Statepattern**      | Wird verwendet um von den Zustand des Spiel zu steuern -> Vom Menu ins Spiel und bei Game Over       zum Endscreen      |
| **Commandpattern** | Wird verwendet um in Shop Prozente zu kaufen und diese wieder zu verkaufen      |

### Singeltonpattern
Das Singelton wird deshalb verwendet da es nicht möglich sein darf, dass es 2 Instanzen der GameManager Klasse geben kann, da dies zu Problemen in der Spiellogik führt und sich manche Zustände somit überschreiben. Es ist zumeist Good practise wenn bei Verwendung einer Klasse welche das Spiel leitet ein Singeltonpattern angewendet wird.

Neben dem GameManger gibt es auch den BoardManager welche teile der Spiellogik übernimmt welche nicht über Prefabs abgehandelt werden kann.

Es wird zudem noch eine Absicherung hinzugefügt fals sich aus irgendeinem Grund eine 2 Instance im Spiel befindet wird diese Zerstört. 

**GameManager**
```c#
public class GameManager : MonoBehaviour {
 public static GameManager instance = null;
    private Zustand state;
    void Awake()
    {
        
        if (instance == null)

            
            instance = this;

        
        else if (instance != this)

            
            Destroy(gameObject);

        
        DontDestroyOnLoad(gameObject);
    }

public GameManager()
    {
        state = null; 
    }

    public void setState(Zustand state)
    {
        this.state = state;
    }

    public Zustand getState()
    {
        return state;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static GameManager getInstance()
    {
        return instance;
    }
}
```
Damit der GameManager zum Start des Spiels Initialisiert wird schreiben wir eine Klasse welche beim Starten des Spiels den GameManager Initialisiert wenn noch keiner vorhanden.

**Loader**
```c#
public class Loader : MonoBehaviour {

  
    public GameObject gameManager;          
    public Intro intro;


    void Awake()
    {
        
        if (GameManager.instance == null)

            
            Instantiate(gameManager);
            Instantiate(intro);
            
        
    }
}
```
### Statepattern
Dieses Pattern wird verwendet um zwischen den Scenen zu wechseln sobald der Spieler das Spiel started.

Statepatterns werden in Spielen oft zur Codierung von Ki's verwendet um Gegnerbehavior zu erstellen, welche zwischen verschiedenen Zuständen wechseln können. 

Wenn der Spieler started gehen wir über den StartState von Scene Start zur Hauptscene(Samplescene) und wenn einer der Überlebenswerte auf 0 sinkt wechesln wir über den LoseState zur End Scene.

**Zustand**<br>
Das Interface welches States definiert.
```c#
public class Zustand : MonoBehaviour {

    public virtual void GameAction()
    {

    }
    public virtual void ChangeScene()
    {

    }
}

```
**StartState**<br>
Der StartState ist einer der beiden States welche im Spiel verwendet werden, hierbei implementiert die Klasse das Interface Zustand. In ChangeScene() wird die Hauptscene geladen wenn wir das Spiel Starten wollen.
```c#
public class StartState : Zustand {

    GameManager gameManager = GameManager.getInstance();

    public override void GameAction()
    {
        
        
        gameManager.setState(new StartState());
    }

    public override void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

  
}
```
**LoseState**
Gleich wie beim StartState nur wird im ChangeScene() die Endscene geladen.
```c#
public class LoseState : Zustand {
    GameManager gameManager = GameManager.getInstance();

    public override void GameAction()
    {

        
        gameManager.setState(new LoseState());
        
    }

    public override void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }
    
}
```
**Setzen des StartStates**<br>
Den Startstate setzen wir wenn der Spieler den Button Start und damit die Methode Enter() ausführt. Wenn das Script ausgeführt wird setzen wir den State in den StartState.
```c#
 public void Enter()
    {

        GameManager gameManager = GameManager.getInstance();
        gameManager.getState().ChangeScene();
    }

    private void Awake()
    {
        StartState startState = new StartState();
        startState.GameAction();
        

    }
```
**Setzen des LoseStates**<br>
Hier überprüfen wir ob im Spiel einer der 4 Werte auf 0 sinkt wobei hier der LoseState gesetzt wird.
```c#
void Update () {
        if(people.value <= 0)
        {
            LoseState lose = new LoseState();
            lose.GameAction();
            GameManager gameManager = GameManager.getInstance();
            gameManager.getState().ChangeScene();
           
            Endscreen.ds = "people";
        }
        else if (defense.value <= 0 )
        {
            LoseState lose = new LoseState();
            lose.GameAction();
            GameManager gameManager = GameManager.getInstance();
            gameManager.getState().ChangeScene();
            
            Endscreen.ds = "defense";
        }
        else if (faith.value <= 0)
        {
            LoseState lose = new LoseState();
            lose.GameAction();
            GameManager gameManager = GameManager.getInstance();
            gameManager.getState().ChangeScene();
            
            Endscreen.ds = "faith";
        }
        else if (food.value <= 0)
        {
            LoseState lose = new LoseState();
            lose.GameAction();
            GameManager gameManager = GameManager.getInstance();
            gameManager.getState().ChangeScene();
            
            Endscreen.ds = "food";
        }
	}
```
## Commandpattern
Das Commandpattern wurde hier verwendet um es möglich zu manchen, im Shop gewisse Aktionen zu tätigen und diese auch wieder rückgängig zu machen.

**Order**<br>
Das Interface welches Aktionen definiert.
```c#
public abstract class Order {

    public abstract void execute(Text text1, Text text2, Text text3, Text text4, Order order);

    public virtual void undo(Text text1, Text text2, Text text3, Text text4) { }

    public virtual double getGain() { return 0; }
}
```
**Buy People Aktion**
```c#
public class PeopleStat : Order
{

    
    private static double gain = 0;

    public override void execute(Text text1, Text text2, Text text3, Text text4, Order order)
    {
        if (AddText.score >= 10)
        {
            gain += 1;
            text1.text = gain.ToString();
            AddText.score -= 10;
            Debug.Log("execute people");
            Stack.stack.Add(order);
        }
    }

    public override void undo(Text text1, Text text2, Text text3, Text text4)
    {
        gain -= 1;
        text1.text = gain.ToString();
        AddText.score += 10;
    }

    public override double getGain()
    {
        Debug.Log(gain);
        double result = gain / 10;
        return result;
    }
}
```
**Buy Defense/Faith/Food Aktion**<br>
Erfolgen gleich wie bei der People Aktion nur wird ein anderes Text Element angesprochen.

**Undo Aktion**
```c#
public class UndoOrder : Order {

    

    public override void execute(Text text1, Text text2, Text text3, Text text4, Order order)
    {


        List<Order> oldOrders = Stack.stack;

        if (oldOrders.Count > 0)
        {
            Order cOrder = oldOrders[oldOrders.Count - 1];
           
                cOrder.undo(text1, text2, text3, text4);
            
            
                
                
            
            oldOrders.RemoveAt(oldOrders.Count - 1);
        }
    }
}

```
**Inputhandler/CommandRecorder**
```c#
public class Stack : MonoBehaviour {

    private Order people, defense, faith, food, sell;
    public static List<Order> stack = new List<Order>();

    [SerializeField] private Text faithT;
    [SerializeField] private Text peopleT;
    [SerializeField] private Text foodT;
    [SerializeField] private Text defenseT;

    [SerializeField] private Slider faithS;
    [SerializeField] private Slider peopleS;
    [SerializeField] private Slider foodS;
    [SerializeField] private Slider defenseS;

    private void Start()
    {
        people = new PeopleStat();
        defense = new DefenseStat();
        faith = new FaithStat();
        food = new FoodStat();
        sell = new UndoOrder();
    }

    public void Buy()
    {
        Debug.Log("execute buy");
        Debug.Log(people.getGain());
        Debug.Log(defense.getGain());
        Debug.Log(faith.getGain());
        Debug.Log(food.getGain());
        defenseS.value += (float) defense.getGain();
        peopleS.value += (float) people.getGain();
        faithS.value += (float) faith.getGain();
        foodS.value += (float) food.getGain();
        stack.Clear();

        peopleT.text = "0";
        defenseT.text = "0";
        faithT.text = "0";
        foodT.text = "0";


    }

    public void People()
    {
        people.execute(peopleT, defenseT, faithT, foodT, people);
    }
    public void Defense()
    {
        defense.execute(peopleT, defenseT, faithT, foodT, defense);
    }
    public void Faith()
    {
        faith.execute(peopleT, defenseT, faithT, foodT, faith);
    }
    public void Food()
    {
        food.execute(peopleT, defenseT, faithT, foodT, food);
    }
    public void Sell()
    {
        sell.execute(peopleT, defenseT, faithT, foodT, sell);
    }
}

```
