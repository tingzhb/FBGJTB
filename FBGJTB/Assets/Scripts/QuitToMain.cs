using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMain : MonoBehaviour {
	private void Update(){
		if (Input.GetKey(KeyCode.Escape)){
			SceneManager.LoadScene(sceneBuildIndex: 0);
		}
	}
}
