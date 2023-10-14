using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    private Vector3 _spawnPosition = new Vector3(35, 0, 0);
    private float _startDelay = 2;
    private float _repeatRate = 2;
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (!_playerController.IsGameOver)
        {
            Instantiate(ObstaclePrefab, _spawnPosition, ObstaclePrefab.transform.rotation);
        }
    }
}
