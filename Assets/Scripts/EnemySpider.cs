using UnityEngine;

public class EnemySpider : Enemy
{
    private float count;

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

    protected override void Move()
    {
        count += Time.deltaTime;

        if (count >= 0.5f)
        {
            SetRandomDir();
            count = 0;
        }

        base.Move();
    }
}
