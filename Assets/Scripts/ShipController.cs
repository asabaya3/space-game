using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShipController : MonoBehaviour {

    public float speed;

    private Transform target;
    private int ships;
    private Text shipText;
    
    void Start(){    
        shipText = transform.Find("Ship Canvas/Ship Text").gameObject.GetComponent<Text>();
    }
    
	public void SetInitialVars(Transform planet, int num){
        target = planet;
        ships = num;
    }
    
	void Update () {
        shipText.text = ships.ToString();
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        
        Vector3 dir = target.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.transform == target){
            Destroy(gameObject);
            other.gameObject.GetComponent<PlanetController>().ships -= ships;
        }
    }
}
