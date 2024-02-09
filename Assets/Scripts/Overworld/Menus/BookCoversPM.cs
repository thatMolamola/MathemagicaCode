using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this Script loads in the closed books as buttons to activate the open books
public class BookCoversPM : MonoBehaviour
{
    private int bookIndex;
    private CombatPrefabRefer allies;
    [SerializeField] private Transform openBookParent, closedBookParent;
    
    void Start() {
        allies = Resources.Load<CombatPrefabRefer>("SOs/Dynamic/CombatRefer");
        booksSetup();
    }

    private void booksSetup() {
        for (int bookIndex = 0; bookIndex < allies.allyTeam.Count; bookIndex++) {
            Transform book = closedBookParent.GetChild(bookIndex);
            book.gameObject.SetActive(true);
        }
    }
    
    public void onBookSelect(int bookNum) {
        openBookParent.GetChild(bookNum).gameObject.SetActive(true);
    }

    public void leaveCraft() {
        foreach (Transform child in openBookParent) {
            child.gameObject.SetActive(false);
        }
    }
}
