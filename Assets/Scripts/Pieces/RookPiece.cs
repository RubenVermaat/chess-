using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RookPiece : Piece
{
    override public void PossibleMoves(MoveCheckType moveCheckType)
    {
        var directions = new List<Vector2>() { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
        foreach (var direction in directions)
        {
            for (int i = 1; i < 8; i++)
            {
                var tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition((int)(direction.x * i), (int)(direction.y * i)));
                if (tempTile != null)
                {
                    if (tempTile.CanMoveTo(this) == 0)
                    { //Different / own piece
                        break;
                    }
                    else if (tempTile.CanMoveTo(this) == 1)
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
                }
            }
        }
    }
}
