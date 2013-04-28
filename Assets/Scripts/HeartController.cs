using UnityEngine;
using System.Collections;

public class HeartController : MonoBehaviour 
{
	[SerializeField]
	private ParticleSystem heartParticles;
	
	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Player")
		{
			this.HeartCollide();
		}
	}
	
	private void HeartCollide()
	{
		GameObject.Instantiate(this.heartParticles, this.transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}
}
