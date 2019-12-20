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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;
using System.Text.RegularExpressions;

namespace IronPythonDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        #region Constructor

        /// <summary>
        /// Window Constructor and events initialization
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            Edit1.DocumentLanguage = Languages.Custom;
#if NETCORE
            Edit1.DocumentSource = "../../../Source.py";
#else
            Edit1.DocumentSource = "../../Source.py";
#endif
            PythonLanguage customLanguage = new PythonLanguage(Edit1);
            customLanguage.Lexem = this.Resources["pythonLanguageLexems"] as LexemCollection;
            customLanguage.Formats = this.Resources["pythonLanguageFormats"] as FormatsCollection;
            Edit1.CustomLanguage = customLanguage;
            fontlst.SelectedItem = new FontFamily("Verdana");
        }

        #endregion

        #region Events

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }

    /// <summary>
    /// PythonLanguage class contains implementations related to custom language implementations
    /// </summary>
    public class PythonLanguage : ProceduralLanguageBase
    {
        #region Local Variables

        /// <summary>
        /// Local variable to hold the current block information
        /// </summary>
        BlockListener currentListener = null;

        /// <summary>
        /// Local stack instance to hold all the blocks that were encountered previously when a block is started.
        /// </summary>
        Stack<BlockListener> blocksStack = null;

        /// <summary>
        /// Local variable to hold ILexem of type comments.
        /// </summary>
        IEnumerable<ILexem> commentsCollection = null;

        /// <summary>
        /// Local variable to stor previous block end line.
        /// </summary>
        int lastBlockEndLine = 0;

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="T:IronPythonDemo.PythonLanguage">PythonLanguage</see> class.
        /// </summary>
        /// <param name="control">represents the EditControl to which to which this instance
        /// has to be hooked</param>
        public PythonLanguage(EditControl control)
            : base(control)
        {
            this.Name = "Python";
            this.FileExtension = "py";
            this.ApplyColoring = true;
            this.SupportsIntellisense = false;
            this.SupportsOutlining = true;
            this.TextForeground = Brushes.Black;
            this.blocksStack = new Stack<BlockListener>();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Initializing the commentsCollection variable when the Lexem property gets
        /// changed.
        /// </summary>
        /// <param name="e">represents the DependencyPropertyChangedEventArgs</param>
        protected override void OnLexemsChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnLexemsChanged(e);
            commentsCollection = this.Lexem.OfType<ILexem>().Where(lex => lex.LexemType == EditTokenType.Comment);
        }

        /// <summary>
        /// Override method of ApplyExpandCollapse to perform any initialization before Expand collapse is applied
        /// interactivity.
        /// </summary>
        protected override void InitializeApplyExpandCollapse()
        {
            currentListener = null;
        }

        /// <summary>
        /// Override method of ApplyExpandCollapse to perform language specific expand
        /// options. This method runs in a background thread to provided better
        /// interactivity.
        /// </summary>
        /// <param name="args">represents the instance of ApplyExpandCollapseArgs contains
        /// all necessary information related to each line</param>
        protected override void ApplyExpandCollapse(ApplyExpandCollapseArgs args)
        {
            bool createListener = false;
            if (args.LanguageBlocks == null)
            {
                return;
            }
            var selblocks = from blk in args.LanguageBlocks
                            where ((!blk.IsRegex && args.ExpandInformation.Text.Trim().StartsWith(blk.BlockStart) || (blk.IsRegex && Regex.Match(args.ExpandInformation.Text, blk.BlockStart).Success)))
                            select blk;
            if (selblocks.Count() > 0)
            {

                var block = selblocks.ElementAt(0);
                if (CheckCommentBlock(args.ExpandInformation))
                {
                    createListener = true;
                }

                if (createListener)
                {
                    if (currentListener != null)
                    {
                        if (currentListener.BlockStart.StartsWith("class") && block.BlockStart.StartsWith("class"))
                        {
                            var parentLineItem = args.Source[currentListener.ParentLineNumber - 1];
                            parentLineItem.EndLine = args.Source.IndexOf(args.ExpandInformation) - 1;
                            currentListener.EndLineNumber = parentLineItem.EndLine;
                            lastBlockEndLine = parentLineItem.EndLine;
                        }
                        else
                        {
                            args.ExpandInformation.ParentLineNumber = currentListener.ParentLineNumber;
                            args.ExpandInformation.StartLine = args.Source.IndexOf(args.ExpandInformation) + 2;
                            if (blocksStack == null)
                            {
                                blocksStack = new Stack<BlockListener>();
                            }
                            blocksStack.Push(currentListener);
                        }
                    }
                    currentListener = new BlockListener()
                    {
                        BlockStart = block.BlockStart,
                        BlockEnd = block.BlockEnd,
                        IsPreprocessor = block.IsPreprocessor,
                        ParentLineNumber = args.Source.IndexOf(args.ExpandInformation) + 1,
                        IsRegex = block.IsRegex,
                        CheckParentType = block.CheckParentType,
                        ParentLexemType = block.ParentLexemType,
                        LexemType = block.LexemType,
                        ScopeLevel = block.ScopeLevel
                    };

                    args.ExpandInformation.ContainsPreprocessor = block.IsPreprocessor;
                    args.ExpandInformation.PreprocessorText = block.IsPreprocessor ? args.ExpandInformation.Text.Trim().Substring(block.BlockStart.Length).Trim() : string.Empty;
                    args.ExpandInformation.ContainsLines = true;
                    int tempInd = args.Source.IndexOf(args.ExpandInformation);
                    args.ExpandInformation.StartLine = block.IsPreprocessor ? tempInd + 1 : tempInd + 2;
                }
                else if (currentListener != null)
                {
                    args.ExpandInformation.ParentLineNumber = currentListener.ParentLineNumber;
                    args.ExpandInformation.IsExpanded = true;
                    args.ExpandInformation.ContainsLines = false;
                }
                else
                {
                    args.ExpandInformation.ParentLineNumber = -1;
                    args.ExpandInformation.IsExpanded = true;
                    args.ExpandInformation.ContainsLines = false;
                }
            }
            else if (currentListener != null)
            {
                args.ExpandInformation.ContainsLines = false;
                args.ExpandInformation.ParentLineNumber = currentListener.ParentLineNumber;
                if (args.ExpandInformation.Text.Trim() == string.Empty)
                {
                    var parentLineItem = args.Source[currentListener.ParentLineNumber - 1];
                    parentLineItem.EndLine = args.Source.IndexOf(args.ExpandInformation);
                    currentListener.EndLineNumber = parentLineItem.EndLine;
                    lastBlockEndLine = parentLineItem.EndLine;
                    currentListener = null;
                    if (blocksStack.Count > 0)
                    {
                        currentListener = blocksStack.Pop();
                    }
                }
                else if (currentListener.BlockEnd == null)
                {
                    currentListener = null;
                    if (blocksStack.Count > 0)
                    {
                        currentListener = blocksStack.Pop();
                    }
                }
            }
            else
            {
                args.ExpandInformation.ContainsLines = false;
                if (!args.ExpandInformation.IsExpanded)
                {
                    args.ExpandInformation.IsExpanded = true;
                    args.ExpandInformation.ToggleExpansion = true;
                }
                args.ExpandInformation.IsExpanded = true;
                args.ExpandInformation.ContainsLines = false;
            }

            if (args.Source.IndexOf(args.ExpandInformation) == args.Source.Count - 1)
            {
                if (currentListener != null)
                {
                    var parentLineItem = args.Source[currentListener.ParentLineNumber - 1];
                    parentLineItem.EndLine = lastBlockEndLine;
                    currentListener.EndLineNumber = parentLineItem.EndLine;
                }
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Helper method to check if the line starts with or single line or multiline
        /// comment
        /// </summary>
        /// <param name="item">represents the LineItemExpandInformation instance.</param>
        /// <returns>
        /// a bool value indicating if the line starts with comment type of lexem.
        /// </returns>
        private bool CheckCommentBlock(LineItemExpandInformation item)
        {
            if (item.LineStartBlock != null && item.LineStartBlock.LexemType == EditTokenType.Comment)
            {
                return false;
            }

            if (commentsCollection != null)
            {
                LineItemExpandInformation tempItem = item;
                RegexOptions options = this.CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;
                var blocks = commentsCollection.Where(lexem => (!lexem.IsMultiline && tempItem.Text.Trim().StartsWith(lexem.StartText)) || (lexem.IsMultiline && tempItem.Text.Trim().StartsWith(lexem.StartText) &&
                    (tempItem.Text.IndexOf(lexem.EndText) == -1 || tempItem.Text.IndexOf(lexem.EndText) == tempItem.Text.Length - lexem.EndText.Length)));
                if (blocks.Count() > 0)
                {
                    return false;
                }
            }

            return true;

        }

        #endregion
    }
}
