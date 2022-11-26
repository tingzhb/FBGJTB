using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInterference : MonoBehaviour{
	private float newRect = 10;
	private Camera camera;
	private Rect originalRect;
	private bool isRight, farClip, rectAdjust;
	

	private void Awake(){
		isRight = GetComponentInParent<CharacterMovement>().isRight;
		camera = GetComponent<Camera>();
		Broker.Subscribe<PickupMessage>(OnNewPickupMessageReceived);
		originalRect = camera.rect;
	}

	private void OnDisable(){
		Broker.Unsubscribe<PickupMessage>(OnNewPickupMessageReceived);
	}
	private void OnNewPickupMessageReceived(PickupMessage obj){
		if (obj.PickUpNumber == 3 && obj.PickupPlayerIsRight && !isRight){
			farClip = true;
			StartCoroutine(ResetFarClip(obj.PickUpDuration));
		}
		if (obj.PickUpNumber == 3 && !obj.PickupPlayerIsRight && isRight){
			farClip = true;
			StartCoroutine(ResetFarClip(obj.PickUpDuration));
		}
		if (obj.PickUpNumber == 4 && obj.PickupPlayerIsRight && !isRight){
			rectAdjust = true;
			StartCoroutine(ResetRect(obj.PickUpDuration));
		}
		if (obj.PickUpNumber == 4 && !obj.PickupPlayerIsRight && isRight){
			rectAdjust = true;
			StartCoroutine(ResetRect(obj.PickUpDuration));
		}
	}

	private IEnumerator ResetFarClip(float duration){
		yield return new WaitForSeconds(duration);
		farClip = false;
		camera.farClipPlane = 1000;
	}

	private IEnumerator ResetRect(float duration){
		yield return new WaitForSeconds(duration);
		rectAdjust = false;
		camera.rect = originalRect;
	}
	private void Update(){
		if (farClip){
			camera.farClipPlane = Mathf.Lerp(0, 30, 30 * Time.deltaTime);
		}
		if (rectAdjust){
			newRect = Mathf.Lerp(250, 750, 30 * Time.deltaTime);
			camera.pixelRect = new Rect(newRect, newRect, newRect, newRect);
		}
	}
}
