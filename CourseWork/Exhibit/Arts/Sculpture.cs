using System.Reflection.Emit;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CourseWork.Arts;

public class Sculpture : Exhibit
{
    public override ExhibitType GetCategoryTypeOfExhibit()
    {
        return ExhibitType.Sculpture;
    }

    private string material;

    private string texture;

    public Sculpture(string material, string texture)
    {
        this.material = material;
        this.texture = texture;
    }

   

    public override void GetAdditionalInfoOfExhibit(ref string materialStr, ref string textureStr,ref string type)
    {
        materialStr = "Матеріал: " + material;
        textureStr = "Текстура: " + texture;
        type = "Тип: Скульптура";
    }

    public string Material
    {
        get { return material; } 
        set { material = value; }
    }

    public string Texture
    {
        get { return texture; }
        set { texture = value; }
    }
}