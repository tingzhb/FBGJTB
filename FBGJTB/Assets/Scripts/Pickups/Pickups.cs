using UnityEngine;

public class Pickups : MonoBehaviour{
	[SerializeField] private int pickupNumber;
	[SerializeField] private float pickupDuration;
	[SerializeField] private string pickupName;
	private void OnTriggerEnter(Collider other){
		PickupMessage pickupMessage = new(){
			PickupName = pickupName,
			PickUpDuration = pickupDuration,
			PickUpNumber = pickupNumber,
			PickupPlayerIsRight = other.GetComponentInParent<CharacterMovement>().isRight
		};
		Broker.InvokeSubscribers(typeof(PickupMessage), pickupMessage);
		
		Destroy(gameObject);
	}
}
