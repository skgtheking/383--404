using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static int level;

    [SerializeField] private GameObject firstRoomFog, secondRoomFog, thirdRoomFog, enemy;

    [SerializeField] private Enemy enemyscript;
    

    [SerializeField] private float fadeDuration = 2f;

    void Start()
    {
        


        enemyscript = GameObject.FindWithTag("enemy").GetComponent<Enemy>();
        enemy.SetActive(false);
        level = 1;
        firstRoomFog.SetActive(false);
        secondRoomFog.SetActive(true);
        thirdRoomFog.SetActive(true);
        
        Vector2 flytrapPosition = new Vector2((float)-2, (float)-1.8);

        TrapHandler.SpawnTrap("Fly", flytrapPosition);
        
    }


    public void fogChanger()
    {
        
        switch (level)
        {
            case 1:
                break;
            case 2:
                StartCoroutine(FadeOut(secondRoomFog));
                enemy.SetActive(true);
                enemyscript.increaseEnemySpeed();  
                break;
            case 3:
                StartCoroutine(FadeOut(thirdRoomFog));
                Destroy(enemy);
                Debug.Log("Enemy Felled!");
                break;
            default:
                Debug.LogError("Invalid level value");
                break;
        }
    }
    private IEnumerator FadeOut(GameObject fogObject)
    {
        Renderer fogRenderer = fogObject.GetComponent<Renderer>();
        Color originalColor = fogRenderer.material.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(originalColor.a, 0f, elapsedTime / fadeDuration);
            Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            fogRenderer.material.color = newColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fogObject.SetActive(false); // Disable the fog GameObject after fading
    }

    public void changeLevel(int lvl)
    {
        level = lvl;
    }

    public float currentLevel()
    {
        return level;
    }
}
