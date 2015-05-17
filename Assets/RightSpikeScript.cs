using UnityEngine;
using System.Collections;

public class RightSpikeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (transform.position.x > 3.7f)
		{
			transform.position = new Vector2 (transform.position.x - 0.05f, transform.position.y);
			if(transform.position.x <3.7f){transform.position = new Vector2 (3.7f, transform.position.y); }
		}

	}
}
