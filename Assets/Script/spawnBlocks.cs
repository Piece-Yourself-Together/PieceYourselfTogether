using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Array to hold the prefabs of the game objects
    public Transform spawnPoint; // Set the spawn point where you want the blocks to appear
    public float tickRate = 1f; // Adjust this value to change tick rate
    private float timer;
    public float customGravity = 5f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tickRate)
        {
            // Trigger tick event
            Tick();
            timer = 0f; // Reset the timer
        }
    }

    private void Tick()
    {
        // Randomly select one of the prefabs
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject prefabToSpawn = objectPrefabs[randomIndex];

        // Generate a random X offset within the range of +2 and -2
        float randomXOffset = Random.Range(-2f, 2f);

        // Generate a random rotation angle in increments of 90 degrees (0, 90, 180, or 270 degrees)
        float randomRotation = Random.Range(0, 4) * 90f;

        // Calculate the spawn position with the random X offset
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x + randomXOffset, spawnPoint.position.y, spawnPoint.position.z);

        // Spawn the selected prefab at the calculated spawnPosition with the random rotation
        GameObject newBlock = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Rotate the spawned block by the random rotation angle around the Z-axis
        newBlock.transform.Rotate(Vector3.forward, randomRotation);
        // Add Rigidbody component to the spawned block
        Rigidbody rb = newBlock.AddComponent<Rigidbody>();
        rb.useGravity = false;

        // Add CustomGravity component to the spawned block
        CustomGravity customGravityComponent = newBlock.AddComponent<CustomGravity>();
        customGravityComponent.downwardForce = customGravity; // Set the custom gravity value
    }
}
