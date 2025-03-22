using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using UnityEditor.Compilation;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Tilemap groundTilemap;
    private PlayerInput playerInput;
    [SerializeField]
    private Vector3Int cursorPosition;

    [SerializeField] GameObject unit1;
    [SerializeField] GameObject unit2;
    [SerializeField] GameObject unit3;
    [SerializeField] GameObject unit4;
    [SerializeField] public int maxActionPts; 
    [SerializeField] private float actionPts;

    
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.neverAutoSwitchControlSchemes = false;
        
        cursorPosition = groundTilemap.WorldToCell(transform.position);
        transform.position = groundTilemap.GetCellCenterWorld(cursorPosition);
    }

    void Update()
    {
        if (actionPts < maxActionPts)
        {
            actionPts += Time.deltaTime;
        }
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
        // Compute the *new cell position* we want to move to
        Vector3Int targetCell = cursorPosition 
            + new Vector3Int((int)direction.x, (int)direction.y, 0);
        
        // Now check if groundTilemap has a tile at targetCell
        // and collisionTilemap does not have one
        if (!groundTilemap.HasTile(targetCell)){
            return false;
        }
        return true;
    }

    private void OnAbility1(InputValue value)
    {
        CreateUnit(unit1);
    }

    private void OnAbility2(InputValue value)
    {
        CreateUnit(unit2);
    }
    private void OnAbility3(InputValue value)
    {
        CreateUnit(unit3);
    }
    private void OnAbility4(InputValue value)
    {
        CreateUnit(unit4);
    }

    private void CreateUnit(GameObject obj)
    {
        Unit sampleUnit = obj.GetComponent<Unit>();
        
        // Check that there are no incompatble unit on the current tile
        Unit[] units = FindObjectsByType<Unit>(FindObjectsSortMode.None);
        foreach(Unit unit in units)
        {
            if (unit.transform.position == transform.position)
            {
                if (!sampleUnit.isStackable)
                {
                    Debug.Log("Cannot put multiple unstackable unit on the same tile");
                    return;
                }
                else if (sampleUnit.GetType() == typeof(Fire) & !unit.isFlamable)
                {
                    Debug.Log("Cannot put fire : inplace unit is not flamable");
                    return;
                }
                else if (sampleUnit.GetType() == unit.GetType())
                {
                    Debug.Log("Cannot stack unit on top of same unit type");
                    return;
                }
                break;
            }
        }

        // Check if the player has enough action points
        if (sampleUnit.cost < actionPts)
        {
            GameObject newObject = Instantiate (obj, transform.position, transform.rotation);
            Unit unit = newObject.GetComponent<Unit>();
            Debug.Log("Instance created");
            actionPts -= sampleUnit.cost;
        }
        else
        {
            Debug.Log("Not enough action points");
            Debug.Log(actionPts);
        }
        
    }
}
