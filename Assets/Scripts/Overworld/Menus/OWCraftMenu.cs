using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OWCraftMenu : MonoBehaviour
{
    private CombatPrefabRefer allies;
    private PlayerUnit selectedPlayer;
    private Inventory ingredients;
    private Button bookButton;
    private EnchantMenu[] charBooks =  new EnchantMenu [3];
    [SerializeField] private Transform openBookParent, closedBookParent;
    

    void Start() {
        allies = Resources.Load<CombatPrefabRefer>("SOs/Dynamic/CombatRefer");
        booksSetup();
    }

    private void booksSetup() {
        foreach (Transform book in closedBookParent) {
            int bookIndex = book.GetSiblingIndex();
            bookButton = book.GetComponent<Button>();
            bookButton.onClick.AddListener(() => onBookSelect(book.GetSiblingIndex()));
            PlayerUnit selectedPlayer = allies.allyTeam[bookIndex].GetComponent<PlayerUnit>();
            charBooks[bookIndex] = openBookParent.GetChild(bookIndex).GetComponent<EnchantMenu>();
            bookButton.onClick.AddListener(() => charBooks[bookIndex].ListLoad(selectedPlayer));
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
