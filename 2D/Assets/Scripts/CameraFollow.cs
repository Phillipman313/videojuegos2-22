using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] GameObject followObject;
    Rigidbody2D followRigidbody2D;

    [SerializeField] Vector2 offsetSize;
    [SerializeField] float speed = 3f;
    private Vector2 threshold;


    [SerializeField] Vector3 offsetPosition;



    // Start is called before the first frame update
    void Start()
    {
        threshold = calculateThreshold();
        followRigidbody2D = followObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 follow = followObject.transform.position - offsetPosition;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);// A B => A - B
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);// A B => A - B
        Vector3 newPosition = transform.position;

        if(Mathf.Abs(xDifference) >= threshold.x){
            newPosition.x = follow.x;
        }
        if(Mathf.Abs(yDifference) >= threshold.y){
            newPosition.y = follow.y;
        }

        float moveSpeed = followRigidbody2D.velocity.magnitude > speed ? followRigidbody2D.velocity.magnitude : speed; 
        transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * moveSpeed);
    }

    private Vector3 calculateThreshold(){
        Rect aspect = Camera.main.pixelRect;
        float cameraSize = Camera.main.orthographicSize; // En nuestro caso nos retorna 5

        //Debug.Log("Ortographic Size: " + Camera.main.orthographicSize);
        //Debug.Log("aspect.width: " + aspect.width);
        //Debug.Log("aspect.height: " + aspect.height);

        Vector2 threshold = new Vector2( cameraSize * aspect.width / aspect.height  , cameraSize);
        threshold -= offsetSize;
        return threshold;
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Vector2 rect = calculateThreshold();
        Gizmos.DrawWireCube(transform.position + offsetPosition, new Vector3(rect.x * 2, rect.y * 2, 1));
    }
}
