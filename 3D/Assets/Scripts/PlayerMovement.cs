using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Translate
    // Rigidbody -> AddForce, Velocity, MovePosition

    // Start is called before the first frame update

    [SerializeField] private float Speed = 5f;

    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() // 300/60 => deltaTime
    {
        //Move(Vector3.left * Speed * Time.deltaTime);  // (-1,0,0)   
    }

    void FixedUpdate(){ // 50 / 60 => fixed delta time
        Move(Vector3.left * Speed * Time.fixedDeltaTime); 
    }

    void Move(Vector3 direction){
        // transform.Translate(direction);
        // rb.AddForce(direction);
        // rb.velocity = direction;
        rb.MovePosition(transform.position + direction);
    }
}
