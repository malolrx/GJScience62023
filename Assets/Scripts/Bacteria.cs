using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static ExposureLight;

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
            return duplicationLimitation;
        }

        set
        {
            duplicationLimitation = value;
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
            if(duplication >= DuplicationLimitation)
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

    private ExposureLightType exposedLight;
    public ExposureLightType ExposedLight
    {
        get
        {
            return exposedLight;
        }
        set
        {
            exposedLight = value;
            LightChanged.Invoke();
        }
    }

    UnityEvent LightChanged;

    // Start is called before the first frame update
    void Start()
    {
        Duplication = 0;
        cmpt = 0;
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
        this.LifeRate = LifeRate;
        this.DuplicationRate = DupliRate;
        this.DuplicationLimitation = DupliLim;
        this.ProductionRate = ProdRate;
        this.MutationRate = MutRate;
        ready = true;
        LightChanged = new UnityEvent();
        LightChanged.AddListener(OnLightChanged);
    }

    private void Update()
    {
        Debug.Log(ExposedLight);
        if (Manager.LightTop.IsInLight(transform.position))
        {
            ExposedLight = Manager.LightTop.Type;
        }
        else if (Manager.LightBot.IsInLight(transform.position))
        {
            ExposedLight = Manager.LightBot.Type;
        }
        else if (Manager.LightLeft.IsInLight(transform.position))
        {
            ExposedLight = Manager.LightLeft.Type;
        }
        else if (Manager.LightRight.IsInLight(transform.position))
        {
            ExposedLight = Manager.LightRight.Type;
        }
        else
        {
            ExposedLight = ExposureLightType.NO;
        }
    }

    // Update is called once per frame
    void UpdateSecond()
    {
        Debug.Log("prod" + ProductionRate);
        Debug.Log("Dupli" + DuplicationRate);
        if (ready)
        {
            Duplication += DuplicationRate;
            Life -= LifeRate;
            Manager.Production += ProductionRate;
        }
        
    }

    private void DuplicateBacteria()
    {
        Manager.CreateBacteria(transform.position);
    }

    private void OnLightChanged()
    {
        Debug.Log("trigger");
        if(ExposedLight == ExposureLightType.RED)
        {
            //croissance 0, production ++
            DuplicationRate = 0;
            ProductionRate = Manager.ProductionMultipliyer;
        }
        else if(ExposedLight == ExposureLightType.GREEN)
        {
            //croissance ++, production 0, lifeRate-
            DuplicationRate = Manager.DuplicationMultipliyer;
            //LifeRate *= 3;
        }
        else
        {
            //base
            DuplicationRate = Manager.BaseDupliRate;
            ProductionRate = Manager.BaseProdRate;
            //LifeRate = Manager.BaseLifeRate;
        }
    }

}
