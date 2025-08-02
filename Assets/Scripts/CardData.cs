using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "SOCard")]
public class CardData : ScriptableObject
{
    public GameObject prefab;
    public string spell;
    public string cardName;
}
