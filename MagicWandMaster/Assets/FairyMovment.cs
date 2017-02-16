using UnityEngine;
using System.Collections;

public class FairyMovment : MonoBehaviour {

	int timer = 0;
	bool move = true;
	private float degree;

	void Start()
	{
		degree = 90.0f;
	}


	// Update is called once per frame
	void Update () {
		
		timer++;
//
//		if(timer > Random.Range(300, 700))
//		{
//			timer = Random.Range(-300, -700);
//		}
//
//		if (timer > 0.0f) {
//			move = true;
//		}
//		else
//			move = false;


//		this.transform.rotation = Quaternion.Slerp);



//		if(this.transform.rotation.y < -90.0f)
//		{
//			this.transform.Rotate(Vector3.up * Time.deltaTime * 20.0f);
//		}
//
//		if(this.transform.rotation.y > 90.0f)
//		{
//			this.transform.Rotate(-Vector3.up * Time.deltaTime * 20.0f);
//		}


//		if(move)
//			this.transform.Rotate(Vector3.up * Time.deltaTime * 50.0f);
//		else
//			this.transform.Rotate(-Vector3.up * Time.deltaTime * 50.0f);
//
//		if (Input.GetKeyUp(KeyCode.RightArrow))
//			degree += 90f;
//		if (Input.GetKeyUp(KeyCode.LeftArrow))
//			degree -= 90f;


		if (timer > 100)
		{
			degree = Random.Range (-90.0f, 90.0f);
			timer = 0;
		}
		//angle = Mathf.LerpAngle(transform.rotation.z, degree, Time.deltaTime);
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, degree, 0), Time.deltaTime * 0.1f);
	}


}
