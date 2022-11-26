using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour{
    [SerializeField] private float multiplier;
    [SerializeField] public bool isRight;
    private void Update() {
        if (!isRight){
            if (Input.GetKey(KeyCode.A)){
                transform.Translate(Vector3.left * (multiplier * Time.deltaTime));
                Debug.Log("A");
            }
            if (Input.GetKey(KeyCode.D)){
                transform.Translate(Vector3.right * (multiplier * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.W)){
                transform.Translate(Vector3.forward * (multiplier * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.S)){
                transform.Translate(Vector3.back * (multiplier * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.Q)){
                transform.Rotate(Vector3.down);
            }
            if (Input.GetKey(KeyCode.E)){
                transform.Rotate(Vector3.up);
            }
        }
        else{
            if (Input.GetKey(KeyCode.J)){
                transform.Translate(Vector3.left * (multiplier * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.L)){
                transform.Translate(Vector3.right * (multiplier * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.I)){
                transform.Translate(Vector3.forward * (multiplier * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.K)){
                transform.Translate(Vector3.back * (multiplier * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.U)){
                transform.Rotate(Vector3.down);
            }
            if (Input.GetKey(KeyCode.O)){
                transform.Rotate(Vector3.up);
            }
        }

    }
}