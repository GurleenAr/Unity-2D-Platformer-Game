using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillHealthBar;
    public float playerHealth;

    public void loseHealth(int value)
    {
       
        playerHealth -=value;
        fillHealthBar.fillAmount=playerHealth/100;
        if(playerHealth<=0){
            FindFirstObjectByType<PlayerLIfe>().death();
            Debug.Log("Game Over");
        }
    }
}
