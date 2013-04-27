using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	
	
	private CharacterController controller;
	private Vector3 velocity = Vector3.zero;
	
	[SerializeField]
	public Polarity right;
	[SerializeField]
	public Polarity left;
	
	[SerializeField]
	private float speed = 1.5f;
	
	[SerializeField]
	private float max_speed = 8.0f;
	
	void Awake () 
	{
		this.controller = this.GetComponent<CharacterController>();
	}
	
	void Update () 
	{
		this.Move();
		this.PolarityShift();
		this.controller.Move(this.velocity *Time.smoothDeltaTime);
		
		this.transform.position = new Vector3(
			this.transform.position.x, 
			this.transform.position.y, 
			0f);
	}
	
	void Move()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		
		if(horizontal == 1)
		{
			if(this.velocity.x <= this.max_speed)
				this.velocity.x += this.speed;
		}
		else if (horizontal == -1)
		{
			if(this.velocity.x >= this.max_speed * -1)
				this.velocity.x -= this.speed;
		}
		else
		{
			this.velocity.x = 0;	
		}
		
		if(vertical == 1)
		{
			if(this.velocity.y <= this.max_speed)
				this.velocity.y += this.speed;
		}
		else if (vertical == -1)
		{
			if(this.velocity.y >= this.max_speed * -1)
				this.velocity.y -= this.speed;
		}
		else
		{
			this.velocity.y = 0;
		}
		
	}
	
	private void PolarityShift()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(this.right.PositivePolarity)
			{
				this.right.PositivePolarity = false;
				this.left.PositivePolarity = true;
			}
			else
			{
				this.right.PositivePolarity = true;
				this.left.PositivePolarity = false;
			}
		}
		
	}
}
