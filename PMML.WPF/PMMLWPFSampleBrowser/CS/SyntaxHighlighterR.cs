#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Windows.Media;

namespace PMMLWPFSampleBrowser
{
    public class SyntaxHighlighterR
    {
        #region Local Variables

        private Regex codeRegex;
        private List<Run> codeParagraphGlobal;

        #endregion

        #region Properties

        public string AlpahNumericRegEx
        {
            get { return @"([a-zA-Z0-9])+"; }
        }

        /// <summary>
        /// Gets the operator reg expression from Code Behind file.
        /// </summary>
        /// <value>The operator reg ex.</value>
        public string OperatorRegEX
        {
            get { return "[&|~><!)(*#%@+/=?:;}{,.^$-']|[][]"; }
        }

        /// <summary>
        /// Gets the number reg expression from Code Behind file.
        /// </summary>
        /// <value>The number reg ex.</value>
        public string NumberRegEX
        {
            get { return @"[0-9].*?(?=:[0-9]*)?"; }
        }

        /// <summary>
        /// Gets the comment reg expression from Code Behind file.
        /// </summary>
        /// <value>The comment reg ex.</value>
        public string CommentRegEx
        {
            get { return @"#.*?(?=\r|\n)"; }
        }

        /// <summary>
        /// Gets the string reg expression from Code Behind file.
        /// </summary>
        /// <value>The string reg ex.</value>
        public string StringRegEx
        {
            get { return @"@?""""|@?"".*?(?!\\).""|''|'.*?(?!\\).'"; }
        }

        /// <summary>
        /// Gets the keywords from C# file.
        /// </summary>
        /// <value>The keywords.</value>
        public string Keywords
        {
            get
            {
                return "break library toString function "
                + "else stop warning return "
                + "FALSE TRUE 0L 1L 2L 3L 4L 5L 13L "
                + "if in NULL NA "
                + "switch for while try";
            }
        }

        /// <summary>
        /// Gets or sets the code regex.
        /// </summary>
        /// <value>The code regex.</value>
        public Regex CodeRegex
        {
            get { return codeRegex; }
            set { codeRegex = value; }
        }

        /// <summary>
        /// Gets or sets the code paragraph global.
        /// </summary>
        /// <value>The code paragraph global.</value>
        public List<Run> CodeParagraphGlobal
        {
            get { return codeParagraphGlobal; }
            set { codeParagraphGlobal = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="SyntaxRichTextBoxCS"/> class.
        /// </summary>
        /// <param name="pro">The pro.</param>
        public SyntaxHighlighterR()
        {
            Regex r;
            r = new Regex(@"\w+|-\w+|#\w+|@@\w+|#(?:\\(?:s|w)(?:\*|\+)?\w+)+|@\\w\*+");
            string regKeyword = r.Replace(Keywords, @"(?<=^|\W)$0(?=\W)");
            r = new Regex(@" +");
            regKeyword = r.Replace(regKeyword, @"|");

            StringBuilder regAll = new StringBuilder();
            regAll.Append("(");
            regAll.Append(CommentRegEx);
            regAll.Append(")|(");
            regAll.Append(StringRegEx);
            regAll.Append(")|(");
            regAll.Append(regKeyword);
            regAll.Append(")|(");
            regAll.Append(NumberRegEX);
            regAll.Append(")|(");
            regAll.Append(OperatorRegEX);
            regAll.Append(")|(");
            regAll.Append(AlpahNumericRegEx);
            regAll.Append(")");
            RegexOptions caseInsensitive = true ? 0 : RegexOptions.IgnoreCase;
            CodeRegex = new Regex(regAll.ToString(), RegexOptions.Singleline | caseInsensitive);
            CodeParagraphGlobal = new List<Run>();
        }



        /// <summary>
        /// Matches the eval.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        public string MatchEval(Match match)
        {
            if (match.Groups[1].Success) //comment
            {
                StringReader reader = new StringReader(match.ToString());
                string line;
                StringBuilder sb = new StringBuilder();
                while ((line = reader.ReadLine()) != null)
                {
                    Run r = new Run(line);
                    r.Foreground = new SolidColorBrush(Color.FromRgb(57, 125, 2));

                    CodeParagraphGlobal.Add(r);
                }
                return "::::::";
            }
            else if (match.Groups[2].Success) //string literal
            {
                Run r = new Run(match.ToString());
                r.Foreground = new SolidColorBrush(Color.FromRgb(0, 160, 0));

                CodeParagraphGlobal.Add(r);
                return "::::::";
            }

            else if (match.Groups[3].Success) //keyword
            {
                Run r = new Run(match.ToString());
                r.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));

                CodeParagraphGlobal.Add(r);
                return "::::::";
            }

            else if (match.Groups[4].Success)//Numbers
            {
                Run r = new Run(match.ToString());
                r.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));

                CodeParagraphGlobal.Add(r);
                return "::::::";

            }
            else if (match.Groups[5].Success)//Operators
            {
                Run r = new Run(match.ToString());
                r.Foreground = new SolidColorBrush(Color.FromRgb(153, 153, 153));

                CodeParagraphGlobal.Add(r);
                return "::::::";

            }
            else if (match.Groups[6].Success)
            {
                Run r = new Run(match.ToString());
                r.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                CodeParagraphGlobal.Add(r);
                return "::::::";
            }
            else
            {
                return "";
            }
        }

        public Paragraph FormatCode(string source)
        {
            Paragraph codeParagraph = new Paragraph();
            //replace special characters
            StringBuilder sb = new StringBuilder(source);
            //color the code
            source = codeRegex.Replace(sb.ToString(), new MatchEvaluator(this.MatchEval));
            //codeRegex.Replace(
            string[] characters = { "::::::" };

            string[] split = source.Split(characters, new StringSplitOptions());
            int currentChunk = 0;
            foreach (string code in split)
            {
                currentChunk++;
                Run r = new Run(code) { FontSize = 14, FontFamily = new FontFamily("Segoe UI") };
                codeParagraph.Inlines.Add(r);
                if ((currentChunk - 1) < codeParagraphGlobal.Count)
                {
                    codeParagraphGlobal[currentChunk - 1].FontFamily = new FontFamily("Segoe UI");
                    codeParagraphGlobal[currentChunk - 1].FontSize = 14;
                    codeParagraph.Inlines.Add(codeParagraphGlobal[currentChunk - 1]);
                }
            }
            return codeParagraph;
        }
        #endregion

    }
}
