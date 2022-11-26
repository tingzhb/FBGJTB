using UnityEngine;

public class PickupExample : MonoBehaviour{
	[SerializeField] private int pickupNumber;
	private void OnTriggerEnter(Collider other){
		PickupMessage pickupMessage = new(){
			PickUpNumber = pickupNumber,
			IsRightPlayer = other.GetComponentInParent<CharacterMovement>().isRight
		};
		Broker.InvokeSubscribers(typeof(PickupMessage), pickupMessage);
	}
}
