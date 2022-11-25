using UnityEngine;

public class PickupEffectExample : MonoBehaviour {

	private void Start(){
		Broker.Subscribe<NewPowerupMessage>(OnNewPowerUpMessageReceived);
	}
	private void OnDisable(){
		Broker.Unsubscribe<NewPowerupMessage>(OnNewPowerUpMessageReceived);
	}
	private void OnNewPowerUpMessageReceived(NewPowerupMessage obj){
		if (obj.PickUpNumber == 0){
			Debug.Log($"Do Something on {obj.PickUpNumber}" );
		}
	}
}
