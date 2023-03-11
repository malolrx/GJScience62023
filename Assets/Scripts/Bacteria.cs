using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
    private double duplicationRate;
    public double DuplicationRate
    {
        get
        {
            return duplicationRate;
        }

        set
        {
            duplicationRate = value;
        }
    }

    private double duplicationLimitation;
    public double DuplicationLimitation
    {
        get
        {
            return duplicationRate;
        }

        set
        {
            duplicationRate = value;
        }
    }

    private double duplication;
    public double Duplication
    {
        get
        {
            return duplication;
        }
        set
        {
            if(value == DuplicationLimitation)
            {
                DuplicateBacteria();
                duplication = 0;
                return;
            }
            duplication = value;
        }
    }

    private float lifeRate;
    public float LifeRate
    {
        get
        {
            return lifeRate;
        }
        set
        {
            lifeRate = value;
        }
    }

    private double productionRate;
    public double ProductionRate
    {
        get
        {
            return productionRate;
        }
        set
        {
            productionRate = value;
        }
    }
    
    private float life;
    public float Life
    {
        get { return life; }
        set
        {
            life = value;
            if (life <= 0)
            {
                Manager.Kill(this.ID);
            }
        }
    }

    private double mutationRate;
    public double MutationRate
    {
        get
        {
            return mutationRate;
        }

        set
        {
            mutationRate = value;
        }
    }

    public int ID;
    public BacteriaManager Manager;
    private int cmpt;
    bool ready;



    // Start is called before the first frame update
    void Start()
    {
        Duplication = 0;
        cmpt = 0;
        ready = false;
        InvokeRepeating("UpdateSecond", 0, 1.0f);
    }

    public void Init(BacteriaManager man,
                    int ID,
                    float Life,
                    float LifeRate,
                    double ProdRate,
                    double DupliRate,
                    int DupliLim,
                    double MutRate
                    )
    {
        this.Manager = man;
        this.ID = ID;
        this.Life = Life;
        this.DuplicationRate = DupliRate;
        this.LifeRate = LifeRate;
        this.ProductionRate = ProdRate;
        this.DuplicationLimitation = DupliLim;
        this.MutationRate = MutRate;
        ready = true;
    }

    // Update is called once per frame
    void UpdateSecond()
    {
        
        if (ready)
        {
            Duplication += DuplicationRate;
            Life -= LifeRate;
        }
        
    }

    private void DuplicateBacteria()
    {
        Manager.CreateBacteria(transform.position,cmpt);
        cmpt++;
    }

}
