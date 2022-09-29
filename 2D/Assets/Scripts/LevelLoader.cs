using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelLoader : MonoBehaviour
{

    // Punto Inicio
    [SerializeField] Transform StartingPoint;
    // Prefab  de las cajas
    [SerializeField] GameObject Block;
    // Referencia al contenedor
    [SerializeField] Transform BlocksContainer;
    // xMov yMov
    [SerializeField] float xMovement = 2f;
    [SerializeField] float yMovement = -2f;

    // Start is called before the first frame update
    void Start()
    {
       LoadLevel("Assets/Levels/Level1.txt");
        // XXXX
        // X X X
    }

    public void LoadLevel(string levelPath){
        string data = LoadLevelFile(levelPath);
        string [] line = data.Split("\n");
        Vector2 position = StartingPoint.position;
        int count = 1;
        for (int i = 0 ; i < line.Length; i++){ // Representa las filas
            for(int j = 0; j < line[i].Length; j++){ // Representa las columnas
                if(line[i][j] == 'X'){
                    GameObject element = GameObject.Instantiate(Block);
                    //element.transform.position = position;
                    StartCoroutine(AnimateToPosition(element, position));
                    
                    element.name = "Block " + count;
                    count++;
                    element.transform.SetParent(BlocksContainer);  
                }
                position.x += xMovement;
            }
            position.y  += yMovement;
            position.x = StartingPoint.position.x;
        }
    }

    IEnumerator AnimateToPosition(GameObject obj, Vector2 position){
        Transform objTransform = obj.transform;
        while(obj != null && Vector2.Distance(objTransform.position, position) > 0.1f ){
            objTransform.position = Vector2.Lerp(objTransform.position, position, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }



   
    public string LoadLevelFile(string path){
        string data = "";
        try{
            using(StreamReader sr = new StreamReader(path)){
                string line;
                while((line = sr.ReadLine()) != null){
                    data += line + "\n";
                }
            }
        }
        catch(IOException e){
            Debug.LogError("File not found: "+ e);
        }
        return data;
    }

}
