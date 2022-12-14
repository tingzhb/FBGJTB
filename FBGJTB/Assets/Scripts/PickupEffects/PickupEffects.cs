using UnityEngine;

public class PickupEffects : MonoBehaviour{
	private bool isRight;
	private void OnEnable(){
		Broker.Subscribe<PickupMessage>(OnNewPickupMessageReceived);
		isRight = GetComponent<CharacterMovement>().isRight;
	}
	
	private void OnDisable(){
		Broker.Unsubscribe<PickupMessage>(OnNewPickupMessageReceived);
	}
	
	private void OnNewPickupMessageReceived(PickupMessage obj){
		if (obj.PickupPlayerIsRight != isRight){
			switch (obj.PickUpNumber){
				case 0:
					Debug.Log($"Did Something on {obj.PickUpNumber} + {isRight}" );
					// Influence game effect here
					break;
				case 1:
					break;
			}
		}	
		
	}
}
