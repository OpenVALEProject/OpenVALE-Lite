using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamAudioSourceHelper : MonoBehaviour
{
    private List<GameObject> sources = new List<GameObject>();
    public GameObject sourcePrefab;
    public GameObject ambiPrefab;

    public int addClip(AudioClip clip, bool isAmbi = false)
    {
        GameObject newSourceObject;
        if (!isAmbi)
            newSourceObject = GameObject.Instantiate(sourcePrefab,Vector3.zero,Quaternion.identity);
        else
            newSourceObject = GameObject.Instantiate(sourcePrefab,Vector3.zero, Quaternion.Euler(0,0,180));

        newSourceObject.GetComponent<AudioSource>().clip = clip;
        newSourceObject.GetComponent<AudioSource>().spatialize = !isAmbi;
        Debug.Log("Ambisonic " + newSourceObject.GetComponent<AudioSource>().clip.ambisonic);
        Debug.Log("Channels " + newSourceObject.GetComponent<AudioSource>().clip.channels);
        sources.Add(newSourceObject);
        return sources.IndexOf(newSourceObject);
    }

    public AudioSource getSourceFromIndex(int index)
    {
        return sources[index].GetComponent<AudioSource>();
    }
    public void setSourceVolumes(float volume)
    {
        foreach(GameObject g in sources)
        {
            g.GetComponent<AudioSource>().volume = volume;
        }
    }
    public void clearSources()
    {
        foreach(GameObject g in sources) {
            if (g != null) {
                Destroy(g);
            }
        }

        sources.Clear();
    }
}
