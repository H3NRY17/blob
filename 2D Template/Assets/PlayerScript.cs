using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public float speed = 5;
    public float jumpHeight = 5;
    private Rigidbody2D rb2d;
    private float _movement;
    private float playerMode = 1;
    private SpriteRenderer rb2dSpriteRenderer;
    private float jumpModifier;
    private float speedModifier;
    private bool swapping;
    private bool canJump;
    private float playerHealth = 10;
    private bool kbFrame = false;
    public static string endCause = "NA";
    public bool lastDirection;

    private float time = 0;

    private bool hasBounced = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2dSpriteRenderer = GetComponent<SpriteRenderer>();
        rb2dSpriteRenderer.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {

        if (rb2d.linearVelocityX > 0)
        {
            lastDirection = true;
        }
        else if (rb2d.linearVelocityX < 0)
        {
            lastDirection = false;
        }


        if (time > .25 || !kbFrame)
            {
                rb2d.linearVelocityX = _movement * Mathf.Clamp(speedModifier, 1, 3);
                kbFrame = false;
                time = 0;
            }
        if (kbFrame)
        {
            time += 1 * Time.deltaTime;
        }




        if (transform.position.y < -12)
        {
            dealPlayerDamage("void", 5);
            transform.position = new Vector3(0, -7, 0);
            rb2d.linearVelocity = new Vector2(0, 0);
        }
    }


    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1 && canJump)
        {
            jumpModifier = (4 - playerMode) / 4 * 3;
            rb2d.linearVelocityY = jumpHeight * Mathf.Clamp(jumpModifier, 1, 3);
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {

        _movement = ctx.ReadValue<Vector2>().x * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            canJump = true;
            hasBounced = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            canJump = false;
        }
    }

    public void Swap(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
        {
            return;
        }

        if (!canJump)
        {
            return;
        }

        switch (playerMode)
        {

            case 1:
                rb2dSpriteRenderer.color = Color.yellow;
                playerMode = 2;
                break;

            case 2:
                playerMode = 3;
                rb2dSpriteRenderer.color = Color.blue;
                break;

            case 3:

                playerMode = 1;
                rb2dSpriteRenderer.color = Color.red;
                break;
        }
        speedModifier = (playerMode) / 3 * 2;
    }


    public void dealPlayerDamage(String cause, float amount)
    {
        playerHealth -= amount;
        if (cause == "spike")
        {
            if (rb2d.linearVelocityX > 0)
            {
                kbFrame = true;
                rb2d.linearVelocityX -= 10 * Mathf.Clamp(speedModifier, 1, 3);

            }
            else if (rb2d.linearVelocityX < 0)
            {
                kbFrame = true;

                rb2d.linearVelocityX += 10 * Mathf.Clamp(speedModifier, 1, 3);
            }
            else
            {
                rb2d.linearVelocityY += 17;

            }

        }

        if (playerHealth <= 0)
        {
            swapCurrentScene("End", cause);
        }
    }


    public void swapCurrentScene(String name, String cause)
    {
        endCause = cause;
        SceneManager.LoadScene(name);
    }

    public void bouncePlayer()
    {
        if (lastDirection)
        {
            kbFrame = true;
            rb2d.linearVelocityX -= 10 * Mathf.Clamp(speedModifier, 1, 3);

        }
        else if (!lastDirection)
        {
            kbFrame = true;
            rb2d.linearVelocityX += 10 * Mathf.Clamp(speedModifier, 1, 3);
        }

        if (!canJump && !hasBounced)
        {
            hasBounced = true;
            rb2d.linearVelocityY += 5;
        }
    }
}
