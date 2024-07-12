using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeCutterNatashaPiece : PawnPiece
{
    override public void PossibleMoves(MoveCheckType moveCheckType)
    {
        if (direction == "up")
        {
            var tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(0, 1));
            if (tempTile != null) { 
                if (tempTile.CanMoveTo(this) == 1 && moveCheckType == MoveCheckType.Move){
                    tempTile.PossibleMove();
                }else if (tempTile.CanMoveTo(this) == 2 && moveCheckType == MoveCheckType.Move){
                    tempTile.PossibleCapture();
                }
            }

            //up-right
            tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(1, 1));
            if (tempTile != null)
            {
                if (tempTile.CanMoveTo(this) == 2)
                { //Enemy piece
                    if (moveCheckType == MoveCheckType.Move)
                    {
                        tempTile.PossibleCapture();
                    }
                    else if (moveCheckType == MoveCheckType.Cover)
                    {
                        tempTile.CoveredTile();
                    }
                }
            }

            //up-left
            tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(-1, 1));
            if (tempTile != null)
            {
                if (tempTile.CanMoveTo(this) == 2)
                { //Enemy piece
                    if (moveCheckType == MoveCheckType.Move)
                    {
                        tempTile.PossibleCapture();
                    }
                    else if (moveCheckType == MoveCheckType.Cover)
                    {
                        tempTile.CoveredTile();
                    }
                }
            }
        }
        else if (direction == "down")
        {
            var tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(0, -1));
            if (tempTile != null) {
                if (tempTile.CanMoveTo(this) == 1 && moveCheckType == MoveCheckType.Move)
                {
                    tempTile.PossibleMove();
                }
                else if (tempTile.CanMoveTo(this) == 2 && moveCheckType == MoveCheckType.Move)
                {
                    tempTile.PossibleCapture();
                }
            }

            //down-right
            tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(1, -1));
            if (tempTile != null)
            {
                if (tempTile.CanMoveTo(this) == 2)
                { //Enemy piece
                    if (moveCheckType == MoveCheckType.Move)
                    {
                        tempTile.PossibleCapture();
                    }
                }
                else if (moveCheckType == MoveCheckType.Cover)
                {
                    tempTile.CoveredTile();
                }
            }

            //down-left
            tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(-1, -1));
            if (tempTile != null)
            {
                if (tempTile.CanMoveTo(this) == 2)
                { //Enemy piece
                    if (moveCheckType == MoveCheckType.Move)
                    {
                        tempTile.PossibleCapture();
                    }
                }
                else if (moveCheckType == MoveCheckType.Cover)
                {
                    tempTile.CoveredTile();
                }
            }

        }
    }
}
