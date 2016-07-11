using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyPopDatabase : ScriptableObject
{
    public List<PopEnemyTable> popEnemyDatabase = new List<PopEnemyTable>();  // 移動距離毎出現確率
}

[System.Serializable]
public class PopEnemyTable
{
    public string name;
    public List<GameObject> popEnemyObj = new List<GameObject>();
    public List<PopEnemyPercentage> popEnemyTable = new List<PopEnemyPercentage>();             // 確率
}
[System.Serializable]
public class PopEnemyPercentage
{
    public float MoveDistance;                      // 移動距離
    public List<float> late = new List<float>();    // 確率
}