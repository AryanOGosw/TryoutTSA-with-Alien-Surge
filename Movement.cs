using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public InputSystem_Actions playerC;

    [Header("Player Component References")]
    [SerializeField] Rigidbody2D rigbody;
    public Animator _animator;

    [Header("Settings")]
    [SerializeField] float speed;
    [SerializeField] float jumpforce;
    [SerializeField] float move;

    [Header("Ground & Respawn")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] GameObject respawn1;
    [SerializeField] GameObject respawn2;
    [SerializeField] GameObject respawn3;
    [SerializeField] GameObject home;

    [Header("Audio")]
    [SerializeField] AudioClip jumpsfx;
    [SerializeField] AudioClip damagesfx;
    [SerializeField] AudioSource source;

    private void Awake()
    {
        playerC = new InputSystem_Actions();
    }
    private void Start()
    {
        rigbody = GetComponent<Rigidbody2D>();
        source.volume = 0.6f;
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.4f, groundLayer);
    }

    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>().x;
        Vector3 localScale = transform.localScale;
        if (move != 0)
        {
            if (move == 1)
            {
                localScale.x = Mathf.Abs(transform.localScale.x);
                transform.localScale = localScale;
            }
            else if (move == -1)
            {
                localScale.x = Mathf.Abs(transform.localScale.x) * -1f;
                transform.localScale = localScale;
            }
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())
        {
            source.clip = jumpsfx;
            source.Play();
            rigbody.linearVelocityY = jumpforce;
        }
        if(context.canceled && rigbody.linearVelocity.y > 0f)
        {
            rigbody.linearVelocity = new Vector2(rigbody.linearVelocity.x, rigbody.linearVelocity.y * 0.5f);
        }
    }

    private void OnEnable()
    {
        playerC.Player.Enable();
        playerC.Player.Jump.performed += Jump;
        playerC.Player.Jump.canceled += Jump;
        playerC.Player.Move.performed += Move;
        playerC.Player.Move.canceled += Move;
    }
    private void OnDisable()
    {
        playerC.Player.Disable();
        playerC.Player.Jump.performed -= Jump;
        playerC.Player.Jump.canceled -= Jump;
        playerC.Player.Move.performed -= Move;
        playerC.Player.Move.canceled -= Move;
    }

    private void Update()
    {
        rigbody.linearVelocity = new Vector2(move * speed, rigbody.linearVelocity.y);
        if (move != 0)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            home.GetComponent<Play>().CamMainy();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Threat")
        {
            source.clip = damagesfx;
            source.Play();
            transform.position = respawn1.transform.position;
        }
        if (collision.gameObject.tag == "Threat2")
        {
            source.clip = damagesfx;
            source.Play();
            transform.position = respawn2.transform.position;
        }
        if (collision.gameObject.tag == "Threat3")
        {
            source.clip = damagesfx;
            source.Play();
            transform.position = respawn3.transform.position;
        }
        if (collision.gameObject.tag == "Gem")
        {
            home.GetComponent<Play>().CamLevelTwoy();
        }
        if (collision.gameObject.tag == "Gem2")
        {
            home.GetComponent<Play>().CamLevelThreey();
        }
        if (collision.gameObject.tag == "Gem3")
        {
            home.GetComponent<Play>().Winner();
        }
    }
}
