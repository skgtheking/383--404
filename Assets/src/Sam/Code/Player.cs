using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]private LevelManager levelManager;

    [SerializeField]private KeyManager keyManager;

    [SerializeField]private GameObject firstDoor, secondDoor, thirdDoor;

    void Start()
    {
        keyManager = GameObject.FindWithTag("keymanagement").GetComponent<KeyManager>();

    }
    private void OnCollisionEnter2D(Collision2D other) 
    {

        if(other.gameObject.CompareTag("key"))
        {
            Debug.Log("Key Obtained!");
            if(keyManager == null)
            {
                Debug.Log("keyManager not initialized..");
            }
            keyManager.aquireKey(levelManager.currentLevel());

        }
        
        if(other.gameObject.CompareTag("door"))
        {
            
            Debug.Log("door!");
            if(keyManager.KeyObtained())
            {
                
                switch(levelManager.currentLevel())
                {
                    case 1:
                        levelManager.changeLevel(2);
                        levelManager.fogChanger();
                        firstDoor.SetActive(false);
                        Debug.Log("Entering level " + levelManager.currentLevel());
                        break;
                    case 2:
                        levelManager.changeLevel(3);
                        levelManager.fogChanger();
                        secondDoor.SetActive(false);
                        Debug.Log("Entering level " + levelManager.currentLevel());
                        break;
                    case 3:
                        SceneManager.LoadScene("GameEndMenu");
                        Debug.Log("Victory!");
                        break;
                    
                }

                keyManager.ResetKey();
            }
            else
            {
                Debug.Log("Need to get key first!");
            }

            
        }   

        else if(other.gameObject.CompareTag("object"))
        {
            Debug.Log("object!");
        }

        else if(other.gameObject.CompareTag("firewall"))
        {
            Debug.Log("Ouch! burns..");
        }

        else if(other.gameObject.CompareTag("enemy"))
        {
            Debug.Log("ARGH");
        }

    }

}
