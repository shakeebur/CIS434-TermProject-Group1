using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
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

        // y = +2, x = +1
        Vector2Int attempt = new Vector2Int(currentX+1, currentY+2);
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(!inTheWay(attempt))
                validMoves.Add(attempt);
        }

        // y = +2, x = -1
        attempt.x = currentX-1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(!inTheWay(attempt))
                validMoves.Add(attempt);
        }

        // y = +1, x = +2
        attempt.x = currentX+2;
        attempt.y = currentY+1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(!inTheWay(attempt))
                validMoves.Add(attempt);
        }

        // y = -1, x = +2
        attempt.y = currentY-1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(!inTheWay(attempt))
                validMoves.Add(attempt);
        }
        //
        // y = -2, x = +1
        attempt.y = currentY-2;
        attempt.x = currentX+1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(!inTheWay(attempt))
                validMoves.Add(attempt);
        }

        // y = -2, x = -1
        attempt.x = currentX-1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(!inTheWay(attempt))
                validMoves.Add(attempt);
        }

        // y = +1, x = -2
        attempt.x = currentX-2;
        attempt.y = currentY+1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(!inTheWay(attempt))
                validMoves.Add(attempt);
        }

        // y = -1, x = -2
        attempt.y = currentY-1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            if(!inTheWay(attempt))
                validMoves.Add(attempt);
        }

        return validMoves;
    }
}
