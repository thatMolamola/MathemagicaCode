using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To-Do: I suspect this will work by chainining one ally to the next when you have more than one ally, but that remains to be tested
public class AllyFollow : MonoBehaviour
{
    private bool close;
    private int moveSpeed = 2;

    [SerializeField] private Transform player;
    [SerializeField] private Animator animator;
    private Vector2 dir;

    // Start is called before the first frame update
    private void Start()
    {
        close = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance (player.transform.position, transform.position) > 2) {
            close = false;
        } else {
            close = true;
        }
        if (!close) {
            Follow();
        }
        if (dir.x != 0 || dir.y != 0) {
            animator.SetBool("isMoving", true);
            Facing();
        } 
    }

    private void Follow() {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed*Time.deltaTime);
        dir = (this.transform.position - player.transform.position).normalized;  
    }

    private void Facing (){  
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y)) {
            if (dir.x > 0) {
                animator.SetFloat("Facing", 2);
            } else if (dir.x < 0) {
                animator.SetFloat("Facing", 4);
            }
        } else if (Mathf.Abs(dir.x) <= Mathf.Abs(dir.y)) {
            if (dir.y > 0) {
                animator.SetFloat("Facing", 1);
            } else if (dir.y < 0) {
                animator.SetFloat("Facing", 3);
            }
        }
    }
}
