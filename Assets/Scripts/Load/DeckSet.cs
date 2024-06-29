using System.Collections.Generic;
[System.Serializable]
public class Deck
{
    public string name;
    public List<StartPiece> cards;
}
[System.Serializable]
public class StartPiece
{
    public string id;
    public string x;
    public string y;
}

