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
            GameManager.Instance.CurrentUser.star += MissileUpgradePanel.missileAutoStar;
            GameManager.Instance.uiManager.UpdateRocketPanel();
            animator.SetBool("IsExplosion", true);
            Invoke("FAni", 1.5f);
        }
        else if (collision.gameObject.tag == "Metor" && gameObject.CompareTag("Rocket_Normal"))
        {
            GameManager.Instance.CurrentUser.star += UpgradePanel.autoStar;
            GameManager.Instance.uiManager.UpdateRocketPanel();
            animator.SetBool("IsExplosion", true);
            Invoke("FAni", 1f);
        }
        else if (collision.gameObject.tag == "Metor" && gameObject.CompareTag("Rocket_Spaceship"))
        {
            GameManager.Instance.CurrentUser.star += SpaceshipUpgradePanel.SpaceshipAutoStar;
            GameManager.Instance.uiManager.UpdateRocketPanel();
            animator.SetBool("IsExplosion", true);
            Invoke("FAni", 1.8f);
        }
        else if (collision.gameObject.tag == "Metor" && gameObject.CompareTag("Rocket_Banana"))
        {
            GameManager.Instance.CurrentUser.star += BananaUpgradePanel.autoStar;
            GameManager.Instance.uiManager.UpdateRocketPanel();
            animator.SetBool("IsExplosion", true);
            Invoke("FAni", 2.5f);
        }
        else if (collision.gameObject.tag == "Metor" && gameObject.CompareTag("Rocket_Speed"))
        {
            GameManager.Instance.CurrentUser.star += SpeedUpgradePanel.autoStar;
            GameManager.Instance.uiManager.UpdateRocketPanel();
            animator.SetBool("IsExplosion", true);
            Invoke("FAni", 0.3f);
        }
        else if (collision.gameObject.tag == "Metor" && gameObject.CompareTag("Rocket_Pencil"))
        {
            GameManager.Instance.CurrentUser.star += ShuttleUpgradePanel.autoStar;
            GameManager.Instance.uiManager.UpdateRocketPanel();
            animator.SetBool("IsExplosion", true);
            Invoke("FAni", 1f);
        }
        else if (collision.gameObject.tag == "Metor" && gameObject.CompareTag("Rocket_Face"))
        {
            GameManager.Instance.CurrentUser.star += ShuttleUpgradePanel.autoStar;
            GameManager.Instance.uiManager.UpdateRocketPanel();
            animator.SetBool("IsExplosion", true);
            Invoke("FAni", 0.3f);
        }
        else if (collision.gameObject.tag == "Metor" && gameObject.CompareTag("Rocket_Shuttle"))
        {
            GameManager.Instance.CurrentUser.star += ShuttleUpgradePanel.autoStar;
            GameManager.Instance.uiManager.UpdateRocketPanel();
            animator.SetBool("IsExplosion", true);
            Invoke("FAni", 2f);
        }
        else if (collision.gameObject.tag == "Metor" && gameObject.CompareTag("Rocket_Train"))
        {
            GameManager.Instance.CurrentUser.star += ShuttleUpgradePanel.autoStar;
            GameManager.Instance.uiManager.UpdateRocketPanel();
            animator.SetBool("IsExplosion", true);
            Invoke("FAni", 7f);
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        if(gameObject.CompareTag("Rocket_Missile"))
            iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", 10, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "movetopath", false));
        else if (gameObject.CompareTag("Rocket_Normal"))
            iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", 6, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "movetopath", false));
        else if (gameObject.CompareTag("Rocket_Spaceship"))
            iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", 15, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "movetopath", false));
        else if (gameObject.CompareTag("Rocket_Banana"))
            iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", 20, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "movetopath", false));
        else if (gameObject.CompareTag("Rocket_Speed"))
            iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", 8, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "movetopath", false));
        else if (gameObject.CompareTag("Rocket_Pencil"))
            iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", 10, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "movetopath", false));
        else if (gameObject.CompareTag("Rocket_Face"))
            iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", 7, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "movetopath", false));
        else if (gameObject.CompareTag("Rocket_Shuttle"))
            iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", 30, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "movetopath", false));
        else if (gameObject.CompareTag("Rocket_Train"))
            iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", 40, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "movetopath", false));

    }
    private void FAni()
    {
        animator.SetBool("IsExplosion", false);
    }
    public void ChangeRocketSprite()
    {
        if (UpgradePanel.upgradeLevel >= 10 && UpgradePanel.upgradeLevel <= 19)
        {
            animator.SetBool("Normal Ani2", true);
        }
        else if (UpgradePanel.upgradeLevel >= 20 && UpgradePanel.upgradeLevel <= 29)
        {
            animator.SetBool("Normal Ani3", true);
        }
        else if (UpgradePanel.upgradeLevel >= 30 && UpgradePanel.upgradeLevel <= 39)
        {
            animator.SetBool("Normal Ani4", true);
        }
        else if (UpgradePanel.upgradeLevel >= 40)
        {
            animator.SetBool("Normal Ani5", true);
        }
    }
    public void ChangeMissileSprtie()
    {
        if (MissileUpgradePanel.missileUpgradeLevel >= 10 && MissileUpgradePanel.missileUpgradeLevel <= 19)
        {
            animator.SetBool("Missile Ani2", true);
        }
        else if (MissileUpgradePanel.missileUpgradeLevel >= 20 && MissileUpgradePanel.missileUpgradeLevel <= 29)
        {
            animator.SetBool("Missile Ani3", true);
        }
        else if (MissileUpgradePanel.missileUpgradeLevel >= 30 && MissileUpgradePanel.missileUpgradeLevel <= 39)
        {
            animator.SetBool("Missile Ani4", true);
        }
        else if (MissileUpgradePanel.missileUpgradeLevel >= 40)
        {
            animator.SetBool("Missile Ani5", true);
        }
    }
    public void ChangeSpaceshipSprtie()
    {
        if(SpaceshipUpgradePanel.spaceshipUpgradeLevel>=10 && SpaceshipUpgradePanel.spaceshipUpgradeLevel<=19)
        {
            animator.SetBool("Rocket Ani2", true);
        }
        else if (SpaceshipUpgradePanel.spaceshipUpgradeLevel >= 20 && SpaceshipUpgradePanel.spaceshipUpgradeLevel <= 29)
        {
            animator.SetBool("Rocket Ani3", true);
        }
        else if (SpaceshipUpgradePanel.spaceshipUpgradeLevel >= 30 && SpaceshipUpgradePanel.spaceshipUpgradeLevel <= 39)
        {
            animator.SetBool("Rocket Ani4", true);
        }
        else if (SpaceshipUpgradePanel.spaceshipUpgradeLevel >= 40)
        {
            animator.SetBool("Rocket Ani5", true);
        }
    }
    public void ChangeBananaSprtie()
    {
        if (BananaUpgradePanel.upgradeLevel >= 10 && BananaUpgradePanel.upgradeLevel <= 19)
        {
            animator.SetBool("Banana Ani2", true);
        }
        else if (BananaUpgradePanel.upgradeLevel >= 20 && BananaUpgradePanel.upgradeLevel <= 29)
        {
            animator.SetBool("Banana Ani3", true);
        }
        else if (BananaUpgradePanel.upgradeLevel >= 30 && BananaUpgradePanel.upgradeLevel <= 39)
        {
            animator.SetBool("Banana Ani4", true);
        }
        else if (BananaUpgradePanel.upgradeLevel >= 40)
        {
            animator.SetBool("Banana Ani5", true);
        }
    }
    public void ChangeSpeedSprtie()
    {
        if (SpeedUpgradePanel.upgradeLevel >= 10 && SpeedUpgradePanel.upgradeLevel <= 19)
        {
            animator.SetBool("Speed Ani2", true);
        }
        else if (SpeedUpgradePanel.upgradeLevel >= 20 && SpeedUpgradePanel.upgradeLevel <= 29)
        {
            animator.SetBool("Speed Ani3", true);
        }
        else if (SpeedUpgradePanel.upgradeLevel >= 30 && SpeedUpgradePanel.upgradeLevel <= 39)
        {
            animator.SetBool("Speed Ani4", true);
        }
        else if (SpeedUpgradePanel.upgradeLevel >= 40)
        {
            animator.SetBool("Speed Ani5", true);
        }
    }
    public void ChangePencilSprtie()
    {
        if (PencilUpgradePanel.upgradeLevel >= 10 && PencilUpgradePanel.upgradeLevel <= 19)
        {
            animator.SetBool("Pencil Ani2", true);
        }
        else if (PencilUpgradePanel.upgradeLevel >= 20 && PencilUpgradePanel.upgradeLevel <= 29)
        {
            animator.SetBool("Pencil Ani3", true);
        }
        else if (PencilUpgradePanel.upgradeLevel >= 30 && PencilUpgradePanel.upgradeLevel <= 39)
        {
            animator.SetBool("Pencil Ani4", true);
        }
        else if (PencilUpgradePanel.upgradeLevel >= 40)
        {
            animator.SetBool("Pencil Ani5", true);
        }
    }
    public void ChangeFaceSprtie()
    {
        if (FaceUpgradePanel.upgradeLevel >= 10 && FaceUpgradePanel.upgradeLevel <= 19)
        {
            animator.SetBool("Face Ani2", true);
        }
        else if (FaceUpgradePanel.upgradeLevel >= 20 && FaceUpgradePanel.upgradeLevel <= 29)
        {
            animator.SetBool("Face Ani3", true);
        }
        else if (FaceUpgradePanel.upgradeLevel >= 30 && FaceUpgradePanel.upgradeLevel <= 39)
        {
            animator.SetBool("Face Ani4", true);
        }
        else if (FaceUpgradePanel.upgradeLevel >= 40)
        {
            animator.SetBool("Face Ani5", true);
        }
    }
    public void ChangeShuttleSprtie()
    {
        if (ShuttleUpgradePanel.upgradeLevel >= 10 && ShuttleUpgradePanel.upgradeLevel <= 19)
        {
            animator.SetBool("Shuttle Ani2", true);
        }
        else if (ShuttleUpgradePanel.upgradeLevel >= 20 && ShuttleUpgradePanel.upgradeLevel <= 29)
        {
            animator.SetBool("Shuttle Ani3", true);
        }
        else if (ShuttleUpgradePanel.upgradeLevel >= 30 && ShuttleUpgradePanel.upgradeLevel <= 39)
        {
            animator.SetBool("Shuttle Ani4", true);
        }
        else if (ShuttleUpgradePanel.upgradeLevel >= 40)
        {
            animator.SetBool("Shuttle Ani5", true);
        }
    }
    public void ChangeTrainSprtie()
    {
        if (TrainUpgradePanel.upgradeLevel >= 10 && TrainUpgradePanel.upgradeLevel <= 19)
        {
            animator.SetBool("Train Ani2", true);
        }
        else if (TrainUpgradePanel.upgradeLevel >= 20 && TrainUpgradePanel.upgradeLevel <= 33)
        {
            animator.SetBool("Train Ani3", true);
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
