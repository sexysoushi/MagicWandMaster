using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellsManager : MonoBehaviour {

	public List<GameObject> spellList;

	// Use this for initialization
	void Start () {
		DrawSpellRandomly ();
	}


	void DrawSpellRandomly()
	{
		GameObject sp = (GameObject)Instantiate (spellList[Random.Range (0, 3)], this.transform.position, Quaternion.identity);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
