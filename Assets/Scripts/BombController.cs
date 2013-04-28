using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour 
{
	
	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Player")
		{
			Debug.Log("BOMB DETONATED");	
		}
	}
}
