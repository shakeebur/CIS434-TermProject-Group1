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
                // check here for other pieces in the way
                if(inTheWay(attempt))
                {
                    break;
                }
                if(enemyPiece(attempt))
                {
                    validMoves.Add(attempt);
                    break;
                }
                validMoves.Add(attempt);
            }
        }

        for(int j = 1; j <= MOVE_RANGE; j++)
        {
            // -x and y=0
           Vector2Int attempt = new Vector2Int(currentX-j, currentY);
            if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
            {
                if(inTheWay(attempt))
                {
                    break;
                }
                if(enemyPiece(attempt))
                {
                    validMoves.Add(attempt);
                    break;
                }
                validMoves.Add(attempt);
            }
        }

        for(int k = 1; k <= MOVE_RANGE; k++)
        {
            // x=0 and +y
            Vector2Int attempt = new Vector2Int(currentX, currentY+k);
            if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
            {
                if(inTheWay(attempt))
                {
                    break;
                }
                if(enemyPiece(attempt))
                {
                    validMoves.Add(attempt);
                    break;
                }
                validMoves.Add(attempt);
            }
        }

        for(int z = 1; z <= MOVE_RANGE; z++)
        {
            // x=0 and -y
            Vector2Int attempt = new Vector2Int(currentX, currentY-z);
            if((attempt.x >= 0 && attempt.y >= 0) && (attempt.x <= MOVE_RANGE && attempt.y <= MOVE_RANGE))
            {
                if(inTheWay(attempt))
                {
                    break;
                }
                if(enemyPiece(attempt))
                {
                    validMoves.Add(attempt);
                    break;
                }
                validMoves.Add(attempt);
            }
        }

        return validMoves;
    }
}
