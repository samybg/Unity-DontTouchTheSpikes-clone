﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	bool jumpDirectionIsRight = false;
	bool[] spikeArrayLeft = new bool[16]; 
	bool[] spikeArrayRight = new bool[16];
	Vector3[] leftSpikePosition = new Vector3[16]; 
	Vector3[] rightSpikePosition = new Vector3[16]; 
	public GameObject leftSpike;
	public GameObject rightSpike;
	public static int score = 0;
	GameObject[] leftSpikes = new GameObject[16];
	GameObject[] rightSpikes = new GameObject[16];
	int spikeNumber;

	public Sprite one;
	public Sprite two;
	public Sprite three;
	public Sprite four;
	public Sprite five;
	public Sprite six;
	public Sprite seven;
	public Sprite eight;
	public Sprite nine;
	public Sprite zero;

	public SpriteRenderer leftNumberRend;
	public SpriteRenderer rightNumberRend;

	public GameObject LeftNumber; //= Resources.Load("fruits_1", typeof(Sprite)) as Sprite;
	public GameObject RightNumber; 

	bool isAlive = true;
	//bool gameIsStarted = false;



	void Start () 
	{

		for (int i = 0; i < 16; i++) 
		{
			leftSpikePosition[i] = new Vector3(-4f, 4f - i*0.6f ,0);
		}
		for (int i = 0; i < 16; i++) 
		{
			rightSpikePosition[i] = new Vector3(4f, 4f - i*0.6f ,0);
		}







		//Rigidbody2D clone;
		//clone = Instantiate (leftSpike, new Vector3 (0, 0, 0), Quaternion.identity)as Rigidbody2D;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown(KeyCode.W) && isAlive == true)
		{
			Jump();
		}
		if (Input.GetKeyDown(KeyCode.R) && isAlive == false)
		{
			Respawn();
		} 

		UpdateScoreboard ();
	}



	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.name =="wall1"&& isAlive ==true || other.name =="wall2" && isAlive ==true)
		{
			jumpDirectionIsRight = !jumpDirectionIsRight;

		if (jumpDirectionIsRight)     //lqva stena
		{
				score++;
				if(score >= 0 && score<=2){spikeNumber = 2;}
				else if(score >2 && score <=5){spikeNumber = 3;}
				else if(score >5 && score <=9){spikeNumber = 4;}
				else if(score >9 && score <=15){spikeNumber = 6;}
				else if(score >15 && score <=22){spikeNumber = 8;}
				else if(score >22 && score <=29){spikeNumber = 10;}
				else if(score >29 && score <=34){spikeNumber = 12;}


				FillSpikes(spikeArrayRight,spikeNumber);
				SpawnSpikesRight(spikeArrayRight);
				ClearArray(spikeArrayRight);
				DespawnSpikes(leftSpikes);
		}
		else
		{
				score++;
				if(score >= 0 && score<=2){spikeNumber = 2;}
				else if(score >2 && score <=5){spikeNumber = 3;}
				else if(score >5 && score <=9){spikeNumber = 4;}
				else if(score >9 && score <=15){spikeNumber = 6;}
				else if(score >15 && score <=22){spikeNumber = 8;}
				else if(score >22 && score <=29){spikeNumber = 10;}
				else if(score >29 && score <=34){spikeNumber = 12;}


			FillSpikes(spikeArrayLeft,spikeNumber); //dqsna stena
			SpawnSpikesLeft(spikeArrayLeft);
			ClearArray(spikeArrayLeft);
			DespawnSpikes(rightSpikes);
		}
		}

		if (other.name == "topspikes" || other.name == "botspikes" || other.name == "RightSpike(Clone)" || other.name == "LeftSpike(Clone)" && isAlive==true) 
		{
			if(other.name == "RightSpike(Clone)")
			{
				rigidbody2D.AddForce(new Vector2(gameObject.transform.position.x-1000,gameObject.transform.position.y-1000));
			}
			if(other.name == "LeftSpike(Clone)")
			{
				rigidbody2D.AddForce(new Vector2(gameObject.transform.position.x+500,gameObject.transform.position.y-1000));
			}

			Death();
			Debug.Log("spikes!");
		}


		//rigidbody2D.velocity = Vector2.zero;
	}


	void Jump()
	{
		if (jumpDirectionIsRight) 
		{
			JumpRight();
		} 
		else 
		{
			JumpLeft();
		}
	}

	void JumpRight() 
	{
		rigidbody2D.velocity = Vector2.zero;
		Vector2 jump = new Vector2 (rigidbody2D.transform.position.x+200,rigidbody2D.transform.position.y+340);
		//Vector2 slowX = new Vector2 (rigidbody2D.transform.position.x-100,rigidbody2D.transform.position.y);
		if (rigidbody2D.velocity.y < 10) 
		{
			rigidbody2D.AddForce (jump);
		}
		if (rigidbody2D.velocity.x > 2) 
		{
			//rigidbody2D.AddForce(slowX);
		}


		
	}



	void JumpLeft()
	{
		rigidbody2D.velocity = Vector2.zero;
		Vector2 jump = new Vector2 (rigidbody2D.transform.position.x-200,rigidbody2D.transform.position.y+340);
		//Vector2 slowX = new Vector2 (rigidbody2D.transform.position.x+200,rigidbody2D.transform.position.y);
		if (rigidbody2D.velocity.y < 10) 
		{
			rigidbody2D.AddForce (jump);
		}
		if (rigidbody2D.velocity.x < -4 ) 
		{
			//rigidbody2D.AddForce(slowX);
		}
	}

	void ClearArray(bool[] array)
	{
		for (int i = 0; i< array.Length; i++)
		{
			array[i] = false;
		}
	}

	 void FillSpikes(bool[] array, int spikeCount)
		{
		int randomPosition = 0;
		int spikesFilled = 0;
		while (spikesFilled < spikeCount)
		{
			randomPosition = Random.Range(0, array.Length);            //new Random.Next Range(0, spikeCount - 1);
			if (array[randomPosition] == false)
			{
				array[randomPosition] = true;
				spikesFilled++;
			}
		}
	}

	void SpawnSpikesLeft(bool[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			if(array[i])
			{
				leftSpikes[i] = Instantiate (leftSpike, leftSpikePosition[i], Quaternion.identity)as GameObject;
			}

		}
	}
	void SpawnSpikesRight(bool[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			if(array[i])
			{
				rightSpikes[i] = Instantiate (rightSpike, rightSpikePosition[i], Quaternion.identity)as GameObject;
			}
			
		}
	}

	void DespawnSpikes(GameObject[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			try
			{
				Destroy(array[i]);
			}
			catch{};

		}
	}

	void Death()
	{
		transform.rotation = Quaternion.Euler(0,0,120);
		isAlive = false;

	}

	void Respawn()
	{
		jumpDirectionIsRight = true;
		score = 0;
		rigidbody2D.angularVelocity = 0;
		float lockPos = 0;
		rigidbody2D.velocity = Vector3.zero;
		transform.rotation = Quaternion.Euler (lockPos, lockPos, lockPos);
		transform.localEulerAngles = new Vector3(0 ,0 ,0);


		DespawnSpikes (leftSpikes);DespawnSpikes (rightSpikes);
		transform.position = new Vector2 (0,1.00f);
		isAlive = true;

		leftNumberRend.sprite = zero;
		rightNumberRend.sprite = zero;

	}
	void OnGUI () 
	{
		GUILayout.BeginArea (new Rect (445, 450, 400, Screen.width / 2)); 

		GUILayout.BeginHorizontal ();
		GUILayout.Label (score.ToString ());

		GUILayout.EndHorizontal ();


		GUILayout.EndArea ();
		
              //GUI.Label (new Rect (450,450,100,50), "This is the text string for a Label Control");

	}


	void UpdateScoreboard()
	{

		if (score < 10) 
		{
			if(score == 1){rightNumberRend.sprite = one; }
			if(score == 2){rightNumberRend.sprite = two; }
			if(score == 3){rightNumberRend.sprite = three; }
			if(score == 4){rightNumberRend.sprite = four; }
			if(score == 5){rightNumberRend.sprite = five; }
			if(score == 6){rightNumberRend.sprite = six; }
			if(score == 7){rightNumberRend.sprite = seven; }
			if(score == 8){rightNumberRend.sprite = eight; }
			if(score == 9){rightNumberRend.sprite = nine; }
		}
		else 
		{
			int leftNumb = score / 10;
			int rightNumbt = score % 10;
			if(leftNumb == 1){leftNumberRend.sprite = one; }
			if(leftNumb == 2){leftNumberRend.sprite = two; }
			if(leftNumb == 3){leftNumberRend.sprite = three; }
			if(leftNumb == 4){leftNumberRend.sprite = four; }
			if(leftNumb == 5){leftNumberRend.sprite = five; }
			if(leftNumb == 6){leftNumberRend.sprite = six; }
			if(leftNumb == 7){leftNumberRend.sprite = seven; }
			if(leftNumb == 8){leftNumberRend.sprite = eight; }
			if(leftNumb == 9){leftNumberRend.sprite = nine; }
		
			if(rightNumbt == 0){rightNumberRend.sprite = zero; }
			if(rightNumbt == 1){rightNumberRend.sprite = one; }
			if(rightNumbt == 2){rightNumberRend.sprite = two; }
			if(rightNumbt == 3){rightNumberRend.sprite = three; }
			if(rightNumbt == 4){rightNumberRend.sprite = four; }
			if(rightNumbt == 5){rightNumberRend.sprite = five; }
			if(rightNumbt == 6){rightNumberRend.sprite = six; }
			if(rightNumbt == 7){rightNumberRend.sprite = seven; }
			if(rightNumbt == 8){rightNumberRend.sprite = eight; }
			if(rightNumbt == 9){rightNumberRend.sprite = nine; }
		
		
		
		
		
		
		
		
		}


	}





}
