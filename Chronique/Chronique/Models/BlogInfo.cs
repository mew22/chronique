using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Chronique
{
    public class BlogInfo : BaseModel, INotifyPropertyChanged
    {
        #region Fields

        private string blogTitle;
        private string blogCategory;
        private string blogAuthor;
//        private ImageSource categoryIcon;
//        private ImageSource autherIcon;
//        private ImageSource blogFacebookIcon;
//        private ImageSource blogTwitterIcon;
//        private ImageSource blogGooglePlusIcon;
//        private ImageSource blogLinkedInIcon;

        private string fb_link;
        private string tw_link;
        private string gp_link;
        private string li_link;
        private string readMoreContent;

        #endregion

        #region Constructor

        public BlogInfo()
        {
        }

        #endregion

        #region Properties

        public string BlogTitle
        {
            get { return blogTitle; }
            set
            {
                blogTitle = value;
                OnPropertyChanged("BlogTitle");
            }
        }

        public string BlogCategory
        {
            get { return blogCategory; }
            set
            {
                blogCategory = value;
                OnPropertyChanged("BlogCategory");
            }
        }

        public string BlogAuthor
        {
            get { return blogAuthor; }
            set
            {
                blogAuthor = value;
                OnPropertyChanged("BlogAuthor");
            }
        }

//        public ImageSource BlogAuthorIcon
//        {
//            get { return autherIcon; }
//            set
//            {
//                autherIcon = value;
//                OnPropertyChanged("BlogAuthorIcon");
//            }
//        }
//
//        public ImageSource BlogCategoryIcon
//        {
//            get { return categoryIcon; }
//            set
//            {
//                categoryIcon = value;
//                OnPropertyChanged("BlogCategoryIcon");
//            }
//        }
//
//        public ImageSource BlogFacebookIcon
//        {
//            get { return blogFacebookIcon; }
//            set
//            {
//                blogFacebookIcon = value;
//                OnPropertyChanged("BlogFacebookIcon");
//            }
//        }
//
//        public ImageSource BlogTwitterIcon
//        {
//            get { return blogTwitterIcon; }
//            set
//            {
//                blogTwitterIcon = value;
//                OnPropertyChanged("BlogTwitterIcon");
//            }
//        }
//
//        public ImageSource BlogGooglePlusIcon
//        {
//            get { return blogGooglePlusIcon; }
//            set
//            {
//                blogGooglePlusIcon = value;
//                OnPropertyChanged("BlogGooglePlusIcon");
//            }
//        }
//
//        public ImageSource BlogLinkedInIcon
//        {
//            get { return blogLinkedInIcon; }
//            set
//            {
//                blogLinkedInIcon = value;
//                OnPropertyChanged("BlogLinkedInIcon");
//            }
//        }

        public string FB_link
        {
            get { return fb_link; }
            set { fb_link = value; OnPropertyChanged("FB_link"); }
        }
        public string TW_link
        {
            get { return tw_link; }
            set { tw_link = value; OnPropertyChanged("TW_link"); }
        }
        public string GP_link
        {
            get { return gp_link; }
            set { gp_link = value; OnPropertyChanged("GP_link"); }
        }
        public string LI_link
        {
            get { return li_link; }
            set { li_link = value; OnPropertyChanged("LI_link"); }
        }

        public string ReadMoreContent
        {
            get { return readMoreContent; }
            set
            {
                readMoreContent = value;
                OnPropertyChanged("ReadMoreContent");
            }
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}