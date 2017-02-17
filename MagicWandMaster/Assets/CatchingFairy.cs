using UnityEngine;
using System.Collections;

public class CatchingFairy : MonoBehaviour {

	public GameObject projectil;
	public GameObject reticle;
	private GameObject proj;
	private bool wasClicking;

	// Use this for initialization
	void Start () {
	}

	void CreateOrb()
	{
		proj = (GameObject)Instantiate (projectil, projectil.transform.position, Quaternion.identity);
		proj.AddComponent<Rigidbody> ();
		proj.GetComponent<Rigidbody> ().useGravity = false;


	void ThrowProjectil()
	{
		Vector3 direction = reticle.transform.position - this.transform.position;
			proj.GetComponent<Rigidbody> ().AddForce (direction, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {

		if (GvrController.ClickButtonDown) {
			if (!wasClicking) {
				wasClicking = true;
				CreateOrb ();
			} else {
				ThrowProjectil ();
			}
		}else {
			if (wasClicking) {
				wasClicking = false;
			}
		}
	
	}
}
