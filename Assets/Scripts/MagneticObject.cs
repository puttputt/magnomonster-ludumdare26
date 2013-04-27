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

	void Update () 
	{
		if(this.player != null)	
		{
			this.playerPositivePolarity = collider.GetComponent<Polarity>().PositivePolarity;
			Debug.Log("DO STUFF");
			if(this.PositivePolarity != this.playerPositivePolarity)
			{
				Debug.Log("OPP");
				//ATTRACT
				this.transform.Translate(this.player.transform.position * Time.deltaTime);
			}
			else
			{
				//PUSH AWAY
				Debug.Log("EQUAL");
				this.transform.Translate(this.player.transform.position * -1 * Time.deltaTime);
			}
		}
		
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
