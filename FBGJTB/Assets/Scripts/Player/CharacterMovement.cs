using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float movementMultiplierL, movementMultiplierR, lookMultiplierL, lookMultiplierR;
    [SerializeField] public bool isRight;
    private void Update() {
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
        else{
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

    }
}