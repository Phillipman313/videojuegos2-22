using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("En Método Start " + this.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("En Método Update "+ this.gameObject.name);
    }
}
