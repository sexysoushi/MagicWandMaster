using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(Text))]
public class InstructionGUI : MonoBehaviour {
	private Text textField;

	public List<GameObject> colorList;
	private int currColor;
	private int timer = 0;
	public Camera cam;

	void Awake() {
		textField = GetComponent<Text>();
	}

	void Start() {
		if (cam == null) {
			cam = Camera.main;
		}

		if (cam != null) {
			// Tie this to the camera, and do not keep the local orientation.
			transform.SetParent(cam.GetComponent<Transform>(), true);
		}

		currColor = 1;
		foreach(GameObject color in colorList)
		{
			color.SetActive (false);
		}
		colorList[currColor].SetActive (true);
	}

	private void ChangeColor (int t)
	{

		colorList[currColor].SetActive (false);
		currColor = currColor + t;

		if(currColor < 0)
		{
			currColor = colorList.Count -1;
		}
		else if(currColor > (colorList.Count -1))
		{
			currColor = 0;
		}
		else
		{
			currColor = currColor;
		}

		colorList[currColor].SetActive (true);

	}

	void LateUpdate() {

		timer++;
		if(timer > 500)
		{
			ChangeColor (1);
			timer = 0;
		}


		textField.text = "Catch the fairy with \nyour special wand and follow \nit with the right color. \n\nColor : ";

//		textField.text = string.Format(DISPLAY_TEXT_FORMAT,
//			msf.ToString(MSF_FORMAT), Mathf.RoundToInt(fps));
	}
}