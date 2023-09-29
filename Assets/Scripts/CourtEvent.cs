using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextKingdom/Court Event")]
public class CourtEvent : ScriptableObject
{
    [field: SerializeField] public string eventName { get; set; }
    [field: SerializeField] [field: TextArea] public string description { get; set; }
    [field: SerializeField] public TextAsset inkJSON { get; private set; }
}
