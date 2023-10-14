using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRigidbody;
    private Animator _playerAnimator;
    public float JumpForce = 10f;
    public float GravityModifier = 1f;
    public bool IsOnGround = true;
    public bool IsGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
        _playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !IsGameOver)
        {
            print("up");
            _playerRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
            _playerAnimator.SetBool("IsJumping", true);
        }
    }

    //whenever a player enters a collision, reset isOnGround to true.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            _playerAnimator.SetBool("IsJumping", false);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            print("game over");
            IsGameOver = true;
            _playerAnimator.SetBool("Death_b", true);
        }
    }
}
