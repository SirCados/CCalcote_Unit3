using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 40;
    private PlayerController _playerController;
    private float _leftBound = -15f;

    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.IsGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }

        if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
