using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

[CreateAssetMenu(fileName = "TextChatData", menuName = "TextChatData/Text Chat Data", order = 1)]

public class TextChatData : ScriptableObject
{
    public List<string> chatLines;
}
