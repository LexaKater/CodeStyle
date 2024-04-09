using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _parentWaypoint;

    private Transform[] _waypoints;
    private int _currentWaypoint = 0; 

    private void Start()
    {
        _waypoints = new Transform[_parentWaypoint.childCount];

        for (int i = 0; i < _parentWaypoint.childCount; i++)
            _waypoints[i] = _parentWaypoint.GetChild(i).GetComponent<Transform>();
    }

    private void Update() => Move();

    public Vector3 AppointNextWaypoint()
    {
        _currentWaypoint++;

        if (_currentWaypoint == _waypoints.Length)
            _currentWaypoint = 0;

        transform.forward = _waypoints[_currentWaypoint].position - transform.position;

        return _waypoints[_currentWaypoint].position;
    }

    private void Move()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
            AppointNextWaypoint();

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}
