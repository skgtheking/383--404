using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;   //Animator component for player animation
    private PlayerState currentState;   //Current state of the player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Intialize the player state to IdleState
        currentState = new IdleState(this);
    }

    void Update()
    {
        //Handle Input based on the current state
        currentState.HandleInput();

        //Update animation based on the current state
        currentState.UpdateAnimation();
    }

    private void FixedUpdate()
    {
        // Perform physics updates based on the current state
        currentState.FixedUpdate();
    }

    // Method to set the current state of the player
    public void SetState(PlayerState state)
    {
        currentState = state;
    }
}

// Abstract class representing a state of the player
public abstract class PlayerState
{
    // Reference to the PlayerControl script
    protected PlayerControl player;

    // Abstract methods to handle input, update animation, and perform physics updates
    public PlayerState(PlayerControl player)
    {
        this.player = player;
    }

    public abstract void HandleInput();
    public abstract void UpdateAnimation();
    public abstract void FixedUpdate();
}

// Concrete class representing the Idle state of the player
public class IdleState : PlayerState
{
    public IdleState(PlayerControl player) : base(player) { }

    public override void HandleInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        player.animator.SetFloat("Horizontal", horizontalInput);
        player.animator.SetFloat("Vertical", verticalInput);
        player.animator.SetFloat("Speed", 0f);

        if (horizontalInput != 0 || verticalInput != 0)
        {
            player.SetState(new MoveState(player));
        }
    }

    public override void UpdateAnimation() { }

    public override void FixedUpdate() { }
}

// Concrete class representing the Move state of the player
public class MoveState : PlayerState
{
    public MoveState(PlayerControl player) : base(player) { }

    public override void HandleInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        player.animator.SetFloat("Horizontal", horizontalInput);
        player.animator.SetFloat("Vertical", verticalInput);
        player.animator.SetFloat("Speed", Mathf.Sqrt(horizontalInput * horizontalInput + verticalInput * verticalInput));

        // Transition to IdleState if there is no input
        if (horizontalInput == 0 && verticalInput == 0)
        {
            player.SetState(new IdleState(player));
        }
    }

    public override void UpdateAnimation() { }

    public override void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement vector based on input and accelerometer data
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.x += Input.acceleration.x;
        movement.y += Input.acceleration.y;

        // Move the player based on the calculated movement vector and speed
        player.rb.MovePosition(player.rb.position + movement.normalized * player.moveSpeed * Time.fixedDeltaTime);
    }
}
