using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour 
{
	[SerializeField]
	private float offset = 0.0f;
	
	[SerializeField]
	private float speed = 5.0f;
	
	[SerializeField]
	private bool VertMovement = true;
	
	private Vector3 apexOne;
	
	private Vector3 apexTwo;
	
	private bool atApexOne;

	private void Awake () 
	{
		if(!this.VertMovement)
		{
			this.apexOne = this.gameObject.transform.position + new Vector3(this.offset, 0f, 0f);
			this.apexTwo = this.gameObject.transform.position + new Vector3(-this.offset, 0f, 0f);
		}
		else
		{
			this.apexOne = this.gameObject.transform.position + new Vector3(0f, this.offset, 0f);
			this.apexTwo = this.gameObject.transform.position + new Vector3(0f, -this.offset, 0f);
		}
	}

	private void FixedUpdate () 
	{
		if(this.transform.position == this.apexOne)
		{
			this.atApexOne = true;
		}
		else if(this.transform.position == this.apexTwo)
		{
			this.atApexOne = false;	
		}
		
		if(!this.atApexOne)
		{
			this.transform.position = Vector3.MoveTowards(
				this.transform.position, 
				this.apexOne, 
				this.speed * Time.deltaTime
				);
		}
		else
		{
			this.transform.position = Vector3.MoveTowards(
				this.transform.position, 
				this.apexTwo, 
				this.speed * Time.deltaTime
				);
		}
	}
}
