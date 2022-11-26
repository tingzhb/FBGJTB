using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHP: MonoBehaviour
{

    //The box's current health point total
    [SerializeField] public int currentHealth = 3;
    [SerializeField] private int number;
    [SerializeField] private Button respawnButton;
    private int kills;
    private int deaths;
    public GameObject player;
    public float Min = 0;
    public float Max = 10;


    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            deaths++;
            respawnButton.gameObject.SetActive(true);
            UIChangeMessage uiChangedMessage = new()
            {
                Kills = kills,
                Deaths = deaths,
                Player = number
            };
            Broker.InvokeSubscribers(typeof(UIChangeMessage), uiChangedMessage);
            //if health has fallen below zero, deactivate it 
            //gameObject.SetActive (false);
            
        }
    }
    
    public void Respawn()
    {
        float x = Random.Range(Min,Max);
        float y = Random.Range(Min,Max);
        float z = Random.Range(Min,Max);
        
        player.transform.position = new Vector3(x,y,z);
        respawnButton.gameObject.SetActive(false);
    }
}
