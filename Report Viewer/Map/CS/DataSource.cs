#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Reflection;

namespace ElectionResultDemo
{
    public class StateElectionResult
    {
        public string State { get; set; }

        public string Candidate { get; set; }

        public double Electors { get; set; }

        public static IList<StateElectionResult> GetStateElectionResult()
        {
            IList<StateElectionResult> electionResult = new List<StateElectionResult>();
            electionResult.Add(new StateElectionResult() { State = "Alabama", Candidate = "McCain", Electors = 9 });
            electionResult.Add(new StateElectionResult() { State = "Alaska", Candidate = "McCain", Electors = 3 });
            electionResult.Add(new StateElectionResult() { State = "Arizona", Candidate = "McCain", Electors = 10 });
            electionResult.Add(new StateElectionResult() { State = "Arkansas", Candidate = "McCain", Electors = 6 });
            electionResult.Add(new StateElectionResult() { State = "California", Candidate = "Obama", Electors = 55 });
            electionResult.Add(new StateElectionResult() { State = "Colorado", Candidate = "Obama", Electors = 9 });
            electionResult.Add(new StateElectionResult() { State = "Connecticut", Candidate = "Obama", Electors = 7 });
            electionResult.Add(new StateElectionResult() { State = "Delaware", Candidate = "Obama", Electors = 3 });
            electionResult.Add(new StateElectionResult() { State = "District of Columbia", Candidate = "Obama", Electors = 3 });
            electionResult.Add(new StateElectionResult() { State = "Florida", Candidate = "Obama", Electors = 27 });
            electionResult.Add(new StateElectionResult() { State = "Georgia", Candidate = "McCain", Electors = 15 });
            electionResult.Add(new StateElectionResult() { State = "Hawaii", Candidate = "Obama", Electors = 4 });
            electionResult.Add(new StateElectionResult() { State = "Idaho", Candidate = "McCain", Electors = 4 });
            electionResult.Add(new StateElectionResult() { State = "Illinois", Candidate = "Obama", Electors = 21 });
            electionResult.Add(new StateElectionResult() { State = "Indiana", Candidate = "Obama", Electors = 11 });
            electionResult.Add(new StateElectionResult() { State = "Iowa", Candidate = "Obama", Electors = 7 });
            electionResult.Add(new StateElectionResult() { State = "Kansas", Candidate = "McCain", Electors = 6 });
            electionResult.Add(new StateElectionResult() { State = "Kentucky", Candidate = "McCain", Electors = 8 });
            electionResult.Add(new StateElectionResult() { State = "Louisiana", Candidate = "McCain", Electors = 9 });
            electionResult.Add(new StateElectionResult() { State = "Maine", Candidate = "Obama", Electors = 2 });
            electionResult.Add(new StateElectionResult() { State = "Maryland", Candidate = "Obama", Electors = 10 });
            electionResult.Add(new StateElectionResult() { State = "Massachusetts", Candidate = "Obama", Electors = 12 });
            electionResult.Add(new StateElectionResult() { State = "Michingan", Candidate = "Obama", Electors = 17 });
            electionResult.Add(new StateElectionResult() { State = "Minnesota", Candidate = "Obama", Electors = 10 });
            electionResult.Add(new StateElectionResult() { State = "Mississippi", Candidate = "McCain", Electors = 6 });
            electionResult.Add(new StateElectionResult() { State = "Missouri", Candidate = "McCain", Electors = 11 });
            electionResult.Add(new StateElectionResult() { State = "Montana", Candidate = "McCain", Electors = 3 });
            electionResult.Add(new StateElectionResult() { State = "Nebraska", Candidate = "McCain", Electors = 2 });
            electionResult.Add(new StateElectionResult() { State = "Nevada", Candidate = "Obama", Electors = 5 });
            electionResult.Add(new StateElectionResult() { State = "New Hampshire", Candidate = "Obama", Electors = 4 });
            electionResult.Add(new StateElectionResult() { State = "New Jersey", Candidate = "Obama", Electors = 15 });
            electionResult.Add(new StateElectionResult() { State = "New Mexico", Candidate = "Obama", Electors = 5 });
            electionResult.Add(new StateElectionResult() { State = "New York", Candidate = "Obama", Electors = 31 });
            electionResult.Add(new StateElectionResult() { State = "North Carolina", Candidate = "Obama", Electors = 15 });
            electionResult.Add(new StateElectionResult() { State = "North Dakota", Candidate = "McCain", Electors = 3 });
            electionResult.Add(new StateElectionResult() { State = "Ohio", Candidate = "Obama", Electors = 20 });
            electionResult.Add(new StateElectionResult() { State = "Oklahoma", Candidate = "McCain", Electors = 7 });
            electionResult.Add(new StateElectionResult() { State = "Oregon", Candidate = "Obama", Electors = 7 });
            electionResult.Add(new StateElectionResult() { State = "Pennsylvania", Candidate = "Obama", Electors = 21 });
            electionResult.Add(new StateElectionResult() { State = "Rhode Island", Candidate = "Obama", Electors = 4 });
            electionResult.Add(new StateElectionResult() { State = "South Carolina", Candidate = "McCain", Electors = 8 });
            electionResult.Add(new StateElectionResult() { State = "South Dakota", Candidate = "McCain", Electors = 3 });
            electionResult.Add(new StateElectionResult() { State = "Tennessee", Candidate = "McCain", Electors = 11 });
            electionResult.Add(new StateElectionResult() { State = "Texas", Candidate = "McCain", Electors = 34 });
            electionResult.Add(new StateElectionResult() { State = "Utah", Candidate = "McCain", Electors = 5 });
            electionResult.Add(new StateElectionResult() { State = "Vermont", Candidate = "Obama", Electors = 3 });
            electionResult.Add(new StateElectionResult() { State = "Virginia", Candidate = "Obama", Electors = 13 });
            electionResult.Add(new StateElectionResult() { State = "Washington", Candidate = "Obama", Electors = 11 });
            electionResult.Add(new StateElectionResult() { State = "West Virginia", Candidate = "McCain", Electors = 5 });
            electionResult.Add(new StateElectionResult() { State = "Wisconsin", Candidate = "Obama", Electors = 10 });
            electionResult.Add(new StateElectionResult() { State = "Wyoming", Candidate = "McCain", Electors = 3 });
            return electionResult;
        }
    }
}
