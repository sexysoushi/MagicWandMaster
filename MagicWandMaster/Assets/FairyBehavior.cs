using UnityEngine;
using System.Collections;

public class FairyBehavior : MonoBehaviour {

	float timer = -50.0f;
	bool move = false;


	// Update is called once per frame
	void Update () {
		this.transform.Rotate(Vector3.up * Time.deltaTime* 500.0f);

		timer++;

		if(timer > 50.0f)
		{
			timer = -50.0f;
		}

		if (timer > 0.0f) {
			move = true;
		}
		else
			move = false;


			
		if(move)
		{
			this.transform.Translate(-Vector3.up * Time.deltaTime);
		}
		else
			this.transform.Translate(Vector3.up * Time.deltaTime);
	}
}
