using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class GoToNextLevel : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SaveLoad.GoToNextSceneAndSave();
    }
}
