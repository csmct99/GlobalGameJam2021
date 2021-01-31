using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour {

    [SerializeField] [Header("Referances")]
    private Camera playerCamera;

    [SerializeField]
    private Transform body;

    [SerializeField]
    private Transform groundChecker;

    [SerializeField]
    private CharacterController controller;

    [SerializeField][Header("Settings")][Range(100f, 3000f)]
    private float mouseSens = 1f;

    [SerializeField][Range(1f, 40f)]
    private float movementSpeed = 12f;

    [SerializeField][Range(1f, 40f)]
    private float sprintAdditionalSpeed = 6f;

    [SerializeField][Range(0f, 10f)][Tooltip("How high you jump in meters")]
    private float jumpHeight = 3f;

    private float currentYRotation = 0f;
    
    [SerializeField][Range(0f, 90f)][Tooltip("The max angle you can look up and down at. + and - not sum.")]
    private float maxYRotation = 80;

    private Vector3 vel;

    [SerializeField][Range(0f, 50f)]
    private float playerGravity = -9.81f; //Gravity const

    [SerializeField][Range(0f, 5f)][Tooltip("Distance to the ground before velocity becomes a constant. Set this to how far the groundChecker point is from the ground when the player is standing still")]
    float groundDist = 0.4f;

    [Header("Inputs (Some are in project inputs)")]
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;

    [SerializeField]
    private KeyCode sprintKey = KeyCode.LeftShift;

    [SerializeField]
    private KeyCode reloadKey = KeyCode.R;

    [SerializeField]
    private KeyCode switchWeaponKey = KeyCode.Alpha1;

    public LayerMask groundMask;

    private bool isOnGround = false;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked; //Locks the cursor to the screen
    }
    
    void Update() {
        CameraController();
        MovementControls();
        PhysicsChecks();
        WeaponControls();
    }

    private void WeaponControls(){
        if(Input.GetKeyDown(switchWeaponKey)){ //Switch weapon

        }

        if(Input.GetKeyDown(reloadKey)){ //Reload
            
        }


    }

    /// <summary>
    /// Moves the player to the ground when they are off the ground, 
    /// Can be expanded later for any other physics that should happen passivly
    /// </summary>
    private void PhysicsChecks(){ //For applying automated things like falling to the ground
        isOnGround = Physics.CheckSphere(groundChecker.position, groundDist, groundMask); //Check if anything ground masked is on the player's feet

        if(isOnGround && vel.y < 0){
            vel.y = -2; //-2 to ensure u dont float a bit above the ground
        }

        vel.y += playerGravity * Time.deltaTime; //Multiply by Time.delta time twice for the ^2 portion of the movement formula, aka accelarion

        // Move the player to the ground
        controller.Move(vel * Time.deltaTime); //Multiply by Time.delta time twice for the ^2 portion of the movement formula, aka accelarion
    }


    /// <summary>
    /// Handles wasd movement
    /// </summary>
    private void MovementControls(){

        float extraMovementSpeed = 0f;

        //Jump Controls
        if(Input.GetKeyDown(jumpKey) && isOnGround){
            vel.y = Mathf.Sqrt(jumpHeight * -2f * playerGravity); //Jump to given height
        }

        //Sprint controls
        if(Input.GetKey(sprintKey) && isOnGround){
            extraMovementSpeed = sprintAdditionalSpeed;
        }

        //WASD controls
        float side = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        Vector3 move = transform.right * side + transform.forward * forward;
        controller.Move(move * (movementSpeed + extraMovementSpeed) * Time.deltaTime); //the controller handles collisions and all the nitty gritty

    }

    /// <summary>
    /// Handles camera input
    /// </summary>
    private void CameraController(){
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        body.Rotate(Vector3.up * mouseX);

        currentYRotation = Mathf.Clamp(currentYRotation - mouseY, -maxYRotation, maxYRotation); //Clamp the look up down angles

        playerCamera.transform.localRotation = Quaternion.Euler(currentYRotation, 0, 0);
    }
}
