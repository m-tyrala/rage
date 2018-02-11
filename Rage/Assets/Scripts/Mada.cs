using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mada : MonoBehaviour {
	private int health = 10;
	private int armor = 0;
	private float attackSpeed = 0.35f;
	private int attack = 1;
	private float lastAttackTimeStamp;

	// Use this for initialization
	void Start () {
		lastAttackTimeStamp = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool TakeDamage() {
		//TODO: blood Color("dd0404"), Color("590303")
		health = health - 1;
		if (health > 0) {
			GameObject.Find("/Sounds/SoundsManager").GetComponent<SoundsManager>().Play("hero/gethit");
			return false;
		} else {
			GameObject.Find("/Sounds/SoundsManager").GetComponent<SoundsManager>().Play("hero/die");
			return true;
		}
	}

	public bool Attack() {
		if (Time.time - lastAttackTimeStamp > attackSpeed) {
			if (attackSpeed > 0.1f) {
				attackSpeed = attackSpeed - 0.001f;
			}
			lastAttackTimeStamp = Time.time;

			GameObject.Find("/Sounds/SoundsManager").GetComponent<SoundsManager>().Play("hero/hit");
			
			return true;
		}
		else {
			return false;
		}
	}

	public int GetHealth() {
		return health;
	}
}
