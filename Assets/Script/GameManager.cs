using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{

    public List<SpriteRenderer> BGImages = new List<SpriteRenderer>();
    public Fungus.Flowchart TargetFC;
    public string NameOfFinalsVariable = "NumFinales";
    List<int> FinalsUnlocked = new List<int>();
    public int TotalNumberOfFinals = 8;

    public void ChangeImage(string ImageName)
    {
        SpriteRenderer r = BGImages.FirstOrDefault(x => x.name == ImageName);
        if (r == null)
        {
            Debug.LogError("Error: Not found image " + ImageName);
            return;
        }

        foreach (SpriteRenderer s in BGImages)
        {
            s.enabled = (s.name == r.name);
        }
    }

    public void PublishNumFinals()
    {
        var variable = TargetFC.Variables.FirstOrDefault(v => v.Key == NameOfFinalsVariable);

        if (variable == null)
        {
            Debug.LogError("Error finding variable " + NameOfFinalsVariable);
            return;
        }


        string str = FinalsUnlocked.Count + "/" + TotalNumberOfFinals.ToString() + "\nConseguidos:";

        for (int i = 1; i <= TotalNumberOfFinals; i++)
        {
            if (FinalsUnlocked.Contains(i))
            {
                str += i.ToString();
                if (i < TotalNumberOfFinals)
                    str += ",";
            }
        }

        TargetFC.SetStringVariable(NameOfFinalsVariable, str);
    }


    public void UnlockFinal(int FinalID)
    {
        if (!FinalsUnlocked.Contains(FinalID))
            FinalsUnlocked.Add(FinalID);

        SaveGameProgress();
    }


    void Start()
    {
        LoadGameProgress();
    }

    void SaveGameProgress()
    {
        for (int i = 1; i <= TotalNumberOfFinals; i++)
        {
            PlayerPrefs.SetInt("Final" + i.ToString(), ContainsFinal(i));
        }
    }

    void LoadGameProgress()
    {
        for (int i = 1; i <= TotalNumberOfFinals; i++)
        {
            bool v = IntIsTrue(PlayerPrefs.GetInt("Final" + i.ToString()));

            if (v)
            {
                if (!FinalsUnlocked.Contains(i))
                    FinalsUnlocked.Add(i);
            }
        }
    }

    int ContainsFinal(int ID)
    {
        if (FinalsUnlocked.Contains(ID))
            return 1;

        return 0;
    }

    bool IntIsTrue(int i)
    {
        if (i == 1)
            return true;
        else
            return false;
    }

}
