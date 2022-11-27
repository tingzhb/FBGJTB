using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Make3DInvisible : MonoBehaviour
{
	private Renderer renderer;
	private Material originalMat;
	[SerializeField] private Material invisibleMat;
	[SerializeField] private bool isRight;

	void OnEnable()
	{
		renderer = GetComponent<Renderer>();
		originalMat = renderer.material;
		Broker.Subscribe<PickupMessage>(OnPickupMessageReceived);
	}

	private void OnPickupMessageReceived(PickupMessage obj){
		if (obj.PickUpNumber == 5 && obj.PickupPlayerIsRight && !isRight){
			renderer.material = invisibleMat;
			StartCoroutine(ResetVisibility(obj.PickUpDuration));
		}
		if (obj.PickUpNumber == 5 && !obj.PickupPlayerIsRight && isRight){
			renderer.material = invisibleMat;
			StartCoroutine(ResetVisibility(obj.PickUpDuration));
		}
	}

	private IEnumerator ResetVisibility(float duration){
		yield return new WaitForSeconds(duration);
		renderer.material = originalMat;
	}
}
