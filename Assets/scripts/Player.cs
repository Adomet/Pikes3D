using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public string playerName = "Player";

    public GameController GC;

    public Pike Pike;
    public GameObject Body;
    public TrailRenderer TR;

    public int PlayerPoint = 1;
    public int KillCount = 0;
    public int pUpCount = 0;

    public bool IsAI = true;

    public GameObject PowerUpPrefab;

    public Vector3 SpPos = new Vector3(0, 1, 0);

    public float SpSpeed = 1f;

    public AIMovement AIMove;
    public PlayerMovement PlayerMove;




    public void AddPointToPlayer(int addition)
    {
        PlayerPoint += addition;
        Pike.AddPower(0.2f);

        if(IsAI)
        {
            AIMove.AddPower(addition,0.1f);
        }

        else
        {
            PlayerMove.AddPower(addition, 0.1f);

        }



        KillCount++;

        Debug.Log("PlayerPoint: " + PlayerPoint);


    }


    // Start is called before the first frame update
    void Start()
    {

        if (IsAI)
        {
            AIMove = GetComponent<AIMovement>();
            playerName += Random.Range(0, 21);
        }
        else
        {
            PlayerMove = GetComponent<PlayerMovement>();
        }




        //TODO search for pike 
        if (Pike == null)
            Destroy(gameObject);


       
    }

    private void OnEnable()
    {

        GC = GameObject.FindObjectOfType<GameController>();


        //Change indivicual color

        Renderer[] rds = Pike.GetComponentsInChildren<Renderer>();
     
        Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); ;
     
        foreach (Renderer rd in rds )
        {
            rd.material.color = color;
        }

        Body.GetComponent<Renderer>().material.color = color;

        TR.startColor = color;

        color.a = 0;
        TR.endColor = color;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {



        GameObject SpCube1 = Instantiate(PowerUpPrefab, (transform.position + SpPos), Random.rotation);
        Vector3 force = -1 * transform.forward * SpSpeed * 1.5f * Random.Range(0.5f, 1.2f);
        SpCube1.GetComponent<Rigidbody>().velocity = force;


        GameObject SpCube3 = Instantiate(PowerUpPrefab, (transform.position + SpPos), Random.rotation);
        Vector3 force3 = -1 * (transform.forward + transform.right) * SpSpeed * Random.Range(0.5f, 1.2f);
        SpCube3.GetComponent<Rigidbody>().velocity = force3;

        GameObject SpCube2 = Instantiate(PowerUpPrefab, (transform.position + SpPos), Random.rotation);
        Vector3 force2 = -1 * (transform.forward - transform.right) * SpSpeed * Random.Range(0.5f, 1.2f);
        SpCube2.GetComponent<Rigidbody>().velocity = force2;



        SpCube1.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        SpCube2.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        SpCube3.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);


        if (IsAI)
            Debug.Log("AI Game Over");
        else
            GC.PlayerGameOver();


    }
}
