using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

	[SerializeField]
	private List<GameObject> hearts = new List<GameObject>();
	
	[SerializeField]
	private UILabel heartLabel;
	
	[SerializeField]
	private UILabel levelLabel;
	
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
		
		this.levelLabel.text = "Level " + this.thisLevelNumber.ToString();
		this.SetHeartLabel(this.heartsCollected, this.totalHearts);
	}
	
	
	
	private void Update ()
	{
		if(this.totalHearts == this.heartsCollected && this.playerAlive)
		{
			if(this.timeout <=0)
			{
				if(this.thisLevelNumber == 9)
				{
					Application.LoadLevel("MainMenu");
				}
				else
				{
					Application.LoadLevel((this.thisLevelNumber + 1).ToString());
				}
			}
			else
			{
				this.timeout -= Time.deltaTime;	
			}
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
	
	private void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("MainMenu");	
		}
	}
	
	public void HeartCollected()
	{
		Debug.Log("collected");
		this.heartsCollected++;
		this.SetHeartLabel(this.heartsCollected, this.totalHearts);
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
	
	private void SetHeartLabel(int collected, int total)
	{
		this.heartLabel.text = "Love Collected: " + collected.ToString() + "/" + total.ToString();	
	}
}
