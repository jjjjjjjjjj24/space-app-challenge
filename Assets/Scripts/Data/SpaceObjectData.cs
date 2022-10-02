using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Space Object")]
public class SpaceObjectData : ScriptableObject
{
    [Header("Object Type")]
    public ObjectType type;

    [Header("Object Description")]
    public Sprite image;
    public string header;
    public string body;

    [Header("Image carried")]
    public Sprite[] capturedImages;
}

public enum ObjectType
{
    Part,
    Telescope
}
