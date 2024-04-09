using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delayBetweenShot;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _target;

    private bool isCoroutineWork = true;

    private void Start() => StartCoroutine(StartShoot());

    private IEnumerator StartShoot()
    {
        WaitForSeconds wait = new WaitForSeconds(_delayBetweenShot);

        while (isCoroutineWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;

            Rigidbody bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bullet.transform.up = direction;
            bullet.velocity = direction * _speed;

            yield return wait;
        }
    }
}
