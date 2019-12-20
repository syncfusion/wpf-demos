#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UMLDiagram;
namespace UMLDiagramDesigner
{
    public class NodeDataTemplateSelector : DataTemplateSelector
    {
        private DataTemplate getDataTemplate(string key)
        {
            return App.Current.Resources[key] as DataTemplate;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (container is Node && (container as Node).Tag != null)
            {
                if ((container as Node).Tag.ToString() == "EditContent")
                {
                    return getDataTemplate("EditClass");
                }
                else if ((container as Node).Tag.ToString() == "EditColor")
                {
                    return getDataTemplate("ColorEdit");
                }
            }
            if (item != null)
            {
                if (item.GetType().Name == "EditingOption")
                {
                    EditingOption content = item as EditingOption;
                    return getDataTemplate("EditingOption" + "_" + content.EditType);
                }
                else if (item.GetType().Name == "NewNode")
                {
                    NewNode content = item as NewNode;
                    return getDataTemplate(item.GetType().Name + "_" + content.NewNodeType);
                }
                return getDataTemplate(item.GetType().Name);
            }
            return null;
        }
    }

    public class EditorDataTemplateSelector : DataTemplateSelector
    {
        private DataTemplate getDataTemplate(string key)
        {
            return App.Current.Resources[key] as DataTemplate;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                if (item.GetType().Name.Contains("Node"))
                {
                    if (item is ClassNode || item is InterfaceNode)
                    {
                        return getDataTemplate("NodeEditor");
                    }
                    else if (item is NoteNode)
                    {
                        return getDataTemplate("NoteEditor");
                    }
                    else
                    {
                        return getDataTemplate("TextEditor");
                    }
                }
                else if (item.GetType().Name.Contains("Line"))
                {
                    return getDataTemplate("LineEditor");
                }
            }
            return null;
        }
    }
}
