using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRigidbody;
    private Animator _playerAnimator;
    private AudioSource _playerAudio;

    public ParticleSystem ExplosionParticle;
    public ParticleSystem DirtParticle;
    public float JumpForce = 10f;
    public float GravityModifier = 1f;
    public bool IsOnGround = true;
    public bool IsGameOver = false;
    public AudioClip JumpSound;
    public AudioClip CrashSound;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
        _playerAnimator = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !IsGameOver)
        {
            DirtParticle.Stop();
            _playerAudio.PlayOneShot(JumpSound, .7f);
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
            DirtParticle.Play();
            IsOnGround = true;
            _playerAnimator.SetBool("IsJumping", false);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            print("game over");
            IsGameOver = true;
            DirtParticle.Stop();
            ExplosionParticle.Play();
            _playerAudio.PlayOneShot(CrashSound, 1f);
            _playerAnimator.SetBool("Death_b", true);
        }
    }
}
