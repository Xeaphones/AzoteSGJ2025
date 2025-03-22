using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap collisionTilemap;

    [SerializeField]
    private string player = "PlayerX";
    private PlayerMovement controls;
    
    void Awake()
    {
        controls = new PlayerMovement();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == "Player1") {
            controls.Player1.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        } else if (player == "Player2") {
            controls.Player2.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        } else {
            Debug.LogError("Player name is not valid");
        }
    }

    private void Move(Vector2 direction) {
        if (CanMove(direction)) {
            transform.position += (Vector3)direction;
        }
    }

    private bool CanMove(Vector2 direction) {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition)) {
            return false;
        }
        return true;
    }
}
