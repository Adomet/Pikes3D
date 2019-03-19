using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public ObjectPooler Pooler;

    public float BoostBarIncrease = 1f;

    public float AIBoostIncrease = 0.5f;

    private void Start()
    {
        this.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }



    private void OnTriggerEnter(Collider other)
    {
        Player pl = other.transform.root.GetComponent<Player>();
        if (pl != null)
        {

            pl.pUpCount++;
            if (!pl.IsAI)
            {
                other.transform.root.GetComponent<PlayerMovement>().AddPower(0.005f, BoostBarIncrease);

                // Pooler.DestroyToPool(this.gameObject);
            }
            //else if () TODO: add aı power up
            else
            {
                other.transform.root.GetComponent<AIMovement>().AddPower(AIBoostIncrease);

                // Pooler.DestroyToPool(this.gameObject);
            }
        }
    }
}
