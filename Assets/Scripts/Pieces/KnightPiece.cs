using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightPiece : Piece
{
    override public void PossibleMoves(MoveCheckType moveCheckType)
    {
        foreach (var pos in new Vector2[] { new Vector2(1, 2), new Vector2(-1, 2), new Vector2(2, 1), new Vector2(2, -1), new Vector2(1, -2), new Vector2(-1, -2), new Vector2(-2, 1), new Vector2(-2, -1) })
        {
            var tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition((int)pos.x, (int)pos.y));
            if (tempTile != null){
                if (tempTile.CanMoveTo(this) == 1)
                { //No piece
                    if (moveCheckType == MoveCheckType.Move)
                    {
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
                        tempTile.PossibleMove();
                    }
                    else if (moveCheckType == MoveCheckType.Cover)
                    {
                        tempTile.CoveredTile();
                    }
                }
            }
        }
    }
}
