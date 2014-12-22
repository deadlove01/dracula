using UnityEngine;
using System.Collections;

public class ChangeBackGround : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		if(sr==null) return;
		
		transform.localScale=new Vector3(1,1,1);
		
		float width=sr.sprite.bounds.size.x;
		float height=sr.sprite.bounds.size.y;
		
		
		float worldScreenHeight=Camera.main.orthographicSize*2f;
		float worldScreenWidth=worldScreenHeight/Screen.height*Screen.width;
		
		transform.localScale = new Vector3(
			worldScreenWidth / sr.sprite.bounds.size.x,
			worldScreenHeight / sr.sprite.bounds.size.y, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
