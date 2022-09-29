using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    public int Lives {set; get;}
    [SerializeField] Transform CratesContainer;
    public static GameManager instance = null;
    [SerializeField] TextMeshProUGUI livesUI;
    [SerializeField] LevelLoader LevelManager;

    private int currentLevel = 1;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }
    }

    void Start(){
        Lives = 3;
        AudioManager.instance.PlayMusic(Constants.MUSIC_TRACK_1_SFX);
         livesUI.text = "Lives: "+ Lives;
    }

    void Update(){
        if(CratesContainer.childCount == 0){
            Debug.Log("Gano :)");
            currentLevel++;
            LevelManager.LoadLevel("Assets/Levels/Level"+currentLevel+".txt");
        }
        if(Lives <= 0){
            Debug.Log("Perdió :(");
        }
    }

    public void UpdateLives(int lives){
        Lives = lives;
        livesUI.text = "Lives: "+ lives;
    }



}
