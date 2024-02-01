using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//this script controls the player movement.
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveBy;
    private Controls pControls;

    private float moveFactor = 5f;

    public bool canMove;
    [SerializeField] private Animator animator;

    


    void Awake() {
        pControls = new Controls();

        pControls.Gameplay.Walk.performed += ctx => moveBy = ctx.ReadValue<Vector2>();
        pControls.Gameplay.Walk.canceled += ctx => moveBy = Vector2.zero;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable() {
        pControls.Gameplay.Enable();
    }

    void OnDisable() {
        pControls.Gameplay.Disable();
    }

    void FixedUpdate() {
        if (canMove) {
            rb.MovePosition(rb.position + moveBy * moveFactor * Time.deltaTime);
            if (moveBy.x != 0 || moveBy.y != 0) {
                animator.SetBool("isMoving", true);
                Facing();
            } 
        }     
    }
    
    private void Facing (){  
        if (moveBy.x > 0) {
            animator.SetFloat("Facing", 4);
        } else if (moveBy.x < 0) {
            animator.SetFloat("Facing", 2);
        }

        if (moveBy.y > 0) {
            animator.SetFloat("Facing", 3);
        } else if (moveBy.y < 0) {
            animator.SetFloat("Facing", 1);
        }
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Enemy") {
            canMove = false;
        }
        StartCoroutine(canMoveAgain());
    }

    IEnumerator canMoveAgain() {
        yield return new WaitForSeconds(2f);
        canMove = true;
    }
}

