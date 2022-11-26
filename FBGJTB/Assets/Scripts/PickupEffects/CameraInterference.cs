using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInterference : MonoBehaviour{
	[SerializeField] private float testVar;
	private Camera camera;
	private bool isRight, farClip;
	

	private void Awake(){
		isRight = GetComponentInParent<CharacterMovement>().isRight;
		camera = GetComponent<Camera>();
		Broker.Subscribe<PickupMessage>(OnNewPickupMessageReceived);
	}

	private void OnDisable(){
		Broker.Unsubscribe<PickupMessage>(OnNewPickupMessageReceived);
	}
	private void OnNewPickupMessageReceived(PickupMessage obj){
		if (obj.PickUpNumber == 3 && obj.PickupPlayerIsRight && !isRight){
			
		}
		if (!obj.PickupPlayerIsRight && isRight){
		}
	}

	private void Update(){
		camera.farClipPlane = Mathf.Lerp(0, 30, 30 * Time.deltaTime);
	}
}
