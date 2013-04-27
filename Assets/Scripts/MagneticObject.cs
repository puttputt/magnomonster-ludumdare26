using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagneticObject : MonoBehaviour {
	
	public bool PositivePolarity { get; private set; }
	
	private Animation animation;
	private List<string> animations = new List<string>();
	
	private bool playerPositivePolarity;
	private GameObject collider;
	private CharacterController player;
	
	void Awake ()
	{
		this.PositivePolarity = true;
		this.animation = this.GetComponent<Animation>();
		
		foreach(AnimationState state in this.animation)
		{
			this.animations.Add(state.name);	
		}
	}

	void FixedUpdate () 
	{
		if(this.player != null)	
		{
			this.playerPositivePolarity = collider.GetComponent<Polarity>().PositivePolarity;
			Debug.Log("DO STUFF");
			
			//Offset player position so its closes to the top horns
			Vector3 playerPosition = this.player.transform.position + new Vector3(0,5,0);
			
			float distance = Vector3.Distance(this.transform.position, playerPosition);
			
			if(this.PositivePolarity != this.playerPositivePolarity)
			{
				Debug.Log("OPP");
				//ATTRACT
				this.transform.position = Vector3.MoveTowards(
					this.transform.position, 
					playerPosition, 
					Time.deltaTime * 10.0f / (distance / 5.0f)
					);
			}
			else
			{
				//PUSH AWAY
				Debug.Log("EQUAL");
				
				//Find away point
				float dx = this.transform.position.x - playerPosition.x;
				float dy = this.transform.position.y - playerPosition.y;
				
				float k = Mathf.Sqrt(distance*distance / (dx*dx + dy*dy));
				
				float x3 = this.transform.position.x + dx * k;
				float y3 = this.transform.position.y + dy * k;
				
				Vector3 newPos = new Vector3(x3, y3, 0);
				
				this.transform.position = Vector3.MoveTowards(
					this.transform.position,
					newPos,
					Time.deltaTime * 10.0f/ (distance / 5.0f )
					);
			}
		}
		
		//Make sure its still on the z plane and is not floating
		this.transform.position = new Vector3(
			this.transform.position.x, 
			this.transform.position.y, 
			0f);
	}
	
	public void ShiftPolarity()
	{
		if(this.PositivePolarity)
			this.PositivePolarity = false;
		else
			this.PositivePolarity = true;
		
		this.Animate();
	}
	
	private void Animate()
	{
		if(this.PositivePolarity)
		{
			this.animation.Play(this.animations[0]);
		}
		else
		{
			this.animation.Play(this.animations[1]);
		}
	}
	
	void OnTriggerEnter(Collider c)
	{
		Debug.Log("ENTER");
		this.player = c.GetComponent<Polarity>().controller;
		this.collider = c.gameObject;
	}
	
	void OnTriggerExit(Collider c)
	{
		this.player = null;
	}

}
