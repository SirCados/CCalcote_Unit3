using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 40;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);       
    }
}
