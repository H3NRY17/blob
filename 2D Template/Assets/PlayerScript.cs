using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

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

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2dSpriteRenderer = GetComponent<SpriteRenderer>();
        rb2dSpriteRenderer.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocityX = _movement;
    }


    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            jumpModifier = (4 - playerMode) / 4 * 3;
            rb2d.linearVelocityY = jumpHeight * Mathf.Clamp(jumpModifier, 1, 3);
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        speedModifier = (playerMode) / 3 * 2;
        _movement = ctx.ReadValue<Vector2>().x * speed * Mathf.Clamp(speedModifier, 1, 3);
    }

    public void Swap(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
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
    }
}
