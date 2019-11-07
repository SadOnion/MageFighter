using UnityEngine;
[CreateAssetMenu(fileName ="New Element",menuName ="Element")]
public class Element : ScriptableObject
{
    public ElementType type;
    public Sprite image;
}