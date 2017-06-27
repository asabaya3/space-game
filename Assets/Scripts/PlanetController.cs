using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlanetController : MonoBehaviour {

    public float speed;
    public float ships;
    public float baseResourcesPerMinute;
    public float resourcesPerMinute;
    
    private GameController gameController;
    private float radius;
    private float rotationalSpeed;
    
	// Use this for initialization
	void Start () {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        transform.Find("Planet Canvas/Planet Name Text").GetComponent<Text>().text = name;
        
        radius = Vector3.Distance(transform.position, Vector3.zero);
        rotationalSpeed = speed / radius;
        
        resourcesPerMinute = baseResourcesPerMinute;
            
        ships = 0;
	}
	
	// Update is called once per frame
	 void Update(){
        transform.RotateAround(Vector3.zero, Vector3.forward, rotationalSpeed * Time.deltaTime);
        transform.localEulerAngles = Vector3.zero;
        ships += Time.deltaTime * resourcesPerMinute / 60;
    }
    
	void OnMouseOver() {
        if(Input.GetMouseButtonDown(0)){
            gameController.Select(this);
        }
        else if(Input.GetMouseButtonDown(1)){
            gameController.Attack(this);
        }
    }
}
