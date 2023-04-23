using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
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
        
        // Diagonal Movements

        for(int i = 1; i <= MOVE_RANGE; i++)
        {
            // +x and +y
            Vector2Int attempt = new Vector2Int(currentX+i, currentY+i);
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
            // -x and +y
            Vector2Int attempt = new Vector2Int(currentX-j, currentY+j);
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

        for(int k = 1; k <= MOVE_RANGE; k++)
        {
            // -x and -y
            Vector2Int attempt = new Vector2Int(currentX-k, currentY-k);
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

        for(int z = 1; z <= MOVE_RANGE; z++)
        {
            // +x and -y
            Vector2Int attempt = new Vector2Int(currentX+z, currentY-z);
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

        // Horizontal and Vertical movement

        for(int m = 1; m <= MOVE_RANGE; m++)
        {
            // +x and y=0
            Vector2Int attempt = new Vector2Int(currentX+m, currentY);
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

        for(int n = 1; n <= MOVE_RANGE; n++)
        {
            // -x and y=0
            Vector2Int attempt = new Vector2Int(currentX-n, currentY);
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

        for(int p = 1; p <= MOVE_RANGE; p++)
        {
            // x=0 and +y
            Vector2Int attempt = new Vector2Int(currentX, currentY+p);
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

        for(int r = 1; r <= MOVE_RANGE; r++)
        {
            // x=0 and -y
            Vector2Int attempt = new Vector2Int(currentX, currentY-r);
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
