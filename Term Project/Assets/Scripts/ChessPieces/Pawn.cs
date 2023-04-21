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

    public override List<Vector2Int> findValidMoves()
    {
        validMoves.Clear();

        // y = +1, x = +0
        Vector2Int attempt = new Vector2Int(currentX, currentY+1);
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            validMoves.Add(attempt);
        }

        // These moves need to be limited to 

        // y = +1, x = +1
        attempt.x = currentX+1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            validMoves.Add(attempt);
        }
        // y = +1, x = -1
        attempt.x = currentX-1;
        if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
        {
            validMoves.Add(attempt);
        }
        return validMoves;
    }
}
