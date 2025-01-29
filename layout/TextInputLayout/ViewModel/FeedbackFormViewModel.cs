#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.layoutdemos.wpf
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the FeedbackFormViewModel class.
    /// </summary>
    public class FeedbackFormViewModel
    {
        /// <summary>
        /// Gets or sets the feedback form model.
        /// </summary>
        public FeedbackForm FeedbackForm { get; set; }

        /// <summary>
        /// Gets or sets the feedback forms.
        /// </summary>
        public List<string> FeedbackForms = new List<string>();

        /// <summary>
        /// Gets or sets the feedback form 1.
        /// </summary>
        public string FeedbackForm1 { get; set; }

        /// <summary>
        /// Gets or sets the feedback form 2.
        /// </summary>
        public string FeedbackForm2 { get; set; }

        /// <summary>
        /// Gets or sets the feedback form 3.
        /// </summary>
        public string FeedbackForm3 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackFormViewModel"/> class.
        /// </summary>
        public FeedbackFormViewModel()
        {
            this.FeedbackForm1 = "My name is John Miller, and I have been using the Calendar Control (version 25.3.1) for the past six months. It’s a reliable tool for managing dates, though I believe it could benefit from additional customization options. Overall, I would rate this product 4 out of 5. For any further details, feel free to reach out to me at johnmiller@gmail.com";
            this.FeedbackForm2 = "My name is Sarah Thompson, and I've been using the Scheduler Control (version 20.1.4) for the past five months. It's a highly effective tool for managing appointments and tasks, though I would appreciate more flexibility in event color-coding. I would rate this product 4.5 out of 5. If you need further information, please contact me at sarahthompson@gmail.com.";
            this.FeedbackForm3 = "My name is Michael Johnson, and I've been using the DataForm Control (version 18.6.7) for the past few months. It's a solid tool for managing form data, though I believe there could be improvements in its validation features. Overall, I would rate this product 4 out of 5. For any further details, feel free to reach out to me at michaeljohnson@gmail.com.";
            this.FeedbackForm = new FeedbackForm();
            //// Initialize the product details dropdown with sample data.
            this.FeedbackForms.Add("{\r\n  \"Name\": \"John Miller\",\r\n  \"Email\": \"johnmiller@gmail.com\",\r\n  \"ProductName\": \"Calendar\",\r\n  \"ProductVersion\": \"25.3.1\",\r\n  \"Rating\": 4,\r\n  \"Comments\": \"My name is John Miller, and I have been using the Calendar Control (version 25.3.1) for the past six months. It’s a reliable tool for managing dates, though I believe it could benefit from additional customization options. Overall, I would rate this product 4 out of 5. For any further details, feel free to reach out to me at johnmiller@gmail.com.\"\r\n}\r\n");
            this.FeedbackForms.Add("{\r\n  \"Name\": \"Sarah Thompson\",\r\n  \"Email\": \"sarahthompson@gmail.com\",\r\n  \"ProductName\": \"Scheduler\",\r\n  \"ProductVersion\": \"20.1.4\",\r\n  \"Rating\": 4.5,\r\n  \"Comments\": \"My name is Sarah Thompson, and I've been using the Scheduler Control (version 20.1.4) for the past five months. It's a highly effective tool for managing appointments and tasks, though I would appreciate more flexibility in event color-coding. I would rate this product 4.5 out of 5. If you need further information, please contact me at sarahthompson@gmail.com.\"\r\n}\r\n");
            this.FeedbackForms.Add("{\r\n  \"Name\": \"Michael Johnson\",\r\n  \"Email\": \"michaeljohnson@gmail.com\",\r\n  \"ProductName\": \"DataForm\",\r\n  \"ProductVersion\": \"18.6.7\",\r\n  \"Rating\": 4,\r\n  \"Comments\": \"My name is Michael Johnson, and I've been using the DataForm Control (version 18.6.7) for the past few months. It's a solid tool for managing form data, though I believe there could be improvements in its validation features. Overall, I would rate this product 4 out of 5. For any further details, feel free to reach out to me at michaeljohnson@gmail.com.\"\r\n}\r\n");
        }
    }

    /// <summary>
    /// Represents the FeedbackForm class.
    /// </summary>
    public class FeedbackForm : INotifyPropertyChanged
    {
        private string name;
        private string email;
        private string age;
        private string productName;
        private string productVersion;
        private string rating;
        private string comments;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invokes the property changed event.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Display(Prompt = "Enter your name", Name = "Name")]
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(20, ErrorMessage = "Name should not exceed 20 characters")]
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Enter Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email
        {
            get => this.email;
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    this.OnPropertyChanged("Email");
                }
            }
        }

        [Display(Prompt = "Enter your product name", Name = "Product Name")]
        [Required(ErrorMessage = "Enter your product name")]
        public string ProductName
        {
            get => this.productName;
            set
            {
                if (this.productName != value)
                {
                    this.productName = value;
                    this.OnPropertyChanged("ProductName");
                }
            }
        }

        [Display(Prompt = "Enter your product version", Name = "Product Version")]
        [Required(ErrorMessage = "Enter your product version")]
        public string ProductVersion
        {
            get => this.productVersion;
            set
            {
                if (this.productVersion != value)
                {
                    this.productVersion = value;
                    this.OnPropertyChanged("ProductVersion");
                }
            }
        }

        [Display(Prompt = "Enter your rating", Name = "Rating")]
        [Required(ErrorMessage = "Enter your between rating 1-5.")]
        public string Rating
        {
            get => this.rating;
            set
            {
                if (this.rating != value)
                {
                    this.rating = value;
                    this.OnPropertyChanged("Rating");
                }
            }
        }

        [Display(Prompt = "Enter your comments in detail", Name = "Comments")]
        [DataType(DataType.MultilineText)]
        public string Comments
        {
            get => this.comments;
            set
            {
                if (this.comments != value)
                {
                    this.comments = value;
                    this.OnPropertyChanged("Comments");
                }
            }
        }
    }
}