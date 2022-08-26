using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;

    private float startY;
    public static int Score = 0;

    void Start(){
        startY = transform.position.y;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if(transform.position.x <= -10f){

            float yPos = startY + UnityEngine.Random.Range(-1f,1f);
            transform.position = new Vector3(transform.position.x + 21f, yPos, transform.position.z);
            moveSpeed += 0.06f;
            Score++;
        }
    }

}
