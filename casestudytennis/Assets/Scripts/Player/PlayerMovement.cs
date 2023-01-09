
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private FloatingJoystick floatingJoystick ;
    [SerializeField] private float speedConstant;
    [SerializeField] private float jumpPower;
    private Vector3 _direction,_position;
    private float _horizontalInput,_verticalInput;
    private Rigidbody _rigidBody;
    private Transform _thisTransform;
    private bool _isGrounded;
    private float _holdTimer = 0f;
    private const float TapAndHoldThreshold = 0.1f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _thisTransform = GetComponent<Transform>();
    }
    private void Update()
    {
         CheckGround();
         if (!LevelManager.Instance.IsGamePaused())
         {
             MovementFunction();
         }
         
    }

    private void MovementFunction()
    {
        

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _holdTimer = 0f;
                    break;
                case TouchPhase.Moved or TouchPhase.Stationary:
                {
                    _holdTimer += Time.deltaTime;

                    if (_holdTimer > TapAndHoldThreshold)
                    {
                        JoystickMovement();
                    }

                    break;
                }
                case TouchPhase.Ended:
                {
                    if (_holdTimer < TapAndHoldThreshold)
                    {
                        Jump();
                    }

                    break;
                }
                
            }
        }
    }
    private void CheckGround()
    {
        if(Physics.Raycast(_thisTransform.position,Vector3.down,1.5f))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
            _rigidBody.AddForce(Vector3.down * 4f ,ForceMode.Impulse);
        }
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _rigidBody.AddForce(Vector3.up * jumpPower ,ForceMode.Impulse);
        }
    }
    
    private void JoystickMovement()
    {
        _horizontalInput = floatingJoystick.Horizontal;
        _verticalInput = floatingJoystick.Vertical;
        
        _position=new Vector3(_horizontalInput*speedConstant*Time.fixedDeltaTime,0,_verticalInput*speedConstant*Time.fixedDeltaTime);
        _rigidBody.velocity += _position;
        
        _direction = Vector3.forward * _verticalInput + Vector3.right * _horizontalInput;
        _rigidBody.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(_direction),10f*Time.fixedDeltaTime);
    }

   
}