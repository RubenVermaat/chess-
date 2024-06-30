using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BishopPiece : Piece
{
    override public void PossibleMoves(MoveCheckType moveCheckType)
    {
        //Up-right
        List<Vector2> directions = new List<Vector2>()
        {
            new Vector2(1, 1), new Vector2(1, -1), new Vector2(-1, 1), new Vector2(-1, -1)
        };

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
