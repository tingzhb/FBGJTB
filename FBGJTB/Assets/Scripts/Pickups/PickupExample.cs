using UnityEngine;

public class PickupExample : MonoBehaviour{
	[SerializeField] private int pickupNumber;
	private void OnTriggerEnter(Collider other){
		NewPowerupMessage newPowerupMessage = new(){PickUpNumber = pickupNumber};
		Broker.InvokeSubscribers(typeof(NewPowerupMessage), newPowerupMessage);
	}
}
