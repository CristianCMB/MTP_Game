using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[System.Serializable]
public class ResourceAmount
{
    [FormerlySerializedAs("ResourceType")] public ResourceTypeSO resourceType;
    public int amount;
}
