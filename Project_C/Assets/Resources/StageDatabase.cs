using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageDatabase : ScriptableObject {
    public StageData[] stageData = new StageData[12];
    public EnemyPopDatabase enemyPopDatabase;
}

[System.Serializable]
public class StageData {
    public string bossName;
    public List<GameObject> BGObj = new List<GameObject>();
    public GameObject bossObj;
    public bool isClear;
}
