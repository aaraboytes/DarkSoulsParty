using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraEffects : MonoBehaviour {
	public static CameraEffects _instance;
	Transform target;
	public float offset;
	public GameObject winnerText;
	void Awake(){
		_instance = this;
	}
	void Start(){
		winnerText = GameObject.FindGameObjectWithTag ("WinnerText");
		winnerText.gameObject.SetActive (false);
		Time.timeScale = 1;
	}
	public void FocusOnWinner(Transform player){
		Time.timeScale = 0;
		transform.position = player.position - (Vector3.forward * offset); 
		winnerText.GetComponent<Text>().text = player.GetComponent<Player> ().prefixInput + " wins";
		winnerText.gameObject.SetActive (true);
	}
}
