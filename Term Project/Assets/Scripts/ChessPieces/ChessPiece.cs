using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum chessPieceType
{
    None = 0,
    Pawn = 1,
    Rook = 2,
    Knight = 3,
    Bishop = 4,
    Queen = 5,
    King = 6
}

public abstract class ChessPiece : MonoBehaviour
{
    public abstract List<Vector2Int> findValidMoves();

    public const int MOVE_RANGE = 7;

    public chessPieceType type;

    // White = 0, Black = 1
    public int team;

    public int currentX;
    public int currentY;
    public List<Vector2Int> validMoves;
    private bool hasBeenMoved;
    
    public ChessBoard board;

    //private Vector3 desiredPosition;
    //private Vector3 desiredScale;

    private void Awake()
    {
        set_hasBeenMoved(false);
        validMoves = new List<Vector2Int>();
    }

    public void setBoard(ChessBoard board)
    {
        this.board = board;
    }

    public bool hasMoved()
    {
        return hasBeenMoved;
    }
    private void set_hasBeenMoved(bool x)
    {
        hasBeenMoved = x;
    }

    public void move(Vector2Int location)
    {
        Vector2Int old_loc = new Vector2Int(currentX, currentY);

        currentX = location.x;
        currentY = location.y;

        board.UpdateBoardAfterMove(this, location, old_loc);

        set_hasBeenMoved(true);
    }

    public bool enemyPiece(Vector2Int loc)
    {
        ChessPiece piece = this.board.getPieceOnBoard(new Vector2Int(loc.x, loc.y));
        if(piece)
        {
            if(piece.team != this.team)
            {
                return true;
            }
        }
        return false;
    }

    public bool inTheWay(Vector2Int loc)
    {
        ChessPiece piece = this.board.getPieceOnBoard(new Vector2Int(loc.x, loc.y));
        if(piece)
        {
            if(piece.team == this.team)
            {
                return true;
            }
        }
        return false;
    }
}
