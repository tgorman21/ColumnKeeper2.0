using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Arrow : XRGrabInteractable
{
   [Header("Settings")]
    public float speed = 2000.0f;
    
    [Header("Hit")]
    public Transform tip = null;
    public LayerMask layerMask = ~Physics.IgnoreRaycastLayer;

    private new Collider collider = null;
    private new Rigidbody rigidbody = null;

    private Vector3 lastPosition = Vector3.zero;
    public bool launched = false;
   
    protected override void Awake()
    {
        base.Awake();
        collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        ////// Do this first, so we get the right physics values
        if (args.interactor is XRDirectInteractor)
            Clear();
        
        ////// Make sure to do this
        base.OnSelectEntering(args);
    }

    private void Clear()
    {
        SetLaunch(false);
        TogglePhysics(true);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        ////// Make sure to do this
        base.OnSelectExited(args);

        ///// If it's a notch, launch the arrow
        if (args.interactor is Notch notch)
            Launch(notch);
       
    }

    private void Launch(Notch notch)
    {
        /////Double-check incase the bow is dropped with arrow socketed
        if (notch.IsReady)
        {
            SetLaunch(true);
            UpdateLastPosition();
            ApplyForce(notch.PullMeasurer);
            ArrowType arrow = GetComponent<ArrowType>();
            arrow.trail.enabled = true;

        }
    }

    public void SetLaunch(bool value)
    {
        collider.isTrigger = value;
        launched = value;
       
    }

    private void UpdateLastPosition()
    {
        ////// Always use the tip's position
        lastPosition = tip.position;
    }

    private void ApplyForce(PullMeasurer pullMeasurer)
    {
        ////// Apply force to the arrow
        float power = pullMeasurer.PullAmount;
        Vector3 force = transform.forward * (power * speed);
        Debug.Log(power + "|" + speed);
        rigidbody.AddForce(force);
    }
    public void Rain(float forceArrow)
    {
        ////// Apply force to the arrow
        float power = forceArrow;
        Vector3 force = transform.forward * (power * speed);
        rigidbody.AddForce(force);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (launched)
        {
          
                ////// Check for collision as often as possible 
                if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
                {
                    if (CheckForCollision())
                        launched = false;

                    UpdateLastPosition();
                }

                //////Only set the direction with each physics update
                if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Fixed)
                    SetDirection();
            }
        
    }

    private void SetDirection()
    {
        /////// Look in the direction the arrow is moving
        if (rigidbody.velocity.z > 0.5f)
            transform.forward = rigidbody.velocity;
    }

    private bool CheckForCollision()
    {
        ////// Check if there was a hit
        if (Physics.Linecast(lastPosition, tip.position, out RaycastHit hit, layerMask))
        {
            TogglePhysics(false);
            Debug.Log("Hit: " + hit.transform.gameObject.name);
            ArrowType arrow = GetComponent<ArrowType>();
            TogglePhysics(false);
            ChildArrow(hit);
            CheckForHittable(hit);
            if (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("ground") || hit.collider.CompareTag("Target"))
            {
                ImpactEffect ie = GetComponent<ImpactEffect>();
                if (ie != null)
                {
                    ie.TriggerEffect(hit.point, hit.collider.transform.rotation);
                }
                switch (arrow.typeOfArrow)
                {
                    
                    case ArrowType.TypeOfArrow.Fire:
                        FireArrow fa = GetComponent<FireArrow>();
                        if (fa != null)
                        {
                            Vector3 pos = new Vector3(hit.point.x, hit.point.y + 12, hit.point.z);
                            fa.Explode(hit.collider.transform.eulerAngles, pos);
                        }

                        break;
                    case ArrowType.TypeOfArrow.Ice:
                        IceArrow ia = GetComponent<IceArrow>();
                        if (ia != null)
                        {
                            ia.IceEffect(PlayerPrefs.GetFloat(arrow.typeOfArrow+"ArrowDamage"));
                        }

                        break;
                    case ArrowType.TypeOfArrow.MeteorShower:
                        MeteorShower shower = GetComponent<MeteorShower>();
                        if (shower != null)
                        {
                            shower.Shower(PlayerPrefs.GetFloat(arrow.typeOfArrow + "ArrowDamage"), transform.position);

                        }
                        break;
                    case ArrowType.TypeOfArrow.Lightning:
                        LightningArrow lightning = GetComponent<LightningArrow>();
                        if (lightning != null)
                        {
                            
                            lightning.LightningStrike(PlayerPrefs.GetFloat(arrow.typeOfArrow + "ArrowDamage"));
                        }

                        break;
                    case ArrowType.TypeOfArrow.Rain:
                        RainOfArrows rain = GetComponent<RainOfArrows>();
                        if (rain != null)
                        {
                            if(hit.collider.GetComponent<Enemy>() != null)
                                hit.collider.GetComponent<Enemy>().DealDamage(PlayerPrefs.GetFloat(arrow.typeOfArrow + "ArrowDamage"));
                            rain.Rain();
                        }

                        break;
                    case ArrowType.TypeOfArrow.Regular:
                        if (hit.collider.GetComponent<Enemy>() != null)
                        {
                            hit.collider.GetComponent<Enemy>().DealDamage(PlayerPrefs.GetFloat(arrow.typeOfArrow + "ArrowDamage"));
                        }
                        else if(hit.collider.GetComponentInParent<Enemy>() != null)
                        {
                            hit.collider.GetComponentInParent<Enemy>().DealDamage(PlayerPrefs.GetFloat(arrow.typeOfArrow + "ArrowDamage"));
                        }
                        else if (hit.collider.GetComponentInChildren<Enemy>() != null)
                        {
                            hit.collider.GetComponentInChildren<Enemy>().DealDamage(PlayerPrefs.GetFloat(arrow.typeOfArrow + "ArrowDamage"));
                        }
                        break;
                    case ArrowType.TypeOfArrow.Target:
                        //Debug.Log("Target Arrow hit: "+hit.collider.GetComponentInParent<GameObject>().name);

                       
                        if(ie != null)
                        {
                            ie.TriggerEffect(hit.point, hit.collider.transform.rotation);
                        }

                        if(hit.collider.GetComponentInParent<TargetPractice>() != null && hit.collider.GetComponentInParent<TargetPractice>().enabled)
                        {
                            hit.collider.GetComponentInParent<TargetPractice>().CollapseTarget(PlayerPrefs.GetFloat(arrow.typeOfArrow + "ArrowDamage"), hit.point);
                        }
                        break;
                    default:
                        Debug.Log("Not an Arrow");
                        break;
                }       
            }

            //////If a heal arrow hits the tower it heals it
            else if (hit.collider.CompareTag("Tower"))
            {
                switch (arrow.typeOfArrow)
                {
                    case ArrowType.TypeOfArrow.Heal:
                        HealArrow heal = GetComponent<HealArrow>();
                        if (heal != null)
                        {
                            if (hit.collider.GetComponent<TowerHealth>() != null)
                            {
                                heal.HealTower(hit.collider.gameObject);
                            }
                        }

                        break;
                    default:
                        Debug.Log("Not an Arrow");
                        break;
                }
            }
        }

        return hit.collider != null;
    }

    private void TogglePhysics(bool value)
    {
        ////// Disable physics for childing and grabbing
        rigidbody.isKinematic = !value;
        rigidbody.useGravity = value;
    }

    private void ChildArrow(RaycastHit hit)
    {
        ////// Child to hit object
        Transform newParent = hit.collider.transform;
        transform.SetParent(newParent);
    }

    private void CheckForHittable(RaycastHit hit)
    {
        ////// Check if the hit object has a component that uses the hittable interface
        GameObject hitObject = hit.transform.gameObject;
        IArrowHittable hittable = hitObject ? hitObject.GetComponent<IArrowHittable>() : null;

        ////// If we find a valid component, call whatever functionality it has
        if (hittable != null)
            hittable.Hit(this);
    }
}
