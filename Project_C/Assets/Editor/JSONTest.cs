using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

[System.Serializable]
public class SaveData {
    public int selectStage;     // 選択したステージ番号
    public int weaponHead;      // 頭装備
    public int weaponBody;      // 体装備
    public int weaponLeg;      // 脚装備
    public List<int> frends = new List<int>();
}

public class JSONTest : MonoBehaviour {

    static SaveData saveData;

    public static void Save()
    {
        // Jsonのデータ形式に変換
        string json = JsonUtility.ToJson(saveData);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveData.json");
    }

    public static void Load()
    {

    }
}
