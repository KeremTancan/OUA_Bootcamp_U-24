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
    public float rotationSpeed = 100f;
    private bool isPaused = false;
    public static bool Durdu = false;
    private float pauseDuration = 3f;
    private float pauseTimer = 0f;

    private void Start()
    {
        spawnTimer = spawnInterval;
        objectSayac = 0;
    }
    void Update()
    {
        if (!isPaused)
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
        else
        {

            pauseTimer += Time.deltaTime;

            if (pauseTimer >= pauseDuration)
            {

                isPaused = false;
                Durdu = false;
                pauseTimer = 0f;
            }
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            Pause();

        }
    }

    void Pause()
    {
        isPaused = true;
        Durdu = true;
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
