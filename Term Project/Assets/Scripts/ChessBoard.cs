using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [Header("Art")]
    [SerializeField] private Material tileMaterial;
    [SerializeField] private float tileSize = 1.0f;
    [SerializeField] private float yoffset = 0.2f;
    [SerializeField] private Vector3 CenterBoard = Vector3.zero;

    [Header("Prefabs & Materials")]
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Material[] teamMaterial;

    private Color defaultColor;
    private Color hoverColor;

    private Player whitePlayer;
    private Player blackPlayer;
    private Player currentPlayer;
    private const int WHITETEAM = 0;
    private const int BLACKTEAM = 1;

    private ChessPiece[,] chessPieces;
    private ChessPiece currentyDragging;
    private const int Tile_Count_X = 8;
    private const int Tile_Count_Y = 8;
    private GameObject[,] tiles;
    private Camera currentCamera;
    private Vector2Int currentHover;
    private Vector3 bounds;

    private ChessPiece selected;
    Vector2Int hitPosition;

    // Start is called before the first frame update
   void Start()
    {
        defaultColor = tileMaterial.color;
        hoverColor = Color.red;

        startNewGame();
    }

    public void startNewGame()
    {
        whitePlayer = new Player(this, WHITETEAM);
        blackPlayer = new Player(this, BLACKTEAM);
        currentPlayer = whitePlayer;

        GenerateBoard(tileSize, Tile_Count_X, Tile_Count_Y);
        SpawnAllPiece();
        PositionAllPieces();
    }


    // Update is called once per frame
    void Update()
    {
        //Implementing turns with ai
        if(currentPlayer == blackPlayer)
        {

        }
        if(!currentCamera)
        {
            currentCamera = Camera.main;
            return;
        }

        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Tile", "Hover")))
        {
            // get info for tiles hit
            Vector2Int hitPosition = LookupTileIndex(info.transform.gameObject);

            //highlight tile that mouse is over 
            if(currentHover == -Vector2Int.one)
            {
                currentHover = hitPosition;
                tiles[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");
                tiles[hitPosition.x, hitPosition.y].GetComponent<MeshRenderer>().material.color = hoverColor;
            }
            //get rid of old highlit tile when hovering over new tile
            if(currentHover != hitPosition)
            {
                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile");
                tiles[currentHover.x, currentHover.y].GetComponent<MeshRenderer>().material.color = defaultColor;

                currentHover = hitPosition;
                tiles[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");
                tiles[hitPosition.x, hitPosition.y].GetComponent<MeshRenderer>().material.color = hoverColor;
            }

            // press down mouse button
            if (Input.GetMouseButtonDown(0))
            {
                if(chessPieces[hitPosition.x, hitPosition.y] != null)
                {
                    //is it our turn
                    if(true)
                   {
                       currentyDragging = chessPieces[hitPosition.x, hitPosition.y];
                   }
                }
                // else
                // {
                //     Capture(currentHover.x, currentHover.y);
                // }
            }
            //release mouse button
           if (currentyDragging != null && Input.GetMouseButtonUp(0))
           {
               Vector2Int previousPosition = new Vector2Int(currentyDragging.currentX, currentyDragging.currentY);

               bool validMove = MoveTo(currentyDragging, hitPosition.x, hitPosition.y);
               if (!validMove)
                {
                    currentyDragging.SetPosition(GetTileCenter(previousPosition.x, previousPosition.y));
                    currentyDragging = null;
               }
               else
               {
                currentyDragging = null;
               }
           }
        }
        
        else
        {
            if(currentHover != -Vector2Int.one)
            {
                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile");
                tiles[currentHover.x, currentHover.y].GetComponent<MeshRenderer>().material.color = defaultColor;
                
                currentHover = -Vector2Int.one;
            }
        }
        
    }




    //Create the Board
    private void GenerateBoard(float tileSize, int tileCountX, int tileCountY)
    {
        yoffset += transform.position.y;
        bounds = new Vector3((tileCountX / 2) * tileSize, 0, (tileCountX / 2) * tileSize) + CenterBoard;

        tiles = new GameObject[tileCountX, tileCountY];
        for(int x = 0; x < tileCountX; x++)
        {
            for (int y = 0; y < tileCountY; y++)
            {
                tiles[x,y] = GernerateSingleTile(tileSize, x, y);
            }
        }

    }
    
    //Gives each tile collision
    private GameObject GernerateSingleTile(float tileSize, int x, int y)
    {
        GameObject tileObject = new GameObject(string.Format("X:{0}, Y:{1}", x, y));
        tileObject.transform.parent = transform;

        Mesh mesh = new Mesh();
        tileObject.AddComponent<MeshFilter>().mesh = mesh;
        tileObject.AddComponent<MeshRenderer>().material = tileMaterial;

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(x * tileSize, yoffset, y * tileSize) - bounds;
        vertices[1] = new Vector3(x * tileSize, yoffset, (y+1) * tileSize) - bounds;
        vertices[2] = new Vector3((x+1) * tileSize, yoffset, y * tileSize) - bounds;
        vertices[3] = new Vector3((x+1) * tileSize, yoffset, (y+1) * tileSize) - bounds;

        int[] tris = new int[] {0, 1, 2, 1, 3, 2};

        mesh.vertices = vertices;
        mesh.triangles = tris;
        
        mesh.RecalculateNormals();

        tileObject.layer = LayerMask.NameToLayer("Tile");

        tileObject.AddComponent<BoxCollider>();

        return tileObject;
    }


    // Create Chess Pieces
    private void SpawnAllPiece()
    {
        chessPieces = new ChessPiece[Tile_Count_X, Tile_Count_Y];

        //White Team
        chessPieces[0,0] = SpawnSinglePiece(chessPieceType.Rook, WHITETEAM);
        chessPieces[1,0] = SpawnSinglePiece(chessPieceType.Knight, WHITETEAM);
        chessPieces[2,0] = SpawnSinglePiece(chessPieceType.Bishop, WHITETEAM);
        chessPieces[3,0] = SpawnSinglePiece(chessPieceType.Queen, WHITETEAM);
        chessPieces[4,0] = SpawnSinglePiece(chessPieceType.King, WHITETEAM);
        chessPieces[5,0] = SpawnSinglePiece(chessPieceType.Bishop, WHITETEAM);
        chessPieces[6,0] = SpawnSinglePiece(chessPieceType.Knight, WHITETEAM);
        chessPieces[7,0] = SpawnSinglePiece(chessPieceType.Rook, WHITETEAM);
        for (int i = 0; i < Tile_Count_X; i++)
        {
            chessPieces[i,1] = SpawnSinglePiece(chessPieceType.Pawn, WHITETEAM);
            whitePlayer.setPiece(chessPieces[i,0]);
            whitePlayer.setPiece(chessPieces[i,1]);
        }

        //Black Team
        chessPieces[0,7] = SpawnSinglePiece(chessPieceType.Rook, BLACKTEAM);
        chessPieces[1,7] = SpawnSinglePiece(chessPieceType.Knight, BLACKTEAM);
        chessPieces[2,7] = SpawnSinglePiece(chessPieceType.Bishop, BLACKTEAM);
        chessPieces[3,7] = SpawnSinglePiece(chessPieceType.Queen, BLACKTEAM);
        chessPieces[4,7] = SpawnSinglePiece(chessPieceType.King, BLACKTEAM);
        chessPieces[5,7] = SpawnSinglePiece(chessPieceType.Bishop, BLACKTEAM);
        chessPieces[6,7] = SpawnSinglePiece(chessPieceType.Knight, BLACKTEAM);
        chessPieces[7,7] = SpawnSinglePiece(chessPieceType.Rook, BLACKTEAM);
        for (int i = 0; i < Tile_Count_X; i++)
        {
            chessPieces[i,6] = SpawnSinglePiece(chessPieceType.Pawn, BLACKTEAM);
            blackPlayer.setPiece(chessPieces[i,7]);
            blackPlayer.setPiece(chessPieces[i,6]);
        }
    }

    private ChessPiece SpawnSinglePiece(chessPieceType type , int team)
    {
        ChessPiece cp = Instantiate(prefabs[(int)type - 1], transform).GetComponent<ChessPiece>();

        cp.type = type;
        cp.team = team;

        cp.setBoard(this);

        cp.GetComponent<MeshRenderer>().material = teamMaterial[team];

        return cp;
    } 

    //Position all pieces
    private void PositionAllPieces()
    {
        for (int x = 0; x < Tile_Count_X; x++)
        {
            for (int y = 0; y < Tile_Count_Y; y++)
            {
                if(chessPieces[x,y] != null)
                {
                    PositionSinglePiece(x, y, true);
                }
            }
        }
    }
    private void PositionSinglePiece(int x, int y, bool force = false)
    {
        chessPieces[x, y].currentX = x;
        chessPieces[x, y].currentY = y;
        chessPieces[x, y].transform.position = GetTileCenter(x,y);
    }

    private Vector3 GetTileCenter(int x, int y)
    {
        return new Vector3(x * tileSize, yoffset, y * tileSize) - bounds + new Vector3(tileSize / 2, 0, tileSize / 2);
    }
    
    private bool MoveTo(ChessPiece cp, int x, int y)
    {
     Vector2Int previousPosition = new Vector2Int(cp.currentX, cp.currentY);  

        //is there a piece on the space
        if(chessPieces[x, y] != null)
        {
            ChessPiece ocp = chessPieces[x, y];

            if(cp.team == ocp.team)
            {
                return false;
            }

            //if enemy piece
        }

     chessPieces[x, y] = cp;
     chessPieces[previousPosition.x, previousPosition.y] = null;
     PositionSinglePiece(x, y);

     passTheTurn();
     return true; 
    }
    private Vector2Int LookupTileIndex(GameObject hitInfo)
    {
        for (int x = 0; x < Tile_Count_X; x++)
        {
         for (int y = 0; y < Tile_Count_Y; y++)
         {
            if(tiles[x,y] == hitInfo)
            {
                return new Vector2Int(x, y);
            }
         }   
        }
       return -Vector2Int.one;

    }
    
    private void Capture(int x, int y)
    {
        ChessPiece piece = chessPieces[x, y];

        if(piece != null)
        {
            if(piece.team != currentPlayer.getTeam())
            {
              Destroy(piece);
              if(piece.type == chessPieceType.King)
              {
                endGame();
                return;
              }
            }
        }

        passTheTurn();
    }

    private void endGame()
    {
        if (currentPlayer == whitePlayer)
        {
            //text.Text = "White team Won!";
            Debug.Log("White team Won!");
        }
        else
        {
            //text.Text = "Black team Won!";
            Debug.Log("Black team Won!");
        }
        foreach (ChessPiece piece in chessPieces)
        {
            Destroy(piece);
        }
        SpawnAllPiece();
        SpawnAllPiece();
    }

    public void UpdateBoardAfterMove(ChessPiece piece, Vector2Int newMove, Vector2Int oldLoc)
    {
        chessPieces[oldLoc.x, oldLoc.y] = null;
        chessPieces[newMove.x, newMove.y] = piece;
    }

    public ChessPiece getPieceOnBoard(Vector2Int loc)
    {
        return chessPieces[loc.x, loc.y];
    }

    public void passTheTurn()
    {
        if(currentPlayer == whitePlayer)
        {
            currentPlayer = blackPlayer;
        }
        else
        {
            currentPlayer = whitePlayer;
        }
    }
}