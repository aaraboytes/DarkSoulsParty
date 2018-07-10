using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterBlock : MonoBehaviour {
	SpriteRenderer sprite;
	public string prefix;
	void Start(){
		sprite = GetComponent<SpriteRenderer> ();
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			Player p = other.GetComponent<Player>();
			prefix = p.prefixInput;
			PainterManager._instance.AddBlock (transform);
			switch (prefix) {
			case "P1.":
				sprite.color = Color.red;
				break;
			case "P2.":
				sprite.color = Color.blue;
				break;
			case "P3.":
				sprite.color = Color.green;
				break;
			case "P4.":
				sprite.color = Color.yellow;
				break;
			default:
				sprite.color = Color.red;
				break;
			}
		}
	}
}
