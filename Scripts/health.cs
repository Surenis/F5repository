using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class health : NetworkBehaviour
{
    public const int maxHealth = 100;
    
    [SyncVar(hook = "OnChangerHealth")]
    public int currenthealth = maxHealth;

    public RectTransform healthBar;
    

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }
        
        currenthealth -= amount;

        if (currenthealth <= 0)
        {
            currenthealth = 0;
            Debug.Log("Dead !");
        }
        
        healthBar.sizeDelta = new Vector2(currenthealth, healthBar.sizeDelta.y);
    }

    void OnChangerHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }
}
