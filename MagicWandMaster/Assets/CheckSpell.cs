using UnityEngine;
using System.Collections;

public class CheckSpell : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		if(GvrController.ClickButton && c.gameObject.name == "Reticle")
		{
			Destroy (this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
