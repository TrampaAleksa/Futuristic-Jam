using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickUps : MonoBehaviour
{
    public static List<Place> selectedPlaces;
    List<GameObject> placeHolders;
    public GameObject package;
    List<string> tags;
    public float timeSpawn = 10;
    public float deletePackage = 20;
    public static List<GameObject> packages;
    public static List<int> takenPlaces;
    float currentTime;
    float spawningTime;
    float deletingTime;

    public GameObject placeholder0;
    public GameObject placeholder1;
    public GameObject placeholder2;
    public GameObject placeholder3;
    public GameObject placeholder4;
    public GameObject placeholder5;
    public string tag0;
    public string tag1;
    public string tag2;
    public string tag3;
    public string tag4;
    public string tag5;
 
    private void Awake()
    {
        takenPlaces = new List<int>();
        placeHolders = new List<GameObject>();
        placeHolders.Add(placeholder0);
        placeHolders.Add(placeholder1);
        placeHolders.Add(placeholder2);
        placeHolders.Add(placeholder3);
        placeHolders.Add(placeholder4);
        placeHolders.Add(placeholder5);
        tags = new List<string>();
        tags.Add(tag0);
        tags.Add(tag1);
        tags.Add(tag2);
        tags.Add(tag3);
        tags.Add(tag4);
        tags.Add(tag5);
       
        selectedPlaces = new List<Place>();
       
        packages = new List<GameObject>();
        currentTime = 0;
        spawningTime = timeSpawn;
        deletingTime = deletePackage;
        Debug.Log(spawningTime + deletingTime);
    }
    private void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        SpawnPackage();
        DeletePackage();
    }

    public void SpawnPackage()
    {
        if ((int)currentTime == (int)spawningTime)
        {
            int i = Random.Range(0, placeHolders.Count);
            int j = Random.Range(0, tags.Count);
            package.tag = tags[j];
            if (IsItFree(i))
            {
                GameObject help = Instantiate(package, placeHolders[i].transform);
                packages.Add(help);
                takenPlaces.Add(i);
                Place p = new Place();
                p.index = i;
                p.package = help;
                selectedPlaces.Add(p);
                Debug.Log("The object has been spawned ");
            }
            spawningTime += timeSpawn;
        }
        //Debug.Log("Next spawning time " + spawningTime);
    }
 
    public void DeletePackage()
    {
        if ((int)currentTime == (int)deletingTime)
        {
            GameObject help = packages[0];
            packages.Remove(packages[0]);
            takenPlaces.Remove(takenPlaces[0]);
            selectedPlaces.Remove(selectedPlaces[0]);
            Destroy(help);
            deletingTime += deletePackage;
            Debug.Log("The object has been deleted ");
        }
    }
    public bool IsItFree(int marko)
    {
        for(int i = 0; i < takenPlaces.Count; i++)
        {
            if (takenPlaces[i] == marko)
                return false;
        }
        return true;
    }
    public static int ReturnIndex(List<Place> selectedPlaces,GameObject package)
    {
        int i = 0;
        for(int j = 0; j < selectedPlaces.Count; j++)
        {
            if (selectedPlaces[j].Equals(package))
                i = j;
        }
        return i;
    }

    public static void DestroyFromPlayer(GameObject gameObject)
    {
        int index = ReturnIndex(selectedPlaces, gameObject);
        takenPlaces.Remove(index);
        packages.Remove(gameObject);
        Place p = new Place();
        p.index = index;
        p.package = gameObject;
        selectedPlaces.Remove(p);
        Destroy(gameObject.gameObject);
    }
}
[System.Serializable]
public class Place
{
   public GameObject package;
   public int index;
}
