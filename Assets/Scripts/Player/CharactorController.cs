using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorController : MonoBehaviour, IDamageable {


    [SerializeField] [Header("Referances")]
    private Camera playerCamera;

    [SerializeField]
    private Transform body;

    [SerializeField]
    private Transform projectileSpawnPoint;

    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Transform groundChecker;

    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    Image spriteRenderer;

    [SerializeField]
    private Animator animator;


    [Header("Settings")]
    [SerializeField]
    private int maxHealth = 20;
    private int currentHealth = 20;

    [SerializeField]
    private float reloadTime = 3f;
    private float gunReloadStartTime = -99f;
    private bool gunEmpty = false;
    private bool isReloading = false;

    [SerializeField][Range(100f, 3000f)]
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
    private bool isOnGround = false;

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
    private int selectedWeapon = 0; //0 fists, 1 sword, 2 gun

    public LayerMask groundMask;


    [SerializeField][Header("Animations")]
    private Sprite idleNoWeapon;

    [SerializeField]
    private Sprite idleSword;

    [SerializeField]
    private Sprite idleGun;

    

    void Start() {
        currentHealth = maxHealth;

        Cursor.lockState = CursorLockMode.Locked; //Locks the cursor to the screen
    }
    
    void Update() {
        PhysicsChecks();
        CameraController();
        MovementControls();
        WeaponControls();
    }

    private void WeaponControls(){

        if(gunEmpty && isReloading && Time.time - gunReloadStartTime > reloadTime){
            gunEmpty = false;
            isReloading = false;
        }

        if(Input.GetKeyDown(switchWeaponKey)){ //Switch weapon //0 fists, 1 sword, 2 gun
            selectedWeapon = (selectedWeapon + 1) % 3; //Cycles the selected weapon

            animator.SetInteger("Weapon Equipped", selectedWeapon);
        }

        if(Input.GetKeyDown(reloadKey)){ //Reload
            if(gunEmpty){
                animator.SetTrigger("Reload");
                gunReloadStartTime = Time.time;
                isReloading = true;
            }
        }

        if(Input.GetMouseButtonDown(0)){ // Attack

            if(selectedWeapon == 2){
                print("Gun empty: " + gunEmpty);
                if(!gunEmpty){
                    
                    gunEmpty = true;
                    animator.SetTrigger("Attack");

                    GameObject bullet = Instantiate(projectilePrefab);
                    bullet.name = "Player Bullet (" + Time.time + ")";
                    bullet.transform.position = projectileSpawnPoint.transform.position;
                    bullet.transform.LookAt(projectileSpawnPoint.transform.forward);


                }
            }
            
            
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


    public void TakeDamage(int damage){
        
        currentHealth -= damage;
        print("Player took " + damage + " damage");

        if(currentHealth < 1){
            print("Player died");
            Destroy(gameObject);
        }
    }
}
