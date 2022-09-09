using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Tener una referencia a otro objeto
    [SerializeField] Pad paddle;
    [SerializeField] Vector2 velocity = new Vector2(1f, 4f);

    [SerializeField] float xVelocity;
    [SerializeField] float yVelocity;
    [SerializeField] float xMultiplier; // Para calcular el rebote con ángulo

    // Bandera
    bool _playing = false;
    float collisionFloat = 0.47f;

    Rigidbody2D _ballRigidbody; 

    Vector2 paddleToBallDistance;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistance = transform.position - paddle.transform.position;
        _ballRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LockToPaddle();
        LaunchOnClick();    
    }

    void LaunchOnClick(){
        if (!_playing && Input.GetMouseButtonDown(0)){
            _playing = true;
            _ballRigidbody.velocity = velocity;
        }
    }

    void LockToPaddle(){
        if(!_playing){
            Vector2 paddleRef = paddle.transform.position;
            Vector2 paddPos = new Vector2(paddleRef.x, paddleRef.y);
            transform.position = paddPos + paddleToBallDistance;
        }
    }

    void OnHorizontalCollision(){
        yVelocity *= -1;
        _ballRigidbody.velocity = new Vector2(xVelocity, yVelocity);
    }

    void OnVerticalCollision(){
        xVelocity *= -1;
        _ballRigidbody.velocity = new Vector2(xVelocity, yVelocity);
    }
     void OnBlockCollision(Collision2D block){
        Vector2 collision = block.contacts[0].point;
        float xColPoint = collision.x - block.transform.position.x;
        float yColPoint = collision.y - block.transform.position.y;
        // Debug.Log("Block collision X: "+ xColPoint + "Block collision Y: " + yColPoint);
        if(Mathf.Abs(yColPoint) > collisionFloat){
            yVelocity *= -1;
            _ballRigidbody.velocity = new Vector2(xVelocity, yVelocity);
        }
        else if (Mathf.Abs(xColPoint) > collisionFloat){
            xVelocity *= -1;
            _ballRigidbody.velocity = new Vector2(xVelocity, yVelocity);
        }
    }
    
    void OnPaddleCollision(Collision2D other){
        float xCollisionPoint = other.contacts[0].point.x - other.transform.position.x;
        yVelocity *= -1;
        xVelocity = xCollisionPoint * xMultiplier;
        _ballRigidbody.velocity = new Vector2(xVelocity, yVelocity);
    }

    void OnCollisionEnter2D(Collision2D other){
        // Contra quien colisiona?
        // Pared
        //     - Horizontal
        //     - Vertical
        // Bloque
        // Paleta
        string collisionTag = other.gameObject.tag;
        //Debug.Log(other.gameObject.name + " xCollisionPoint " + xCollisionPoint);
        if(collisionTag == Constants.HORIZONTAL_WALL){
            OnHorizontalCollision();            
        }
        if(collisionTag == Constants.VERTICAL_WALL){
            OnVerticalCollision();
        }
        if(collisionTag == Constants.PADDLE){
            OnPaddleCollision(other);
        }
        if(collisionTag == Constants.BLOCK){
            OnBlockCollision(other);
        }
    }
}
