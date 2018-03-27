using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollectKeys {

    static int CountOfKeys = 1;

    public static List<GameObject> keys = new List<GameObject>();

    public static bool IsAllKeysCollected()
    {
        return keys.Count == CountOfKeys;
    }
}
