using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementController : MonoBehaviour
{

    PlayerInput playerInput;
    public CharacterController characterController;
    // Movement
    Vector2 currentMovementInput;
    public Vector3 currentMovement;
    public Vector3 currentRunMovement;
    bool isMovementPressed;
    bool isRunPressed;
    int isWalkingHash;
    int isRunningHash;   
    Animator animator;
    [SerializeField] private float rotationFactorPerFrame = 8f;
    [SerializeField] private float runMultiplier = 10.0f;
    [SerializeField] private int speed;

    //Attacking 
    [SerializeField] private KeyCode attackingKey;
    [SerializeField] private bool isAttacking;
    [SerializeField] private BoxCollider swordCollider;
    [SerializeField] private BoxCollider buffedSwordCollider;


    //Shield

    private bool _boolValue;
    public bool isShield;
    private Collider _collider; 


    

    void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

        playerInput.CharacterControls.Move.started += onMovementInput;
        playerInput.CharacterControls.Move.canceled += onMovementInput;
        playerInput.CharacterControls.Move.performed += onMovementInput;
        playerInput.CharacterControls.Run.started += onRun;
        playerInput.CharacterControls.Run.canceled += onRun;
        playerInput.CharacterControls.Run.performed+= onRun;
    }

    private void Start()
    {
        
    }
    void FixedUpdate()
    {
        handleGravity();
        handleRotation();
        handleAnimation();
        if (isRunPressed)
        {
            characterController.Move(currentRunMovement * Time.deltaTime);
        }
        else
        {
            characterController.Move(currentMovement * Time.deltaTime);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(attackingKey) && !isAttacking && !isShield)
        {
            animator.SetTrigger("attacking");
            isAttacking = true;
            playerInput.CharacterControls.Move.Disable();
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1) && !isAttacking)
        {
            SetBool();
            isShield = true;
            playerInput.CharacterControls.Move.Disable();
            characterController.detectCollisions = false; 

        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            SetBool();
            isShield = false;
            characterController.detectCollisions = true; 
            playerInput.CharacterControls.Move.Enable();
        }
         
    }

    private void setAttackBool()
    {
        isAttacking = false; 
    }


    private void SetBool()
    {
        _boolValue = !_boolValue;

        animator.SetBool("isShield", _boolValue);
      
    }



    public void StopAttacking()
    {
        playerInput.CharacterControls.Move.Enable();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyWeapon")
        {
            if (animator != null)
            {
                animator.Play("GetHit");
            }
        }
    }

    void BuffedSwordColliderOn()
    {
        buffedSwordCollider.enabled = true;
    }

    void BuffedSwordColliderOff()
    {
        buffedSwordCollider.enabled = false; 
    }

    void SwordColliderOn()
    {
        swordCollider.enabled = true;
    }

    void SwordColliderOff()
    {
        swordCollider.enabled = false;
    }

    void onRun (InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;

        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }

    }

    void onMovementInput (InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x * speed;
        currentMovement.z = currentMovementInput.y * speed;
        currentRunMovement.x = currentMovementInput.x * runMultiplier;
        currentRunMovement.z = currentMovementInput.y * runMultiplier;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void handleAnimation()
    {
        
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        
        
        if (isMovementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true); 
        }
        
        else if (!isMovementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if ((isMovementPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if ((!isMovementPressed || !isRunPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }


    void handleGravity()
    {
        if (characterController.isGrounded)
        {
            float groundedGravity = .05f;
            currentMovement.y = groundedGravity;
            currentRunMovement.y = groundedGravity; 
        }
        else
        {
            float gravity = -9.8f;
            currentMovement.y += gravity * Time.deltaTime * 2.0f;
            currentRunMovement.y += gravity * Time.deltaTime * 2.0f;
        }
    }

    void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }





    void OnDisable()
    {
        playerInput.CharacterControls.Disable();
    }

}
