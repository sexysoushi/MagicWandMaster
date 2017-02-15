using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawSpell : MonoBehaviour {

	public GameObject spell_0;
	public GameObject spell_1;
	public GameObject spell_2;
	public GameObject spell_3;
	public GameObject spell_4;

	public GameObject reticle;

	private List<GameObject> spellList;

	// Use this for initialization
	void Start () {
		spellList = new List<GameObject> ();



	}
	
	// Update is called once per frame
	void Update () {
		// Choose the appropriate material to render based on button states.
		if (GvrController.ClickButton) {
			GameObject sp;
			if(SwipeDetector.currWand == 0) //red
			{
				sp = (GameObject)Instantiate(spell_0, reticle.transform.position, Quaternion.identity);
			}

			if(SwipeDetector.currWand == 1) //yellow
			{
				sp = (GameObject)Instantiate(spell_1, reticle.transform.position, Quaternion.identity);
			}

			if(SwipeDetector.currWand == 2) //blue
			{
				sp = (GameObject)Instantiate(spell_2, reticle.transform.position, Quaternion.identity);
			}

			if(SwipeDetector.currWand == 3) //green
			{
				sp = (GameObject)Instantiate(spell_3, reticle.transform.position, Quaternion.identity);
			}

			if(SwipeDetector.currWand == 4) //purple
			{
				sp = (GameObject)Instantiate(spell_4, reticle.transform.position, Quaternion.identity);
			}

			spellList.Add (sp);


		} else {
			// Change material to reflect button presses.
			if (GvrController.AppButton) {
				foreach(GameObject go in spellList)
				{
					Destroy (go.gameObject);
				}
			} else if (GvrController.Recentering) {

			} else {

			}
		}
	
	}
}
