using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameSetupManager : MonoBehaviour
{
    private PiecesManager piecesManager;
    private PlayerManager playerManager;

    void Start(){
        piecesManager = FindObjectOfType<PiecesManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        foreach (Player player in playerManager.GetPlayers){
            PlacePieces(player);
        }
    }
    public void PlacePieces(Player player){
        foreach (var piece in player.GetDeck.cards)
        {
            piecesManager.PlaceStartPiece(piece, player.GetTeam);
        }
    }
}