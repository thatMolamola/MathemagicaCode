using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class OWInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private SpriteRenderer interactSprite;

    private GameObject playerTransform;
    private const float interactDist = 2f; 

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player");    
    }

    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && IsCloseEnough()){
            Interact();
        }

        if (interactSprite.gameObject.activeSelf && !IsCloseEnough())
        {
            interactSprite.gameObject.SetActive(false);
        } else if (!interactSprite.gameObject.activeSelf && IsCloseEnough()) {
            interactSprite.gameObject.SetActive(true);
        }
    }

    public abstract void Interact();

    private bool IsCloseEnough()
    {
        if (Vector2.Distance(playerTransform.transform.position, transform.position) < interactDist){
            return true;
        } else {return false;}
    }
}
