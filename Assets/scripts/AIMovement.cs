using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{

    public float rotSpeed = 5.0f;
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
        MyRig = GetComponent<Rigidbody>();

        // @TODO Add randomized Aı poperties may be a seed for each
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Quaternion rot = transform.rotation;

        float y = rot.eulerAngles.y;

        y -= rotSpeed * Time.deltaTime;

        rot = Quaternion.Euler(0, y, 0);

        transform.rotation = rot;


        Vector3 movement = (AISpeed * Vector3.forward)  * Time.deltaTime;

        MyRig.MovePosition(transform.position + (rot * movement));


        transform.Rotate(transform.up,rotSpeed);
    }
}
