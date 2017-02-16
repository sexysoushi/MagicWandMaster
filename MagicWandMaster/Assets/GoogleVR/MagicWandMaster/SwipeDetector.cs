using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Code inspiration from : blog.trsquarelab.com
 * 
 */


public class SwipeDetector : MonoBehaviour {

	public GameObject wand_main;
	public GameObject wand_1;
	public GameObject wand_2;
	public GameObject wand_3;
	public GameObject wand_4;

	private List<GameObject> wandList;
	public static int currWand;

	    private const int mMessageWidth  = 200;
	    private const int mMessageHeight = 64;
	 
	    private readonly Vector2 mXAxis = new Vector2(1, 0);
	    private readonly Vector2 mYAxis = new Vector2(0, 1);
	 
	    private readonly string [] mMessage = {
		        "",
		        "Swipe Left",
		        "Swipe Right",
		        "Swipe Top",
		        "Swipe Bottom"
		    };
	 
	    private int mMessageIndex = 0;
	 
	    // The angle range for detecting swipe
	    private const float mAngleRange = 30;
	 
	    // To recognize as swipe user should at lease swipe for this many pixels
	    private const float mMinSwipeDist = 0.6f;
	 
		private Vector2 iniTouchPos;
		private bool wasTouching;

	 
	    // Use this for initialization
	    void Start () {

		wandList = new List<GameObject> ();

		wandList.Add (wand_main);
		wandList.Add (wand_1);
		wandList.Add (wand_2);
		wandList.Add (wand_3);
		wandList.Add (wand_4);

		foreach(GameObject w in wandList)
		{
			w.SetActive (false);
		}

		currWand = 0;
		wandList[currWand].SetActive (true);



			if (GvrArmModel.Instance != null) {
				GvrArmModel.Instance.OnArmModelUpdate += OnArmModelUpdate;
			} else {
				Debug.LogError("Unable to find GvrArmModel.");
			}
	    }


	void OnDestroy() {
		if (GvrArmModel.Instance != null) {
			GvrArmModel.Instance.OnArmModelUpdate -= OnArmModelUpdate;
		}
	}



	private void OnArmModelUpdate() {

		if (GvrController.IsTouching) {
			// Reset the elapsedScaleTime when we start touching.
			// This flag is necessary because
			// GvrController.TouchDown sometimes becomes true a frame after GvrController.Istouching
			if (!wasTouching) {
				wasTouching = true;

				iniTouchPos = GvrController.TouchPos;
			} else {


				Vector2 endPosition = GvrController.TouchPos;
				Vector2 swipeVector = endPosition - iniTouchPos;

				//Debug.Log ("Vector magnitude : " + swipeVector.magnitude);

				if (swipeVector.magnitude > mMinSwipeDist) {
					// if the swipe has enough velocity and enough distance

					swipeVector.Normalize();

					float angleOfSwipe = Vector2.Dot(swipeVector, mXAxis);
					angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;


					//Debug.Log ("BARBARA  angleOfSwipe : " + angleOfSwipe);


					// Detect left and right swipe
					if (angleOfSwipe < mAngleRange) {
						//OnSwipeRight();
						OnSwipe (1);
						wasTouching = false;
						return;
					} else if ((180.0f - angleOfSwipe) < mAngleRange) {
						//OnSwipeLeft();
						OnSwipe (-1);
						wasTouching = false;
						return;
					} else {
						OnSwipe (0);
						wasTouching = false;
						return;
					}
					/*
					else {
						// Detect top and bottom swipe
						angleOfSwipe = Vector2.Dot(swipeVector, mYAxis);
						angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;
						if (angleOfSwipe < mAngleRange) {
							OnSwipeTop();
						} else if ((180.0f - angleOfSwipe) < mAngleRange) {
							OnSwipeBottom();
						} else {
							mMessageIndex = 0;
						}
					}
					*/
				}
			}

		} else {
			// Reset the elapsedScaleTime when we stop touching.
			// This flag is necessary because
			// GvrController.TouchDown sometimes becomes true a frame after GvrController.Istouching
			if (wasTouching) {
				wasTouching = false;
			}
		}
	}

	private void OnSwipe (int t)
	{
		//Debug.Log ("BARBARA  taille list" + wandList.Count);
		wandList[currWand].SetActive (false);
		currWand = currWand + t;
		Debug.Log ("BARBARA  before prosses" + currWand);
		if(currWand < 0)
		{
			currWand = wandList.Count -1;
		}
		else if(currWand > (wandList.Count -1))
		{
			currWand = 0;
		}
		else
		{
			currWand = currWand;
		}
		Debug.Log ("BARBARA  after prosses" + currWand);
		wandList[currWand].SetActive (true);

	}
}