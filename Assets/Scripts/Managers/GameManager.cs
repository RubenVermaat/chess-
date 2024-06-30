using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int turnOff = 1;
    private PlayerManager playerManager;
    private GridManager gridManager;

    public void Start(){
        playerManager = FindObjectOfType<PlayerManager>();
        gridManager = FindObjectOfType<GridManager>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            gridManager.ResetTiles();
        }
    }

    public void NextTurn()
    {
        CheckCheck();
        if (turnOff == playerManager.GetPlayers.Count){
            turnOff = 1;
        }else{
            turnOff++;
        }
        CheckCheck();
    }

    public void CheckCheck(){
        foreach (var tile in gridManager.GetTiles.Values)
        {
            if (tile.GetPiece() != null)
            {
                var piece = tile.GetPiece();
                if (piece.GetComponent<Piece>().GetTeam != turnOff) //All the enemy pieces
                {
                    if(piece.GetComponent<Piece>() != null){
                        piece.GetComponent<Piece>().PossibleMoves(MoveCheckType.Cover);
                    }
                }
            }
        }
        foreach (var tile in gridManager.GetTiles.Values)
        {
            if (tile.GetPiece() != null)
            {
                if (tile.Covered){
                    var piece = tile.GetPiece();
                    if (piece.GetComponent<KingPiece>() != null) //All the enemy pieces
                    {
                        Debug.Log("Check! " + turnOff);
                    }
                }
            }
        }
        gridManager.ResetTiles();
    }
}