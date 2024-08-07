using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[CreateAssetMenu(fileName = "Bombs", menuName = "Bomb")]
public class BombTypes : ScriptableObject
{
    public int price;
    public Sprite bombIcon;
    public string nameBomb;
}
