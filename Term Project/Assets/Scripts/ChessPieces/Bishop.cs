using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
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
            // +x and +y
            Vector2Int attempt = new Vector2Int(currentX+i, currentY+i);
            if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
            {
                if(board.getPieceOnBoard(attempt).team == 1)
                    break;
                validMoves.Add(attempt);
            }
        }
        for(int j = 1; j <= MOVE_RANGE; j++)
        {
            // -x and +y
            Vector2Int attempt = new Vector2Int(currentX-j, currentY+j);
            if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
            {
                validMoves.Add(attempt);
            }
        }
        for(int k = 1; k <= MOVE_RANGE; k++)
        {
            // -x and -y
            Vector2Int attempt = new Vector2Int(currentX-k, currentY-k);
            if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
            {
                validMoves.Add(attempt);
            }
        }
        for(int z = 1; z <= MOVE_RANGE; z++)
        {
            // +x and -y
            Vector2Int attempt = new Vector2Int(currentX+z, currentY-z);
            if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
            {
                validMoves.Add(attempt);
            }
        }
        
        return validMoves;
    }
}
