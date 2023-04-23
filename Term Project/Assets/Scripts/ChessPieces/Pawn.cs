using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void blackMoves()
    {
        validMoves.Clear();

        // y = -1, x = +0
        Vector2Int attempt = new Vector2Int(currentX, currentY-1);
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(inTheWay(attempt) || enemyPiece(attempt)){}
            else { validMoves.Add(attempt); }   
        }

        // If this pawn has not been moved yet this game, it can move 2 spaces forward

        if(!hasMoved())
        {
            // y-2, x=0
            attempt.x = currentX;
            attempt.y = currentY-2;
            if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
            {
                if(inTheWay(new Vector2Int(currentX, currentY-1)) || inTheWay(attempt) || enemyPiece(attempt)
                    || enemyPiece(new Vector2Int(currentX, currentY-1))){}
                else { validMoves.Add(attempt); }   
            }
        }

        // Pawn can move diagonally only to capture an enemy piece

        // y = -1, x = +1
        attempt.x = currentX+1;
        attempt.y = currentY-1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(enemyPiece(attempt)){ validMoves.Add(attempt); }
        }
        // y = -1, x = -1
        attempt.x = currentX-1;
        attempt.y = currentY-1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(enemyPiece(attempt)){ validMoves.Add(attempt); }
        }
    }

    private void whiteMoves()
    {
        validMoves.Clear();

        // y = +1, x = +0
        Vector2Int attempt = new Vector2Int(currentX, currentY+1);
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(inTheWay(attempt) || enemyPiece(attempt)){}
            else { validMoves.Add(attempt); }   
        }

        // If this pawn has not been moved yet this game, it can move 2 spaces forward

        if(!hasMoved())
        {
            attempt.x = currentX;
            attempt.y = currentY+2;
            if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
            {
                if(inTheWay(new Vector2Int(currentX, currentY+1)) || inTheWay(attempt) || enemyPiece(attempt)
                    || enemyPiece(new Vector2Int(currentX , currentY+1))){}
                else { validMoves.Add(attempt); }   
            }
        }

        // Pawn can move diagonally only to capture an enemy piece

        // y = +1, x = +1
        attempt.x = currentX+1;
        attempt.y = currentY+1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(enemyPiece(attempt)){ validMoves.Add(attempt); }
        }
        // y = +1, x = -1
        attempt.x = currentX-1;
        attempt.y = currentY+1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(enemyPiece(attempt)){ validMoves.Add(attempt); }
        }
    }

    public override List<Vector2Int> findValidMoves()
    {
        if(team == 0){ whiteMoves(); }
        else if (team == 1){ blackMoves(); }
        else { return null; }
        return validMoves;
    }
}
