using UnityEngine;
using System.Collections;

public class ChangeTarget : MonoBehaviour {

	public GameObject reticle;
	public GameObject player;

	private Vector3 newPosTarget;

	// Use this for initialization
	void Start () {
		newPosTarget = player.transform.position;
		this.transform.position = newPosTarget;
	}
	
	// Update is called once per frame
	void Update () {

		if (GvrController.ClickButton) {
			newPosTarget = reticle.transform.position;
			this.transform.position = newPosTarget;

		} else {
			newPosTarget = player.transform.position;
			this.transform.position = newPosTarget;
		}
	
	}
}
