using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkealityItemComponent : MonoBehaviour
{

   // public ParticleSystem particles;

    public List<IkealityItemComponent> spheresToActivate;

    public GameObject circleToActivate;

    public bool circleActivated;


    // Start is called before the first frame update
    private void Awake()
    {
        circleActivated = false;

        //particles = GetComponent<ParticleSystem>();


        IkealityItemComponent[] allIkealityComponentsinScene = FindObjectsOfType<IkealityItemComponent>();

        foreach (IkealityItemComponent i in allIkealityComponentsinScene)
        {
            if (i.gameObject.name == this.gameObject.name)
            {
                spheresToActivate.Add(i);
            }
        }

        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateAllCircles()
    {
        StartCoroutine(ActivateAllCirclesTimer());
    }

    public IEnumerator ActivateAllCirclesTimer()
    {
        foreach(IkealityItemComponent sphere in spheresToActivate)
        {
            
            if (!sphere.circleActivated)
            {
                sphere.circleActivated = true;
            }
            yield return new WaitForSeconds(0.1f);
            sphere.gameObject.SetActive(true);
        }
    }

   
}
