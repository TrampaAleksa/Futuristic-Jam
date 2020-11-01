using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickUps : MonoBehaviour
{
    public static List<Place> selectedPlaces;
    public List<GameObject> placeHolders;
    public GameObject package;
    public List<string> tags;
    public float timeSpawn = 15;
    public float deletePackage = 30;
    public static List<GameObject> packages;
    public static List<int> takenPlaces;
    float currentTime = 0;
    float spawningTime;
    float deletingTime;

    private void Awake()
    {
        spawningTime = timeSpawn;
        deletingTime= deletePackage;
    }
    private void Update()
    {
        currentTime += currentTime + Time.deltaTime;
        if (currentTime == spawningTime)
        {
            SpawnPackage();
            spawningTime += spawningTime;
        }
        if(currentTime == deletingTime)
        {
            DeletePackage();
            deletingTime += deletePackage;
        }
    }

    public void SpawnPackage()
    {
        int i = Random.Range(0, placeHolders.Count);
        int j = Random.Range(0, tags.Count);
        package.tag = tags[j];
        if (IsItFree(i))
        {
            Instantiate(package, placeHolders[i].transform);
            packages.Add(package);
            takenPlaces.Add(i);
            Place p = new Place();
            p.index = i;
            p.package = package;
            selectedPlaces.Add(p);
        }
    }
 
    public void DeletePackage()
    {
        GameObject help = packages[0];
        packages.Remove(packages[0]);
        takenPlaces.Remove(takenPlaces[0]);
        selectedPlaces.Remove(selectedPlaces[0]);
        Destroy(help.gameObject);
    }
    public bool IsItFree(int index)
    {
        foreach(int i in takenPlaces)
        {
            if(index == i)
            {
                return true;
            }
        }
        return false;
    }
    public static int ReturnIndex(List<Place> selectedPlaces,GameObject package)
    {
        int i = 0;
        for(int j = 0; j < selectedPlaces.Count; j++)
        {
            if (selectedPlaces[j].package.transform.position == package.transform.position)
                i = j;
        }
        return i;
    }

}
[System.Serializable]
public class Place
{
   public GameObject package;
    public int index;
}
