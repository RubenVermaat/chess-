using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPiece : Piece
{

    override public void PossibleMoves(MoveCheckType moveCheckType)
    {
        if (direction == "up"){
            var tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(0, 1));
            if (tempTile != null) { if (tempTile.CanMoveTo(this) == 1 && moveCheckType == MoveCheckType.Move) { tempTile.PossibleMove(); } }

            //up-right
            tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(1, 1));
            if (tempTile != null) {
                if (tempTile.CanMoveTo(this) == 2)
                { //Enemy piece
                    if (moveCheckType == MoveCheckType.Move)
                    {
                        tempTile.PossibleMove();
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
                        tempTile.PossibleMove();
                    }
                    else if (moveCheckType == MoveCheckType.Cover)
                    {
                        tempTile.CoveredTile();
                    }
                }
            }
        }
        else if (direction == "down"){
            var tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(0, -1));
            if (tempTile != null) { if (tempTile.CanMoveTo(this) == 1 && moveCheckType == MoveCheckType.Move) { tempTile.PossibleMove(); } }

            //down-right
            tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(1, -1));
            if (tempTile != null)
            {
                if (tempTile.CanMoveTo(this) == 2)
                { //Enemy piece
                    if (moveCheckType == MoveCheckType.Move)
                    {
                        tempTile.PossibleMove();
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
                        tempTile.PossibleMove();
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
