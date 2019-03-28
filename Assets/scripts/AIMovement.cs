﻿using System.Collections;
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
    public float BoostBar = 10f;
    public float boost = 1.0f;
    public Tracker Tracker;
    public Transform target;
    public float range = 10000f;
    public bool IsBoostButtonPressed = false;

    //------------------------------------







    public float rotSpeed = 5.0f;
    private float tmprot;
    public float AISpeed = 5.0f;

    private Rigidbody MyRig;


    public void AddPower(float addition,float BoostBarIncrease)
    {

        BoostBar += BoostBarIncrease;

        if (BoostBar >= 10.0f)
        {
            BoostBar = 10.0f;
        }

        rotSpeed += addition;
        AISpeed += addition;
    }


    // Start is called before the first frame update
    void Start()
    {


        Tracker = GameObject.FindObjectOfType<Tracker>();
        MyRig = GetComponent<Rigidbody>();

        InvokeRepeating("FindTarget", Random.Range(0.1f,1f), Random.Range(0.1f, 0.5f));

        tmprot = rotSpeed;

        // @TODO Add randomized Aı poperties may be a seed for each
    }

    public void AIAttack()
    {
        // if got any target ---> go target and poke his face
        if (target == null)
        {
            IsBoostButtonPressed = false;
            State = AIState.Roam;
            return;
        }


        Vector3 dir = target.position - transform.position;
        Quaternion lookrotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(dir),rotSpeed);

        transform.rotation = lookrotation;

        Vector3 movement = (AISpeed * Vector3.forward) *boost * Time.deltaTime;

        MyRig.MovePosition(transform.position + (transform.rotation * movement));


        //Use Boost
        IsBoostButtonPressed = true;
    }



    public void FindTarget()
    {
        if (!this.enabled)
            return;

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (Player enemy in Tracker.Players)
        {

            if (enemy != null)
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

        rotSpeed = rotSpeed - 0.01f;
        if (rotSpeed <= 0f)
        {
            rotSpeed = tmprot;
        }

       
        
         Vector3 movement = (AISpeed * Vector3.forward) * boost * Time.deltaTime;
        
         MyRig.MovePosition(transform.position + (transform.rotation * movement));
        
         transform.Rotate(transform.up,rotSpeed);

        if (target != null)
        {
            rotSpeed = tmprot;
            State = AIState.Attack;
        }

       // else if (BoostBar < 3.0f)
       // {
       //     State = AIState.Getresource;
       // }

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

        if (IsBoostButtonPressed)
        {
            if (BoostBar > 0)
            {
                BoostBar -= 0.1f;
                boost = 1.3f;
            }
            else
            {
                BoostBar = 0;
                boost = 1f;
            }

        }

        else
            boost = 1.0f;


        AIMove();


       
    }
}
