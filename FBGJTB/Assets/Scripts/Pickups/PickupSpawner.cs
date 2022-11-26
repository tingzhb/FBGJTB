using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickupSpawner : MonoBehaviour{
	[SerializeField] private GameObject[] spawnPoints;
	[SerializeField] private GameObject[] pickupVariants;
	private int totalSpawned;
	
	private void OnEnable(){
		Broker.Subscribe<PickupMessage>(OnNewPickupMessageReceived);
	}
	
	private void OnDisable(){
		Broker.Unsubscribe<PickupMessage>(OnNewPickupMessageReceived);
	}
	private void OnNewPickupMessageReceived(PickupMessage obj){
		totalSpawned--;
	}

	private void Update(){
		if (totalSpawned > 2)
			return;
		var randomSpawn = Random.Range(0, spawnPoints.Length);
		var randomPickup = Random.Range(0, pickupVariants.Length);
		Instantiate(pickupVariants[randomPickup], spawnPoints[randomSpawn].transform.position, Quaternion.identity);
		totalSpawned++;
	}
}
