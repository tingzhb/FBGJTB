using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float movementMultiplierL, movementMultiplierR, lookMultiplierL, lookMultiplierR;
    [SerializeField] public bool isRight;
    [SerializeField] private int addMultiplier;
    private bool invert, boost;
    
    private void Awake(){
        Broker.Subscribe<PickupMessage>(OnNewPickupMessageReceived);
        isRight = GetComponent<CharacterMovement>().isRight;
    }
	
    private void OnDisable(){
        Broker.Unsubscribe<PickupMessage>(OnNewPickupMessageReceived);
    }
    private void OnNewPickupMessageReceived(PickupMessage obj){
        if (obj.PickUpNumber == 0 && obj.IsRightPlayer && !isRight){
            invert = true;
            StartCoroutine(InvertDuration(obj.PickUpDuration));
        }
        if (obj.PickUpNumber == 0 && !obj.IsRightPlayer && isRight){
            invert = true;
            StartCoroutine(InvertDuration(obj.PickUpDuration));
        }
        if (obj.PickUpNumber == 1 && obj.IsRightPlayer && !isRight){
            ChangeMultiplier(addMultiplier);
            StartCoroutine(BoostDuration(obj.PickUpDuration));
        }
        if (obj.PickUpNumber == 1 && !obj.IsRightPlayer && isRight){
            ChangeMultiplier(addMultiplier);
            StartCoroutine(BoostDuration(obj.PickUpDuration));
        }
    }

    private IEnumerator InvertDuration(float duration){
        yield return new WaitForSeconds(duration);
        invert = false;
    }
    
    private IEnumerator BoostDuration(float duration){
        yield return new WaitForSeconds(duration);
        ChangeMultiplier(-addMultiplier);
    }

    private void ChangeMultiplier(int delta){
        movementMultiplierL += delta;
        movementMultiplierR += delta;
        lookMultiplierL += delta;
        lookMultiplierR += delta;
    }
    private void Update(){

        if (!isRight){
            if (Input.GetKey(KeyCode.A)){
                transform.Translate(Vector3.left * (movementMultiplierL * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.D)){
                transform.Translate(Vector3.right * (movementMultiplierL * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.W)){
                transform.Translate(Vector3.forward * (movementMultiplierL * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.S)){
                transform.Translate(Vector3.back * (movementMultiplierL * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.Q)){
                transform.Rotate(Vector3.down * (lookMultiplierL * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.E)){
                transform.Rotate(Vector3.up * (lookMultiplierL * Time.deltaTime));
            }
        }
        if (isRight){
            if (Input.GetKey(KeyCode.J)){
                transform.Translate(Vector3.left * (movementMultiplierR * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.L)){
                transform.Translate(Vector3.right * (movementMultiplierR * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.I)){
                transform.Translate(Vector3.forward * (movementMultiplierR * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.K)){
                transform.Translate(Vector3.back * (movementMultiplierR * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.U)){
                transform.Rotate(Vector3.down * (lookMultiplierR * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.O)){
                transform.Rotate(Vector3.up * (lookMultiplierR * Time.deltaTime));
            }
        }
        if (!isRight && invert){
            if (Input.GetKey(KeyCode.L)){
                transform.Translate(Vector3.left * (movementMultiplierR * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.J)){
                transform.Translate(Vector3.right * (movementMultiplierR * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.K)){
                transform.Translate(Vector3.forward * (movementMultiplierR * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.I)){
                transform.Translate(Vector3.back * (movementMultiplierR * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.O)){
                transform.Rotate(Vector3.down * (lookMultiplierR * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.U)){
                transform.Rotate(Vector3.up * (lookMultiplierR * Time.deltaTime));
            }

        }
        if (isRight && invert){
            if (Input.GetKey(KeyCode.D)){
                transform.Translate(Vector3.left * (movementMultiplierL * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.A)){
                transform.Translate(Vector3.right * (movementMultiplierL * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.S)){
                transform.Translate(Vector3.forward * (movementMultiplierL * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.W)){
                transform.Translate(Vector3.back * (movementMultiplierL * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.E)){
                transform.Rotate(Vector3.down * (lookMultiplierL * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.R)){
                transform.Rotate(Vector3.up * (lookMultiplierL * Time.deltaTime));
            }
        }
    }
}