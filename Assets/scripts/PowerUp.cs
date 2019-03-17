using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private void Start()
    {
        this.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.GetComponent<Player>() != null)
        {
            other.transform.root.GetComponent<PlayerMovement>().AddPower(0.005f);

            Destroy(this.gameObject);
        }
        //else if () TODO: add aı power up
        else if(other.transform.root.GetComponent<AI>() != null)
        {
            other.transform.root.GetComponent<AIMovement>().AddPower(0.5f);

            Destroy(this.gameObject);
        }

        else
        return;
    }
}
