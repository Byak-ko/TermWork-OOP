using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class AppliedArt : Exhibit
    {
        public override ExhibitType GetCategoryTypeOfExhibit()
        {
            return ExhibitType.AppliedArt;
        }

        private string performance;

        private string purpose;

        public AppliedArt(string performance, string purpose)
        {
            this.performance = performance;
            this.purpose = purpose;
        }

       

        public override void GetAdditionalInfoOfExhibit(ref string materialStr, ref string textureStr, ref string type)
        {
            materialStr = "Представлення: " + performance;
            textureStr = "Призначення: " + purpose;
            type = "Тип: Прикладне мистецтво";
        }
        public string Performance
        {
            get { return performance; }
            set { performance = value; }
        }

        public string Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }
    }
}
