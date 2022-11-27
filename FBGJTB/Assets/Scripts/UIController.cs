using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour{
	[SerializeField] private TextMeshProUGUI kills, deaths, pickup;
	[SerializeField] private int playerNumber;
	[SerializeField] private GameObject[] healthBars;

	private void Awake(){
		kills.text = $"K: 0";
		deaths.text = $"D: 0";
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
			foreach (var healthBar in healthBars){
				healthBar.SetActive(false);
			}
			for (int i = 0; i < obj.Health; i++){
				healthBars[i].SetActive(true);
			}
		}
	}
}
