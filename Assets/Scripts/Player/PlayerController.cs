using UnityEngine;

/// <summary>
/// player controller : such -> movement and camera move and move effect
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Player MoveMent")]
    [SerializeField] public CharacterController playerController;
    [SerializeField] float normalSpeed;
    [SerializeField] float highSpeed;
    [SerializeField] float gravityForce;

    float m_playerSpeed; //It stores whether the speed is running or normal.
    float m_verticalVelocity; //Its values ​​are combined with gravity and jump force to simulate physics.
    Vector3 m_moveDir; //To determine the direction of the player's movement

    [Header("Jump")]
    [SerializeField] float jumpForce;

    [Header("Player Camera")]
    [SerializeField] Camera playerCamera;
    [SerializeField] float cameraSensitivityUp; //Y axis
    [SerializeField] float cameraSensitivityRight; //X axis
    [SerializeField] float maxRotation; //Minimum rotation to move camera 
    [SerializeField] float minRotation; //Maximum rotation to move camera
    float m_cameraAngleUp; //Store the camera movement angle vertically

    [Header("Head Bob Settings")]
    [SerializeField] float bobFrequency = 5f;
    [SerializeField] float bobAmplitude = 0.05f;
    [SerializeField] float smoothTransition = 10f;

    private float m_bobOffset;
    private Vector3 m_originalCameraPosition;
    private Vector3 m_targetCameraPosition;

    float m_hori, m_vert;
    float m_inputMouseRight, m_inputMouseUp;
    bool m_isRun;

    private void Start()
    {
        m_originalCameraPosition = playerCamera.transform.localPosition;
    }

    private void Update()
    {
        HandleInputs();
        ApplyGravity();
        ApplyMovement();
        CameraRotation();
        ApplyHeadBob();
    }

    /// <summary>
    /// Apply player movement
    /// </summary>
    private void ApplyMovement()
    {
        m_playerSpeed = m_isRun ? highSpeed: normalSpeed;
        m_playerSpeed = (m_vert > 0) ? m_playerSpeed : (m_vert == 0 && m_hori != 0) ? m_playerSpeed / 3 : m_playerSpeed / 3;

        m_moveDir = new Vector3(m_hori * m_playerSpeed, m_verticalVelocity, m_vert * m_playerSpeed);
        m_moveDir = transform.TransformDirection(m_moveDir);

        playerController.Move(m_moveDir * Time.deltaTime);
    }

    /// <summary>
    /// Allows you to move the camera
    /// </summary>
    private void CameraRotation()
    {
        float rotationToRight = m_inputMouseRight * cameraSensitivityRight * Time.deltaTime;
        float rotationToUp = m_inputMouseUp * cameraSensitivityUp  * Time.deltaTime;

        m_cameraAngleUp -= rotationToUp;
        m_cameraAngleUp = Mathf.Clamp(m_cameraAngleUp, minRotation, maxRotation);

        transform.Rotate(0, rotationToRight, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(m_cameraAngleUp, 0, 0);
    }

    /// <summary>
    /// Effect of simulating camera shake while walking
    /// </summary>
    private void ApplyHeadBob()
    {
        if (!playerController.isGrounded) return;

        float speed = playerController.velocity.magnitude;
        float bobFrequencyPerSpeed = bobFrequency * (m_playerSpeed / 2);

        if (speed > 0.1f)
        {
            m_bobOffset = Mathf.Sin(Time.time * bobFrequencyPerSpeed) * bobAmplitude;
        }
        else
        {
            m_bobOffset = Mathf.Lerp(m_bobOffset, 0, Time.deltaTime * smoothTransition);
        }

        m_targetCameraPosition = m_originalCameraPosition + new Vector3(0, m_bobOffset, 0);
        playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, m_targetCameraPosition, Time.deltaTime * smoothTransition);
    }

    /// <summary>
    /// Gravity simulation
    /// </summary>
    private void ApplyGravity()
    {
        if (playerController.isGrounded && m_verticalVelocity < 0)
        {
            m_verticalVelocity = -gravityForce * Time.deltaTime;
        }
        else
        {
            m_verticalVelocity -= gravityForce * Time.deltaTime;
        }
    }

    /// <summary>
    /// Apply all required inputs in one place
    /// </summary>
    private void HandleInputs()
    {
        m_hori = Input.GetAxis("Horizontal");
        m_vert = Input.GetAxis("Vertical");
        m_isRun = Input.GetKey(KeyCode.LeftShift);

        m_inputMouseRight = Input.GetAxis("Mouse X");
        m_inputMouseUp = Input.GetAxis("Mouse Y");
    }
}
