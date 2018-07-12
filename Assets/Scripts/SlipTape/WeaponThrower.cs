using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrower : MonoBehaviour {
	[SerializeField]
	Pool axesPool;
	[SerializeField]
	Pool swordsPool;
	public float speed,distance,timeForDrop;
	float timer = 0;
	float sinVar = 0;
	void Update () {
		//Movement
		sinVar += Time.deltaTime * speed;
		//Dropping time
		timer+=Time.deltaTime;
		GameObject weapon = null;
		if (timer > timeForDrop) {
			float randomSelection = Random.Range (0.0f, 1.0f);
			Debug.Log (randomSelection);
			if (randomSelection>0.5f) {
				weapon = axesPool.Recycle (transform.position, Quaternion.Euler (Vector3.forward * Random.Range (0, 360)));
			} else {
				weapon = swordsPool.Recycle (transform.position, Quaternion.Euler (Vector3.forward * Random.Range (0, 360)));
			}
			Rigidbody2D weaponBody = weapon.GetComponent<Rigidbody2D> ();
			if(weaponBody!=null)
				weaponBody.velocity = Vector3.zero;
			timer = 0;
		}
	}
	void FixedUpdate(){
		float movement = Mathf.Sin (sinVar);
		transform.position = new Vector3 (movement * distance, transform.position.y, 0);
	}
}
