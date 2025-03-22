using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap collisionTilemap;

    private PlayerInput playerInput;
    [SerializeField]
    private Vector3Int cursorPosition;
    
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.neverAutoSwitchControlSchemes = false;
        
        cursorPosition = groundTilemap.WorldToCell(transform.position);
        transform.position = groundTilemap.GetCellCenterWorld(cursorPosition);
    }

    void OnMovement(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();

        var device = playerInput.devices.Count > 0 ? playerInput.devices[0] : null;
        if (device is Gamepad gp)
        {
            // We can see the actual deviceId
            Debug.Log($"Movement from Gamepad deviceId={gp.deviceId}");
        }

        Move(direction);
    }

    private void Move(Vector2 direction) {
        if (CanMove(direction)) {
           cursorPosition += new Vector3Int((int)direction.x, (int)direction.y, 0);
           transform.position = groundTilemap.GetCellCenterWorld(cursorPosition);            
            
        }
    }

    private bool CanMove(Vector2 direction) {
        Vector3Int gridPosition = groundTilemap.WorldToCell(cursorPosition + new Vector3Int((int)direction.x, (int)direction.y, 0));
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition)) {
            return false;
        }
        return true;
    }
}
