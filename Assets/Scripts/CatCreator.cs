using UnityEngine;

public class CatCreator : MonoBehaviour
{
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    public GameObject catPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnCat", minSpawnTime);    
    }

    void SpawnCat()
    {
        Camera cameraMain = Camera.main;
        Vector3 cameraPosition = cameraMain.transform.position;
        float xMax = cameraMain.aspect * cameraMain.orthographicSize;
        float xMin = xMax - (xMax * 1.25f);
        float yRange = cameraMain.orthographicSize - 1.75f;

        Vector3 spawnPosition = new Vector3(
                                            cameraPosition.x + Random.Range(xMin, xMax),
                                            Random.Range(-yRange, yRange),
                                            catPrefab.transform.position.z
                                            );

        Instantiate(catPrefab, spawnPosition, Quaternion.identity);

        Invoke("SpawnCat", Random.Range(minSpawnTime, maxSpawnTime));
    }
}
