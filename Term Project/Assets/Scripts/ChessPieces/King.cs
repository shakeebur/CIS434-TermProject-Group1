using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public override List<Vector2Int> findValidMoves()
    {
        validMoves.Clear();

         // x=0 and y+1
        Vector2Int attempt = new Vector2Int(currentX, currentY+1);
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            // TODO: add in a check here for other pieces in the way
            validMoves.Add(attempt);
        }

        // x+1 , y+1
        attempt.x = currentX+1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            // TODO: add in a check here for other pieces in the way
            validMoves.Add(attempt);
        }

        // x+1 and y=0
        attempt.y = currentY;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            // TODO: add in a check here for other pieces in the way
            validMoves.Add(attempt);
        }

        // x+1 , y-1
        attempt.y = currentY-1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            // TODO: add in a check here for other pieces in the way
            validMoves.Add(attempt);
        }

        // x=0 , y-1
        attempt.x = currentX;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            // TODO: add in a check here for other pieces in the way
            validMoves.Add(attempt);
        }

        // x-1 , y-1
        attempt.x = currentX-1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            // TODO: add in a check here for other pieces in the way
            validMoves.Add(attempt);
        }

        // x-1 , y=0
        attempt.y = currentY;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            // TODO: add in a check here for other pieces in the way
            validMoves.Add(attempt);
        }

        // x-1 , y+1
        attempt.y = currentY+1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            // TODO: add in a check here for other pieces in the way
            validMoves.Add(attempt);
        }

        return validMoves;
    }
}
