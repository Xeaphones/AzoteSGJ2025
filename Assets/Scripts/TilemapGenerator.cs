using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TilemapGenerator : MonoBehaviour
{
    [Range(0, 100), SerializeField]
    private int initChance;
    [Range(1, 8), SerializeField]
    private int birthLimit;
    [Range(1, 8), SerializeField]
    private int deathLimit;
    [Range(0, 100), SerializeField]
    private int spreadChance;

    [Range(1, 10), SerializeField]
    private int numR;
    private int count = 0;

    private int[,] terrainMap;
    [SerializeField]
    private Vector3Int tmpSize;
    [SerializeField]
    private Tilemap groundMap;
    [SerializeField]
    private GameObject forestUnit;
    [SerializeField]
    private Tile emptyTile;

    int width;
    int height;

    private void doSim(int numR) {
        clearMap(false);
        width = tmpSize.x;
        height = tmpSize.y;

        if (terrainMap == null) {
            terrainMap = new int[width, height];
            initMap();
        }

        for (int i = 0; i < numR; i++) {
            terrainMap = genTilePos(terrainMap);
        }

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (terrainMap[x, y] == 1) {
                    groundMap.SetTile(new Vector3Int(-x + width/2, -y + height/2, 0), forestUnit.GetComponent<Unit>().tile);
                    Vector3 position = groundMap.GetCellCenterWorld(new Vector3Int(-x + width/2, -y + height/2, 0));
                    GameObject unit = Instantiate(forestUnit, position, Quaternion.identity);
                    unit.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                } else {
                    groundMap.SetTile(new Vector3Int(-x + width/2, -y + height/2, 0), emptyTile);
                }
            }
        }
    }

    void Start()
    {
        clearMap(true);
        doSim(numR);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            doSim(numR);
        }

        if (Input.GetMouseButtonDown(1)) {
            clearMap(true);
        }
    }

    private int[,] genTilePos(int[,] oldMap) {
    int[,] newMap = new int[width,height];
    int neighb;
    BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);

    for (int x = 0; x < width; x++)
    {
        for (int y = 0; y < height; y++)
        {
            neighb = 0;
            foreach (var b in myB.allPositionsWithin)
            {
                if (b.x == 0 && b.y == 0) continue;
                int nx = x + b.x;
                int ny = y + b.y;
                if (nx >= 0 && nx < width && ny >= 0 && ny < height)
                {
                    neighb += oldMap[nx, ny];
                }
                else
                {
                    // no longer counting out-of-bounds as forest
                }
            }

            if (oldMap[x,y] == 1)
            {
                // Survive if neighbor count is >= deathLimit
                if (neighb < deathLimit) newMap[x, y] = 0;
                else newMap[x, y] = 1;
            }
            else
            {
                // normal birth rule
                if (neighb > birthLimit) newMap[x, y] = 1;
                else
                {
                    // remain empty unless we allow "spread"
                    newMap[x, y] = 0;

                    // If there's at least one neighbor that is forest,
                    // randomly let forest "spread"
                    if (neighb > 0)
                    {
                        int roll = Random.Range(0, 100);
                        if (roll < spreadChance)
                        {
                            newMap[x, y] = 1;
                        }
                    }
                }
            }
        }
    }

    return newMap;
}


    private int[,] genTilePosOld(int[,] oldMap) {
        int[,] newMap = new int[width,height];
        int neighb;
        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                neighb = 0;
                foreach (var b in myB.allPositionsWithin)
                {
                    if (b.x == 0 && b.y == 0) continue;
                    if (x+b.x >= 0 && x+b.x < width && y+b.y >= 0 && y+b.y < height)
                    {
                        neighb += oldMap[x + b.x, y + b.y];
                    }
                    else
                    {
                       
                    }
                }

                if (oldMap[x,y] == 1)
                {
                    if (neighb < deathLimit) newMap[x, y] = 0;
                    else
                    {
                        newMap[x, y] = 1;


                    }
                }

                if (oldMap[x,y] == 0)
                {
                    if (neighb > birthLimit) newMap[x, y] = 1;
                    else
                    {
                        newMap[x, y] = 0;
                    }
                }
            }
        }

        return newMap;
    }

    private void initMap() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                terrainMap[x, y] = Random.Range(1, 101) < initChance ? 1 : 0;
            }
        }
    }

    private void clearMap(bool complete) {
        groundMap.ClearAllTiles();
        if (complete) {
            terrainMap = null;
        }
    }
}
