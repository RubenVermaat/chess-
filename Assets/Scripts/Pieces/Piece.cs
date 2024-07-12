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
    protected GameManager gameManager;
    protected string pieceID;
    protected string wavePiece;
    protected string direction = "up";
    protected bool firstMove = true;
    protected int possibleMoves;
    public void Start(){
        gridManager = FindObjectOfType<GridManager>();
        gameManager = FindObjectOfType<GameManager>();
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
        if (newSprite == null)
        {
            newSprite = Resources.Load<Sprite>("Textures/Pieces/Team_" + GetTeam + "_Unkown");
            Debug.LogError("Sprite not found at the specified path: " + "Textures/Pieces/" + wavePiece + "/Team_" + GetTeam + "/Piece-" + pieceID);
        }
        GetComponent<SpriteRenderer>().sprite = newSprite;
        transform.localScale = new Vector3(0.7f, 0.7f);
    }
    public virtual void Moved(){
        //This runs when the piece is moved
        if (firstMove){
            firstMove = false;
        }
    }
}