using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement2 : MonoBehaviour
{
    
    [SerializeField] float Speed = 1f;

    public Rigidbody rb;

    [SerializeField] Transform _face;
    [SerializeField] Transform _lookingAt;
    [SerializeField] Transform _player;
    [SerializeField] Vector2 _inputMovement;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _face = transform.Find("Face").transform;
        _lookingAt = transform.Find("LookingAt").transform;
        _player = transform.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _lookingAt.localPosition = new Vector3(_inputMovement.x * 2.5f, 0, _inputMovement.y * 2.5f);

        // Rotar la cara?
        float rad = Mathf.Atan2(_inputMovement.y, _inputMovement.x);
        float deg = rad * 180/Mathf.PI;
        _face.rotation = Quaternion.Euler(0,-deg,0);
        _face.localPosition =  new Vector3(_inputMovement.x * 0.5f, _face.localPosition.y, _inputMovement.y * 0.5f);




    }

    void FixedUpdate(){

    }

    public void Move(InputAction.CallbackContext context){
        if(context.performed){
            _inputMovement = context.ReadValue<Vector2>();
        }
        else if(context.canceled){
            _inputMovement = Vector2.zero;
        }
    }
}
