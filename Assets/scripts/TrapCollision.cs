using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class TrapCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {           
            FindAnyObjectByType<PlayerLIfe>().hurt();
            FindAnyObjectByType<HealthBar>().loseHealth(damage);
        }
    }
}
