using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text selectedText;
    public Text resourcesText;
    public Text shipsText;
    public Text attackText;
    public Text messageText;
    public GameObject shipType;
    
    private PlanetController selected;
    private int attackShips;
    private float attackMultiplier = 1;
    
	// Use this for initialization
	void Start () {
        selectedText.text = "None";
        resourcesText.text = "RPM: 0";
        shipsText.text = "Ships: 0";
        attackText.text = "Attacking: 0";
        messageText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        if(selected != null){
            selectedText.text = selected.name;
            resourcesText.text = "RPM: " +  Mathf.FloorToInt(selected.resourcesPerMinute).ToString();
            shipsText.text = "Ships: " +  Mathf.FloorToInt(selected.ships).ToString();
            attackText.text = "Attacking: " +  Mathf.FloorToInt(selected.ships * attackMultiplier).ToString();
            attackShips = Mathf.FloorToInt(selected.ships * attackMultiplier);
        }
	}
    
    void WriteMessage(string line){
        messageText.text += "\r\n" + line;
    }
    
    public void SetAttackMultiplier(float mult){
        attackMultiplier = mult;
    }
   
    public void Attack(PlanetController planet){
        GameObject ship;
        
        ship = (GameObject)Instantiate(shipType, selected.transform.position, selected.transform.rotation);
        ship.GetComponent<ShipController>().SetInitialVars(planet.transform, attackShips);
    
        this.WriteMessage(selected.name + " attacks " + planet.name + " with " + attackShips.ToString() + " ships.");
        selected.ships -= attackShips;
    }
    
    public void Select(PlanetController planet){
        selected = planet;
    }
}
