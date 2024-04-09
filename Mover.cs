using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;

    private Transform[] _waypoints;
    private int _currentWaypoint = 0;

    private void Start()
    {
        _waypoints = new Transform[_path.childCount];

        for (int i = 0; i < _waypoints.Length; i++)
            _waypoints[i] = _path.GetChild(i);
    }

    private void Update() => Move();

    private void Move()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}