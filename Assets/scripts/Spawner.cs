using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{


    [System.Serializable]
    public class Spawn
    {
        public string tag;
        public GameObject Obj;
        public int spSize;
    }

    public List<Spawn> Spawns;

    public ObjectPooler objPooler;

    public float rndminX = 0f;
    public float rndmaxX = 0f;
    public float rndminZ = 0f;
    public float rndmaxZ = 0f;
    


    // Start is called before the first frame update
    void Start()
    {
        foreach (Spawn sp in Spawns)
        {
            for (int i = 0; i < sp.spSize; i++)
            {
                GameObject SpObj = objPooler.SpawnFromPool(sp.tag,sp.Obj, new Vector3(Random.Range(rndminX, rndmaxX), transform.position.y, Random.Range(rndminZ, rndmaxZ)), Quaternion.identity);
                    
            }
        }
    }
}
