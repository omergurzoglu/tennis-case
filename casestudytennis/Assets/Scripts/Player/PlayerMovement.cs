
using UnityEngine;


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

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _thisTransform = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        CheckGround();
        if (Input.GetMouseButton(0))
        {
            JoystickMovement();
        }
        if(Input.GetKey(KeyCode.Space))
        {
            Jump();
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
            _rigidBody.AddForce(Vector3.down*3f,ForceMode.Impulse);
        }
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _rigidBody.AddForce(Vector3.up*jumpPower,ForceMode.Impulse);
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