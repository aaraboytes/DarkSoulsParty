using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReflectorMove : MonoBehaviour {
	float sinMove;
	public float speed;
	
	// Update is called once per frame
	void Update () {
		sinMove += Time.deltaTime;
		transform.rotation = Quaternion.Euler (0, 0, Mathf.Sin (sinMove) * speed);
	}
}
