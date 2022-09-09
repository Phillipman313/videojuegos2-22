using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    
    [SerializeField] float screenSizeUnit = 17.76f;
    [SerializeField] float minX = 0;
    [SerializeField] float maxX = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener el punto en pantalla del Mouse
        //Debug.Log("Posición es X: " +  Input.mousePosition.x);

        // Cómo normalizamos?
        //Debug.Log("Posición relativa a la pantalla " + Input.mousePosition.x/Screen.width * screenSizeUnit);

        float paddlePos = Input.mousePosition.x / Screen.width * screenSizeUnit;
        //transform.position = new Vector2(paddlePos, transform.position.y);
        
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        position.x = Mathf.Clamp(paddlePos, minX, maxX);
        transform.position = position;
    }
}
