using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using UnityEditor.Compilation;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap effectTilemap;
    private PlayerInput playerInput;
    [SerializeField]
    private Vector3Int cursorPosition;

    private bool hasUsedMonsoon = false;

    [SerializeField] GameObject unit1;
    [SerializeField] GameObject unit2;
    [SerializeField] GameObject unit3;
    [SerializeField] GameObject unit4;
    [SerializeField] public int maxActionPts; 
    [SerializeField] private float actionPts;

    public int currentAction;
    
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
        currentAction = 1;
    }

    private void OnAbility2(InputValue value)
    {
        CreateUnit(unit2);
        currentAction = 2;
    }
    private void OnAbility3(InputValue value)
    {
        CreateUnit(unit3);
        currentAction = 3;
    }
    private void OnAbility4(InputValue value)
    {
        CreateUnit(unit4);
        currentAction = 4;
    }

    private void CreateUnit(GameObject obj)
    {
        Unit sampleUnit = obj.GetComponent<Unit>();
        
        // Check that there are no incompatble unit on the current tile
        Unit[] units = FindObjectsByType<Unit>(FindObjectsSortMode.None);
        bool canSetFire = false;

        foreach(Unit unit in units)
        {
            if (unit.transform.position == transform.position & sampleUnit.GetType() != typeof(Monsoon))
            {
                // if (!sampleUnit.isStackable)
                // {
                //     Debug.Log("Cannot put multiple unstackable unit on the same tile");
                //     return;
                // }
                // else if (sampleUnit.GetType() == typeof(Fire) & !unit.isFlamable)
                // {
                //     Debug.Log("Cannot put fire : inplace unit is not flamable");
                //     return;
                // }
                // else if (sampleUnit.GetType() == unit.GetType())
                // {
                //     Debug.Log("Cannot stack unit on top of same unit type");
                //     return;
                // }
                // break;

                if (sampleUnit.GetType() == typeof(Fire) & unit.isFlamable)
                {
                    canSetFire = true;
                    break;
                }
                else
                {
                    Debug.Log("Cannot set unit: tile already occupied");
                    return;
                }
            }
        }

        if (!canSetFire & sampleUnit.GetType() == typeof(Fire))
        {
            Debug.Log("Cannot put fire on non-flamable tile");
            return;
        }

        // Check if the player has enough action points
        if (sampleUnit.cost < actionPts)
        {
            // monsoon can only be used once per game
            if (sampleUnit.GetType() == typeof(Monsoon))
            {
                if (hasUsedMonsoon)
                {
                    Debug.Log("Monsoon already used");
                    return;
                }
                else
                {
                    hasUsedMonsoon = true;
                }
            }
            // create the unit inplace
            GameObject newObject = Instantiate (obj, transform.position, transform.rotation);
            newObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);

            if (sampleUnit.isEffect) {
                newObject.GetComponent<Unit>().tilemap = effectTilemap;
                effectTilemap.SetTile(cursorPosition, sampleUnit.tile);
            } else {
                newObject.GetComponent<Unit>().tilemap = groundTilemap;
                groundTilemap.SetTile(cursorPosition, sampleUnit.tile);
            }
            Debug.Log("Instance created");
            actionPts -= sampleUnit.cost;
        }
        else
        {
            Debug.Log("Not enough action points");
            Debug.Log(actionPts);
        }
    }
    
    public Vector3Int GetCursorPosition()
    {
        return cursorPosition;
    }
    
    public TileBase GetTerrain()
    {
        return groundTilemap.GetTile(cursorPosition);
    }
    
}
