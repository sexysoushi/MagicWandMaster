using UnityEngine;
using System.Collections;

public class FairyBehavior : MonoBehaviour {

	float timer = -80.0f;
	bool move = true;


	// Update is called once per frame
	void Update () {
		//this.transform.Rotate(Vector3.up * Time.deltaTime* 700.0f);

		timer++;

		if(timer > 80.0f)
		{
			timer = -80.0f;
		}

		if (timer > 0.0f) {
			move = true;
		}
		else
			move = false;


			
		if (move) {
			this.transform.Translate (-Vector3.up * Time.deltaTime);

		} else {
			this.transform.Translate(Vector3.up * Time.deltaTime);
			this.transform.Rotate (Vector3.up * Time.deltaTime * 700.0f);

		}
			
	}
}
