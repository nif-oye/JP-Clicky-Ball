using UnityEngine;

public class Target : MonoBehaviour
{
    GameManager gameManager;
    float torqueBound = 10;
    float xPos = 4;
    float yPos = 2;
    Rigidbody targetRB;
    public int pointValue;
    public ParticleSystem explosionParticle;
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(Vector3.up * RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), ForceMode.Impulse);
        transform.position = new Vector3(RandomPosition(), -yPos);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {

    }

    float RandomForce()
    {
        return Random.Range(12, 16);
    }
    Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(-torqueBound, torqueBound), Random.Range(-torqueBound, torqueBound), Random.Range(-torqueBound, torqueBound));
    }
    float RandomPosition()
    {
        return Random.Range(-xPos, xPos);
    }

    void OnMouseDown()
    {
        if (gameManager.gameOver == false)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Game Over Mark") && gameObject.CompareTag("Good"))
        {
            gameManager.GameIsOver();
            Destroy(gameObject);
        }
    }
}
