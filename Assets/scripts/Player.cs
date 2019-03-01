using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Pike Pike;
    public int PlayerPoint = 1;

    public void AddPointToPlayer(int addition)
    {
        PlayerPoint += addition;
        Debug.Log("PlayerPoint: " + PlayerPoint);
    }


    // Start is called before the first frame update
    void Start()
    {

        //TODO search for pike 
        if (Pike == null)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
