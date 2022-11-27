using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UIDeathMessage : MonoBehaviour
{
    private int playerNumber;
    private Text kills;
    private Text deaths;
   
    
  private void Awake()
  {
          Broker.Subscribe<UIChangeMessage>(OnUIChangedMessageReceived);
         
  }
  
      private void OnDisable()
      {
          Broker.Unsubscribe<UIChangeMessage>(OnUIChangedMessageReceived);
      }

      private void OnUIChangedMessageReceived(UIChangeMessage obj)
      {
          if (obj.Player == playerNumber)
          {
              kills.text = $"Kills{obj.Kills}";
              deaths.text = $"Deaths{obj.Deaths}";
          }
      }
}
