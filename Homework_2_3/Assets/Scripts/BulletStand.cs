using UnityEngine;

public class BulletStand : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.Gun.ChangeBullet(this.bulletPrefab);
        }
    }
}
