using System.Collections.Generic;
using UnityEngine;

public class Oyun2_Secimler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    public List<GameObject> boykotPanels;
    public List<GameObject> trPanels;
    
    private GameObject[] exBoykotPanels;
    private GameObject[] exTrPanels;

    private int sagSol;
    
    private void Start()
    {
        for (int i = 1; i <= 9; i++)
        {
            sagSol = Random.Range(0, 2);
            if (sagSol == 1)
            {
                int panelIndex1 = RandomSayiUret(0, boykotPanels.Count);
                int panelIndex2 = RandomSayiUret(0, boykotPanels.Count);
                boykotPanels[panelIndex1].transform.position = new Vector3(player.transform.position.x + 2f, player.transform.position.y, player.transform.position.z + 20f * i);
                trPanels[panelIndex2].transform.position = new Vector3(player.transform.position.x - 2f, player.transform.position.y, player.transform.position.z + 20f * i);
                RemoveList(panelIndex1, panelIndex2);
            }
            else
            {
                int panelIndex3 = RandomSayiUret(0, boykotPanels.Count);
                int panelIndex4 = RandomSayiUret(0, boykotPanels.Count);
                boykotPanels[panelIndex3].transform.position = new Vector3(player.transform.position.x - 2f, player.transform.position.y, player.transform.position.z + 20f * i);
                trPanels[panelIndex4].transform.position = new Vector3(player.transform.position.x + 2f, player.transform.position.y, player.transform.position.z + 20f * i);
                RemoveList(panelIndex3, panelIndex4);
            }
        }
    }

    private int RandomSayiUret(int min, int max)
    {
        return Random.Range(min, max);
    }

    private void RemoveList(int obj, int obj2)
    {
        boykotPanels.RemoveAt(obj);
        trPanels.RemoveAt(obj2);
    }
}
