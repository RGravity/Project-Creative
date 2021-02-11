using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour {

    // Here we store all the variables for this script.
    #region Variables
    // The speed at which the player object moves.
    [SerializeField]
    public float _movementSpeed = 10f;
    Vector3 _movement;

    [SerializeField]
    private float _jumpSpeed;

    /// <summary>
    /// ---TODO: IMPLEMENT A BOOL WHERE YOU CAN ONLY JUMP IF YOU'RE TOUCHING THE FLOAR OR A WALL
    /// </summary>
    private bool _canJump;

    public bool CanJumpSetter { set { _canJump = value; } }

    // The physics object of the Player where we will send the Velocity of the movement too.
    private Rigidbody _playerRigidBody;
    #endregion

    // Here are the properties for the variables where we can set the security of said variables.
    #region Properties
    public float Speed { get { return _movementSpeed; } set { _movementSpeed = value; } }
    public float JumpSpeed { get { return _jumpSpeed; } set { _jumpSpeed = value; } }
    //public Rigidbody PlayerRigidBody { get { return _playerRigidBody; } set { _playerRigidBody = value; } }
    #endregion

    // Use this for initialization
    void Start () {
        _playerRigidBody = GetComponent<Rigidbody>();
    }

    // Fixed Update for physics based objects.
    void FixedUpdate()
    {
        _playerMovement();
        _playerJumping();
    }

    // For the basic movement of Forward, Backward, Left and Right
    private void _playerMovement ()
    {
        // Scalar to get the amount of Input for Strafing
        float moveHorizontal = Input.GetAxis("Horizontal");
        // Scalar to get the amount of Input for Forward or Backward
        float moveVertical = Input.GetAxis("Vertical");

        _movement.Set(moveHorizontal, 0, moveVertical);
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            _playerRigidBody.MoveRotation(Quaternion.LookRotation(_movement));
        }
        _movement = _movement.normalized * _movementSpeed * Time.deltaTime;
        _playerRigidBody.MovePosition(transform.position + _movement);
    }

    // For jumping the Player
    private void _playerJumping()
    {
        /// <summary>
        /// ---TODO: IMPLEMENT A BOOL WHERE YOU CAN ONLY JUMP IF YOU'RE TOUCHING THE FLOAR OR A WALL
        /// </summary>
        if (Input.GetButtonDown("Jump") && _canJump == true)
        {
            _playerRigidBody.AddForce(Vector3.up * _jumpSpeed);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
