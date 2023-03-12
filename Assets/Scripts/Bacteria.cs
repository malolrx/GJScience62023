using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static ExposureLight;

public class Bacteria : MonoBehaviour
{
    private double duplicationRateOffset;
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


    private double productionRateOffset;
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
            if (life < 0)
            {
                // death animation
                DuplicationRate = 0;
                Duplication = 0;
                ProductionRate = 0;
                LifeRate = 1f/4f;
                random_mov rm = GetComponent<random_mov>();
                if (rm) Destroy(rm);

                float rate = (100f+life)/100f;
                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                sr.sprite = Manager.sprite_dead(ID%3);
                sr.color *= rate;
                
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.mass = rate;
            }

            if (life <= -100) 
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

    private double mutationRateOffset;
    private double mutation;
    public double Mutation
    {
        get
        {
            return mutation;
        }

        set
        {
            mutation = value;
            if (isAlmostMutated()) {
                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                sr.sprite = Manager.sprite_almo_muta(ID%3);
                // change sprite to almost mutated
            }
            if (isMutated()) {
                // gets a mutation and a new sprite

                // productionRateOffset-=1; ?
                mutationRateOffset+=2;
                duplicationRateOffset+=1;
                LifeRate = Manager.BaseLifeRate;
                DuplicationRate = Manager.BaseDupliRate;

                // ?
                // Mutation = 0;

                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                sr.sprite = Manager.sprite_mutated(ID%3);
            }
        }
    }

    public int ID;
    public BacteriaManager Manager;
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

    bool isBurnedOut() {
        return Life < DuplicationLimitation-Duplication;
    }

    bool isMutated() {
        return Mutation > Manager.MutationThreshold;
    }

    bool isAlmostMutated() {
        return Mutation > Manager.MutationTriggering;
    }

    void resetRates() {
        if (Life < 0) return;

        LifeRate = Manager.BaseLifeRate;
        DuplicationRate = Manager.BaseDupliRate;
        ProductionRate = Manager.BaseProdRate;
        MutationRate = Manager.BaseMutRate;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (Mutation > Manager.MutationThreshold) {
            sr.sprite = Manager.sprite_mutated(ID%3);
            return;
        }
        if (isBurnedOut()) {
            sr.sprite = Manager.sprite_burn_stat(ID%3);
            return;
        }
        if (isAlmostMutated()) {
            sr.sprite = Manager.sprite_almo_muta(ID%3);
            return;
        }
        sr.sprite = Manager.sprite_norm_stat(ID%3);
    }

    // Start is called before the first frame update
    void Start()
    {
        mutationRateOffset=0;
        duplicationRateOffset=0;
        productionRateOffset=0;
        Duplication = 0;
        InvokeRepeating("UpdateSecond", 0, 1.0f);
        GetComponent<SpriteRenderer>().sprite = Manager.sprite_norm_stat(ID%3);
    }

    public void Init(BacteriaManager man,
                    int ID,
                    float Life,
                    float LifeRate,
                    double ProdRate,
                    double DupliRate,
                    int DupliLim,
                    double MutRate,
                    double Mutation
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
        this.Mutation = Mutation;
        ready = true;
        LightChanged = new UnityEvent();
        LightChanged.AddListener(OnLightChanged);
    }

    private void Update()
    {
        if (!MainManager.Pause)
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
            if (Life < 0)
                Life -= LifeRate;
        }
        
    }

    // Update is called once per frame
    void UpdateSecond()
    {
        if (ready && !MainManager.Pause)
        {
            Duplication += DuplicationRate + duplicationRateOffset;
            Life -= LifeRate;
            Mutation += MutationRate + mutationRateOffset;
            Manager.Production += ProductionRate;
        }
        
    }

    private void DuplicateBacteria()
    {
        Debug.Log("duplication : " + Life + " " + Mutation);
        // Duplication = 0;
        Mutation *= 0.92f;
        if (Manager.CreateBacteria(transform.position, Mutation))
            Life = Manager.BaseLife;

    }

    private void OnLightChanged()
    {
        if (isMutated()) return;
        if (Life <= 0) return;

        Debug.Log("trigger");
        if(ExposedLight == ExposureLightType.RED)
        {
            resetRates();
            //croissance 0, production ++
            if (duplicationRateOffset != 0) {
                DuplicationRate = 0;
            }
            if (productionRateOffset == 0)
            {
                ProductionRate = Manager.ProductionMultipliyer;
            } else {
                ProductionRate = productionRateOffset;
            }
            LifeRate = Manager.LifeRateDivider;

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (isBurnedOut()) {
                sr.sprite = Manager.sprite_burn_work(ID%3);
            } else {
                sr.sprite = Manager.sprite_norm_work(ID%3);
            }
        }
        else if(ExposedLight == ExposureLightType.GREEN)
        {
            resetRates();
            //croissance ++, production 0, lifeRate-
            if (duplicationRateOffset == 0)
                DuplicationRate = Manager.DuplicationMultipliyer;
            LifeRate /= Manager.LifeRateDivider;
            MutationRate += Manager.MutationMultipliyer;
        }
        else
        {
            //base
            resetRates();
        }
    }

}
