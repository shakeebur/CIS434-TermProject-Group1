using UnityEngine;

public class PawnController : MonoBehaviour
{
    // The speed at which the pawn moves
    public float moveSpeed = 2f;

    // The position to move the pawn to
    private Vector3 targetPosition;

    void Start()
    {
        // Set the target position to the pawn's initial position
        targetPosition = transform.position;
    }

    void Update()
    {
        // If the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from the mouse position to the chessboard
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // If the hit object is a chessboard tile
                if (hit.collider.tag == "ChessTile")
                {
                    // Move the pawn to the center of the tile
                    targetPosition = hit.collider.transform.position;
                    targetPosition.y = transform.position.y;
                }
            }
        }

        // Move the pawn towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
