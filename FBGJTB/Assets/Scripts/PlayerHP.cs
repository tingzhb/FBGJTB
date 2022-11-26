using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerHP: MonoBehaviour
{

    //The box's current health point total
    [SerializeField] public int currentHealth = 3, playerNumber;
    [SerializeField] private GameObject deathNotice;
    [SerializeField] private GameObject[] spawnPoints;
    private int kills;
    private int deaths;
    private bool dead;

    public void Damage(int damageAmount) {
        //subtract damage amount when Damage function is called
        if (!dead){
            currentHealth -= damageAmount;
        }

        //Check if health has fallen below zero
        if (currentHealth <= 0 && !dead){
            dead = true;
            deaths++;
            deathNotice.gameObject.SetActive(true);
            StartCoroutine(WaitToRespawn());
            UIChangeMessage uiChangedMessage = new()
            {
                Kills = kills,
                Deaths = deaths,
                Player = playerNumber
            };
            Broker.InvokeSubscribers(typeof(UIChangeMessage), uiChangedMessage);
            //if health has fallen below zero, deactivate it 
            //gameObject.SetActive (false);
            
        }
    }
    
    private void Respawn(){
        var spawnIndex = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[spawnIndex].transform.position;
        deathNotice.SetActive(false);
        currentHealth = 3;
        dead = false;
    }

    private IEnumerator WaitToRespawn(){
        yield return new WaitForSeconds(2);
        Respawn();
    }
}
