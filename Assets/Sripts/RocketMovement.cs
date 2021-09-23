using UnityEngine;
using UnityEngine.UI;
public class RocketMovement : MonoBehaviour
{
    public Transform[] path;
    private Animator animator;
    private User user;
    private Rocket rocket;
    void OnDrawGizmos()
    {
        iTween.DrawPath(path);
    }
    public int rotateSpeed;
    [SerializeField]
    public Transform target;
    private MissileUpgradePanel missileUpgradePanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Metor")
        {
            animator.SetBool("IsExplosion", true);
            GameManager.Instance.CurrentUser.star += MissileUpgradePanel.missileAutoStar;
            Invoke("FAni", 0.5f);
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
        switch (UpgradePanel.upgradeLevel)
        {
            case 5:
                animator.SetBool("Rocket Ani2", true);
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
    public void ChangeSpaceshipSprtie()
    {
        switch (SpaceshipUpgradePanel.spaceshipUpgradeLevel)
        {
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
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
