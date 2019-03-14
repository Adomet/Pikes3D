using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject AIPrefab;
    public GameObject PowerPrefab;

    //@TODO Add pooling 
    //@TODO Add pooling 
    //@TODO Add pooling 
    //@TODO Add pooling 
    //@TODO Add pooling 




    // Start is called before the first frame update
    void Start()
    {
       // GameObject AıPlayer = Instantiate(AIPrefab,transform.position + new Vector3 (0,1,0),Quaternion.identity);

        for (int i = 0; i < 5; i++)
        {
           // GameObject PowerUP = Instantiate(PowerPrefab, transform.position + new Vector3(0, i +1 , 0), Quaternion.identity);
        }
     
    }
}
