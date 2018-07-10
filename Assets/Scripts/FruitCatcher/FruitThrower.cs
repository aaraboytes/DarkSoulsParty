using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitThrower : MonoBehaviour {
	[SerializeField]
	Pool fruitsPool;
	public float speed,distance,timeForDrop;
	float currentTimer = 0;
	float sinVar = 0;
	void Update(){
		//Alteration
		if (FruitManager._instance.getRemainingTime() <= 10) {
			timeForDrop = timeForDrop / 2;
		}
		//Movement
		speed += Time.deltaTime;
		sinVar+=Time.deltaTime * speed;
		//Dropping timing
		currentTimer += Time.deltaTime;
		if (currentTimer > timeForDrop) {
			GameObject fruit = fruitsPool.Recycle (transform.position, Quaternion.identity);
			Rigidbody2D fruitBody = fruit.GetComponent<Rigidbody2D> ();
			fruitBody.velocity = Vector3.zero;
			currentTimer = 0;
		}
	}
	void FixedUpdate () {
		float movement = Mathf.Sin (sinVar);
		transform.position = new Vector3 (movement * distance, transform.position.y, 0);
	}
}
