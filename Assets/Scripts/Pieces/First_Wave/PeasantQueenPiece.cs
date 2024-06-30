using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeasantQueenPiece : QueenPiece
{
    override public void PossibleMoves(MoveCheckType moveCheckType)
    {
       base.PossibleMoves(moveCheckType);
    }
}
