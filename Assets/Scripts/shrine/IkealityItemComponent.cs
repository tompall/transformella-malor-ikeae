using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkealityItemComponent : MonoBehaviour
{

    public ParticleSystem particles;

    public List<GameObject> spheresToActivate;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();

       

        IkealityItemComponent[] allIkealityComponentsinScene = FindObjectsOfType<IkealityItemComponent>();

        foreach(IkealityItemComponent i in allIkealityComponentsinScene)
        {
            if (i.gameObject.name == this.gameObject.name)
            {
                spheresToActivate.Add(i.gameObject);
            }
        }

        Invoke("DeactivateParticles", 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeactivateParticles()
    {

        particles.enableEmission = false;
    }
}
