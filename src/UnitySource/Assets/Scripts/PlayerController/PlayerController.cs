using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public BoxCollider2D edge;
	public SpriteRenderer spriteRender;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	

		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");

		if(Input.GetKey(KeyCode.A))
		{
			animator.SetInteger("Direction", 1);
			OnMove(Vector3.left);
		}
		else if(Input.GetKey(KeyCode.D))
		{
			animator.SetInteger("Direction", 3);
			OnMove(Vector3.right);
		}else if(Input.GetKey(KeyCode.W))
		{
			animator.SetInteger("Direction", 2);
			OnMove(Vector3.up);
		}else if(Input.GetKey(KeyCode.S))
		{
			animator.SetInteger("Direction", 0);
			OnMove(Vector3.down);
		}

//		if(ver > 0)
//		{
//			animator.SetInteger("Direction", 2);
//			//OnMove(Vector3.right);
//		}else if(ver < 0)
//		{
//			animator.SetInteger("Direction", 0);
//			OnMove(Vector3.left);
//		}
//		else if(hor < 0)
//		{
//			animator.SetInteger("Direction", 1);
//			//OnMove(Vector3.down);
//		}else if(hor > 0)
//		{
//			animator.SetInteger("Direction", 3);
//			//OnMove(Vector3.up);
//		}
	}

	void OnMove(Vector3 dir)
	{	
		Vector3 newPos = dir * 4 * Time.deltaTime;
		newPos += transform.position;
//		this.transform.position += (dir * 4 * Time.deltaTime);
		Vector3 pos = Camera.main.WorldToViewportPoint(newPos);
		float offetX = spriteRender.sprite.bounds.size.x *10;
	
		float x = Mathf.Clamp(pos.x, 0.0f, 1.0f - offetX);
		Debug.LogError(x);
		float y =  Mathf.Clamp(pos.y, 0.0f, 1.0f);
		pos = new Vector3(x, y, pos.z);
		Vector3 worldPos =  Camera.main.ViewportToWorldPoint(pos);
		transform.position = worldPos;

	}
}
