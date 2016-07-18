using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GameProgressionData : ScriptableObject {

//    public int selectStage;     // 選択したステージ番号
    public int weaponHead;      // 頭装備
    public int weaponBody;      // 体装備
    public int weaponLeg;      // 脚装備
    public List<int> frends = new List<int>();
}
