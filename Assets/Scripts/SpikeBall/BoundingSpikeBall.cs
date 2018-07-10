using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingSpikeBall : MonoBehaviour {
	public float force;
	Rigidbody2D spikeBall;
	SpriteRenderer spriteBall;
	public float rotationSpeed;
	Vector3 dir;
	void Start () {
		spikeBall = GetComponent<Rigidbody2D> ();
		spriteBall = GetComponent<SpriteRenderer> ();
		spriteBall.transform.Rotate (Vector3.forward * Random.Range (0, 360));
		if (Random.Range (0, 1) > 0.5) {
			dir = Vector2.up * (Random.Range (0, 1) > 0.5 ? 1 : -1);
		} else {
			dir = Vector2.right * (Random.Range (0, 1) > 0.5 ? 1 : -1);
		}
	}
	bool forced = false;
	void Update () {
		if(!forced)
			spikeBall.AddForce(dir * force);
		forced = true;
		spriteBall.transform.Rotate (Vector3.forward * rotationSpeed * Time.deltaTime);
	}

}
