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

    public WorldAnchor anchorNegentropy;

    public WorldAnchor anchorWorld;

    public bool savedRootShrine;

    public bool savedRootCeramics;

    public bool savedRootNegentropy;

    public bool saveWorld;

    public GameObject rootGameObjectShrine;

    public GameObject rootGameObjectCeramics;

    public GameObject rootGameObjectNegentropy;

    public GameObject rootGameObjectWorld;

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
        //LoadGameShrine();
        //LoadGameCeramics();
        LoadGameWorld();
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
            savedRootShrine = this.store.Save("rootGameObjectShrinef2", anchorShrine);

            Debug.Log(anchorShrine.transform.position);
        }
    }

    public void SaveGameWorld()
    {
        if (!savedRootShrine)
        {
            saveWorld = this.store.Save("rootGameObjectWorldf2", anchorWorld);
          
            Debug.Log(anchorWorld.transform.position);
        }
    }

    public void SaveGameCeramics()
    {
        if (!savedRootCeramics)
        {
            savedRootCeramics = this.store.Save("rootGameObjectCeramicsf1", anchorCeramics);

            Debug.Log(anchorCeramics.transform.position);
        }
    }

    public void SaveGameNegentropy()
    {
        if (!savedRootNegentropy)
        {
            savedRootCeramics = this.store.Save("rootGameObjectNegentropyf1", anchorNegentropy);

            Debug.Log(anchorNegentropy.transform.position);
        }
    }

    private void LoadGameShrine()
    {
        savedRootShrine = store.Load("rootGameObjectShrinef1", rootGameObjectShrine);

        if (!this.savedRootShrine)
        {
            Debug.Log("no shrine anchor was saved");
            //  SaveGameShrine();
            //  Debug.Log("Saving.." + anchorShrine.transform.position);
        }
    }

    private void LoadGameWorld()
    {
        saveWorld = store.Load("rootGameObjectWorldf2", rootGameObjectWorld);

        if (!this.saveWorld)
        {
            Debug.Log("no world anchor was saved");
            //  SaveGameShrine();
            //  Debug.Log("Saving.." + anchorShrine.transform.position);
        }
    }

    private void LoadGameCeramics()
    {
        savedRootShrine = store.Load("rootGameObjectCeramicsf1", rootGameObjectCeramics);

        if (!this.savedRootCeramics)
        {
            Debug.Log("no ceramics anchor was saved");
          //  SaveGameCeramics();
          //  Debug.Log("Saving.." + anchorCeramics.transform.position);
        }
    }

    private void LoadGameNegentropy()
    {
        savedRootShrine = store.Load("rootGameObjectNegentropyf1", rootGameObjectNegentropy);

        if (!this.savedRootNegentropy)
        {
            Debug.Log("no Negentropy anchor was saved");
            //  SaveGameCeramics();
            //  Debug.Log("Saving.." + anchorCeramics.transform.position);
        }
    }



    private void ResetPositioningShrine()
    {
        store.Delete("rootGameObjectShrinef1");
        savedRootShrine = false;

        // or 
       // store.Clear();
       // for all data delete

    }

    private void ResetPositioningWorld()
    {
        store.Delete("rootGameObjectWorldf2");
        saveWorld = false;

        // or 
        // store.Clear();
        // for all data delete

    }

    private void ResetPositioningCeramics()
    {
        store.Delete("rootGameObjectCeramicsf1");
        savedRootCeramics = false;

        // or 
        // store.Clear();
        // for all data delete

    }

    private void ResetPositioningNegentropy()
    {
        store.Delete("rootGameObjectNegentropyf1");
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
        ResetPositioningCeramics();
        var sphereAnchor = rootGameObjectCeramics.GetComponent<WorldAnchor>();
        Destroy(sphereAnchor);

    }

    public void RemoveAnchorNegentropy()
    {
        ResetPositioningNegentropy();
        var sphereAnchor = rootGameObjectNegentropy.GetComponent<WorldAnchor>();
        Destroy(sphereAnchor);
    }

    public void RemoveAnchorWorld()
    {
        ResetPositioningNegentropy();
        var sphereAnchor = rootGameObjectWorld.GetComponent<WorldAnchor>();
        Destroy(sphereAnchor);
    }
    public void AddAnchorWorld()
    {
        anchorWorld = rootGameObjectWorld.AddComponent<WorldAnchor>();
    }

    public void AddAnchorShrine()
    {
        anchorShrine = rootGameObjectShrine.AddComponent<WorldAnchor>();
    }

    public void AddAnchorCeramics()
    {
        anchorCeramics = rootGameObjectCeramics.AddComponent<WorldAnchor>();
    }

    public void AddAnchorNegentropy()
    {
        anchorNegentropy = rootGameObjectNegentropy.AddComponent<WorldAnchor>();
    }

}

