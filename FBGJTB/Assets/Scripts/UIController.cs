using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour{
	[SerializeField] private TextMeshProUGUI kills, deaths, pickup;
	[SerializeField] private int playerNumber;

	private void Awake(){
		Broker.Subscribe<UIChangeMessage>(OnUIChangedMessageReceived);
		Broker.Subscribe<PickupMessage>(OnNewPickupMessageReceived);
	}

	private void OnDisable(){
		Broker.Unsubscribe<UIChangeMessage>(OnUIChangedMessageReceived);
		Broker.Unsubscribe<PickupMessage>(OnNewPickupMessageReceived);
	}
	private void OnNewPickupMessageReceived(PickupMessage obj){
		if (obj.PickupPlayerIsRight && playerNumber == 0){
			pickup.text = obj.PickupName;
			StartCoroutine(ResetText(obj.PickUpDuration));
		}
		if (!obj.PickupPlayerIsRight && playerNumber == 1){
			pickup.text = obj.PickupName;
			StartCoroutine(ResetText(obj.PickUpDuration));
		}
	}

	private IEnumerator ResetText(float duration){
		yield return new WaitForSeconds(duration);
		pickup.text = "";
	}
	private void OnUIChangedMessageReceived(UIChangeMessage obj){
		if (obj.Player == playerNumber) {
			kills.text = $"K: {obj.Kills}";
			deaths.text = $"D: {obj.Deaths}";
		}
	}
}
