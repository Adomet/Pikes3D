using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pike : MonoBehaviour
{
    public float powerLevel = 2.0f;


    public void AddPower(float addition)
    {
        powerLevel += addition;
        ScalePike(powerLevel);
    }

    public void ScalePike(float powerLevel)
    {
        Debug.Log("powerLevel:" + powerLevel);
        transform.parent.localScale = new Vector3(0.3f, powerLevel, 0.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
          //Debug.Log(other.transform.name);

        if (other.transform.GetComponent<Pike>() == null)
        {
            if (other.transform.root.GetComponent<Player>() != null)
            {
                other.transform.root.GetComponent<Player>().GameOver();

                Destroy(other.transform.root.gameObject);
            }
            else if (other.transform.root.GetComponent<AI>() != null)
            {
                transform.root.GetComponent<Player>().AddPointToPlayer(1);

                if (other.transform.root.GetComponent<AI>() != null)
                    other.transform.root.GetComponent<AI>().GameOver();

                Destroy(other.transform.root.gameObject);
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
