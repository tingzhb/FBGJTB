using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Resize : MonoBehaviour{
    [SerializeField] private bool isRight;
    private void Awake(){
        Broker.Subscribe<PickupMessage>(OnNewPickupMessageReceived);
    }

    private void OnDisable(){
        Broker.Unsubscribe<PickupMessage>(OnNewPickupMessageReceived);
    }
    private void OnNewPickupMessageReceived(PickupMessage obj){
        if (obj.PickUpNumber == 7 && obj.PickupPlayerIsRight && !isRight){
            StartCoroutine (ChangeSize(obj.PickUpDuration));
        }
        if (obj.PickUpNumber == 7 && !obj.PickupPlayerIsRight && isRight){
            StartCoroutine (ChangeSize(obj.PickUpDuration));
        }
        
        if (obj.PickUpNumber == 8 && obj.PickupPlayerIsRight && !isRight){
            StartCoroutine (Shrink(obj.PickUpDuration));
        }
        if (obj.PickUpNumber == 8 && !obj.PickupPlayerIsRight && isRight){
            StartCoroutine (Shrink(obj.PickUpDuration));
        }
    }

    private IEnumerator ChangeSize(float duration)
    {
        float randomX = Random.Range(-10, 3);
        float randomY = Random.Range(-10, 2);
        float randomZ = Random.Range(-10, 4);
        Vector3 originalLocalScale = transform.localScale;
        transform.localScale = new Vector3(randomX, randomY, randomZ);
        yield return new WaitForSeconds(duration);
        transform.localScale = originalLocalScale;
    }
    
    private IEnumerator Shrink(float duration)
    {
        Vector3 originalLocalScale = transform.localScale;
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        yield return new WaitForSeconds(duration);
        transform.localScale = originalLocalScale;
    }
}

