using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;

    [SerializeField]
    protected float speed;

    private float maxSpawnX = 3.5f;
    private float maxSpawnZ = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Spawn()
    {
        float randX = Random.Range(-maxSpawnX, maxSpawnX);
        float randZ = Random.Range(-maxSpawnZ, maxSpawnZ);

        transform.position = new Vector3(randX, 0, randZ);
    }

    protected virtual void Move()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    public void LoseHealth()
    {
        health--;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
