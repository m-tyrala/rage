using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
	
	private string turn;
	private string kind;
	private Vector2 velocity;
	private float lastAttackTimeStamp = 0;
	private float speed;
	private float attackSpeed;
	private int health;
	
	
	public void set(
		ImagePosition positionNode, 
		Vector3 scale, 
		int enemyId, 
		string enemyKind, 
		float enemySpeed, 
		float enemyAttackSpeed, 
		int enemyHealth)
	{

		speed = enemySpeed;
		attackSpeed = enemyAttackSpeed;
		health = enemyHealth;
		kind = enemyKind;
		turn = positionNode.ToString();

		this.transform.localScale = scale;
		
		if (turn == "UpPosition")
			velocity = new Vector2(0, speed);
		else if (turn == "DownPosition")
			velocity = new Vector2(0, -speed);
		else if (turn == "LeftPosition") {
			velocity = new Vector2(speed, 0);
			transform.localScale = new Vector3(-scale[0], scale[1], scale[2]);
		}
		else if (turn == "RightPosition")
			velocity = new Vector2(-speed, 0);

		name = kind + enemyId;			
	}

	public bool checkPosition() {
		Transform madaTransform = GameObject.Find("/Game/Mada").transform;
		
		if (turn == "UpPosition") {
			return gameObject.transform.position[1] < madaTransform.position[1];
		} else if (turn == "DownPosition") {
			return gameObject.transform.position[1] > madaTransform.position[1];
		} else if (turn == "LeftPosition") {
			return gameObject.transform.position[0] < madaTransform.position[0];
		} else if (turn == "RightPosition") {
			return gameObject.transform.position[0] > madaTransform.position[0];
		}
		else {
			return false;
		}
	}

	public bool decreaseHealth(int hit) {
		health = health - hit;
		//var bloodNode = bloodClass.new(Color("2a9609"), Color("083502"), turn)
		GameObject.Find("/Sounds/SoundsManager").GetComponent<SoundsManager>().Play(kind, kind);
		//TODO destroy on
		return health > 0;
	}
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject mada = GameObject.Find("/Game/Mada");
		if (checkPosition()) {
			gameObject.transform.Translate(velocity * Time.deltaTime);
		}
		else {
			if (Time.time - lastAttackTimeStamp > attackSpeed && mada.GetComponent<Mada>().GetHealth() <= 0) {
				lastAttackTimeStamp = Time.time;
				GameObject.Find("/Sounds/SoundsManager").GetComponent<SoundsManager>().Play(kind, kind);
				mada.GetComponent<Mada>().TakeDamage();
			}
		}
	}
}
