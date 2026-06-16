using UnityEngine;

public class ScriptChuva : MonoBehaviour
{
    public ParticleSystem rain;
    public float value;
    void Start()
    {
        var emission = rain.emission;
        emission.rateOverTime = 0;
    }
    void Update()
    {
        var emission = rain.emission;
        value += 15*Time.deltaTime;
        emission.rateOverTime = value; 
    }

    public float rainVal()
    {
        return value;
    }
}
