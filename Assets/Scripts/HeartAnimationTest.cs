using UnityEngine;
using System.Collections;

public class HeartAnimationTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			this.GetComponent<MagneticObject>().ShiftPolarity();
		}
	
	}
}
