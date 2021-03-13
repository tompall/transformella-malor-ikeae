using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;
using UnityEngine.XR.WSA;
using System;

public class WorldAnchorManager : MonoBehaviour
{
    public WorldAnchorStore store;

    public WorldAnchor anchorShrine; 
    
    public WorldAnchor anchorCeramics;

    public bool savedRootShrine;

    public bool savedRootCeramics;

    public GameObject rootGameObjectShrine;

    public GameObject rootGameObjectCeramics;

    // Start is called before the first frame update
    void Start()
    {
        WorldAnchorStore.GetAsync(StoreLoaded);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void StoreLoaded (WorldAnchorStore store)
    {
        this.store = store;

        ListAnchors();
        LoadGameShrine();
        LoadGameCeramics();
       
    }

    private void ListAnchors()
    {
        string[] ids = store.GetAllIds();
        for (int i = 0; i < ids.Length; i++)
        {
            Debug.Log(ids[i]);
        }
        
    }

    public void SaveGameShrine()
    {
        if (!savedRootShrine)
        {
            savedRootShrine = this.store.Save("rootGameObjectShrine2", anchorShrine);
          
            Debug.Log(anchorShrine.transform.position);
        }
    }

    public void SaveGameCeramics()
    {
        if (!savedRootCeramics)
        {
            savedRootCeramics = this.store.Save("rootGameObjectCeramics2", anchorCeramics);

            Debug.Log(anchorCeramics.transform.position);
        }
    }

    private void LoadGameShrine()
    {
        savedRootShrine = store.Load("rootGameObjectShrine2", rootGameObjectShrine);

        if (!this.savedRootShrine)
        {
            Debug.Log("no shrine anchor was saved");
            SaveGameShrine();
            Debug.Log("Saving.." + anchorShrine.transform.position);
        }
    }

    private void LoadGameCeramics()
    {
        savedRootShrine = store.Load("rootGameObjectCeramics2", rootGameObjectCeramics);

        if (!this.savedRootCeramics)
        {
            Debug.Log("no ceramics anchor was saved");
            SaveGameCeramics();
            Debug.Log("Saving.." + anchorCeramics.transform.position);
        }
    }




    private void ResetPositioningShrine()
    {
        store.Delete("rootGameObjectShrine2");
        savedRootShrine = false;

        // or 
       // store.Clear();
       // for all data delete

    }

    private void ResetPositioningCeramics()
    {
        store.Delete("rootGameObjectCeramics2");
        savedRootCeramics = false;

        // or 
        // store.Clear();
        // for all data delete

    }
    public void RemoveAnchorSrhine()
    {
        ResetPositioningShrine();
        var sphereAnchor = rootGameObjectShrine.GetComponent<WorldAnchor>();
        Destroy(sphereAnchor);
        
    }

    public void RemoveAnchorCermics()
    {
        ResetPositioningShrine();
        var sphereAnchor = rootGameObjectCeramics.GetComponent<WorldAnchor>();
        Destroy(sphereAnchor);

    }

    public void AddAnchorShrine()
    {
        anchorShrine = rootGameObjectShrine.AddComponent<WorldAnchor>();
    }

    public void AddAnchorCeramics()
    {
        anchorCeramics = rootGameObjectCeramics.AddComponent<WorldAnchor>();
    }

}

