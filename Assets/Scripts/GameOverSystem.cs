using System;
using System.Collections;
using UnityEngine;

public class GameOverSystem : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverMenu, Player, floor;
    void Awake()
    {
        CatFollowersSystem.onDisconnect += GameOver;
    }

    void GameOver()
    {
        
        RemoveObjectsFromScene();
        floor.SetActive(false);
        StartCoroutine(ShowGameOverScreen());

    }

    IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(3);
        gameOverMenu.gameObject.SetActive(true);
        
        Time.timeScale = 0;

    }

    void RemoveObjectsFromScene()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            
                obstacle.gameObject.SetActive(false);
            
            
        }
    }

    void OnDestroy()
    {
        CatFollowersSystem.onDisconnect -= GameOver;
    }
}
