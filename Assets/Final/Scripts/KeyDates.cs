using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Calendar System/Keydate")]
public class KeyDates : ScriptableObject
{
    public string description;
    public string eventDescription;
    public Text keydateName;
    public AudioSource music; 
}
