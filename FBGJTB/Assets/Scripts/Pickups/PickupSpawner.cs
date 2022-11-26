using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickupSpawner : MonoBehaviour{
	[SerializeField] private GameObject[] spawnPoints;
	[SerializeField] private GameObject[] pickupVariants;

	private void OnEnable(){
		Broker.Subscribe<PickupMessage>(OnNewPickupMessageReceived);
		SpawnObject();
	}
	
	private void OnDisable(){
		Broker.Unsubscribe<PickupMessage>(OnNewPickupMessageReceived);
	}
	private void OnNewPickupMessageReceived(PickupMessage obj){
		Debug.Log("Message");
		SpawnObject();
	}
	
	private void SpawnObject(){
		var randomPickup = Random.Range(0, pickupVariants.Length);
		var randomSpawn = Random.Range(0, spawnPoints.Length);
		Instantiate(pickupVariants[randomPickup], spawnPoints[randomSpawn].transform.position, Quaternion.identity);
	}
}
