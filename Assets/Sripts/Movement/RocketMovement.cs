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
        if (collision.gameObject.tag == "Metor"&&gameObject.CompareTag("Rocket_Missile"))
        {
                animator.SetBool("IsExplosion", true);
                GameManager.Instance.CurrentUser.star += MissileUpgradePanel.missileAutoStar;
                Invoke("FAni", 1.5f);
        }
        else if (collision.gameObject.tag == "Metor" && gameObject.CompareTag("Rocket_Normal"))
        {
            animator.SetBool("IsExplosion", true);
            GameManager.Instance.CurrentUser.star += UpgradePanel.autoStar;
            Invoke("FAni", 1f);
        }
        else if (collision.gameObject.tag == "Metor" && gameObject.CompareTag("Rocket_Spaceship"))
        {
            animator.SetBool("IsExplosion", true);
            GameManager.Instance.CurrentUser.star += SpaceshipUpgradePanel.SpaceshipAutoStar;
            Invoke("FAni", 1.8f);
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        if(gameObject.CompareTag("Rocket_Missile"))
            iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", 10, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "movetopath", false));
        else if (gameObject.CompareTag("Rocket_Normal"))
            iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", 7, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "movetopath", false));
        else if (gameObject.CompareTag("Rocket_Spaceship"))
            iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", 15, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "movetopath", false));
    }
    private void FAni()
    {
        animator.SetBool("IsExplosion", false);
    }
    public void ChangeRocketSprite()
    {
        if (UpgradePanel.upgradeLevel >= 5 && UpgradePanel.upgradeLevel <= 20)
        {
            animator.SetBool("Normal Ani2", true);
        }
        else if (UpgradePanel.upgradeLevel >= 21 && UpgradePanel.upgradeLevel <= 40)
        {
            animator.SetBool("Normal Ani3", true);
        }
        else if (UpgradePanel.upgradeLevel >= 41 && UpgradePanel.upgradeLevel <= 60)
        {
            animator.SetBool("Normal Ani4", true);
        }
        else if (UpgradePanel.upgradeLevel >= 61)
        {
            animator.SetBool("Normal Ani5", true);
        }
    }
    public void ChangeMissileSprtie()
    {
        if (MissileUpgradePanel.missileUpgradeLevel >= 5 && MissileUpgradePanel.missileUpgradeLevel <= 20)
        {
            animator.SetBool("Missile Ani2", true);
        }
        else if (MissileUpgradePanel.missileUpgradeLevel >= 21 && MissileUpgradePanel.missileUpgradeLevel <= 40)
        {
            animator.SetBool("Missile Ani3", true);
        }
        else if (MissileUpgradePanel.missileUpgradeLevel >= 41 && MissileUpgradePanel.missileUpgradeLevel <= 60)
        {
            animator.SetBool("Missile Ani4", true);
        }
        else if (MissileUpgradePanel.missileUpgradeLevel >= 61)
        {
            animator.SetBool("Missile Ani5", true);
        }
    }
    public void ChangeSpaceshipSprtie()
    {
        if(SpaceshipUpgradePanel.spaceshipUpgradeLevel>=5 && SpaceshipUpgradePanel.spaceshipUpgradeLevel<=20)
        {
            animator.SetBool("Rocket Ani2", true);
        }
        else if (SpaceshipUpgradePanel.spaceshipUpgradeLevel >= 21 && SpaceshipUpgradePanel.spaceshipUpgradeLevel <= 40)
        {
            animator.SetBool("Rocket Ani3", true);
        }
        else if (SpaceshipUpgradePanel.spaceshipUpgradeLevel >= 41 && SpaceshipUpgradePanel.spaceshipUpgradeLevel <= 60)
        {
            animator.SetBool("Rocket Ani4", true);
        }
        else if (SpaceshipUpgradePanel.spaceshipUpgradeLevel >= 61)
        {
            animator.SetBool("Rocket Ani5", true);
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
