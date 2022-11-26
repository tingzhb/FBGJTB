using UnityEngine;

public class Pickups : MonoBehaviour{
	[SerializeField] private int pickupNumber;
	[SerializeField] private float pickupDuration;
	private void OnTriggerEnter(Collider other){
		PickupMessage pickupMessage = new(){
			PickUpDuration = pickupDuration,
			PickUpNumber = pickupNumber,
			IsRightPlayer = other.GetComponentInParent<CharacterMovement>().isRight
		};
		Broker.InvokeSubscribers(typeof(PickupMessage), pickupMessage);
		
		Destroy(gameObject);
	}
}
