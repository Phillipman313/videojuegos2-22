using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    

    private Rigidbody2D physics;
    [Header("Physics")]
    [SerializeField] float forceX = 1000f;
    [SerializeField] Vector2 direction = Vector2.zero;
    // Start is called before the first frame update

    public bool onGround = false;
    public float groundLength = 0.6f;
    public LayerMask groundLayer;

    [SerializeField] float jumpSpeed = 6f;
    void Start()
    {
        physics = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){
            //physics.AddForce(new Vector2(forceX * Time.deltaTime, 0));
            direction =  new Vector2(forceX, 0);
        }
        else if(Input.GetKey(KeyCode.A)){
            //physics.AddForce(new Vector2(-1 * forceX * Time.deltaTime, 0));
            direction =  new Vector2(-1*forceX, 0);
        }
        else{
            direction = Vector2.zero;
        }

    }

    void FixedUpdate(){
        physics.AddForce(direction * Time.fixedDeltaTime);
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);
        
    }

    public void Jump(InputAction.CallbackContext context){
        Debug.Log(context);
       
        if(context.performed){
            physics.AddForce(Vector2.up *jumpSpeed, ForceMode2D.Impulse);     
        }
        else if(context.canceled){

        }
    }

   

    public void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundLength);
    }
}
