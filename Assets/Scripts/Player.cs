using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float rotatespeed = 8f;

    private PlayerControls controls;
    private Vector2 moveInput;
    private bool isWalking; 

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Jump.performed += context => Jump();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Update()
    {
        moveInput = controls.Gameplay.Move.ReadValue<Vector2>();

        isWalking = moveInput != Vector2.zero;

        Vector3 moveDir = new Vector3(moveInput.x, 0f, moveInput.y);

        transform.position += moveDir * movespeed * Time.deltaTime;

        if (isWalking)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotatespeed);
        }

         Debug.Log(moveInput);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    private void Jump()
    {
        Debug.Log("Jump!");
        // „ Ë‚§È¥°√–‚¥¥∑’Ëπ’Ë
    }
}