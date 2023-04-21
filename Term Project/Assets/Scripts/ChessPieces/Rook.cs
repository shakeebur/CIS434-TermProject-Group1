using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        findValidMoves();
    }

    public override List<Vector2Int> findValidMoves()
    {
        validMoves.Clear();

        for(int i = 1; i <= MOVE_RANGE; i++)
        {
            // +x and y=0
            Vector2Int attempt = new Vector2Int(currentX+i, currentY);
            if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
            {
                validMoves.Add(attempt);
            }

            // -x and y=0
            attempt.x = currentX-i;
            if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
            {
                validMoves.Add(attempt);
            }

            // x=0 and +y
            attempt.x = currentX;
            attempt.y = currentY+i;
            if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
            {
                validMoves.Add(attempt);
            }

            // x=0 and -y
            attempt.y = currentY-i;
            if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
            {
                validMoves.Add(attempt);
            }
        }

        return validMoves;
    }
}
