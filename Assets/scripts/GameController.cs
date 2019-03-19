using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool IsGameOver = false;
    public List<GameObject> GameOverObjects;


    public void PlayerGameOver()
    {
        foreach (GameObject go in GameOverObjects)
        {
            go.SetActive(true);

        }

        IsGameOver = true;
    }
}
