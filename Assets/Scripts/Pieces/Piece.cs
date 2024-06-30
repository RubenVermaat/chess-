using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveCheckType
{
    Move,
    Cover
}

public class Piece : MonoBehaviour
{
    [SerializeField] private int team = 0;
    [SerializeField] protected Tile tile;
    protected GridManager gridManager;
    protected string pieceID;
    protected string wavePiece;
    protected string direction = "up";
    protected bool firstMove = true;
    public void Start(){
        gridManager = FindObjectOfType<GridManager>();
    }
    public void SetTile(Tile tile) => this.tile = tile;
    public void SetTeam(int team) => this.team = team;
    public void SetID(string id) => pieceID = id;
    public void SetWave(string wave) => wavePiece = wave;
    public void SetDirection(string direction) => this.direction = direction;
    public string GetDirection => direction;
    public int GetTeam => team;
    public virtual void PossibleMoves(MoveCheckType moveCheckType) {}
    public virtual void Cover() {}
    public virtual void Setup()
    {
        Sprite newSprite = Resources.Load<Sprite>("Textures/Pieces/" + wavePiece + "/Team_" + GetTeam + "/Piece-" + pieceID);
        if (newSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        else
        {
            Debug.LogError("Sprite not found at the specified path: " + "Textures/Pieces/" + wavePiece + "/Team_" + GetTeam + "/Piece-" + pieceID);
        }
        transform.localScale = new Vector3(0.7f, 0.7f);
    }
    public virtual void Moved(){
        //I run when the piece has moved
        if (firstMove){
            firstMove = false;
        }
    }
}