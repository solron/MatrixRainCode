using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject letterSpawners;
    public float spawnRate;
    float spawnResetValue;

    private void Awake()
    {
        spawnResetValue = spawnRate;
    }

    void Update()
    {
        SpawnLetterSpawner();
        QuitOnEsc();
    }

    void QuitOnEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   // Quit the app when we press ESC
            Application.Quit();
    }

    void SpawnLetterSpawner()
    {
        spawnRate -= Time.deltaTime;
        if (spawnRate < 0)
        {
            spawnRate = spawnResetValue;
            int multiplier = Random.Range(-60, 60);
            float xVal = multiplier * 0.2f;

            Instantiate(letterSpawners, new Vector3(xVal, 5.5f, 0), Quaternion.identity);   // Spawn the letter spawners
        }
    }
}
