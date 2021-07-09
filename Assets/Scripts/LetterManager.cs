using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public GameObject newLetter;    // GameObject to spawn
    public Sprite[] characters;     // Letters to select from
    
    private SpriteRenderer rend;    // Get the sprite renderer so we can change letter
    float letterHeight;
    float spawnHeight;
    float changeLetterTime = 0.1f;

    Vector2 oldPos;         // Used for calculate distance the letters have traveled
    float travelDistance;
    private float moveSpeed = 0.05f;

    int letterNumber;       // Used for randomizing the letters

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        letterNumber = Random.Range(0, 20);     // Start with a random letter

        RandomLetterSize();

        SpawnCharracter();
        oldPos = transform.position;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.down * moveSpeed);  

        changeLetterTime -= Time.deltaTime;

        ChangeLetter();

        SpawnCharracter();

        DestroyOutsideScreen();
    }

    void DestroyOutsideScreen()
    {
        if (transform.position.y < -10)
            Destroy(gameObject);
    }

    void SpawnCharracter()
    {
        travelDistance += Vector2.Distance(transform.position, oldPos);
        if (travelDistance > spawnHeight)
        {
            newLetter.transform.localScale = transform.localScale;
            Instantiate(newLetter, transform.position, Quaternion.identity);
            travelDistance = 0;
        }
        oldPos = transform.position;  
    }

    void ChangeLetter()
    {
        if (changeLetterTime < 0)       // Change letter every 0.1 seconds
        {
            changeLetterTime = 0.1f;
            rend.sprite = characters[Random.Range(0, 25)];
            letterNumber++;
            if (letterNumber > 25)
                letterNumber = 0;
        }
    }

    void RandomLetterSize()
    {       
        int sizeMultiplier = Random.Range(2, 5);        // Get a random multiplier between 2 and 4
        transform.localScale = new Vector3(sizeMultiplier * 0.05f, sizeMultiplier * 0.05f, 1);  // Set the size of the letters
        moveSpeed = sizeMultiplier * 0.0125f;   // Max speed is 4 * 0.0125
        letterHeight = rend.bounds.size.y;
        spawnHeight = letterHeight + (letterHeight / 6);
    }
}
