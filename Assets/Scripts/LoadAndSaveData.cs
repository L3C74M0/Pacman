using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class LoadAndSaveData {
    
    public static void SaveData<T> (T data, string path, string fileName) {
        string fullPath = Application.persistentDataPath + "/" + path + "/";
        bool checkFolderExit = Directory.Exists(fullPath);
        if (checkFolderExit == false) {
            Directory.CreateDirectory(fullPath);
        }

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(fullPath + fileName + ".json", json);
    }
    
    public static T LoadData<T> (string path, string fileName) {
        string fullPath = Application.persistentDataPath + "/" + path + "/" + fileName + ".json";
        if (File.Exists(fullPath)) {
            string textJson = File.ReadAllText(fullPath);
            var tmp = JsonUtility.FromJson<T>(textJson);
            return tmp;
        } else {
            return default;
        }
    }
}
