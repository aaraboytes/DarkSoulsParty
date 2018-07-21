using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraEffects3D : MonoBehaviour {
	public static CameraEffects3D _instance;
	Transform target = null;
	public float yOffset;
	public float zOffset;
	public float speed;
	public GameObject winnerText;

	void Awake(){
		if (_instance == null)
			_instance = this;
	}
	void Start(){
		winnerText = GameObject.FindGameObjectWithTag ("WinnerText");
		winnerText.gameObject.SetActive (false);
	}
	void Update(){
		if (target != null) {
			transform.position = Vector3.Lerp (transform.position, target.position + new Vector3(0.0f,yOffset,zOffset), speed);
			winnerText.GetComponent<Text>().text = target.GetComponent<BallController> ().prefixInput + " wins";
			winnerText.gameObject.SetActive (true);
		}
	}
	public void setTarget(Transform _target){
		Debug.Log ("Player setted");
		target = _target;
	}
}
