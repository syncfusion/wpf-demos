public class CustomEditorViewModel : NotificationObject
{       
    public CustomEditorCollection CustomEditorCollection { get; set; }

    public CustomEditorViewModel()
    {
        //Initialize the custom editor collection
        CustomEditorCollection = new CustomEditorCollection();

        // CurrenyEditor added to CustomEditor collection 
        // And it will applied to the "Salary" property
        CustomEditor customEditor = new CustomEditor();
        customEditor.Editor = new CurrencyEditor();
        customEditor.Properties.Add("Salary");

        CustomEditorCollection.Add(customEditor);

        //DoubleUpdownEditor added to the collection 
        //And it will applied to the "Double" type properties
        CustomEditor customEditor1 = new CustomEditor();
        customEditor1.Editor = new DoubleUpDownEditor();
        customEditor1.HasPropertyType = true;
        customEditor1.PropertyType = typeof(double);

        CustomEditorCollection.Add(customEditor1);
    }
}
