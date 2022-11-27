using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour{
	private bool leftReady, rightReady;
	[SerializeField] private GameObject leftR, rightR, letsGo;
	private void Update(){
		if (Input.GetKey(KeyCode.Space)){
			leftReady = true;
			leftR.SetActive(true);
		}
		if (Input.GetKey(KeyCode.RightShift)){
			rightReady = true;
			rightR.SetActive(true);
		}
		if (rightReady && leftReady){
			leftR.SetActive(false);
			rightR.SetActive(false);
			letsGo.SetActive(true);
			StartCoroutine(DelayStart());
		}
		if (Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
	}
	
	private IEnumerator DelayStart(){
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(sceneBuildIndex: 1);
	}
}
