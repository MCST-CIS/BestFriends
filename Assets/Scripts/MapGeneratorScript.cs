using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorScript : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject platformPrefab;
    public GameObject jumpPadPrefab;
    public GameObject keyPrefab;
    public GameObject doorPrefab;
    public GameObject circlePrefab;
    public GameObject ceiling;

    [Header("Map Settings")]
    public float mapLeft = -10.91f;
    public float mapRight = 10.91f;
    public float floorY = -4.65f;
    public float minMapHeight = 20f;
    public float maxMapHeight = 35f;

    [Header("Players")]
    public Transform player1;
    public Transform player2;

    private List<GameObject> spawnedObjects = new List<GameObject>();
    private List<Rect> occupiedRects = new List<Rect>();
    private float mapHeight;
    private float camOrthoSize = 9.53713f;

    public void GenerateMap()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null) Destroy(obj);
        }
        spawnedObjects.Clear();
        occupiedRects.Clear();

        mapHeight = Random.Range(minMapHeight, maxMapHeight);

        float ceilingY = floorY + mapHeight;

        if (ceiling != null) ceiling.transform.position = new Vector3(0f, ceilingY, 0);

        GameObject leftWall = GameObject.Find("LeftWall");
        GameObject rightWall = GameObject.Find("RightWall");

        float wallCenterY = floorY + mapHeight / 2f;
        float wallHeight = mapHeight + 2f;

        if (leftWall != null)
        {
            leftWall.transform.position = new Vector3(-10.91f, wallCenterY, 0);
            SpriteRenderer lr = leftWall.GetComponent<SpriteRenderer>();
            if (lr != null) lr.size = new Vector2(lr.size.x, wallHeight);
        }
        if (rightWall != null)
        {
            rightWall.transform.position = new Vector3(10.91f, wallCenterY, 0);
            SpriteRenderer rr = rightWall.GetComponent<SpriteRenderer>();
            if (rr != null) rr.size = new Vector2(rr.size.x, wallHeight);
        }

        float camMinY = floorY + camOrthoSize;
        float camMaxY = ceilingY - camOrthoSize;

        Camera.main.transform.position = new Vector3(0f, camMinY, Camera.main.transform.position.z);

        CameraFollow cam = Object.FindFirstObjectByType<CameraFollow>();
        if (cam != null)
        {
            cam.minY = camMinY;
            cam.maxY = camMaxY;
        }

        if (player1 != null) player1.position = new Vector3(-1f, floorY + 1f, 0);
        if (player2 != null) player2.position = new Vector3(1f, floorY + 1f, 0);

        foreach (PlayerMovement player in Object.FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None))
        {
            player.abilityActive = false;
            player.abilityTimer = 0f;
            player.cooldownTimer = 0f;
        }

        GeneratePlatforms();

        TrySpawnAtValidPosition(jumpPadPrefab, 5f, 2f, floorY + 2f, floorY + mapHeight * 0.33f, 4f);
        TrySpawnAtValidPosition(keyPrefab, 1f, 1f, floorY + mapHeight * 0.6f, floorY + mapHeight * 0.8f);

        // Spawn a guaranteed platform for the door/exit area
        float doorY = floorY + mapHeight - 2f;
        float doorX = Random.Range(mapLeft + 4f, mapRight - 4f);
        float platformY = doorY - 2f;

        // Spawn the platform first so door always has something to stand on
        SpawnObjectAt(platformPrefab, doorX, platformY, 4f, 0.5f);

        GameObject door = SpawnObjectAt(doorPrefab, doorX, doorY, 1.5f, 3f);
        GameObject circle = SpawnObjectAt(circlePrefab, doorX, doorY, 1f, 1f);

        // Reset door state
        Door doorScript = door.GetComponent<Door>();
        if (doorScript != null) doorScript.ResetDoor();

        Key keyScript = Object.FindFirstObjectByType<Key>();
        if (keyScript != null) keyScript.door = door;
    }

    void GeneratePlatforms()
    {
        float currentY = floorY + 1.5f;
        float mapTop = floorY + mapHeight * 0.85f;

        while (currentY < mapTop)
        {
            int platformsInRow = Random.Range(1, 3);
            List<float> usedX = new List<float>();

            for (int i = 0; i < platformsInRow; i++)
            {
                float x = GetValidX(usedX, 3f);
                if (x == float.MinValue) continue;
                usedX.Add(x);
                SpawnObjectAt(platformPrefab, x, currentY, 2.5f, 0.5f);
            }

            currentY += Random.Range(1.5f, 2.3f);
        }
    }

    void TrySpawnAtValidPosition(GameObject prefab, float width, float height, float minY, float maxY, float margin = 3f)
    {
        int attempts = 0;
        while (attempts < 20)
        {
            float x = Random.Range(mapLeft + margin, mapRight - margin);
            float y = Random.Range(minY, maxY);
            Rect r = new Rect(x - width / 2, y - height / 2, width, height);

            if (!OverlapsAny(r))
            {
                SpawnObjectAt(prefab, x, y, width, height);
                return;
            }
            attempts++;
        }
    }

    GameObject SpawnObjectAt(GameObject prefab, float x, float y, float width, float height)
    {
        Rect r = new Rect(x - width / 2, y - height / 2, width, height);
        occupiedRects.Add(r);
        GameObject obj = Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
        spawnedObjects.Add(obj);
        return obj;
    }

    float GetValidX(List<float> usedX, float minSpacing)
    {
        int attempts = 0;
        while (attempts < 20)
        {
            float x = Random.Range(mapLeft + 4f, mapRight - 4f);
            bool tooClose = false;
            foreach (float used in usedX)
            {
                if (Mathf.Abs(x - used) < minSpacing) { tooClose = true; break; }
            }
            if (!tooClose) return x;
            attempts++;
        }
        return float.MinValue;
    }

    bool OverlapsAny(Rect r)
    {
        foreach (Rect occupied in occupiedRects)
        {
            if (r.Overlaps(occupied)) return true;
        }
        return false;
    }
}