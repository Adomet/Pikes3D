using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private GameObject MyPlayer; 
    public float speed  = 10f;
    public float BoostBar = 10f;
    public float powerLevel = 1.0f;
    public float boost = 1.0f;
    public float Rotspeed = 90f;
    private Rigidbody MyRig ;


    //UI

    //Boost Button

    public bool IsBoostButtonPressed = false;


    //Joystick

    public Joystick joystick;
    

   

    // Start is called before the first frame update
    void Start()
    {
        MyRig = GetComponent<Rigidbody>();

        if (MyPlayer == null)
            MyPlayer = this.gameObject;
        
    }


    public void BoostButtonPressed()
    {
        IsBoostButtonPressed = true;
}

    public void BoostButtonReleased()
    {
        IsBoostButtonPressed = false;
    }




    public void AddPower(float addition)
    {
        powerLevel += addition;
        if (BoostBar >= 10.0f)
        {
            BoostBar = 10.0f;
        }
        else
            BoostBar += 2.0f;
    }



    // Update is called once per frame
    void Update()
    {
        // For PC
        // float hAxis = Input.GetAxis("Horizontal");
        // float vAxis = Input.GetAxis("Vertical");

        //For Mobile

        float hAxis = joystick.Horizontal;
        float vAxis = joystick.Vertical;

        if (IsBoostButtonPressed)
        {
            if (BoostBar > 0)
            {
                BoostBar -= 0.1f;
                boost = 1.3f;
            }
            else
                BoostBar = 0;
        }

        else
            boost = 1.0f;


        Quaternion rot = transform.rotation;

        float y = rot.eulerAngles.y;

        y -= hAxis * Rotspeed *Time.deltaTime;

        rot = Quaternion.Euler(0, y, 0);

        transform.rotation = rot;

        Vector3 movement = Vector3.forward * speed* boost * Time.deltaTime;

        MyRig.MovePosition(transform.position +(rot *movement * boost * powerLevel));
    }
}
