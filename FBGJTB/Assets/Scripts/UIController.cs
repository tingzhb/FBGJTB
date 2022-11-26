using System;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour{
	[SerializeField] private TextMeshProUGUI kills, deaths;
	[SerializeField] private int playerNumber;

	private void Awake(){
		Broker.Subscribe<UIChangeMessage>(OnUIChangedMessageReceived);
	}

	private void OnDisable(){
		Broker.Unsubscribe<UIChangeMessage>(OnUIChangedMessageReceived);

	}
	private void OnUIChangedMessageReceived(UIChangeMessage obj){
		if (obj.Player == playerNumber) {
			kills.text = $"Kills{obj.Kills}";
			deaths.text = $"Deaths{obj.Deaths}";
		}
	}
}
