using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject MyPlayer; 
    public float speed  = 10f;
    public float powerLevel = 1;
    public float Rotspeed = 90f;
    private Rigidbody MyRig ;
   

    // Start is called before the first frame update
    void Start()
    {
        MyRig = GetComponent<Rigidbody>();

        if (MyPlayer == null)
            MyPlayer = this.gameObject;
        
    }

    public void AddPower(float addition)
    {
        powerLevel += addition;
    }



    // Update is called once per frame
    void Update()
    {
       
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        

       

        Quaternion rot = transform.rotation;

        float y = rot.eulerAngles.y;

        y -= hAxis * Rotspeed *Time.deltaTime;

        rot = Quaternion.Euler(0, y, 0);

        transform.rotation = rot;



        Vector3 movement = (vAxis * Vector3.forward) * speed * Time.deltaTime;

        MyRig.MovePosition(transform.position +(rot *movement * powerLevel));
    }
}
