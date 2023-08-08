using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject _enemyObject;
    [SerializeField] float _generationInterval;
    [SerializeField] float _generationWigth;
    float timer = 10;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > _generationInterval)
        {
            Instantiate(_enemyObject).transform.position = new Vector2(Random.Range(-_generationWigth, _generationWigth), transform.position.y);
            timer = 0;
        }
    }
}