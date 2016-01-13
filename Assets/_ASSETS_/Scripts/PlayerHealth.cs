using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color (1f, 0f, 0f, 0.1f);


	Animator anim;
	AudioSource playerAudio;
	// reference to player movement script
	PlayerMovement playerMovement;
	PlayerShooting playerShooting;
	bool isDead;
	bool damaged;
	//bool playerIsSinking;


	void Awake ()
	{
		anim = GetComponent <Animator> ();
		playerAudio = GetComponent <AudioSource> ();
		playerMovement = GetComponent <PlayerMovement> ();
		playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHealth = startingHealth;
	}


	void Update ()
	{
		if (damaged) {
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}


	public void TakeDamage (int amount)
	{
		damaged = true;

		currentHealth -= amount;

		healthSlider.value = currentHealth;

		playerAudio.Play ();

		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}


	void Death ()
	{
		isDead = true;

		playerShooting.DisableEffects ();

		anim.SetTrigger ("Die");

		playerAudio.clip = deathClip;
		playerAudio.Play ();

		playerMovement.enabled = false;
		playerShooting.enabled = false;

		//playerIsSinking = true;

		// COMMENT THESE LINES OUT TO LET THE GAME KEEP RUNNING AFTER
		// PLAYER DIES. HOWEVER, PLAYER HAS FUNKY DEATH ANIMATION OR
		// NEEDS SINKING METHOD LIKE ENEMY TO HANDLE IT.
		//Destroy (gameObject, 2f);
		//RestartLevel ();
	}


	public void RestartLevel ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void PlayerSinking ()
	{
		//GetComponent <NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		GameObject bunny = GameObject.Find ("Zombunny");
		//Destroy (bunny.gameObject, 2f);
		//playerIsSinking = true;
		//ScoreManager.score += scoreValue;
		//Destroy (gameObject, 4f);
	}
}
