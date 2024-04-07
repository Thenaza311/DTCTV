using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAbilitiesQuickly : MonoBehaviour
{
    public List<Image> abilities = new List<Image>();
    public List<SkillPage> skillPages = new List<SkillPage>();

    private void Start()
    {
        foreach (var Skill in skillPages)
        {
            if (Skill.unlocked == true)
            {
                Image matchingImage = abilities.Find(image => image.name == Skill.skillName);

                if (matchingImage != null)
                {
                    StartCoroutine(ActivateAndDeactivate(matchingImage));
                }
            }
        }
    }

    private IEnumerator ActivateAndDeactivate(Image image)
    {
        image.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        image.gameObject.SetActive(false);
    }
}
