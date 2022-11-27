using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float movementMultiplierL, movementMultiplierR, lookMultiplierL, lookMultiplierR;
    [SerializeField] public bool isRight;
    [SerializeField] private int addMultiplier;
    private bool invert, boost;
    private bool canMove = true;
    private void Awake(){
        Broker.Subscribe<PickupMessage>(OnNewPickupMessageReceived);
        Broker.Subscribe<UIChangeMessage>(OnUIChangedMessageReceived);
    }
	
    private void OnDisable(){
        Broker.Unsubscribe<PickupMessage>(OnNewPickupMessageReceived);
        Broker.Unsubscribe<UIChangeMessage>(OnUIChangedMessageReceived);

    }
    private void OnUIChangedMessageReceived(UIChangeMessage obj){
        if (obj.Player == 0 && !isRight){
            canMove = false;
            StartCoroutine(ReableMovement());
        }
        if (obj.Player == 1 && isRight){
            canMove = false;
            StartCoroutine(ReableMovement());
        }
    }
    
    private IEnumerator ReableMovement(){
        yield return new WaitForSeconds(2); 
        canMove = true;
    }
    private void OnNewPickupMessageReceived(PickupMessage obj){
        // Invert Controls
        if (obj.PickUpNumber == 0 && obj.PickupPlayerIsRight && !isRight){
            invert = true;
            StartCoroutine(InvertDuration(obj.PickUpDuration));
        }
        if (obj.PickUpNumber == 0 && !obj.PickupPlayerIsRight && isRight){
            invert = true;
            StartCoroutine(InvertDuration(obj.PickUpDuration));
        }
        // Increase Move Speed
        if (obj.PickUpNumber == 1 && obj.PickupPlayerIsRight && !isRight){
            ChangeMultiplier(addMultiplier);
            StartCoroutine(BoostDuration(obj.PickUpDuration));
        }
        if (obj.PickUpNumber == 1 && !obj.PickupPlayerIsRight && isRight){
            ChangeMultiplier(addMultiplier);
            StartCoroutine(BoostDuration(obj.PickUpDuration));
        }
        
        // Send Player Backwards
        if (obj.PickUpNumber == 6 && obj.PickupPlayerIsRight && !isRight){
            transform.Translate(Vector3.back * (movementMultiplierL * 0.5f));
        }
        if (obj.PickUpNumber == 6 && !obj.PickupPlayerIsRight && isRight){
            transform.Translate(Vector3.back * (movementMultiplierR * 0.5f));
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

        if (!isRight && canMove && !invert){
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
        if (isRight && canMove && !invert){
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
        if (isRight && invert && canMove){
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
        if (!isRight && invert && canMove){
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
            if (Input.GetKey(KeyCode.Q)){
                transform.Rotate(Vector3.up * (lookMultiplierL * Time.deltaTime));
            }
        }
    }
}