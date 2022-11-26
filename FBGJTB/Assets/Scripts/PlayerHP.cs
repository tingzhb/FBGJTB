using UnityEngine;
using System.Collections;

public class PlayerHP: MonoBehaviour
{

    //The box's current health point total
    public int currentHealth = 3;
    [SerializeField] private int number;
    private int kills;
    private int deaths;

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            deaths++;
            UIChangeMessage uiChangedMessage = new()
            {
                Kills = kills,
                Deaths = deaths,
                Player = number
            };
            Broker.InvokeSubscribers(typeof(UIChangeMessage), uiChangedMessage);
            //if health has fallen below zero, deactivate it 
            gameObject.SetActive (false);
        }
    }
}
