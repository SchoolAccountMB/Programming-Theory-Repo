using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;

    [SerializeField]
    protected float speed;

    protected Vector3 dir;

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

    protected void Spawn()
    {
        float randX = Random.Range(-maxSpawnX, maxSpawnX);
        float randZ = Random.Range(-maxSpawnZ, maxSpawnZ);

        transform.position = new Vector3(randX, 0, randZ);

        SetRandomDir();
    }

    protected void SetRandomDir()
    {
        float dirX = Random.Range(-1.0f, 1.0f);
        float dirZ = Random.Range(-1.0f, 1.0f);

        dir = new Vector3(dirX, 0, dirZ);
        dir.Normalize();
    }

    protected virtual void Move()
    {
        transform.Translate(dir * speed * Time.deltaTime);
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
