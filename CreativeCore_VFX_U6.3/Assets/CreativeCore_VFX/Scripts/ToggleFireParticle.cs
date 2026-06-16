using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class ToggleFireParticle : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Space;

    private ParticleSystem fireParticle;
    public ParticleSystem igniteParticle;
    public ParticleSystem extinguishParticle;
    public GameObject pointLight;
    public float rainValue;
    public ScriptChuva chuva;

    bool isPlaying = true;

    private void Start()
    {
        fireParticle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        rainValue = chuva.rainVal();
        Debug.Log(rainValue);
        if(Input.GetKeyDown(toggleKey))
        {
            if(isPlaying)
            {
                Extinguish();
            } 
            else
            {
                Light();
            }
        }
        if(isPlaying && rainValue > 300)
        {
            Extinguish();
        }
        fireParticle.startSpeed -= Time.deltaTime/12;
    }

    public void Light()
    {
        fireParticle.Play();
        pointLight.SetActive(true);
        if (igniteParticle != null)
            igniteParticle.Play();
        isPlaying = true;
    }

    public void Extinguish()
    {
        fireParticle.Stop();
        pointLight.SetActive(false);
        if (extinguishParticle != null)
            extinguishParticle.Play();
        isPlaying = false;
    }
}
