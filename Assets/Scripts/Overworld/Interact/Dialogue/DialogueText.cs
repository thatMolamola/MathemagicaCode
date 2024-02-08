using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/New Dialogue Container")]
public class DialogueText : ScriptableObject
{
    public string[] speakerNames;
    public string[] paragraphs;
    public Sprite[] images;
}
