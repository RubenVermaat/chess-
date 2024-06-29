using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PiecesManager : MonoBehaviour
{
    [SerializeField] List<Card> pieces;
    private GridManager gridManager;

    void Start(){
        gridManager = FindObjectOfType<GridManager>();
        LoadPieces();
    }
    public void LoadPieces()
    {
        string filePath = "Assets/Json/PiecesWave_1.json";
        string json = File.ReadAllText(filePath);
        Wave pieceWave = JsonUtility.FromJson<Wave>(json);
        
        foreach (var card in pieceWave.cards)
        {
            card.wave = pieceWave.id;
            pieces.Add(card);
        }
    }

    public Card GetPiece(string id){
        return pieces.Find(x => x.id == id);
    }

    public void PlaceStartPiece(StartPiece startPiece, int team)
    {
        var piece = GetPiece(startPiece.id);
        gridManager.PlaceStartPiece(piece, new Vector2(int.Parse(startPiece.x), int.Parse(startPiece.y)), team);
    }
}