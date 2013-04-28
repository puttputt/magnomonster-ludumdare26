using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour 
{
	[SerializeField]
	private GameObject explosion;
	
	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Player")
		{
			this.Explode();
		}
	}
	
	private void Explode()
	{
		GameObject.Instantiate(
			this.explosion,
			this.transform.position,
			Quaternion.identity
			);
		Destroy(this.gameObject);
	}
}
