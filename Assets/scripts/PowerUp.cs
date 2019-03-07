using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{




    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.GetComponent<Player>() != null)
        {
            other.transform.root.GetComponent<PlayerMovement>().AddPower(0.005f);

            Destroy(this.gameObject);
        }
        //else if () TODO: add aı power up
            else
            return;
    }
}
