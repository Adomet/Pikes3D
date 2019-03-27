using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{

    public enum AIType
    {
        Passive, Aggrasive
    };

    public enum AIState
    {
        Attack, Roam, Getresource
    };

    //--------- AI Brain----------------
   
    public AIType       Type        = AIType.Passive;
    public AIState      State       = AIState.Roam;
    public Player[] PlayersNear;
    public List<PowerUp> PUpsNear   = new List<PowerUp>();
    public float AILookDistance = 1f;

    public Transform target;
    public float range = 10000f;

    //------------------------------------
    






    public float rotSpeed = 5.0f;
    private float tmprot;
    public float AISpeed = 5.0f;

    private Rigidbody MyRig;


    public void AddPower(float addition)
    {
        rotSpeed += addition;
        AISpeed += addition;
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayersNear = GameObject.FindObjectsOfType<Player>();

        MyRig = GetComponent<Rigidbody>();

        InvokeRepeating("FindTarget", 0.5f, 0.5f);

        tmprot = rotSpeed;

        // @TODO Add randomized Aı poperties may be a seed for each
    }

    public void AIAttack()
    {
        // if got any ---> go target and poke his face
        if (target == null)
        {
            State = AIState.Roam;
            return;
        }
           
       




    }
    public void FindTarget()
    {
      
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (Player enemy in PlayersNear)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy > 0f)
            {
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy.gameObject;
                }
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }

        else
        {
            target = null;
        }
    }

    public void AIRoam()
    {
        // find a Mengageable target to poke
        // rotate random -> find nearest enemy analyze

        rotSpeed = rotSpeed - 0.005f;
        if (rotSpeed <= 0f)
        {
            rotSpeed = tmprot;
        }

         Quaternion rot = transform.rotation;
        
         float y = rot.eulerAngles.y;
        
         y -= rotSpeed * Time.deltaTime;
        
         rot = Quaternion.Euler(0, y, 0);
        
        
        
         Vector3 movement = (AISpeed * Vector3.forward)  * Time.deltaTime;
        
         MyRig.MovePosition(transform.position + (rot * movement));
        
         transform.Rotate(transform.up,rotSpeed);

        if (target != null)
        {
            State = AIState.Attack;
        }

    }
    public void AIGetresource()
    {
        //Get some resource when too low 


    }

    //@TODO Make a Default strategy system based on AIType
    public void AIMove()
    {
        switch (State)
        {
            case AIState.Attack:
                AIAttack();
                break;
            case AIState.Roam:
                AIRoam();
                break;
            case AIState.Getresource:
                AIGetresource();
                break;
            default:
                AIGetresource();
                break;
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void FixedUpdate()
    {

        AIMove();


       
    }
}
