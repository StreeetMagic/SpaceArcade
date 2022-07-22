using UnityEngine;

public class ActiveEnemyPool : MonoBehaviour
{
    public event System.Action<Transform> EnemyDied;

    public void GetEnemyTransform(Transform position)
    {
        EnemyDied?.Invoke(position);
    }
}
