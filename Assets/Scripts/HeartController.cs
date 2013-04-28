using UnityEngine;
using System.Collections;

public class HeartController : MonoBehaviour 
{
	[SerializeField]
	private ParticleSystem heartParticles;
	
	private LevelController levelController;
	
	private void Awake()
	{
		this.levelController = GameObject.Find("World").GetComponent<LevelController>();
	}
	
	private void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == "Player")
		{
			this.HeartCollide();
		}
		else if(c.gameObject.tag == "Bomb")
		{
			this.levelController.HeartDestroyed();
			Destroy(this.gameObject);
		}
	}
	
	private void HeartCollide()
	{
		GameObject.Instantiate(this.heartParticles, this.transform.position, Quaternion.identity);
		this.levelController.HeartCollected();
		Destroy(this.gameObject);
	}
}
