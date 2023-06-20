using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public abstract class Exhibit
    {
        protected ArtsMovement artMovement;
        private string author;
        private int creationTime;
        private string originHistory;
        private string name;
        private string imagePath;

        public ArtsMovement ArtMovement
        {
            get => artMovement;
            set => artMovement = value;
        }
        public abstract ExhibitType GetCategoryTypeOfExhibit();

        public abstract void GetAdditionalInfoOfExhibit(ref string addInfo1,ref string addInfo2,ref string type);
        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Description
        {
            get => originHistory;
            set => originHistory = value;
        }

        public int Date
        {
            get => creationTime;
            set => creationTime = value;
        }

        public string ImagePath
        {
            get => imagePath;
            set => imagePath = value;
        }
        public string Author 
        { 
            get => author;
            set => author = value; 
        }
    }
}
