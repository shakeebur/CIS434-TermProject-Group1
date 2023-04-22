using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public ChessBoard board;
    private List<ChessPiece> myPieces;
    private int team;

    public Player(ChessBoard cb, int t)
    {
        board = cb;
        team = t;
        myPieces = new List<ChessPiece>();
    }

    public int getTeam()
    {
        return team;
    }

    public void setPiece(ChessPiece piece)
    {
        myPieces.Add(piece);
    }
    public void removePiece(ChessPiece piece)
    {
        myPieces.Remove(piece);
    }

    public List<ChessPiece> getPieces()
    {
        return myPieces;
    }
}
