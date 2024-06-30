using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BishoooopPiece : BishopPiece
{
    override public void PossibleMoves(MoveCheckType moveCheckType)
    {
        base.PossibleMoves(moveCheckType);
        //Can move one forward
        if (direction == "up")
        {
            var tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(0, 1));
            if (tempTile != null) { if (tempTile.CanMoveTo(this) == 1 && moveCheckType == MoveCheckType.Move) { tempTile.PossibleMove(); } }
        }
        else if (direction == "down")
        {
            var tempTile = gridManager.GetTileAtPosition(tile.GetVectorPosition(0, -1));
            if (tempTile != null) { if (tempTile.CanMoveTo(this) == 1 && moveCheckType == MoveCheckType.Move) { tempTile.PossibleMove(); } }
        }
    }
}
