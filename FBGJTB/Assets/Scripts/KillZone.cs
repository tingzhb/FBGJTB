using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Player")){
			other.gameObject.GetComponentInParent<PlayerHP>().Damage(3, false);
		}
	}
}
