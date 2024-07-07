using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KingPiece : Piece
{
    public bool CanMove(){
        possibleMoves = 0;
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                var tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(x, y));
                if (tempTile != null)
                {
                    if (tempTile.CanMoveTo(this) == 1)
                    { //No piece
                        if (!tempTile.Covered){
                            return true;
                        }
                    }
                    else if (tempTile.CanMoveTo(this) == 2)
                    { //Enemy piece
                        return true;
                    }
                }
            }
        }
        return false;
    }
    override public void PossibleMoves(MoveCheckType moveCheckType)
    {
        possibleMoves = 0;
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                var tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(x, y));
                if (tempTile != null){
                    if (tempTile.CanMoveTo(this) == 1)
                    { //No piece
                        if (moveCheckType == MoveCheckType.Move)
                        {
                            possibleMoves++;
                            tempTile.PossibleMove();
                        }
                        else if (moveCheckType == MoveCheckType.Cover)
                        {
                            tempTile.CoveredTile();
                        }
                    }
                    else if (tempTile.CanMoveTo(this) == 2)
                    { //Enemy piece
                        if (moveCheckType == MoveCheckType.Move)
                        {
                            tempTile.PossibleCapture();
                        }
                        else if (moveCheckType == MoveCheckType.Cover)
                        {
                            tempTile.CoveredTile();
                        }
                        break;
                    }
                }
            }
        }
    }
}
