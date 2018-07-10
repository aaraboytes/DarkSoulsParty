using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitCatcher : MonoBehaviour {
	[SerializeField]
	Pool effectsPool;
	int fruitsCounter;
	string sceneName;
	void Update(){
		if (fruitsCounter == 25) {
			SceneManager.LoadScene (sceneName);
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("item")) {
			fruitsCounter++;
			//effectsPool.Recycle (transform.position, Quaternion.identity);
			GameManager._instance.IncreaseScore (1, this.GetComponent<Player> ().prefixInput);
			FruitManager._instance.incrementCounter (this.GetComponent<Player> ().prefixInput);
			other.gameObject.SetActive (false);
		}
	}	
}
