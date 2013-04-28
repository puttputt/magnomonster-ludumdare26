using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour 
{
	[SerializeField]
	private GameObject explosion;
	
	private LevelController levelController;
	
	private void Awake()
	{
		this.levelController = GameObject.Find("World").GetComponent<LevelController>();	
	}
	
	private void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == "Player" || c.gameObject.tag == "Heart")
		{
			this.Explode(c.gameObject);
		}
	}
	
	private void Explode(GameObject collidedObject)
	{
		GameObject.Instantiate(
			this.explosion,
			this.transform.position,
			Quaternion.identity
			);
		
		this.levelController.Explode();
		
		Destroy(collidedObject);
		Destroy(this.gameObject);
	}
}
