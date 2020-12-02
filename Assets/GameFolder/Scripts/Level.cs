using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; //serialized for debugging purposes

    SceeneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceeneLoader>();
    }

    public void CountBlock()
    {
        breakableBlocks++;
    }
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks == 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
