using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{
    [Header("Raycast Shoot Settings")]
    [SerializeField] private Transform gun;
    [SerializeField] private float rayDistance;
    [SerializeField] private Vector3 offsetGun;

    [Header("Raycast Shoot Settings")]
    [SerializeField] private Transform sword;
    [SerializeField] private float radius;
    [SerializeField] private Vector3 offsetSword;

    [Header("Attack Settings")]
    [SerializeField] private float damage = 10f;

    [SerializeField] private float cooldownAttack;
    private bool canAttack = true;
    private Vector3 origin;
    private Vector3 dir;
    private bool isCharacter;
    private RaycastHit hit;

    [SerializeField] private bool isPlayer;
    [SerializeField] private bool isMelee;

    private PlayerMovement pM;

    private void Awake()
    {
        pM = GetComponent<PlayerMovement>();
    }

    private void Update()
    {

        if (isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
            {
                if (isMelee)
                {
                    Melee();
                    
                }
                else
                {
                    Shoot();
                }
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!isMelee)
        {
            if (hit.collider == null) return;
            Gizmos.color = isCharacter ? Color.green : Color.red;

            Gizmos.DrawLine(origin, hit.point);
        }
        else
        {
            Gizmos.color = isCharacter ? Color.green : Color.red;

            Gizmos.DrawWireSphere(origin, radius);
        }


    }

    public void Shoot()
    {

        RaycastInfo(offsetGun);

        if (Physics.Raycast(origin, dir, out hit, rayDistance))
        {

            AplyDamage(hit.collider.gameObject);

        }
        StartCoroutine(AttackCooldown());
    }

    public void Melee()
    {

        RaycastInfo(offsetSword);
        Collider[] colliders =  Physics.OverlapSphere(origin, radius);
        if (colliders.Length > 0)//solo para visualizar el debug
        {
            foreach (Collider col in colliders)
            {
                if (col.gameObject.CompareTag("Character") || col.gameObject.CompareTag("Player"))
                {
                    AplyDamage(col.gameObject);
                }

            }
        }
        else
        {
            isCharacter = false;
        }

        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        float currentSpeed=0f;
        if (isPlayer)
        {
            currentSpeed = pM.Speed;
            pM.Speed = 0f;
            canAttack = false;

            yield return new WaitForSeconds(cooldownAttack);


            pM.Speed = currentSpeed;
            canAttack = true;
        }

        
        


    }

    private void AplyDamage(GameObject hitObj)
    {
        if ((hitObj.CompareTag("Player") || hitObj.CompareTag("Character") ) && hitObj!=null)
        {
            //if (hitObj == null) return;
            Debug.Log($"<color=red>Se aplico daño<>");
            hitObj.GetComponent<HealthSystem>().TakeDamage(damage);

            isCharacter = true;//variable de apoyo
        }
        else
        {
            isCharacter = false;
        }
 
    }


    private void RaycastInfo(Vector3 offset)
    {
        origin = sword.TransformPoint(offset);
        dir = transform.forward;
    }

}