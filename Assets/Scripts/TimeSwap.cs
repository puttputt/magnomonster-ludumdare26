using UnityEngine;
using System.Collections;

public class TimeSwap : MonoBehaviour 
{
	[SerializeField]
	private float time = 3.0f;
	
	private float timer;
	
	private MagneticObject magneticObject;
	
	private void Awake () 
	{
		this.magneticObject = this.GetComponent<MagneticObject>();
		this.timer = this.time;
	}
	
	
	private void FixedUpdate () 
	{
		if(this.timer <= 0)
		{
			this.magneticObject.ShiftPolarity();
			this.timer = this.time;
		}
		else
		{
			this.timer -= Time.deltaTime;
		}
	}	
}
