using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BacteriaManager : MonoBehaviour
{

    public Sprite sprite_norm_stat(int key) {
        switch(key) {
            case 0: return sprite_norm_stat_1;
            case 1: return sprite_norm_stat_2;
            case 2: return sprite_norm_stat_3;
            default :
            return sprite_norm_stat_1;
        }
    }
    public Sprite sprite_norm_work(int key) {
        switch(key) {
            case 0: return sprite_norm_work_1;
            case 1: return sprite_norm_work_2;
            case 2: return sprite_norm_work_3;
            default :
            return sprite_norm_work_1;
        }
    }
    public Sprite sprite_burn_stat(int key) {
        switch(key) {
            case 0: return sprite_burn_stat_1;
            case 1: return sprite_burn_stat_2;
            case 2: return sprite_burn_stat_3;
            default :
            return sprite_burn_stat_1;
        }
    }

    public Sprite sprite_burn_work(int key) {
        switch(key) {
            case 0: return sprite_burn_work_1;
            case 1: return sprite_burn_work_2;
            case 2: return sprite_burn_work_3;
            default :
            return sprite_burn_work_1;
        }
    }

    public Sprite sprite_almo_muta(int key) {
        switch(key) {
            case 0: return sprite_almo_muta_1;
            case 1: return sprite_almo_muta_2;
            case 2: return sprite_almo_muta_3;
            default :
            return sprite_almo_muta_1;
        }
    }

    public Sprite sprite_mutated(int key) {
        switch(key) {
            case 0: return sprite_mutated_1;
            case 1: return sprite_mutated_2;
            case 2: return sprite_mutated_3;
            default :
            return sprite_mutated_1;
        }
    }

    public Sprite sprite_dead(int key) {
        switch(key) {
            case 0: return sprite_dead_1;
            case 1: return sprite_dead_2;
            case 2: return sprite_dead_3;
            default :
            return sprite_dead_1;
        }
    }


    public Sprite sprite_norm_stat_1;
    public Sprite sprite_norm_work_1;
    public Sprite sprite_burn_stat_1;
    public Sprite sprite_burn_work_1;
    public Sprite sprite_almo_muta_1;
    public Sprite sprite_mutated_1;
    public Sprite sprite_dead_1;
    public Sprite sprite_norm_stat_2;
    public Sprite sprite_norm_work_2;
    public Sprite sprite_burn_stat_2;
    public Sprite sprite_burn_work_2;
    public Sprite sprite_almo_muta_2;
    public Sprite sprite_mutated_2;
    public Sprite sprite_dead_2;
    public Sprite sprite_norm_stat_3;
    public Sprite sprite_norm_work_3;
    public Sprite sprite_burn_stat_3;
    public Sprite sprite_burn_work_3;
    public Sprite sprite_almo_muta_3;
    public Sprite sprite_mutated_3;
    public Sprite sprite_dead_3;
    
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
    public float LifeRateDivider;
    public float MutationMultipliyer;

    public int MutationTriggering;
    public int MutationThreshold;

    public ExposureLight LightTop;
    public ExposureLight LightBot;
    public ExposureLight LightRight;
    public ExposureLight LightLeft;
    public TextMeshProUGUI text;

    public Dictionary<int, Bacteria> bacterias;
    int cmpt;
    public double Production;

    private void Start()
    {
        bacterias = new Dictionary<int, Bacteria>();
        cmpt = 0;
        Production = 0;


        // MutationTriggering = 800;
        // MutationThreshold = 1000;

        CreateBacteria(transform.position);
    }

    public bool CreateBacteria(Vector3 position, double mutation = 0, int modifier = 0)
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
                BaseMutRate, 
                mutation);
            return true;
        }
        Debug.Log(bacterias.Count);
        return false;
    }

    public void Kill(int ID)
    {
        Destroy(bacterias[ID].gameObject);
        bacterias.Remove(ID);
        //BacteriaIdManager.Instance.LiberateId(ID);
    }

    private void Update()
    {
        if(!MainManager.Pause)
        text.text = Production.ToString();
    }

}
