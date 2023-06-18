using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;

namespace CourseWork
{
    public class Painting : Exhibit
    {
        public override ExhibitType GetCategoryTypeOfExhibit()
        {
            return ExhibitType.Painting;
        }

        private string dye;

        private string size;

        public Painting(string dye, string size)
        {
            this.dye = dye;
            this.size = size;
        }

      

        public override void GetAdditionalInfoOfExhibit(ref string dyeStr,ref string sizeStr, ref string type)
        {
            dyeStr = "Фарба: " + dye;
            sizeStr = "Розмір: " + size;
            type = "Тип: Живопис";
        }
        public string Dye
        {
            get { return dye; }
            set { dye = value; }
        }

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

    }
}
