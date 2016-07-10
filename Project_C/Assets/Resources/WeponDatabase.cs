using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WeponDatabase : ScriptableObject
{
    public List<Wepon> weponHeadData = new List<Wepon>();
    public List<Wepon> weponTaliData = new List<Wepon>();
    public List<Wepon> weponLegData = new List<Wepon>();
}



[System.Serializable]
public class Wepon
{
    public string Name;         // 名前
    public string explaine;     // 説明
    public int HP;              // HP
    public int Charisma;        // カリスマ
}