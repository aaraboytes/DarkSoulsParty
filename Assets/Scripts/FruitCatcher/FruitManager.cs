using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FruitManager : MonoBehaviour {
	public static FruitManager _instance;
	public float gameTime;
	float timer;
	public Text timerText;
	public string winnerScene;
	[SerializeField]
	int[] fruits;

	void Awake(){
		_instance = this;
	}
	void Start(){
		fruits = new int[5];
		GameManager._instance.setPlayersOnScene ();
	}
	void Update(){
		timer += Time.deltaTime;
		timerText.text = ((int)(gameTime - timer)).ToString ();
		if (timer > gameTime) {
			float max = 0;
			for (int i = 0; i < fruits.Length; i++) {
				if (fruits[i] > max) {
					max = fruits [i];
				}
			}
			for (int i = 0; i < fruits.Length; i++) {
				if (fruits [i] == max) {
					switch (i) {
					case 0:
						GameManager._instance.SetLastWinner ("P1.");
						break;
					case 1:
						GameManager._instance.SetLastWinner ("P2.");
						break;
					case 2:
						GameManager._instance.SetLastWinner ("P3.");
						break;
					case 3:
						GameManager._instance.SetLastWinner ("P4.");
						break;
					default:
						GameManager._instance.SetLastWinner ("");
						break;
					}
				}
			}
			SceneManager.LoadScene (winnerScene);
		}
	}
	public void incrementCounter(string player){
		switch (player) {
		case "P1.":
			fruits[0]++;
			break;
		case "P2.":
			fruits[1]++;
			break;
		case "P3.":
			fruits[2]++;
			break;
		case "P4.":
			fruits[3]++;
			break;
		default:
			fruits[4]++;
			break;
		}
	}
	public float getRemainingTime(){
		return gameTime - timer;
	}
}
