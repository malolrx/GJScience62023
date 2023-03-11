using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaManager : MonoBehaviour
{
    sealed class BacteriaIdManager
    {
        private static BacteriaIdManager _instance;
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

        BacteriaIdManager() { Init(); }

        void Init()
        {
            freeIds = new List<int>();
            cmpt = 1;
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
                return cmpt--;
            }
        }

        public void LiberateId(int id)
        {
            freeIds.Add(id);
        }
    }

    public GameObject BacteriaPrefab;

    public int BaseLife;
    public float BaseLifeRate;
    public float BaseProdRate;
    public float BaseDupliRate;
    public float MutRate;

    private Dictionary<int, Bacteria> bacterias;

    private void Start()
    {
        bacterias = new Dictionary<int, Bacteria>();
        CreateBacteria(transform.position);
    }

    public void CreateBacteria(Vector3 position,int modifier = 0)
    {
        var go = Instantiate(BacteriaPrefab, position + new Vector3(1*modifier,1), Quaternion.identity);
        var bac = go.GetComponent<Bacteria>();
        
            
    }

    public void Kill(int ID)
    {
        Destroy(bacterias[ID].gameObject);
        bacterias.Remove(ID);
        BacteriaIdManager.Instance.LiberateId(ID);
    }

}
