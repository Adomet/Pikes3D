using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public GameObject PowerUpPrefab;

    public Vector3 SpPos = new Vector3(0,1,0);

    public float SpSpeed = 1f;

   public void GameOver ()
    {

        Quaternion rot = transform.rotation;
        float y = rot.eulerAngles.y;
        rot = Quaternion.Euler(0, y, 0);


        GameObject SpCube1 = Instantiate(PowerUpPrefab, (transform.position + SpPos), Random.rotation);
        Vector3 force = -1 * transform.forward * SpSpeed * 1.5f * Random.Range(0.5f,1.2f);
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


        Debug.Log("AI GameOver");
    }
}
