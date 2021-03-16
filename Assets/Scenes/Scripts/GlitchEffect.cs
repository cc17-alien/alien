/**
This work is licensed under a Creative Commons Attribution 3.0 Unported License.
http://creativecommons.org/licenses/by/3.0/deed.en_GB

You are free:

to copy, distribute, display, and perform the work
to make derivative works
to make commercial use of the work
*/

using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/GlitchEffect")]
[RequireComponent(typeof(Camera))]
public class GlitchEffect : MonoBehaviour
{
	public Texture2D displacementMap;
	public Shader Shader;
	[Header("Glitch Intensity")]

	[Range(0, 1)]
	public float intensity;

	[Range(0, 1)]
	private float flipIntensity;

	[Range(0, 1)]
	private float colorIntensity;

	private float flicker;
	private float _flickerTime = 0.5f;
	private Material _material;
    private float proximity = 0;

	void Start()
	{
        Vibration.Init();
        Debug.Log(proximity);
        StartCoroutine(VibrateWithProximity());
		_material = new Material(Shader);
	}

    float FindClosestAlien(GameObject[] alienObjects)
    {
        float closestAlienProximity = 0;

        foreach (GameObject alien in alienObjects)
        {
            float alienProximity = alien.GetComponent<alienMovement>().ProximityIndicator();

            if (alienProximity > closestAlienProximity)
            {
                closestAlienProximity = alienProximity;
            }
        }

        return closestAlienProximity;
    }

    IEnumerator VibrateWithProximity()
    {
        if (proximity == 0f) Vibration.Cancel();
        if (proximity == 0.25f) Vibration.VibratePop();
        if (proximity == 0.5f) Vibration.VibrateNope();
        if (proximity == 0.75f) Vibration.Vibrate();
        if (proximity >= 1f) Vibration.VibratePeek();

        yield return new WaitForSeconds(1);

        StartCoroutine(VibrateWithProximity());
    }

	// Called by camera to apply image effect
	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		GameObject[] alienObjects = GameObject.FindGameObjectsWithTag("Alien");
        proximity = FindClosestAlien(alienObjects);
        colorIntensity = proximity;
        flipIntensity = proximity;

		_material.SetFloat("_Intensity", intensity);
		_material.SetFloat("_ColorIntensity", colorIntensity);
		_material.SetTexture("_DispTex", displacementMap);

        // set flicker and colour
		flicker += Time.deltaTime * colorIntensity;
		if (flicker > _flickerTime)
		{
			_material.SetFloat("filterRadius", Random.Range(-3f, 3f) * colorIntensity);
			_material.SetVector("direction", Quaternion.AngleAxis(Random.Range(0, 360) * colorIntensity, Vector3.forward) * Vector4.one);
			flicker = 0;
			_flickerTime = Random.value;
		}

		if (colorIntensity == 0)
			_material.SetFloat("filterRadius", 0);

        // do the glitch
		if (Random.value < 0.1f * flipIntensity)
			_material.SetFloat("flip_up", Random.Range(0, 1f) * flipIntensity);
		else
			_material.SetFloat("flip_up", 0);

		if (flipIntensity == 0)
			_material.SetFloat("flip_up", 0);

        // set flip
		if (flipIntensity == 0)
			_material.SetFloat("flip_down", 1);

		if (Random.value < 0.05 * intensity)
		{
			_material.SetFloat("displace", Random.value * intensity);
			_material.SetFloat("scale", 1 - Random.value * intensity);
		}
		else
			_material.SetFloat("displace", 0);

		Graphics.Blit(source, destination, _material);
	}
}
