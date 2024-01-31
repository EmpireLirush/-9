using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public int Id { get; private set; }

    private void Awake()
    {
        if(Id == 0)
            Id = Random.Range(0, 10000000);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
