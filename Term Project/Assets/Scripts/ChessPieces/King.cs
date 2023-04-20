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
        validMoves.Add(new Vector2Int(currentX,currentY) + new Vector2Int(0,1));
        return validMoves;
    }
}
