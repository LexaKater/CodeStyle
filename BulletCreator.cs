using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletCreator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delayBetweenShot;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _target;

    private bool isCoroutineWork = true;
    private Rigidbody _weaponRigidbody;

    private void Start()
    {
        _weaponRigidbody = GetComponent<Rigidbody>();
        StartCoroutine(StartShoot());
    }

    private IEnumerator StartShoot()
    {
        WaitForSeconds wait = new WaitForSeconds(_delayBetweenShot);

        while (isCoroutineWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;

            GameObject bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            if (_weaponRigidbody != null)
            {
                bullet.transform.up = direction;
                _weaponRigidbody.velocity = direction * _speed * Time.deltaTime;
            }

            yield return wait;
        }
    }
}
