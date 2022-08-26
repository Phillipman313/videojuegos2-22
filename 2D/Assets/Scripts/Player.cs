using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
   
    [SerializeField] Vector2 jump = Vector2.up; // new Vector2 (0,1);
    Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            rb.velocity = jump;
        }     
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other.name);
        if(other.CompareTag("Death")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
