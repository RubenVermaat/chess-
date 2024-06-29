using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;
[System.Serializable]
public class Wave
{
    public string name;
    public string id;
    public List<Card> cards;
}
[System.Serializable]
public class Card
{
    public string id;
    public string name;
    public string type;
    public string wave;
}

