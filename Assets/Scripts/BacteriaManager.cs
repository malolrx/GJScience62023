using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BacteriaManager : MonoBehaviour
{
    /*sealed class BacteriaIdManager
    {
        private static BacteriaIdManager _instance = null;
        public static BacteriaIdManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BacteriaIdManager();
                }
                return _instance;
            }
        }

        private List<int> freeIds;

        private int cmpt;

        BacteriaIdManager() { Init();}

        void Init()
        {
            freeIds = new List<int>();
            cmpt = 0;

        }

        public int GetId()
        {
            if (freeIds.Count > 0)
            {
                var id = freeIds[0];
                freeIds.Remove(id);
                return id;
            }
            else
            {
                cmpt++;
                Debug.LogWarning(cmpt);
                return cmpt--;
            }
        }

        public void LiberateId(int id)
        {
            freeIds.Add(id);
        }
    }
    */
    public GameObject BacteriaPrefab;

    public int BacteriaMax;

    public int BaseLife;
    public float BaseLifeRate;
    public float BaseProdRate;
    public float BaseDupliRate;
    public int BaseDupliLim;
    public float BaseMutRate;
    public int DuplicationMultipliyer;
    public int ProductionMultipliyer;

    public ExposureLight LightTop;
    public ExposureLight LightBot;
    public ExposureLight LightRight;
    public ExposureLight LightLeft;
    public TextMeshProUGUI text;

    private Dictionary<int, Bacteria> bacterias;
    int cmpt;
    public double Production;

    private void Start()
    {
        bacterias = new Dictionary<int, Bacteria>();
        cmpt = 0;
        Production = 0;
        CreateBacteria(transform.position);
    }

    public void CreateBacteria(Vector3 position,int modifier = 0)
    {
        if(bacterias.Count < BacteriaMax)
        {
            var go = Instantiate(BacteriaPrefab, position + new Vector3(1, 1), Quaternion.identity);
            
            var bac = go.GetComponent<Bacteria>();
            var id = cmpt;
            cmpt++;
            
            bacterias.Add(id, bac);
            bac.Init(this,
                id,
                BaseLife,
                BaseLifeRate,
                BaseProdRate,
                BaseDupliRate,
                BaseDupliLim,
                BaseMutRate);
        }
        Debug.Log(bacterias.Count);
    }

    public void Kill(int ID)
    {
        Destroy(bacterias[ID].gameObject);
        bacterias.Remove(ID);
        //BacteriaIdManager.Instance.LiberateId(ID);
    }

    private void Update()
    {
        text.text = Production.ToString();
    }

}
