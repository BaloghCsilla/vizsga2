using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] string gameSceneName;


    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName);
        Debug.Log("mmm");

    }

}   
