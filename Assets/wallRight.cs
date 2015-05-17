using UnityEngine;
using System.Collections;

public class wallRight : MonoBehaviour {
	
	bool directionIsUp = false;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (directionIsUp) 
		{
			transform.position = new Vector2 (transform.position.x, transform.position.y + 0.09f);
			if(transform.position.y > 2.13f){directionIsUp = false;}
		}
		else
		{
			transform.position = new Vector2 (transform.position.x, transform.position.y - 0.09f);
			if(transform.position.y < -2.13f){directionIsUp = true;}	
		}
	}
}
