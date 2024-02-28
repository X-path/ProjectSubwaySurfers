using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using DG.Tweening;


public class Player : MonoBehaviour
{
    private IState currentState;
    //[SerializeField] float speed;
    [SerializeField] public bool isGrounded;
    public bool isJumping;
    public bool isRolling;
    bool isCrashing;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float jumpPower;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] public Animator animator;
    [SerializeField] Transform groundControlTransform;
    [SerializeField] List<int> posXList = new List<int>();
    public int posXListRow = 1;
    [SerializeField] SkinnedMeshRenderer playerMesh;
    void Start()
    {
        currentState = new IdleState();
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.instance.GState != GameState.Play)
            return;

        //HandleMovement();
        HandleInput();
        currentState.UpdateState(this);
    }
    void HandleInput()
    {


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Right
            ChangeXTransform(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Left
            ChangeXTransform(false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Jump
            isJumping = true;

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Roll
            isRolling = true;
        }

    }
    /*void HandleMovement()
    {
        rigidbody.velocity = new Vector3(transform.position.x, rigidbody.velocity.y, speed);
    }
    */
    void ChangeXTransform(bool isValue)
    {
        if (isValue)
        {
            if (posXListRow + 1 <= posXList[posXList.Count - 1])
            {
                posXListRow += 1;
                rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                transform.DOMoveX(posXList[posXListRow], 0.15f).OnComplete(() =>
                {
                    rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                });
            }
        }
        else
        {
            if (posXListRow - 1 >= 0)
            {
                posXListRow -= 1;
                rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                transform.DOMoveX(posXList[posXListRow], 0.15f).OnComplete(() =>
                {
                    rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                });
            }
        }
    }
    public void HandleJump()
    {
        Debug.Log($"JUMP");
        rigidbody.AddForce(transform.up * jumpPower);
    }
    public void ChangeState(IState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState?.EnterState(this);
    }
    public bool IsGrounded()
    {
        float raycastLength = 0.25f;
        isGrounded = Physics.Raycast(groundControlTransform.position, Vector3.down, raycastLength, groundLayer);
        return isGrounded;
    }
    private void OnDrawGizmosSelected()
    {
        float raycastLength = .25f;
        Debug.DrawRay(groundControlTransform.position, Vector3.down * raycastLength, Color.red);
    }
    public bool IsJumping()
    {
        return isJumping;
    }
    public bool IsRolling()
    {
        return isRolling;
    }

    public void ObstacleCrash()
    {
        if (!isCrashing)
        {
            isCrashing = true;
            StartCoroutine(BlinkAnim());
            return;

        }
        else
        {
            ChangeState(new IdleState());
            UIManager.instance.Died();
        }
    }
    IEnumerator BlinkAnim()
    {
        int i = 0;
        while (i < 6)
        {
            if (playerMesh.enabled)
            {
                playerMesh.enabled = false;
            }
            else
            {
                playerMesh.enabled = true;
            }
            i++;

            yield return new WaitForSeconds(.15f);
        }

        playerMesh.enabled = true;
        isCrashing = false;

    }

}
