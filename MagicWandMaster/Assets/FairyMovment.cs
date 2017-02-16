using UnityEngine;
using System.Collections;

public class FairyMovment : MonoBehaviour {

	int timer = -500;
	bool move = false;

	// Update is called once per frame
	void Update () {
		
		timer++;

		if(timer > Random.Range(300, 700))
		{
			timer = Random.Range(-300, -700);
		}

		if (timer > 0.0f) {
			move = true;
		}
		else
			move = false;



		if(move)
		{
			this.transform.Rotate(Vector3.up * Time.deltaTime * 50.0f);
		}
		else
			this.transform.Rotate(-Vector3.up * Time.deltaTime * 50.0f);

	}
}
