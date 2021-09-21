using UnityEngine;
using UnityEngine.UI;
public class RocketMovement : MonoBehaviour
{
    public Transform[] path;
    private Animator animator;
    [SerializeField]
    private EffectText StarTextTemplate = null;
    void OnDrawGizmos()
    {
        iTween.DrawPath(path);
    }
    public int rotateSpeed;
    [SerializeField]
    public Transform target;
    public static int rocketStar = 333;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Metor")
        {
            animator.SetBool("IsExplosion", true);

            Invoke("FAni", 0.8f);
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", 6, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "movetopath", false));
    }
    private void FAni()
    {
        animator.SetBool("IsExplosion", false);
    }
    public void ChangeRocketSprite()
    {
        EffectText rocketText = null;
        switch (UpgradePanel.upgradeLevel)
        {
            case 5:
                animator.SetBool("Rocket Ani2", true);
                if (GameManager.Instance.Pool.childCount > 0)
                {
                    rocketText = GameManager.Instance.Pool.GetChild(0).GetComponent<EffectText>();
                    rocketText.transform.SetParent(GameManager.Instance.Pool.parent);
                }
                else
                {
                    rocketText = Instantiate(StarTextTemplate, GameManager.Instance.Pool.parent).GetComponent<EffectText>();
                }
                rocketText.gameObject.SetActive(true);
                rocketText.Show(rocketStar);
                break;
        }
    }
    public void ChangeMissileSprtie()
    {
        switch (MissileUpgradePanel.missileUpgradeLevel)
        {
            case 5:
                animator.SetBool("Rocket Ani2", true);
                break;
        }
    }
    void Update()
    {
        if (target != null)
        {
            Vector2 direction = new Vector2(
                transform.position.x - target.position.x,
                transform.position.y - target.position.y
            );

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion angleAxis = Quaternion.AngleAxis(angle - 100f, Vector3.forward);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }
    }
}
