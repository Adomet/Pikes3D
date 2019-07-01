using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pike : MonoBehaviour
{
    public ObjectPooler Pooler;
    public float powerLevel = 1.0f;
    public Player MyPlayer; 


    public void Awake()
    {
        Pooler = GameObject.FindObjectOfType<ObjectPooler>();

        MyPlayer = transform.root.GetComponent<Player>();

    }


    public void AddPower(float addition)
    {
        powerLevel += addition;
        ScalePike(powerLevel);
    }

    public void ScalePike(float powerLevel)
    {
        //Debug.Log("powerLevel:" + powerLevel);
        transform.parent.localScale = new Vector3(0.3f, powerLevel, 0.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag != "Pike")
        {
            Player pl = other.transform.root.GetComponent<Player>();
      
            if (pl != null)
            {
                pl.GameOver();
      
                if (pl.IsAI)
                {
                    Pooler.DestroyToPool(pl.gameObject);
                    MyPlayer.AddPointToPlayer(1);
                }
                else
                {
                    pl.gameObject.SetActive(false);
                }
            }
            else
            {
                Pooler.DestroyToPool(other.transform.gameObject);
            }
        }
     
    }
}
