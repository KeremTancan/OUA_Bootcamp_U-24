using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 1f;
    public float moveSpeed = 5f;
    public Vector3 rotationAngles = Vector3.zero;
    public int maxObjects = 25;

    private float spawnTimer;
    private int objectSayac;

    private void Start()
    {
        spawnTimer = spawnInterval;
        objectSayac = 0;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnObject();
            spawnTimer = spawnInterval;
        }
        foreach (Transform child in transform)
        {
            child.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

    }

    private void SpawnObject()
    {        
        GameObject newObject = Instantiate(objectToSpawn, transform.position, Quaternion.Euler(rotationAngles), transform);
        objectSayac++;
        
        if (objectSayac > maxObjects)
        {
            Destroy(transform.GetChild(0).gameObject);
            objectSayac--;
        }
    }
}
