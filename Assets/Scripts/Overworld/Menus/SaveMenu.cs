using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Leguar.TotalJSON;

public class SaveMenu : MonoBehaviour
{
    private SaveData saveData;
    private string filePath = Application.persistentDataPath + ".json";
    private JSON json = new JSON();

    void Start() {
        createFile();
        readFile();
    }

    public JSON saveToJSON()
    {
        return JSON.Serialize(saveData);
    }

    public void onSaveClick() {
        json = saveToJSON();
    }

    private void createFile() {
        if (!File.Exists(filePath)) {
            File.Create(filePath).Close();
        }
    }

    private void readFile() {
        using (StreamReader reader = new StreamReader(filePath)) {
            while (!reader.EndOfStream) { // until done
                //keep reading
            } 
        }
    }

    public void writeFile(JSON json) {
        using (StreamWriter writer = new StreamWriter(filePath)) {
            writer.WriteLine(json.ToString());
        }
    }
}
