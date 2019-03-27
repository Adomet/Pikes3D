using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pike : MonoBehaviour
{
    public ObjectPooler Pooler;
    private float powerLevel = 1.0f;


    public void Awake()
    {
        Pooler = GameObject.FindObjectOfType<ObjectPooler>();
    }


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
            Player pl = other.transform.root.GetComponent<Player>();

            if (pl != null)
            {
                pl.GameOver();

                if (pl.IsAI)
                {
                    Pooler.DestroyToPool(other.transform.root.gameObject);
                    transform.root.GetComponent<Player>().AddPointToPlayer(1);
                }
                else
                {
                    Destroy(other.transform.root.gameObject);
                }
            }
            else
            {
                Pooler.DestroyToPool(other.transform.gameObject);
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
