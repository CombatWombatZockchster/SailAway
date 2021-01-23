using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshSequencer : MonoBehaviour
{
    public String resourceFolderName = "fluidTest";
    public Mesh[] meshes;
    int index = 0;
    public int fps = 25;
    MeshFilter filter;

    
    void Start()
    {
        meshes = Resources.LoadAll<Mesh>(resourceFolderName);
        if (meshes.Length == 0)
            return;
        filter = GetComponent<MeshFilter>();
        StartCoroutine(switcher());
    }

    IEnumerator switcher()
    {
        while (true)
        {
            filter.mesh = meshes[index];
            index++;
            if (index >= meshes.Length) index = 0;
            yield return new WaitForSeconds(1.0f / (float)fps);
        }
    }
}
