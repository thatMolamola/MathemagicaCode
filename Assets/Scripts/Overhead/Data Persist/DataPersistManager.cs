using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistManager : MonoBehaviour
{

    private GameData gameData;
    public static DataPersistManager instance { get; private set;}

    private void Start() {
        LoadGame();
    }
    
    private void Awake() {
        if (instance != null) {
            Debug.LogError ("Found more than one Data Persist Manager");
        }
        instance = this;
    }
    
    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){
        if (this.gameData == null){
            Debug.Log("No data was found");
            NewGame();
        }
    }

    public void SaveGame() {

    }
}
