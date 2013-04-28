using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour 
{	
	private CharacterController controller;
	private Vector3 velocity = Vector3.zero;
	private Animation animation;
	
	private float prevHor;
	private float prevVert;
	
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
		this.animation = this.GetComponent<Animation>();
	}
	
	void FixedUpdate () 
	{
		this.Move();
		this.PolarityShift();
		this.controller.Move(this.velocity *Time.smoothDeltaTime);
		
		this.transform.position = new Vector3(
			this.transform.position.x, 
			this.transform.position.y, 
			0f);
	}
	
	void MoveAnimation()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		
		//ONLY MOVING RIGHT
		if(horizontal == 1 && vertical == 0)
		{
			//Moving Right from Left
			if(this.prevHor == -1)
			{
				Debug.Log("Swap");
				this.animation.animation.CrossFade("LeftToCenter");
				this.animation.animation.CrossFadeQueued("CenterToRight", 0f, QueueMode.CompleteOthers);
			}
			//Moving Right from Center
			else if(this.prevHor == 0)
			{
				this.animation.animation.CrossFade("CenterToRight");
			}
			
			//Moving Right from top
			if(this.prevVert == 1)
			{
				this.animation.animation.CrossFade("TopToRight");
			}
			
			//Moving right f rom Bottom
			else if(this.prevVert == -1)
			{
				this.animation.animation.CrossFade("BottomToRight");
			}
			
		}
		
		//ONLY MOVING LEFT
		else if(horizontal == -1 && vertical == 0)
		{
			//Moving Left from Right
			if(this.prevHor == 1)
			{
				this.animation.animation.CrossFade("RightToCenter");
				this.animation.animation.CrossFadeQueued("CenterToLeft", 0f, QueueMode.CompleteOthers);
			}
			//Moving Left from Center
			else if(this.prevHor ==0)
			{
				this.animation.animation.CrossFade("CenterToLeft");
			}
			
			//Moving Right from top
			if(this.prevVert == 1)
			{
				this.animation.animation.CrossFade("TopToLeft");
			}
			
			//Moving right f rom Bottom
			else if(this.prevVert == -1)
			{
				this.animation.animation.CrossFade("BottomToLeft");
			}
		}
		
		//ONLY MOVING UP
		else if(horizontal == 0 && vertical == 1)
		{
			//Moving Up from Bottom
			if(this.prevVert == -1)
			{
				this.animation.animation.CrossFade("BottomToCenter");
				this.animation.animation.CrossFadeQueued("CenterToTop", 0f, QueueMode.CompleteOthers);
			}
			//Moving Up from Center
			else if(this.prevVert == 0 )
			{
				this.animation.animation.CrossFade("CenterToTop");
			}
			
			//Moving Up from right
			if(this.prevHor == 1)
			{
				this.animation.animation["TopToRight"].speed = -1;
				this.animation.animation["TopToRight"].time = this.animation.animation["TopToRight"].length;
				this.animation.animation.CrossFade("TopToRight");
			}
			
			//Moving Up from Left
			else if(this.prevHor == -1)
			{
				this.animation.animation["TopToLeft"].speed = -1;
				this.animation.animation["TopToLeft"].time = this.animation.animation["TopToLeft"].length;
				this.animation.animation.CrossFade("TopToLeft");
			}
		}
		
		//ONLY MOVING DOWN
		else if(horizontal == 0 && vertical == -1)
		{
			//Moving Down from BTop
			if(this.prevVert == 1)
			{
				this.animation.animation.CrossFade("TopToCenter");
				this.animation.animation.CrossFadeQueued("CenterToBottom", 0f, QueueMode.CompleteOthers);
			}
			//Moving Up from Center
			else if(this.prevVert == 0 )
			{
				this.animation.animation.CrossFade("CenterToBottom");
			}
			
			//Moving Down from right
			if(this.prevHor == 1)
			{
				this.animation.animation["BottomToRight"].speed = -1;
				this.animation.animation["BottomToRight"].time = this.animation.animation["BottomToRight"].length;
				this.animation.animation.CrossFade("BottomToRight");
			}
			
			//Moving Down from Left
			else if(this.prevHor == -1)
			{
				this.animation.animation["BottomToLeft"].speed = -1;
				this.animation.animation["BottomToLeft"].time = this.animation.animation["BottomToLeft"].length;
				this.animation.animation.CrossFade("BottomToLeft");
			}
		}
		
		//No longer Moving
		else
		{
			//Previously going right, go to middle
			if(this.prevHor == 1)
			{
				this.animation.animation.CrossFade("RightToCenter");	
			}
			//Previously going left, go to middle
			else if(this.prevHor == -1)
			{
				this.animation.animation.CrossFade("LeftToCenter");	
			}
			
			//Previously going up, go to midddle
			if(this.prevVert == 1)
			{
				this.animation.animation.CrossFade("TopToCenter");	
			}
			//previously going down, go to middle
			else if (this.prevVert == -1)
			{
				this.animation.animation.CrossFade("BottomToCenter");	
			}
			
		}
		
	}
	
	void Move()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		
		this.MoveAnimation();
		
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
		
		this.prevHor = horizontal;
		this.prevVert = vertical;
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
