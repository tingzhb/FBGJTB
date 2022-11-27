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

    private void Awake(){
        Broker.Subscribe<KillMessage>(OnKillMessageReceived);
    }

    private void OnDisable(){
        Broker.Unsubscribe<KillMessage>(OnKillMessageReceived);
    }
    private void OnKillMessageReceived(KillMessage obj){
        if (obj.Player != playerNumber){
            kills++;
            SendUIChangedMessage();
        }
    }
    public void Damage(int damageAmount, bool playerKill) {
        //subtract damage amount when Damage function is called
        if (!dead){
            currentHealth -= damageAmount;
            SendUIChangedMessage();
        }

        //Check if health has fallen below zero
        if (currentHealth <= 0 && !dead){
            dead = true;
            deaths++;
            deathNotice.gameObject.SetActive(true);
            StartCoroutine(WaitToRespawn());
            SendUIChangedMessage();

            if (playerKill){
                KillMessage killMessage = new(){
                    Player = playerNumber
                };
                Broker.InvokeSubscribers(typeof(KillMessage), killMessage); 
            }
        }
    }
    private void SendUIChangedMessage(){

        UIChangeMessage uiChangedMessage = new(){
            Health = currentHealth,
            Player = playerNumber,
            Kills = kills,
            Deaths = deaths
        };
        Broker.InvokeSubscribers(typeof(UIChangeMessage), uiChangedMessage);
    }

    private void Respawn(){
        var spawnIndex = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[spawnIndex].transform.position;
        deathNotice.SetActive(false);
        currentHealth = 3;
        dead = false;
        SendUIChangedMessage();
    }

    private IEnumerator WaitToRespawn(){
        yield return new WaitForSeconds(2);
        Respawn();
    }
}
