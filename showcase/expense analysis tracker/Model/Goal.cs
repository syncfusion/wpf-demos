#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;

namespace syncfusion.expenseanalysis.wpf
{
    /// <summary>
    /// Represents a financial savings goal. It tracks the goal's name, timeframe, target amount and current savings.
    /// </summary>
    public class Goal : BaseViewModel, IDataErrorInfo
    {
        private string name;
        private DateTime startDate;
        private DateTime endDate;
        private double target;
        private double saving;

        /// <summary>
        /// Gets or sets the name of the savings goal.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(nameof(Name)); }
        }

        /// <summary>
        /// Validates the Name property.
        /// </summary>
        /// <returns>An error message if validation fails, otherwise, null.</returns>
        private string ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return "Name cannot be empty";
            }
            return null;
        }

        /// <summary>
        /// Gets or sets the start date for the saving goal.
        /// </summary>
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; RaisePropertyChanged(nameof(StartDate)); }
        }

        /// <summary>
        /// Gets or sets the end date by which the goal should be achieved.
        /// </summary>
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; RaisePropertyChanged(nameof(EndDate)); }
        }

        /// <summary>
        /// Validate the Enddate property.
        /// </summary>
        /// <returns>An error message if validation fails, otherwise, null.</returns>
        private string ValidateEndDate()
        {
            if (EndDate.Date <= StartDate.Date)
            {
                return "End date cannot be less than today";
            }
            return null;
        }

        /// <summary>
        /// Gets or sets the target amount to be saved.
        /// </summary>
        public double Target
        {
            get { return target; }
            set { target = value; RaisePropertyChanged(nameof(Target)); }
        }

        /// <summary>
        /// Validates the target property.
        /// </summary>
        /// <returns>An error message if validation fails, otherwise, null.</returns>
        private string ValidateTarget()
        {
            if (Target < 1)
            {
                return "Target cannot be less than 1";
            }
            return null;
        }

        /// <summary>
        /// Gets or sets the amount currently saved towards the goal.
        /// </summary>
        public double Saving
        {
            get { return saving; }
            set { saving = value; RaisePropertyChanged(nameof(Saving)); }
        }

        /// <summary>
        /// Gets the string indicating the current status of the goal.
        /// </summary>
        public string Status
        {
            get
            {
                if (Saving >= Target)
                {
                    return "Successfully\nCompleted";
                }
                else if (DateTime.Now <= EndDate)
                {
                    var days = (EndDate.Date - DateTime.Now.Date).Days;
                    if(days > 30)
                    {
                        return days / 30 + " months left";
                    }
                    else
                    {
                        return days + " days left";
                    }
                }
                else
                {
                    return "Incomplete";
                }
            }
        }

        /// <summary>
        /// Gets the calculated monthly savings target required to meet the goal on time.
        /// </summary>
        public double MonthlyTarget
        {
            get
            {
                var days = (EndDate - StartDate).Days;
                if(days > 30)
                {
                    return target / (days / 30);
                }
                else
                {
                    return target;
                }
            }
        }

        /// <summary>
        /// Gets the percentage of the goal that has been completed.
        /// </summary>
        public double CompletePercent
        {
            get
            {
                return Saving / Target;
            }
        }

        /// <summary>
        /// Gets an error message indicating what is wrong with this object. It aggregates validation errors from multiple properties.
        /// </summary>
        public string Error
        {
            get
            {
                return ValidateName() ?? ValidateEndDate() ?? ValidateTarget() ?? null;
            }
        }

        /// <summary>
        /// Gets the error message for the property with the given name. This is part of the <see cref="IDataErrorInfo"/> interface.
        /// </summary>
        /// <param name="columnName">The name of the proeprty to validate.</param>
        /// <returns>An error message if validation fails, otherwise, null if there is no error.</returns>
        public string this[string columnName]
        {
            get
            {
                RaisePropertyChanged(nameof(Error));
                switch (columnName)
                {
                    case nameof(Name):
                        return ValidateName();
                    case nameof(EndDate):
                        return ValidateEndDate();
                    case nameof(Target):
                        return ValidateTarget();
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// Creates a deep copy of the current goal object.
        /// </summary>
        /// <returns>A new <see cref="Goal"/> instance with the same values as the current one.</returns>
        public Goal Clone()
        {
            var g = new Goal();
            g.Name= Name;
            g.StartDate = StartDate;
            g.EndDate = EndDate;
            g.Target = Target;
            g.Saving = Saving;
            return g;
        }

        /// <summary>
        /// Applies the properties of another <see cref="Goal"/> object to this interface.
        /// </summary>
        /// <param name="g">The goal object whose values will be applied.</param>
        public void Apply(Goal g)
        {
            Name = g.Name;
            StartDate = g.StartDate;
            EndDate = g.EndDate;
            Target = g.Target;
            Saving= g.Saving;
        }

    }

    /// <summary>
    /// Represents a temporary or new goal being created, typically for use in "ADD" or "EDIT" dialogs. It inherits from the base <see cref="Goal"/> class.
    /// </summary>
    public class AddGoal : Goal { }

}