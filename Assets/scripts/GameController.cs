using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    public GameObject PlayerObject;
    public bool IsGameOver = false;
    public List<GameObject> GameOverObjects;

    public float rndmaxX = 0f;
    public float rndmaxZ = 0f;


    public void PlayerGameOver()
    {
        foreach (GameObject go in GameOverObjects)
        {
            go.SetActive(true);

        }

        IsGameOver = true;
    }


    public void RestartGame ()
    {

       //Make your Respawn the player with reset
       // Application.LoadLevel(0);

       PlayerObject.transform.position = new Vector3(Random.Range(-rndmaxX, rndmaxX), 0.865f, Random.Range(-rndmaxZ, rndmaxZ));

        PlayerMovement mov = PlayerObject.GetComponent<PlayerMovement>();
        Player player = PlayerObject.GetComponent<Player>();

        mov.speed =3;
        mov.powerLevel =1;
        mov.Rotspeed=42;

        player.PlayerPoint =1;
        player.KillCount=0;
        player.pUpCount = 0;
        player.Pike.powerLevel = 1;
        player.Pike.ScalePike(1);

        player.Body.transform.parent.transform.localPosition = Vector3.zero;



        foreach (GameObject go in GameOverObjects)
        {
            go.SetActive(false);

        }

        IsGameOver = false;


        PlayerObject.SetActive(true);


    }

    public void ExitGame ()
    {

        Application.Quit();
    }
}
