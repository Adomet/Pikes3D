using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pike : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Pike>() == null)
        {
            if(other.transform.root.GetComponent<Player>() != null)
            {
                other.transform.root.GetComponent<Player>().GameOver();
            }
            else
            {
                Destroy(other.transform.root.gameObject);
            }
        }
        else
            return;



        //if (other.GetComponent<Pike>() == null && other.transform.root.GetComponent<Player>() == null)
        ////Todo:Check if its a enemy
        //{
        //    Destroy(other.transform.root.gameObject);
        //}
        //
        //else if (other.transform.root.GetComponent<Player>() != null)
        //{
        //    GameObject player = other.transform.root.gameObject;
        //    player.GetComponent<Player>().GameOver();
        //}
        //else
        //    return;
    }
}
