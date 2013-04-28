using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

	[SerializeField]
	private List<GameObject> hearts = new List<GameObject>();
	
	private int totalHearts;
	private int heartsCollected;
	
	[SerializeField]
	private int thisLevelNumber;
	
	private bool playerAlive;
	
	private float timeout = 3.0f;
	
	private void Awake () 
	{
		this.totalHearts = hearts.Count;
		this.heartsCollected = 0;
		this.playerAlive = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(this.totalHearts == this.heartsCollected)
		{
			//Win
			Application.LoadLevel((this.thisLevelNumber + 1).ToString());
		}
		else if (!this.playerAlive)
		{
			if(this.timeout <= 0)
			{
				Application.LoadLevel(this.thisLevelNumber.ToString());
			}
			else
			{
				this.timeout -= Time.deltaTime;	
			}
		}
	
	}
	
	public void HeartCollected()
	{
		Debug.Log("collected");
		this.heartsCollected++;
	}
	
	public void HeartDestroyed()
	{
		Debug.Log("Heart Destroyed");
		this.playerAlive = false;
	}
	
	public void Explode()
	{
		Debug.Log("you lose");	
		this.playerAlive = false;
	}
}
