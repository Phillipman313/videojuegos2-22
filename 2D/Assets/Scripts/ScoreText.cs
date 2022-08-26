using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreText : MonoBehaviour
{
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>(); // Caché del objeto, getComponent posee un overhead
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(Block.Score.ToString());
    }
}
