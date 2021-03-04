using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;
using UnityEngine.XR.WSA;
using System;

public class WorldAnchorManager : MonoBehaviour
{
    public WorldAnchorStore store;

    public WorldAnchor anchor;

    public bool savedRoot;

    public GameObject rootGameObject;

    // Start is called before the first frame update
    void Start()
    {
        WorldAnchorStore.GetAsync(StoreLoaded);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            SaveGame();
        }
        if (Input.GetKey(KeyCode.V))
        {
            LoadGame();
        }
        if (Input.GetKey(KeyCode.B))
        {
            ListAnchors();
        }
        if (Input.GetKey(KeyCode.N))
        {
            ResetPositioning();
        }
    }

    private void StoreLoaded (WorldAnchorStore store)
    {
        this.store = store;

        ListAnchors();
        LoadGame();
       
    }

    private void ListAnchors()
    {
        string[] ids = store.GetAllIds();
        for (int i = 0; i < ids.Length; i++)
        {
            Debug.Log(ids[i]);
        }
        if(ids == null)
        {
            Debug.Log("No anchors in store");
        }
    }

    private void SaveGame()
    {
        if (!savedRoot)
        {
            savedRoot = store.Save("rootGameObject", anchor);
            Debug.Log(anchor.transform.position);
        }
    }

    private void LoadGame()
    {
        savedRoot = store.Load("rootGameObject", rootGameObject);

        if (!this.savedRoot)
        {
            Debug.Log("no anchor was saved");
        }
    }



    private void ResetPositioning()
    {
        store.Delete("rootGameObject");

        // or 
       // store.Clear();
       // for all data delete

    }

    

   
}

