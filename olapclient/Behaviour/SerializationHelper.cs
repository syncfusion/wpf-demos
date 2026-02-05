#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion


namespace syncfusion.olapclientdemos.wpf
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    public static class SerializationHelper
    {
        #region [ Serialize ]
        
        public static void Serialize<T>(Type type, T instance, string destinationFile)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            TextWriter writer = new StreamWriter(destinationFile);

            serializer.Serialize(writer, instance);
            writer.Close();
        } 

        #endregion

        #region [ De-serialize ]
        
        public static T Deserialize<T>(Type type, string sourceFile)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            TextReader reader = new StreamReader(sourceFile);

            return (T)serializer.Deserialize(reader);
        } 

        #endregion
    }
}
