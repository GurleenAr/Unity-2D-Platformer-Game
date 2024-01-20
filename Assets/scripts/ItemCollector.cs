using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private int collectedItems=0;
    [SerializeField] private Text strawberryText;
    [SerializeField] private AudioSource collectItemSound;
    private void Start(){
        collectedItems=PlayerPrefs.GetInt("Items Collected");
        if(SceneManager.GetActiveScene().buildIndex==1){
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("Items Collected", 0);
        }
        if(SceneManager.GetActiveScene().buildIndex>1){
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            collectedItems=PlayerPrefs.GetInt("Items Collected");
            strawberryText.text = "Items Collected:" + collectedItems;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectible"))
        {
            collectItemSound.Play();
            Destroy(collision.gameObject);
            collectedItems +=1;
            strawberryText.text = "Items Collected:" + collectedItems;
            PlayerPrefs.SetInt("Items Collected", collectedItems);
        }
    }
    
}
